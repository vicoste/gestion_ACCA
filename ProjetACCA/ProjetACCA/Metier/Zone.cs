using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class Zone
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }

        private int idZone;
        public int IdZone
        {
            get { return idZone; }
            set { idZone = value; OnPropertyChanged("IdZone"); }
        }

        private ObservableCollection<Poste> lesPostes;
        public ObservableCollection<Poste> LesPostes
        {
            get { return lesPostes; }
            set { lesPostes = value; OnPropertyChanged("LesPostes"); }
        }

        public Zone(string nom, int id = 0)
        {
            this.nom = nom;
            idZone = id;
            lesPostes = new ObservableCollection<Poste>() { new Poste("1", "1", "1", "1"), new Poste("2", "2", "2", "2"), new Poste("1", "1", "1", "1") } ;
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
