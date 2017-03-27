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
    public partial class UCCotisation : UserControl
    {
        private Metier.Application app;

        public UCCotisation(Metier.Application app)
        {
            this.app = app;
            DataContext = this;

            InitializeComponent();

            gridCotisations.ItemsSource = app.LesCotisations;
        }

        private void buttonAjoutCotisation(object sender, RoutedEventArgs e)
        {
            List<Adherent> lAd = new List<Adherent>();
            foreach(var f in app.ListFonctionnaires)
            {
                if(!lAd.Contains(f.Adherent))
                    lAd.Add(f.Adherent);
            }
            foreach(Adherent a in lAd)
            {
                CotisationAdherent cAd = new CotisationAdherent(a, new Cotisation(0, 0, a.Statut), DateTime.Today);
                cAd.IsNew = true;
                app.LesCotisations.Add(cAd);
            }
        }

        private void saveModifCotisation(object sender, RoutedEventArgs e)
        {
            ((CotisationAdherent)gridCotisations.SelectedItem).IsModified = true;
        }
    }
}
