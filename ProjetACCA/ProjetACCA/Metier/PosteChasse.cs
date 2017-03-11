using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class PosteChasse
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Zone> zones;
        public ObservableCollection<Zone> Zones
        {
            get { return zones; }
            set { zones = value;  OnPropertyChanged("Zones"); }
        }

        public PosteChasse()
        {
            zones = Zone.demandeInfos();
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
