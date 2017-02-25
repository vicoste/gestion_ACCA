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

        public Fonctionnaire(Adherent adherent, Fonction fonction, DateTime dateDebut)
        {
            this.adherent = adherent;
            this.fonction = fonction;
            this.dateDebut = dateDebut;
        }

        public Fonctionnaire()
        {
            Adherent = new Adherent();
        }

        //Code BDD
        public static ObservableCollection<Fonctionnaire> demandeInfos()
        {
            ObservableCollection<Fonctionnaire> fonctionnaires = new ObservableCollection<Fonctionnaire>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAdherent a, TRoleAdherent ra WHERE a.Matricule = ra.MatriculeAdherent", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Fonctionnaire f = new Fonctionnaire(
                        new Adherent(
                            (int)reader["Matricule"],
                            (string)reader["Pseudo"],
                            (string)reader["Mdp"],
                            (string)reader["Nom"],
                            (string)reader["Prenom"],
                            (String)reader["Statut"],
                            (string)reader["Adresse"],
                            (string)reader["Telephone"],
                            (string)reader["Mail"]
                            ),
                           new Fonction((string)reader["RoleAdherent"]),
                           (DateTime)reader["DateDebut"]);
                    fonctionnaires.Add(f);
                }
                connection.Close();
            }
            return fonctionnaires;
        }
        //Fin code BDD

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
