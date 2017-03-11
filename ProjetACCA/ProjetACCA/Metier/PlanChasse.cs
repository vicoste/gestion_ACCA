using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class PlanChasse
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Autorisation> autorisations;
        public ObservableCollection<Autorisation> Autorisations
        {
            get { return autorisations; }
            set { autorisations = value; OnPropertyChanged("Autorisations"); }
        }
        private ObservableCollection<Animal> lesAnimaux;
        public ObservableCollection<Animal> LesAnimaux
        {
            get { return lesAnimaux; }
            set { lesAnimaux = value; OnPropertyChanged("LesAnimaux"); }
        }

        public PlanChasse()
        {
            //query BDD
            autorisations = new ObservableCollection<Autorisation>();
            autorisations.Add(new Autorisation("Cervidé", 10));

            lesAnimaux = Animal.recupAnimaux();
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
