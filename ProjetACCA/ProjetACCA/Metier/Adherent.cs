using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Metier
{
    public class Adherent
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int idAdherent;
        public int IdAdherent {
            get { return idAdherent; }
            set { idAdherent = value; OnPropertyChanged("IdAdherent"); }
        }

        private string login;
        public string Login{
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }

        private string mdp;
        public string Mdp{
            get { return mdp; }
            set { mdp = value; OnPropertyChanged("Mdp"); }
        }

        private string nom;
        public string Nom {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }

        private string prenom;
        public string Prenom {
            get { return prenom; }
            set { prenom = value; OnPropertyChanged("Prenom"); }
        }

        private string statut; 
        public string Statut {
            get { return statut; }
            set { statut = value; OnPropertyChanged("Statut"); }
        }

        private string adresse;
        public string Adresse{
            get { return adresse; }
            set { adresse = value; OnPropertyChanged("Adresse"); }
        }

        private string tel;
        public string Tel{
            get { return tel; }
            set { tel = value; OnPropertyChanged("Tel"); }
        }

        private string mail;
        public string Mail{
            get { return mail; }
            set { mail = value; OnPropertyChanged("Mail"); }
        }

        private DateTime dateAdhesion;
        public DateTime DateAdhesion
        {
            get { return dateAdhesion; }
            set { dateAdhesion = value; OnPropertyChanged("DateAdhesion"); }
        }

        private DateTime dateDepart;
        public DateTime DateDepart
        {
            get { return dateDepart; }
            set { dateDepart = value; OnPropertyChanged("DateDepart"); }
        }

        public Adherent(int idAdherent, string login, string mdp, string nom, string prenom, string statut, string adresse, string tel, string mail, DateTime dateAdhesion)
        {
            this.idAdherent = idAdherent;
            this.login = login;
            this.mdp = mdp;
            this.nom = nom;
            this.prenom = prenom;
            this.statut = statut;
            this.adresse = adresse;
            this.tel = tel;
            this.mail = mail;
            this.dateAdhesion = dateAdhesion;
        }

        public Adherent(int idAdherent, string login, string mdp, string nom, string prenom, string statut, string adresse, string tel, string mail)
            : this(idAdherent, login, mdp, nom, prenom, statut, adresse, tel, mail, DateTime.Today)
        { }

        public Boolean participerEvenement(Evenement evenement)
        {
            if (evenement.Participants.Contains(this))
            {
                return false;
            }
            else
            {
                evenement.Participants.Add(this);
                return true;
            }
        }

        public Boolean quitterEvenement(Evenement evenement)
        {
            if (!evenement.Participants.Contains(this))
            {
                return false; 
            }
            else
            {
                evenement.Participants.Remove(this);
                return true;
            }
        }

        public static string getAllFonction(int idAdherent)
        {
            string allFonction = "Voici toutes les fonctions qui vous avez effectué:\n";

            SqlConnection connection = Metier.Application.getInstance();
            connection.Open();

            string textCommand = "SELECT * FROM TRoleAdherent WHERE MatriculeAdherent = @Id ORDER BY DateDebut ASC";
            SqlCommand sqlCommand = new SqlCommand(textCommand, connection);
            sqlCommand.Parameters.AddWithValue("@Id", idAdherent);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                DateTime debut = (DateTime)reader["DateDebut"];
                DateTime fin = (reader["DateFin"] as DateTime?).GetValueOrDefault(DateTime.Today);
                string role = (string)reader["RoleAdherent"];
                allFonction += "Du : " + debut
                    + "\tAu : " + fin + "\t"
                    + "\tFonction : " + role + "\n";
            }

            connection.Close();
            return allFonction;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
