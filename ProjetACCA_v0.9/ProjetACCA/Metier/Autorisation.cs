using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;

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

        public static void addAutorisationBDD(ObservableCollection<Autorisation> autorisations)
        {
            SqlConnection connection = Application.getInstance();
            foreach (Autorisation a in autorisations)
            { 
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TAutorisation (Type,Nombre,DateAutorisation,PremiereBague) VALUES (@Type, @Nombre, @Date, @PreB)", connection);
                sqlCommand.Parameters.AddWithValue("@Type", a.Key);
                sqlCommand.Parameters.AddWithValue("@Nombre", a.Value);
                sqlCommand.Parameters.AddWithValue("@Date", DateTime.Today);
                sqlCommand.Parameters.AddWithValue("@PreB", a.PremiereBague);

                sqlCommand.ExecuteNonQuery();

                connection.Close();
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
            return Key;
        }
    }
}
