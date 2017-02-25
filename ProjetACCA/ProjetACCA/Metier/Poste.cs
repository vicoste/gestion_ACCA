using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Poste
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value;  OnPropertyChanged("Numero"); }
        }

        private string libelle;
        public string Libelle
        {
            get { return libelle; }
            set { libelle= value; OnPropertyChanged("Libelle"); }
        }

        private string gps;
        public string Gps
        {
            get { return gps; }
            set { gps = value; OnPropertyChanged("Gps"); }
        }

        private string observation;
        public string Observation
        {
            get { return observation; }
            set { observation = value; OnPropertyChanged("Observation"); }
        }

        public Poste(string numero, string libelle, string gps, string observation)
        {
            this.numero = numero;
            this.libelle = libelle;
            this.gps = gps;
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
