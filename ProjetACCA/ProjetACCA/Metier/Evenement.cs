using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
     public abstract class Evenement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string titre;
        public string Titre
        {
            get { return titre; }
            set { titre = value;  OnPropertyChanged("Titre"); }
        }

        private DateTime dateEvent;
        public DateTime DateEvent
        {
            get { return dateEvent; }
            set { dateEvent = value;  OnPropertyChanged("DateEvent"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private ObservableCollection<Adherent> participants;
        public ObservableCollection<Adherent> Participants
        {
            get { return participants; }
            set { participants = value;  OnPropertyChanged("Participants"); }
        }

         protected void OnPropertyChanged(string v)
         {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public void participerEvenement(Adherent adherent)
        {
            Participants.Add(adherent);
        }

        public void annulerParticipation(Adherent adherent)
        {
            Participants.Remove(adherent);
        }
    }
}
