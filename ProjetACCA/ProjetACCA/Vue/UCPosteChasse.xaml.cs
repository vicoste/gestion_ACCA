using Projet_tut_ACCA.Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_tut_ACCA.Vue
{
    public partial class UCPosteChasse : UserControl
    {
        public ObservableCollection<Zone> lesZones { get; set; }

        public UCPosteChasse(ObservableCollection<Zone> zones)
        {
            this.DataContext = this;
            lesZones = zones;    

            InitializeComponent();
        }

        private void buttonModifPoste(object sender, RoutedEventArgs e)
        {
            if (listZones.SelectedItem != null)
            {
                bool modifPoste = ((Zone)listZones.SelectedItem).IsModified;
                ((Zone)listZones.SelectedItem).IsModified = true;
            }

            if (listPostes.SelectedItem != null)
            {
                bool modifPoste = ((Poste)listPostes.SelectedItem).IsModified;
                ((Poste)listPostes.SelectedItem).IsModified = !modifPoste;
            }
        }

        private string calculNumeroPoste(Zone z)
        {
            char[] separators = { ' ', ',', '.', ':', '\t', '-' };
            return z.Nom.Split(separators).Last()[0] + (z.ListPoste.Count + 1).ToString("000");
        }

        private void ajouterNouveauPoste(object sender, RoutedEventArgs e)
        {
            Zone selectZone = (Zone)listZones.SelectedItem;
            if (selectZone != null)
            {
                Poste newPoste = new Poste(calculNumeroPoste(selectZone), "Nouveau Libelle", "Nouvelle Coordonnées", "Non rempli");
                newPoste.IsNew = true;
                selectZone.ListPoste.Add(newPoste);
            }
        }

        private void ajouterNouvelleZone(object sender, RoutedEventArgs e)
        {
            Zone newZone = new Zone(0, "NOUVEAU NOM", new ObservableCollection<Poste>(), 1);
            newZone.IsNew = true;
            lesZones.Add(newZone);
        }
    }
}
