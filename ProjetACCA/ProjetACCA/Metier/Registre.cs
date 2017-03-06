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
    public class Registre
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        private Adherent payant;
        public Adherent Payant
        {
            get { return payant; }
            set { payant = value; OnPropertyChanged("Payant"); }
        }

        private Cotisation paiement;
        public Cotisation Paiement
        {
            get { return paiement; }
            set { paiement = value; OnPropertyChanged("Paiement"); }
        }

        private DateTime datePaiement;
        public DateTime DatePaiement
        {
            get { return datePaiement; }
            set { datePaiement = value;  OnPropertyChanged("DatePaiement"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public Registre(Adherent payant, Cotisation paiement, DateTime datePaiement)
        {
            this.payant = payant;
            this.paiement = paiement;
            this.datePaiement = datePaiement;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public static ObservableCollection<Registre> DemanderCotisation()
        {
            ObservableCollection<Registre> registres = new ObservableCollection<Registre>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TCotisationAdherent ca, TCotisation c, TAdherent a WHERE c.IdCotisation = ca.IdCotisation AND a.Matricule = ca.MatriculePayeur", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Registre r = new Registre(
                        new Adherent(
                            (int)reader["Matricule"],
                            (string)reader["Pseudo"],
                            (string)reader["Mdp"],
                            (string)reader["Nom"],
                            (string)reader["Prenom"],
                            (string)reader["Statut"],
                            (string)reader["Adresse"],
                            (string)reader["Telephone"],
                            (string)reader["Mail"]
                        ),
                        new Cotisation(
                            (int)reader["IdCotisation"],
                            (float)reader["Montant"],
                            (string)reader["TypePaiement"]
                        ),
                        (DateTime)reader["DatePaiement"]
                    );
                    registres.Add(r);
                }
                connection.Close();
            }
            return registres;
        }

        public static void AjouterRegistre(ObservableCollection<Registre> lr)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Registre r in lr)
            {
                if (r.IsNew)
                {
                    int noCotisation;

                    //---------INSERT INTO TCotisation---------
                    connection.Open();

                    string commandTAd = "INSERT INTO TCotisation (IdCotisation, Montant, TypePaiement) VALUES ("
                        + "@NoCotisation, @Paiement, @Type)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@NoCotisation", r.Paiement.NoCotisation);
                    sqlCommandTAd.Parameters.AddWithValue("@Paiement", r.Paiement.Paiement);
                    sqlCommandTAd.Parameters.AddWithValue("@Type", r.Paiement.Type);

                    sqlCommandTAd.ExecuteNonQuery();

                    connection.Close();

                    //---------SELECT Matricule FROM TCotisation---------
                    connection.Open();

                    string commandS = "SELECT IdCotisation FROM TCotisation WHERE IdCotisation = @NoCotisation";
                    SqlCommand sqlCommandS = new SqlCommand(commandS, connection);
                    sqlCommandS.Parameters.AddWithValue("@NoCotisation", r.Paiement.NoCotisation);
                    SqlDataReader reader = sqlCommandS.ExecuteReader();
                    if (reader.Read())
                        noCotisation = (int)reader["IdCotisation"];
                    else
                        return;

                    connection.Close();

                    //---------INSERT INTO TCotisationAdherent---------
                    connection.Open();

                    string commandTRAd = "INSERT INTO TCotisationAdherent (MatriculePayeur,IdCotisation,DatePaiement) VALUES ("
                        + "@Matricule, @NoCotisation, @DatePaiement)";

                    SqlCommand sqlCommandTRAd = new SqlCommand(commandTRAd, connection);

                    sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", r.Payant.IdAdherent);
                    sqlCommandTRAd.Parameters.AddWithValue("@RoleAdherent", noCotisation);
                    sqlCommandTRAd.Parameters.AddWithValue("@DateDebut", r.DatePaiement);

                    sqlCommandTRAd.ExecuteNonQuery();

                    connection.Close();
                }
                if (r.IsModified)
                {
                    //---------UPDATE TCotisation---------
                    connection.Open();

                    string commandUTAd = "UPDATE TCotisation SET Montant = @Paiement, TypePaiement = @Type WHERE IdCotisation = @NoCotisation";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@NoCotisation", r.Paiement.NoCotisation);
                    sqlCommandUTAd.Parameters.AddWithValue("@Paiement", r.Paiement.Paiement);
                    sqlCommandUTAd.Parameters.AddWithValue("@Type", r.Paiement.Type);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
