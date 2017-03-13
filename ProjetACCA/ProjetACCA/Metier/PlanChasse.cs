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
            autorisations = Autorisation.recupAutorisation();         

            lesAnimaux = Animal.recupAnimaux();

            foreach (var a in autorisations)
            {
                if (a.Value != -1)
                {
                    int i = a.PremiereBague;
                    for (int c = i; c < a.Value + i; c++)
                    {
                        int count = lesAnimaux.Count(an => an.NumBague == c);
                        if (count == 0)
                            LesAnimaux.Add(new Animal(a.Key, c, new DateTime(1, 1, 1), "N", 0, "Non rempli", "Non"));
                    }
                }
            }
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
