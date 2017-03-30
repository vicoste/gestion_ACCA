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
    public class CarnetBattue : Evenement
    {
        private Zone zone;
        public Zone Zone
        {
            get { return zone; }
            set { zone = value; OnPropertyChanged("Zone"); }
        }
        private Fonctionnaire chef;
        public Fonctionnaire Chef
        {
            get { return chef; }
            set { chef = value; OnPropertyChanged("Chef"); }
        }

        private Dictionary<Poste,Adherent> quiVaOu;
        public Dictionary<Poste, Adherent> QuiVaOu
        {
            get { return quiVaOu; }
            set { quiVaOu = QuiVaOu; OnPropertyChanged("QuiVaOu"); }
        }

        private int isModif;
        public int IsModif
        {
            get { return isModif; }
            set { isModif = value; OnPropertyChanged("IsModif"); }
        }

        public static void ajoutBattueBDD(CarnetBattue c)
        {
            SqlConnection connection = Application.getInstance();

            connection.Open();

            string commandIB = "INSERT INTO TBattue (IdBattue, IdChef, IdZoneBattue) VALUES ("
                + "@IdBattue, @IdChef, @IdZone)";
            SqlCommand sqlCommandIB = new SqlCommand(commandIB, connection);

            sqlCommandIB.Parameters.AddWithValue("@IdBattue", c.IdEvenement);
            sqlCommandIB.Parameters.AddWithValue("@IdChef", c.Chef.Adherent.IdAdherent);
            sqlCommandIB.Parameters.AddWithValue("@IdZone", c.Zone.IdZone);

            sqlCommandIB.ExecuteNonQuery();

            connection.Close();
        }

        public static Dictionary<Poste, Adherent> recupQuiVaOu(int idBattue, Zone z, ObservableCollection<Fonctionnaire> lesFonctionnaires)
        {
            Dictionary<Poste, Adherent> quiVaOu = new Dictionary<Poste, Adherent>();

            SqlConnection connection = Application.getInstance();
            connection.Open();

            string commandSAP = "SELECT * FROM TAdherentPoste WHERE IdChasse = @IdChasse";
            SqlCommand sqlCommandSAP = new SqlCommand(commandSAP, connection);

            sqlCommandSAP.Parameters.AddWithValue("@IdChasse", idBattue);

            SqlDataReader reader = sqlCommandSAP.ExecuteReader();
            while(reader.Read())
            {
                string numero = (string)reader["IdPosteBattue"];
                Poste poste = null;
                foreach (Poste p in z.ListPoste)
                {
                    if (p.Numero.Equals(numero))
                    {
                        poste = p;
                        break;
                    }
                }
                quiVaOu.Add(
                    poste,
                    lesFonctionnaires.First(f => f.Adherent.IdAdherent == (int)reader["IdChasseur"]).Adherent);
            }

            connection.Close();
            return quiVaOu;
        }

        public CarnetBattue(int id, string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants, string heureD, string heureF, Zone z, Fonctionnaire f, Dictionary<Poste, Adherent> quiVaOu, int isModif = 1)
            : base(id, titre, dateEvent, type, description, participants, heureD, heureF)
        {
            zone = z;
            chef = f;
            this.quiVaOu = quiVaOu;
            this.isModif = isModif;
        }
    }
}
