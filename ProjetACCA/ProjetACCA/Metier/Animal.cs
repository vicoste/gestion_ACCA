using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Animal
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        private char sexe;
        public char Sexe
        {
            get { return sexe; }
            set { sexe = value; OnPropertyChanged("Sexe"); }
        }
        private float masse;
        public float Masse
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

        public Animal(string type, DateTime datePrelevement, char sexe, float masse, string observation)
        {
            this.type = type;
            this.datePrelevement = datePrelevement;
            this.sexe = sexe;
            this.masse = masse;
            this.observation = observation;
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
