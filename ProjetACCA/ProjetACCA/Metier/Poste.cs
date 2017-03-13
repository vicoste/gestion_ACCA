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
    public class Poste
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value;  OnPropertyChanged("Numero"); }
        }

        private string libelle;
        public string Libelle
        {
            get { return libelle; }
            set { libelle= value; OnPropertyChanged("Libelle"); }
        }

        private string gps;
        public string Gps
        {
            get { return gps; }
            set { gps = value; OnPropertyChanged("Gps"); }
        }

        private string observation;
        public string Observation
        {
            get { return observation; }
            set { observation = value; OnPropertyChanged("Observation"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public Poste(string numero, string libelle, string gps, string observation)
        {
            this.numero = numero;
            this.libelle = libelle;
            this.gps = gps;
            this.observation = observation;
        }

        public static void ajoutPosteBDD(ObservableCollection<Poste> lp, int idZone)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Poste p in lp)
            {
                if (p.IsNew)
                {

                    //---------INSERT INTO TPoste---------
                    connection.Open();

                    string commandTAd = "INSERT INTO TPoste (IdPoste, Libelle, Gps, Observations, IdZone) VALUES (@IdPoste, @Libelle, @Gps, @Observations, @IdZone)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@IdPoste", p.Numero);
                    sqlCommandTAd.Parameters.AddWithValue("@Libelle", p.Libelle);
                    sqlCommandTAd.Parameters.AddWithValue("@Gps", p.Gps);
                    sqlCommandTAd.Parameters.AddWithValue("@Observations", p.Observation);
                    sqlCommandTAd.Parameters.AddWithValue("@IdZone", idZone);

                    sqlCommandTAd.ExecuteNonQuery();

                    connection.Close();
                }

                if (p.IsModified)
                {
                    //---------UPDATE TPoste---------
                    connection.Open();

                    string commandUTAd = "UPDATE TPoste SET IdPoste = @IdPoste, Libelle = @Libelle, Gps = @Gps, Observations = @Observations, IdZone = @IdZone"
                        + " WHERE IdPoste = @IdPoste";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@IdPoste", p.Numero);
                    sqlCommandUTAd.Parameters.AddWithValue("@IsChassable", p.Libelle);
                    sqlCommandUTAd.Parameters.AddWithValue("@IdZone", p.Gps);
                    sqlCommandUTAd.Parameters.AddWithValue("@IdZone", p.Observation);
                    sqlCommandUTAd.Parameters.AddWithValue("@IdZone", idZone);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
                }
            }
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
            return Libelle;
        }
    }
}
