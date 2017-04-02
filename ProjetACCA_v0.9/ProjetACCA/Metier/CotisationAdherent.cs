using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
namespace Projet_tut_ACCA.Metier
{
    public class CotisationAdherent
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        private Adherent payant;
        public Adherent Payant
        {
            get { return payant; }
            set { payant = value; OnPropertyChanged("Payant"); }
        }

        private Cotisation cotisation;
        public Cotisation Cotisation
        {
            get { return cotisation; }
            set { cotisation = value; OnPropertyChanged("Cotisation"); }
        }

        private DateTime datePaiement;
        public DateTime DatePaiement
        {
            get { return datePaiement; }
            set { datePaiement = value;  OnPropertyChanged("DatePaiement"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public CotisationAdherent(Adherent payant, Cotisation paiement, DateTime datePaiement)
        {
            this.payant = payant;
            this.cotisation = paiement;
            this.datePaiement = datePaiement;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public static ObservableCollection<CotisationAdherent> DemanderCotisation(Application app)
        {
            ObservableCollection<CotisationAdherent> registres = new ObservableCollection<CotisationAdherent>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TCotisationAdherent ca, TCotisation c WHERE c.IdCotisation = ca.IdCotisation", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    CotisationAdherent r = new CotisationAdherent(
                       app.getAdherentById((int)reader["MatriculePayeur"]),
                        new Cotisation(
                            (int)reader["IdCotisation"],
                            (int)reader["Montant"],
                            (string)reader["TypePaiement"]
                        ),
                        (DateTime)reader["DatePaiement"]
                    );
                    if ((int)reader["Montant"] == 0)
                        r.IsModified = true;
                    registres.Add(r);
                }
                connection.Close();
            }
            return registres;
        }

        public static void AjouterCotisation(ObservableCollection<CotisationAdherent> lr)
        {
            SqlConnection connection = Application.getInstance();

            foreach (CotisationAdherent r in lr)
            {
                if (r.IsNew)
                {
                    int noCotisation;

                    //---------INSERT INTO TCotisation---------
                    connection.Open();

                    string commandIC = "INSERT INTO TCotisation (Montant, TypePaiement) OUTPUT INSERTED.IdCotisation VALUES ("
                        + "@Paiement, @Type)";

                    SqlCommand sqlCommandIC = new SqlCommand(commandIC, connection);

                    sqlCommandIC.Parameters.AddWithValue("@Paiement", r.Cotisation.Paiement);
                    sqlCommandIC.Parameters.AddWithValue("@Type", r.Cotisation.Type);

                    noCotisation = (int) sqlCommandIC.ExecuteScalar();

                    connection.Close();

                    //---------INSERT INTO TCotisationAdherent---------
                    connection.Open();

                    string commandTRAd = "INSERT INTO TCotisationAdherent (MatriculePayeur,IdCotisation,DatePaiement) VALUES ("
                        + "@MatriculeAdherent, @NoCotisation, @DatePaiement)";

                    SqlCommand sqlCommandTRAd = new SqlCommand(commandTRAd, connection);

                    sqlCommandTRAd.Parameters.AddWithValue("@MatriculeAdherent", r.Payant.IdAdherent);
                    sqlCommandTRAd.Parameters.AddWithValue("@NoCotisation", noCotisation);
                    sqlCommandTRAd.Parameters.AddWithValue("@DatePaiement", r.DatePaiement);

                    sqlCommandTRAd.ExecuteNonQuery();

                    connection.Close();
                }
                if (r.IsModified)
                {
                    //---------UPDATE TCotisation---------
                    connection.Open();

                    string commandUTAd = "UPDATE TCotisation SET Montant = @Paiement, TypePaiement = @Type WHERE IdCotisation = @NoCotisation";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@NoCotisation", r.Cotisation.NoCotisation);
                    sqlCommandUTAd.Parameters.AddWithValue("@Paiement", r.Cotisation.Paiement);
                    sqlCommandUTAd.Parameters.AddWithValue("@Type", r.Cotisation.Type);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
