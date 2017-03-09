using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projet_tut_ACCA.Metier
{
    public class Fonction
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string role; 
        public string Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged("Role"); }
        }
        private ObservableCollection<string> fonctions;
        public ObservableCollection<string> Fonctions
        {
            get { return fonctions;  }
            set { fonctions = value; OnPropertyChanged("Fonctions"); }
        }

        public Fonction(string role)
        {
            this.role = role;
            fonctions = new ObservableCollection<string>();
            fonctions.Add("Accueil");
            fonctions.Add("Infos Personelles");
            switch (role)
            {
                case "President":
                    
                    fonctions.Add("Les Adhérents");
                    fonctions.Add("Cotisation");
                    fonctions.Add("Plan de Chasse");
                    break;
                case "Membre":
                    
                    break;
                default:
                    break;
            }
            
        }

        public Fonction()
        {

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
