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

        public CarnetBattue(int id, string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants, string heureD, string heureF, Zone z, Fonctionnaire f)
            : base(id,titre,dateEvent,type,description,participants, heureD, heureF)
        {
            zone = z;
            chef = f;
        }
    }
}
