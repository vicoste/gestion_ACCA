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
        private string heureD;
        public string HeureD
        {
            get { return heureD; }
            set { heureD = value;  OnPropertyChanged("HeureD"); }
        }

        private string heureF;
        public string HeureF
        {
            get { return heureF; }
            set { heureF = value; OnPropertyChanged("HeureF"); }
        }

        public CarnetBattue(string titre, DateTime dateEvent, string type, string description, ObservableCollection<Adherent> participants, string heureD, string heureF)
        {
            Titre = titre;
            DateEvent = dateEvent;
            Type = type;
            Description = description;
            Participants = participants;
            this.heureD = heureD;
            this.heureF = heureF;
        }
    }
}
