using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Evenement (int idEvenement, string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants)
        {
            this.idEvenement = idEvenement;
            this.titre = titre;
            this.dateEvent = dateEvent;
            this.type = type;
            this.description = description;
            this.participants = participants;
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

        public static ObservableCollection<Evenement> recupEvenement()
        {
            ObservableCollection<Evenement> evenements = new ObservableCollection<Evenement>();
            ObservableCollection<Adherent> participants = new ObservableCollection<Adherent>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TEvenement", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Evenement e = new Evenement(
                            (int)reader["Id"],
                            (string)reader["Titre"],
                            (DateTime)reader["DateEvent"],
                            (string)reader["Type"],
                            (string)reader["Description"],
                            participants = recupParticipants((int)reader["Id"])
                            );
                    evenements.Add(e);
                }
                connection.Close();
            }
            return evenements;
        }

        public static void ajouterEvenementBDD(ObservableCollection<Evenement> le)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Evenement e in le)
            {
                if (e.IsNew)
                {

                    //---------INSERT INTO TEvenement---------
                    // Cette partie sera probablement optionnelle dans le cas présent, et sera utilisé lors de l'ajout d'un participant
                    /*
                    connection.Open();

                    string commandTAd = "INSERT INTO TEvenement (Titre, DateEvent, Type, Description) VALUES ("
                        + "@Titre, @DateEvent, @Type, @Description)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@Titre", e.Titre);
                    sqlCommandTAd.Parameters.AddWithValue("@DateEvent", e.DateEvent);
                    sqlCommandTAd.Parameters.AddWithValue("@Type", e.Type);
                    sqlCommandTAd.Parameters.AddWithValue("@Description", e.Description);

                    sqlCommandTAd.ExecuteNonQuery();

                    connection.Close();

                    //---------SELECT Id FROM TEvenement---------
                    connection.Open();

                    string commandS = "SELECT Id FROM TEvenement WHERE Titre = @Titre AND DateEvent = @DateEvent";
                    SqlCommand sqlCommandS = new SqlCommand(commandS, connection);
                    sqlCommandS.Parameters.AddWithValue("@Titre", e.Titre);
                    SqlDataReader reader = sqlCommandS.ExecuteReader();
                    if (reader.Read())
                        noEvenement = (int)reader["Id"];
                    else
                        return;

                    connection.Close();

                    //---------INSERT INTO TEvenementAdherent---------
                    // Cette partie sera probablement optionnelle dans le cas présent, et sera utilisé lors de l'ajout d'un participant
                    /*
                    connection.Open();

                    string commandTRAd = "INSERT INTO TEvenementAdherent (MatriculeAdherent,IdEvenement) VALUES ("
                        + "@MatriculeAdherent, @IdEvenement)";

                    SqlCommand sqlCommandTRAd = new SqlCommand(commandTRAd, connection);

                    sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", matricule);
                    sqlCommandTRAd.Parameters.AddWithValue("@RoleAdherent", noEvenement);

                    sqlCommandTRAd.ExecuteNonQuery();

                    connection.Close();*/
                }
                if (e.IsModified)
                {
                    //---------UPDATE TEvenement---------
                    connection.Open();

                    string commandUTAd = "UPDATE TEvenement SET Titre = @Titre, DateEvent = @DateEvent, Type = @Type, Description = @Description WHERE Titre = @Titre";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@Titre", e.Titre);
                    sqlCommandUTAd.Parameters.AddWithValue("@DateEvent", e.DateEvent);
                    sqlCommandUTAd.Parameters.AddWithValue("@Type", e.Type);
                    sqlCommandUTAd.Parameters.AddWithValue("@Description", e.Description);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
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
            // Cette partie sera probablement optionnelle dans le cas présent, et sera utilisé lors de l'ajout d'un participant
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
            Participants.Remove(adherent);
        }
    }
}
