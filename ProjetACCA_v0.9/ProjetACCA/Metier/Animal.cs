using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Projet_tut_ACCA.Metier
{
    public class Animal
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int idAnimal;
        public int IdAnimal
        {
            get { return idAnimal; }
            set { idAnimal = value; OnPropertyChanged("IdAnimal"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }
        private int numBague;
        public int NumBague
        {
            get { return numBague; }
            set { numBague = value; OnPropertyChanged("NumBague"); }
        }
        private DateTime datePrelevement;
        public DateTime DatePrelevement
        {
            get { return datePrelevement; }
            set { datePrelevement = value; OnPropertyChanged("DatePrelevement"); }
        }
        private string sexe;
        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; OnPropertyChanged("Sexe"); }
        }
        private int masse;
        public int Masse
        {
            get { return masse; }
            set { masse = value; OnPropertyChanged("Masse"); }
        }
        private string observation;
        public string Observation
        {
            get { return observation; }
            set { observation = value; OnPropertyChanged("Observation"); }
        }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        private string idPoste; 
        public string IdPoste
        {
            get { return idPoste; }
            set { idPoste = value; OnPropertyChanged("IdPoste"); }
        }

        public Animal(string type, int bague, DateTime datePrelevement, string sexe, int masse, string observation,  string idPoste)
        {
            NumBague = bague;
            this.type = type;
            this.datePrelevement = datePrelevement;
            this.sexe = sexe;
            this.masse = masse;
            this.observation = observation;
            this.idPoste = idPoste;
        }

        public static ObservableCollection<Animal> recupAnimaux()
        {
            ObservableCollection<Animal> animaux = new ObservableCollection<Animal>();
            using (SqlConnection connection = Application.getInstance())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAnimal", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Animal a = new Animal(
                            (string)reader["Type"],
                            (int)reader["NumBague"],
                            (DateTime)reader["DatePrelevement"],
                            (string)reader["Sexe"],
                            (int)reader["Masse"],
                            (string)reader["Observation"],
                            (string)reader["IdPosteChasse"]);
                    animaux.Add(a);
                }
                connection.Close();
            }
            return animaux;
        }

        public static void ajoutAnimalBDD(ObservableCollection<Animal> la)
        {
            SqlConnection connection = Application.getInstance();

            foreach (Animal a in la)
            {
                if (a.IsNew)
                {

                    //---------INSERT INTO TAnimal---------
                    connection.Open();

                    string commandTAd = "INSERT INTO TAnimal (Type,NumBague,DatePrelevement,Sexe,Masse,Observation,IdPosteChasse) VALUES ("
                        + "@Type, @NumBague, @DatePrelevement, @Sexe, @Masse, @Observation, @IdPosteChasse)";

                    SqlCommand sqlCommandTAd = new SqlCommand(commandTAd, connection);

                    sqlCommandTAd.Parameters.AddWithValue("@Type", a.Type);
                    sqlCommandTAd.Parameters.AddWithValue("@NumBague", a.NumBague);
                    sqlCommandTAd.Parameters.AddWithValue("@DatePrelevement", a.DatePrelevement);
                    sqlCommandTAd.Parameters.AddWithValue("@Sexe", a.Sexe);
                    sqlCommandTAd.Parameters.AddWithValue("@Masse", a.Masse);
                    sqlCommandTAd.Parameters.AddWithValue("@Observation", a.Observation);
                    sqlCommandTAd.Parameters.AddWithValue("@IdPosteChasse", a.IdPoste);

                    sqlCommandTAd.ExecuteNonQuery();

                    connection.Close();
                }
                // SI C'EST NECESSAIRE JE LE MODIFIERAI ----CLTOURESSE----
                
                /*if (a.IsModified) FAIL MODIF NE PAS EN TENIR COMPTE
                {
                    //---------UPDATE TAnimal---------
                    connection.Open();

                    string commandUTAd = "UPDATE TAnimal SET DatePrelevement = @DatePrelevement, Sexe = @Sexe, Masse = @Masse WHERE IdAnimal = @IdAnimal";

                    SqlCommand sqlCommandUTAd = new SqlCommand(commandUTAd, connection);

                    sqlCommandUTAd.Parameters.AddWithValue("@IdAnimal", a.IdAnimal);
                    sqlCommandUTAd.Parameters.AddWithValue("@Nom", f.Adherent.Nom);
                    sqlCommandUTAd.Parameters.AddWithValue("@Prenom", f.Adherent.Prenom);
                    sqlCommandUTAd.Parameters.AddWithValue("@Statut", f.Adherent.Statut);
                    sqlCommandUTAd.Parameters.AddWithValue("@Adresse", f.Adherent.Adresse);
                    sqlCommandUTAd.Parameters.AddWithValue("@Telephone", f.Adherent.Tel);
                    sqlCommandUTAd.Parameters.AddWithValue("@Mail", f.Adherent.Mail);

                    sqlCommandUTAd.ExecuteNonQuery();

                    connection.Close();
                }*/
            }
        }

        public static void supprimerInfos(int numBague, DateTime datePrelevement)
        {
            int numAnimal;
            SqlConnection connection = Application.getInstance();
            connection.Open();
            string commandUTAd = "SELECT * FROM TAnimal WHERE NumBague = @NumBague AND DatePrelevement = @DatePrelevement";

            SqlCommand sqlCommandUTA = new SqlCommand(commandUTAd, connection);
            sqlCommandUTA.Parameters.AddWithValue("@NumBague", numBague);
            sqlCommandUTA.Parameters.AddWithValue("@DatePrelevement", datePrelevement);
            SqlDataReader reader = sqlCommandUTA.ExecuteReader();
            if (reader.Read())
            {
                numAnimal = (int)reader["IdAnimal"];
            }
            else
            {
                numAnimal = 0;
            }
            connection.Close();
            if (numAnimal != 0)
            {
                connection.Open();
                string commandTA = "DELETE FROM TAnimal WHERE IdAnimal = @IdAnimal";
                SqlCommand sqlCommandTA = new SqlCommand(commandTA, connection);
                sqlCommandTA.Parameters.AddWithValue("@IdAnimal", numAnimal);
                sqlCommandTA.ExecuteNonQuery();
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
    }
}
