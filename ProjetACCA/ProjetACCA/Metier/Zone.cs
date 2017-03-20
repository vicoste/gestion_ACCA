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
    public class Zone
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int idZone;
        public int IdZone
        {
            get { return idZone; }
            set { idZone = value; OnPropertyChanged("IdZone"); }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }

        private ObservableCollection<Poste> listPoste;
        public ObservableCollection<Poste> ListPoste
        {
            get { return listPoste; }
            set { listPoste = value; OnPropertyChanged("ListPoste"); }
        }

        private int isChassable;
        public int IsChassable
        {
            get { return isChassable; }
            set { isChassable = value; OnPropertyChanged("IsChassable"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public Zone(int idZone, string nom, ObservableCollection<Poste> listPoste, int isChassable)
        {
            this.idZone = idZone;
            this.nom = nom;
            this.listPoste = listPoste;
            this.isChassable = isChassable;
        }

        public static ObservableCollection<Zone> recupZones()
        {
            ObservableCollection<Zone> zones = new ObservableCollection<Zone>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TZone", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Zone z = new Zone(
                            (int)reader["IdZone"],
                            (string)reader["Nom"],
                            recupPostes((int)reader["IdZone"]),
                            (int)reader["IsChassable"]);
                    zones.Add(z);
                }
                connection.Close();
            }
            return zones;
        }

        private static ObservableCollection<Poste> recupPostes(int IdZone)
        {
            ObservableCollection<Poste> postes = new ObservableCollection<Poste>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TPoste p WHERE p.IdZone = @IdZone", connection);
                sqlCommand.Parameters.AddWithValue("@IdZone", IdZone);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Poste p = new Poste(
                            (string)reader["IdPoste"],
                            (string)reader["Libelle"],
                            (string)reader["Gps"],
                            (string)reader["Observations"]);
                    postes.Add(p);
                }
                connection.Close();
            }
            return postes;
        }

        public static void ajoutZoneBDD(ObservableCollection<Zone> lz)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Zone z in lz)
            {
                if (z.IsNew)
                {

                    //---------INSERT INTO TZone---------
                    connection.Open();

                    string commandTAd = "INSERT INTO TZone (Nom, IsChassable) VALUES (@Nom, 1)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@Nom", z.Nom);

                    sqlCommandTAd.ExecuteNonQuery();

                    connection.Close();
                }

                if (z.IsModified)
                {
                    //---------UPDATE TZone---------
                    connection.Open();

                    string commandUTAd = "UPDATE TZone SET Nom = @Nom, IsChassable = @IsChassable WHERE IdZone = @IdZone";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@Nom", z.Nom);
                    sqlCommandUTAd.Parameters.AddWithValue("@IsChassable", z.IsChassable);
                    sqlCommandUTAd.Parameters.AddWithValue("@IdZone", z.IdZone);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
                }
                Poste.ajoutPosteBDD(z.ListPoste, z.idZone);
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
            return Nom;
        }
    }
}
