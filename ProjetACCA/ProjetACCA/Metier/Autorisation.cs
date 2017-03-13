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
    public class Autorisation
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value;  OnPropertyChanged("Key"); }
        }

        private int value;
        public int Value
        {
            get { return value; }
            set { this.value = value; OnPropertyChanged("Value"); }
        }

        private int premiereBague;
        public int PremiereBague
        {
            get { return premiereBague; }
            set { this.premiereBague = value; OnPropertyChanged("PremiereBague"); }
        }

        public Autorisation(string key, int value, int premiereBague)
        {
            this.key = key;
            this.value = value;
            this.premiereBague = premiereBague;
        }

        public static ObservableCollection<Autorisation> recupAutorisation()
        {
            ObservableCollection<Autorisation> autorisations = new ObservableCollection<Autorisation>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAutorisation WHERE DateAutorisation = (SELECT MAX(DateAutorisation) FROM TAutorisation)", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Autorisation a = new Autorisation(
                        (string)reader["Type"],
                        (int)reader["Nombre"],
                        (int)reader["PremiereBague"]);
                    autorisations.Add(a);
                }
                connection.Close();
            }
            return autorisations;
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
