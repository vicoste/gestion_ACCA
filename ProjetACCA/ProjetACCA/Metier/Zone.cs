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

        public Zone(int idZone, string nom, ObservableCollection<Poste> listPoste)
        {
            this.idZone = idZone;
            this.nom = nom;
            this.listPoste = listPoste;
        }

        public static ObservableCollection<Zone> demandeInfos()
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
                            recupPostes((int)reader["IdZone"]));
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

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

    }
}
