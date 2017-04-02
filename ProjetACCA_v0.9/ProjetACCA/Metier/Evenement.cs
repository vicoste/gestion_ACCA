using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace Projet_tut_ACCA.Metier
{
     public class Evenement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int idEvenement;
        public int IdEvenement
        {
            get { return idEvenement; }
            set { idEvenement = value; OnPropertyChanged("IdEvenement"); }
        }

        private string titre;
        public string Titre
        {
            get { return titre; }
            set { titre = value;  OnPropertyChanged("Titre"); }
        }

        private DateTime dateEvent;
        public DateTime DateEvent
        {
            get { return dateEvent; }
            set { dateEvent = value;  OnPropertyChanged("DateEvent"); }
        }

        private string heureDebut;
        public string HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; OnPropertyChanged("HeureDebut"); }
        }

        private string heureFin;
        public string HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; OnPropertyChanged("HeureFin"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private ObservableCollection<Adherent> participants;
        public ObservableCollection<Adherent> Participants
        {
            get { return participants; }
            set { participants = value;  OnPropertyChanged("Participants"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public Evenement (int idEvenement, string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants, string hD, string hF = null)
        {
            this.idEvenement = idEvenement;
            this.titre = titre;
            this.dateEvent = dateEvent;
            this.type = type;
            this.description = description;
            this.participants = participants;
            heureDebut = hD;
            heureFin = hF;
        }

        private static ObservableCollection<Adherent> recupParticipants(int idEvent)
        {
            ObservableCollection<Adherent> participants = new ObservableCollection<Adherent>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAdherent a, TEvenementAdherent te WHERE a.Matricule = te.MatriculeAdherent AND te.IdEvenement = @IdEvent", connection);
                sqlCommand.Parameters.AddWithValue("@IdEvent", idEvent);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Adherent a = new Adherent(
                            (int)reader["Matricule"],
                            (string)reader["Pseudo"],
                            (string)reader["Mdp"],
                            (string)reader["Nom"],
                            (string)reader["Prenom"],
                            (string)reader["Statut"],
                            (string)reader["Adresse"],
                            (string)reader["Telephone"],
                            (string)reader["Mail"]
                            );
                    participants.Add(a);
                }
                connection.Close();
            }
            return participants;
        }

        public static ObservableCollection<Evenement> recupEvenement(ObservableCollection<Fonctionnaire> fs, ObservableCollection<Zone> zs)
        {
            ObservableCollection<Evenement> evenements = new ObservableCollection<Evenement>();
            ObservableCollection<Adherent> participants;
            using (SqlConnection connection = Application.getInstance())
            {
                //---------SELECT * FROM TEvenement---------
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TEvenement WHERE DateEvent > @LocalDate AND Type != @Battue", connection);
                sqlCommand.Parameters.AddWithValue("@LocalDate", DateTime.Today);
                sqlCommand.Parameters.AddWithValue("@Battue", "Battue");

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Evenement e = new Evenement(
                            (int)reader["Id"],
                            (string)reader["Titre"],
                            (DateTime)reader["DateEvent"],
                            (string)reader["Type"],
                            (string)reader["Description"],
                            participants = recupParticipants((int)reader["Id"]),
                            (string)reader["HeureDebut"],
                            (string)reader["HeureFin"]
                            );
                    evenements.Add(e);
                }
                connection.Close();

                //---------SELECT * FROM TBattue---------
                connection.Open();
                SqlCommand sqlCommandB = new SqlCommand("SELECT * FROM TEvenement e, TBattue b WHERE e.Type = @Battue AND e.Id = b.IdBattue", connection);
                sqlCommandB.Parameters.AddWithValue("@Battue", "Battue");

                SqlDataReader readerB = sqlCommandB.ExecuteReader();
                while (readerB.Read())
                {
                    Zone zoneBattue = zs.First(z => z.IdZone == (int)readerB["IdZoneBattue"]);
                    CarnetBattue e = new CarnetBattue(
                            (int)readerB["Id"],
                            (string)readerB["Titre"],
                            (DateTime)readerB["DateEvent"],
                            (string)readerB["Type"],
                            (string)readerB["Description"],
                            participants = recupParticipants((int)readerB["Id"]),
                            (string)readerB["HeureDebut"],
                            (string)readerB["HeureFin"],
                            zoneBattue,
                            fs.First(f => f.Adherent.IdAdherent == (int)readerB["IdChef"]),
                            CarnetBattue.recupQuiVaOu((int)readerB["Id"], zoneBattue, fs)
                            );
                    if (e.DateEvent <= DateTime.Today)
                    {
                        e.IsModif = 0;
                    }

                    evenements.Add(e);
                }
                connection.Close();
            }
            return evenements;
        }

        public void ajouterEvenementBDD()
        {
            SqlConnection connection = Application.getInstance();

            //---------INSERT INTO TEvenement---------

            connection.Open();

            string commandTAd = "INSERT INTO TEvenement (Titre, DateEvent, HeureDebut, HeureFin, Type, Description) OUTPUT INSERTED.Id VALUES ("
                + "@Titre, @DateEvent, @HeureDebut, @HeureFin, @Type, @Description)";

            SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

            sqlCommandTAd.Parameters.AddWithValue("@Titre", Titre);
            sqlCommandTAd.Parameters.AddWithValue("@DateEvent", DateEvent);
            sqlCommandTAd.Parameters.AddWithValue("@HeureDebut", HeureDebut);
            sqlCommandTAd.Parameters.AddWithValue("@HeureFin", HeureFin);
            sqlCommandTAd.Parameters.AddWithValue("@Type", Type);
            sqlCommandTAd.Parameters.AddWithValue("@Description", Description);

            IdEvenement = (int)sqlCommandTAd.ExecuteScalar();

            connection.Close();

            //---------INSERT INTO TBattue---------
            if (this.Type.Equals("Battue"))
            {
                CarnetBattue.ajoutBattueBDD((CarnetBattue) this);
            }
        }

        public static void modifEvenementBDD(ObservableCollection<Evenement> evs)
        {
            SqlConnection connection = Application.getInstance();
            foreach (Evenement ev in evs)
            {
                if (ev.DateEvent <= DateTime.Today && ev.Type.Equals("Battue"))
                {
                    connection.Open();
                    string commandUB = "UPDATE TBattue SET IsModif = 0 WHERE IdBattue = @IdBattue";
                    SqlCommand sqlCommandUB = new SqlCommand(commandUB, connection);

                    sqlCommandUB.Parameters.AddWithValue("@IdBattue", ev.IdEvenement);

                    sqlCommandUB.ExecuteNonQuery();
                    connection.Close();
                }

                if (ev.IsModified)
                {
                    if (ev.Type.Equals("Battue"))
                    {
                        connection.Open();
                        string commandDAP = "DELETE FROM TAdherentPoste WHERE IdChasse = @IdChasse";
                        SqlCommand sqlCommandDAP = new SqlCommand(commandDAP, connection);

                        sqlCommandDAP.Parameters.AddWithValue("@IdChasse", ev.IdEvenement);
                        sqlCommandDAP.ExecuteNonQuery();

                        connection.Close();

                        connection.Open();
                        foreach (var kv in ((CarnetBattue)ev).QuiVaOu)
                        {
                            string commandIAP = "INSERT INTO TAdherentPoste (IdChasseur, IdPosteBattue, IdChasse) VALUES ("
                                + "@IdChasseur, @IdPosteBattue, @IdChasse)";
                            SqlCommand sqlCommandIAP = new SqlCommand(commandIAP, connection);

                            sqlCommandIAP.Parameters.AddWithValue("@IdChasseur", kv.Value.IdAdherent);
                            sqlCommandIAP.Parameters.AddWithValue("@IdPosteBattue", kv.Key.Numero);
                            sqlCommandIAP.Parameters.AddWithValue("@IdChasse", ev.IdEvenement);

                            sqlCommandIAP.ExecuteNonQuery();
                        }
                        connection.Close();   
                    }
                    else
                    {
                        //Modif pour les evenements normaux à voir
                    }
                }
            }
        }

        protected void OnPropertyChanged(string v)
         {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public void participerEvenement(Adherent adherent)
        {
            SqlConnection connection = Application.getInstance();

            //---------INSERT INTO TEvenementAdherent---------
            connection.Open();

            string commandTRAd = "INSERT INTO TEvenementAdherent (MatriculeAdherent,IdEvenement) VALUES ("
                + "@MatriculeAdherent, @IdEvenement)";

            SqlCommand sqlCommandTRAd = new SqlCommand(commandTRAd, connection);

            sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", adherent.IdAdherent);
            sqlCommandTRAd.Parameters.AddWithValue("@IdEvenement", IdEvenement);

            sqlCommandTRAd.ExecuteNonQuery();

            connection.Close();
            
            Participants.Add(adherent);
        }

        public void annulerParticipation(Adherent adherent)
        {
            SqlConnection connection = Application.getInstance();

            //---------DELETE FROM TEvenementAdherent---------
            connection.Open();

            string commandTEAd = "DELETE FROM TEvenementAdherent WHERE MatriculeAdherent = @MatriculeAdherent AND IdEvenement = @IdEvenement";

            SqlCommand sqlCommandTRAd = new SqlCommand(commandTEAd, connection);

            sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", adherent.IdAdherent);
            sqlCommandTRAd.Parameters.AddWithValue("@IdEvenement", IdEvenement);

            sqlCommandTRAd.ExecuteNonQuery();

            connection.Close();

            Adherent aR = Participants.First(ad => ad.IdAdherent == adherent.IdAdherent);
            if(aR != null) Participants.Remove(aR);
        }
    }
}
