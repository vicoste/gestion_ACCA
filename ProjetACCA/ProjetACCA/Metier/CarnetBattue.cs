using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    class CarnetBattue : Evenement
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

        public CarnetBattue(string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants, string heureD, string heureF, Zone z, Fonctionnaire f)
            : base(0,titre,dateEvent,type,description,participants, heureD, heureF)
        {
            zone = z;
            chef = f;
        }
    }
}
