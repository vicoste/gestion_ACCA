using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class PlanChasse
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, int> autorisation;
        public Dictionary<string, int> Autorisation
        {
            get { return autorisation; }
            set { autorisation = value; OnPropertyChanged("Autorisation"); }
        }

        public PlanChasse(Dictionary<string, int> autorisation)
        {
            this.autorisation = autorisation;
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
