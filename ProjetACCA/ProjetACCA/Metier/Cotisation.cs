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
        private Adherent payeur;
        public Adherent Payeur
        {
            get { return payeur; }
            set { payeur = value; OnPropertyChanged("Payeur"); }
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

        public Cotisation(Adherent payeur, float paiement, string type)
        {
            this.payeur = payeur;
            this.paiement = paiement;
            this.type = type;
        }

        public Cotisation demandeInfos()
        {
            return null;
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
