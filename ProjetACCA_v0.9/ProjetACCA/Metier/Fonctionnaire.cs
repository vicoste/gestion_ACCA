using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Metier
{
    public class Fonctionnaire
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Adherent adherent;
        public Adherent Adherent
        {
            get { return adherent; }
            set { adherent = value; OnPropertyChanged("Adherent"); }
        }
        private Fonction fonction;
        public Fonction Fonction
        {
            get { return fonction; }
            set { fonction = value; OnPropertyChanged("Fonction"); }
        }
        private DateTime dateDebut;
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; OnPropertyChanged("DateDebut"); }
        }

        private DateTime dateFin;
        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; OnPropertyChanged("DateFin"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public Fonctionnaire(Adherent adherent, Fonction fonction, DateTime dateDebut)
        {
            this.adherent = adherent;
            this.fonction = fonction;
            this.dateDebut = dateDebut;
            IsNew = false;
        }

        //Code BDD
        public static void ajouterFonctionnaireBDD(ObservableCollection<Fonctionnaire> lf)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Fonctionnaire f in lf)
            {
                if (f.IsNew)
                {
                    int matricule;

                    //---------INSERT INTO TAdherent---------
                    connection.Open();

                    string commandTAd = "INSERT INTO TAdherent (Nom,Prenom,Statut,Adresse,Telephone,Mail,Pseudo,Mdp,DateAdhesion,DateDepart) OUTPUT INSERTED.Matricule VALUES ("
                        + "@Nom, @Prenom, @Statut, @Adresse, @Telephone, @Mail, @Pseudo, @Mdp, @DateAdhesion, NULL)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@Nom", f.Adherent.Nom);
                    sqlCommandTAd.Parameters.AddWithValue("@Prenom", f.Adherent.Prenom);
                    sqlCommandTAd.Parameters.AddWithValue("@Statut", f.Adherent.Statut);
                    sqlCommandTAd.Parameters.AddWithValue("@Adresse", f.Adherent.Adresse);
                    sqlCommandTAd.Parameters.AddWithValue("@Telephone", f.Adherent.Tel);
                    sqlCommandTAd.Parameters.AddWithValue("@Mail", f.Adherent.Mail);
                    sqlCommandTAd.Parameters.AddWithValue("@Pseudo", f.Adherent.Login);
                    sqlCommandTAd.Parameters.AddWithValue("@Mdp", f.Adherent.Mdp);
                    sqlCommandTAd.Parameters.AddWithValue("@DateAdhesion", f.Adherent.DateAdhesion);

                    matricule = (int) sqlCommandTAd.ExecuteScalar();

                    connection.Close();

                    //---------INSERT INTO TRoleAdherent---------
                    connection.Open();

                    string commandTRAd = "INSERT INTO TRoleAdherent (MatriculeAdherent,RoleAdherent,DateDebut,DateFin) VALUES ("
                        + "@MatriculeAdherent, @RoleAdherent, @DateDebut, NULL)";

                    SqlCommand sqlCommandTRAd = new SqlCommand(commandTRAd, connection);

                    sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", matricule);
                    sqlCommandTRAd.Parameters.AddWithValue("@RoleAdherent", f.Fonction.Role);
                    sqlCommandTRAd.Parameters.AddWithValue("@DateDebut", f.DateDebut);

                    sqlCommandTRAd.ExecuteNonQuery();

                    connection.Close();
                }
                if(f.IsModified)
                {
                    //---------UPDATE TAderent---------
                    connection.Open();

                    string commandUTAd = "UPDATE TAdherent SET Nom = @Nom, Prenom = @Prenom, Statut = @Statut, Adresse = @Adresse, Telephone = @Telephone, Mail = @Mail WHERE Matricule = @Matricule";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@Matricule", f.Adherent.IdAdherent);
                    sqlCommandUTAd.Parameters.AddWithValue("@Nom", f.Adherent.Nom);
                    sqlCommandUTAd.Parameters.AddWithValue("@Prenom", f.Adherent.Prenom);
                    sqlCommandUTAd.Parameters.AddWithValue("@Statut", f.Adherent.Statut);
                    sqlCommandUTAd.Parameters.AddWithValue("@Adresse", f.Adherent.Adresse);
                    sqlCommandUTAd.Parameters.AddWithValue("@Telephone", f.Adherent.Tel);
                    sqlCommandUTAd.Parameters.AddWithValue("@Mail", f.Adherent.Mail);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();

                    //---------SELECT TRoleAdherent---------
                    connection.Open();

                    string exFonction;

                    string commandSRA = "SELECT RoleAdherent FROM TRoleAdherent WHERE MatriculeAdherent = @MatriculeAdherent AND DateFin IS NULL";
                    SqlCommand sqlCommandSRA = new SqlCommand(commandSRA, connection);
                    sqlCommandSRA.Parameters.AddWithValue("@MatriculeAdherent", f.Adherent.IdAdherent);
                    SqlDataReader reader = sqlCommandSRA.ExecuteReader();
                    if (reader.Read())
                        exFonction = (string)reader["RoleAdherent"];
                    else
                        return;

                    connection.Close();

                    if(!f.Fonction.Role.Equals(exFonction))
                    {
                        //---------UPDATE TRoleAdherent SET DateFin---------
                        connection.Open();

                        string commandUTRAd = "UPDATE TRoleAdherent SET DateFin = @DateFinU WHERE MatriculeAdherent = @MatriculeU AND DateFin IS NULL";

                        SqlCommand sqlCommandUTRAd = new SqlCommand(commandUTRAd, connection);

                        sqlCommandUTRAd.Parameters.AddWithValue("@MatriculeU", f.Adherent.IdAdherent);
                        sqlCommandUTRAd.Parameters.AddWithValue("@DateFinU", DateTime.Today);

                        sqlCommandUTRAd.ExecuteNonQuery();

                        connection.Close();

                        //---------INSERT INTO TRoleAdherent---------
                        connection.Open();

                        string commandIRAd = "INSERT INTO TRoleAdherent (MatriculeAdherent, RoleAdherent, DateDebut, DateFin) VALUES("
                        + "@MatriculeAdherentI, @RoleAdherentI, @DateDebutI, NULL)";

                        SqlCommand sqlCommandIRAd = new SqlCommand(commandIRAd, connection);

                        sqlCommandIRAd.Parameters.AddWithValue("@MatriculeAdherentI", f.Adherent.IdAdherent);
                        sqlCommandIRAd.Parameters.AddWithValue("@RoleAdherentI", f.Fonction.Role);
                        sqlCommandIRAd.Parameters.AddWithValue("@DateDebutI", DateTime.Today);

                        sqlCommandIRAd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
        }

        public static ObservableCollection<Fonctionnaire> demandeInfos()
        {
            ObservableCollection<Fonctionnaire> fonctionnaires = new ObservableCollection<Fonctionnaire>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAdherent a, TRoleAdherent ra WHERE a.Matricule = ra.MatriculeAdherent AND DateFin IS NULL ", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DateTime parti = reader["DateDepart"] == DBNull.Value ? new DateTime(1, 1, 1) : (DateTime)reader["DateDepart"];
                    Fonctionnaire f = new Fonctionnaire(
                        new Adherent(
                            (int)reader["Matricule"],
                            (string)reader["Pseudo"],
                            (string)reader["Mdp"],
                            (string)reader["Nom"],
                            (string)reader["Prenom"],
                            (string)reader["Statut"],
                            (string)reader["Adresse"],
                            (string)reader["Telephone"],
                            (string)reader["Mail"],
                            (DateTime)reader["DateAdhesion"],
                            parti),
                        new Fonction((string)reader["RoleAdherent"]),
                        (DateTime)reader["DateDebut"]);
                    fonctionnaires.Add(f);
                }
                connection.Close();
            }
            return fonctionnaires;
        }
        //Fin code BDD

        public override string ToString()
        {
            return Adherent.Nom + " " + Adherent.Prenom;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
