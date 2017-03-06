using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Cotisation
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int noCotisation;
        public int NoCotisation
        {
            get { return noCotisation; }
            set { noCotisation = value;  OnPropertyChanged("NoCotisation"); }
        }

        private float paiement;
        public float Paiement
        {
            get { return paiement; }
            set { paiement = value; OnPropertyChanged("Paiement"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        public Cotisation(int noCotisation, float paiement, string type)
        {
            this.noCotisation = noCotisation;
            this.paiement = paiement;
            this.type = type;
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
