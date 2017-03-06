using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Autorisation
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value;  OnPropertyChanged("Key"); }
        }

        private int value;
        public int Value
        {
            get { return value; }
            set { this.value = value; OnPropertyChanged("Value"); }
        }

        public Autorisation(string key, int value)
        {
            Key = key;
            Value = value;
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
