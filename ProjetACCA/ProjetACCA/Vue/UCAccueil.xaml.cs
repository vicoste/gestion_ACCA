using System;
using System.Collections.Generic;
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
using Projet_tut_ACCA.Metier;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Vue
{
    public partial class UCAccueil : UserControl
    {
        bool rech = true;
        private WAccueil a;
        public ObservableCollection<Evenement> LesEvents { get; set; }

        public UCAccueil(WAccueil a, ObservableCollection<Evenement> l)
        {
            this.DataContext = this;
            this.a = a;
            LesEvents = l;
            InitializeComponent();

            ListeB.ItemsSource = LesEvents;     
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            ListeB.SelectedIndex = ListeB.SelectedIndex + 1;
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            if (ListeB.SelectedIndex != 0)
            {
                ListeB.SelectedIndex = ListeB.SelectedIndex - 1;
            }
        }

        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            if (rech)
            {
                tex.Visibility = Visibility.Visible;
                comboBox.Visibility = Visibility.Hidden;
                rech = false;
            }
            else
            {
                tex.Text.ToLower();
                if (tex.Text != null)
                {
                    /*
                    ICollectionView srcEv = (LesEvents as CollectionViewSource).View;
                    srcEv.Filter = new Predicate<object>(n => (n as Evenement).Titre.ToLower().Contains(tex.Text.ToLower()));
                    */
                }
                tex.Visibility = Visibility.Hidden;
                comboBox.Visibility = Visibility.Visible;
                rech = true;
            }
        }

        private void btnparticiper_Click(object sender, RoutedEventArgs e)
        {
            Evenement eve = (Evenement)ListeB.SelectedItem;

            eve.participerEvenement(a.CurrentUser.Adherent);
        }


        private void btnAnnulerParticip_Click(object sender, RoutedEventArgs e)
        {
            Evenement eve = (Evenement)ListeB.SelectedItem;

            eve.annulerParticipation(a.CurrentUser.Adherent);

        }

        private void Filtre_Click(object sender, RoutedEventArgs e)
        {
            /*CollectionViewSource view = (UCAcceuil.Resources["Collec"] as CollectionViewSource);
            switch (comboBox.Text)
            {
                case "Type": Reset_Click(sender, e); view.GroupDescriptions.Add(new PropertyGroupDescription("Type")); view.SortDescriptions.Add(new SortDescription("Type", ListSortDirection.Ascending)); view.SortDescriptions.Add(new SortDescription("Type", ListSortDirection.Ascending)); break;
                case "Nom": Reset_Click(sender, e); view.SortDescriptions.Add(new SortDescription("Nom", ListSortDirection.Ascending)); break;
                default: break;
            }*/
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            /*CollectionViewSource view = (UCAcceuil.Resources["Collec"] as CollectionViewSource);
            view.GroupDescriptions.Clear();
            view.SortDescriptions.Clear();*/
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}