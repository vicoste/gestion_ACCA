using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Registre
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Adherent payant;
        public Adherent Payant
        {
            get { return payant; }
            set { payant = value; OnPropertyChanged("Payant"); }
        }

        private Cotisation paiement;
        public Cotisation Paiement
        {
            get { return paiement; }
            set { paiement = value; OnPropertyChanged("Paiement"); }
        }

        private DateTime datePaiement;
        public DateTime DatePaiement
        {
            get { return datePaiement; }
            set { datePaiement = value;  OnPropertyChanged("DatePaiement"); }
        }

        public Registre(Adherent payant, Cotisation paiement, DateTime datePaiement)
        {
            this.payant = payant;
            this.paiement = paiement;
            this.datePaiement = datePaiement;
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
