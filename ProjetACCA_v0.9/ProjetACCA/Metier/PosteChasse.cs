using System.Collections.ObjectModel;
using System.ComponentModel;

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
            zones = Zone.recupZones();
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
