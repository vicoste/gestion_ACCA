using Projet_tut_ACCA.Metier;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Projet_tut_ACCA.Vue
{
    public partial class UCPlanChasse : UserControl
    {
        private PlanChasse pc;
        private PosteChasse poc;
        public ObservableCollection<Animal> LesAnimaux { get; set; }

        public UCPlanChasse(PlanChasse p, PosteChasse po)
        {
            LesAnimaux = p.LesAnimaux;
            poc = po;
            pc = p;
            this.DataContext = this;
            InitializeComponent();
        }

        private void ajouterBague(object sender, RoutedEventArgs e)
        {
            WAjoutAnimal a = new WAjoutAnimal(pc.Autorisations, pc.LesAnimaux, poc.Zones);
            if (a.ShowDialog() == true)
            {
                LesAnimaux.Add(a.newA);
            }
            else gridAnimaux.Items.Refresh();
        }

        private void gestionBague(object sender, RoutedEventArgs e)
        {
            WGestionBague gb = new WGestionBague(pc.Autorisations);
            if(gb.ShowDialog() == true)
            {
                Autorisation.addAutorisationBDD(gb.autorisations);
            }
        }

        private void supprAnimal(object sender, RoutedEventArgs e)
        {
            Animal a = (Animal)gridAnimaux.SelectedItem;
            Animal.supprimerInfos(a.NumBague, a.DatePrelevement);
            LesAnimaux.Remove(a);
        }

        private void rechercheByDate(object sender, RoutedEventArgs e)
        {
            dateRecherche.Foreground = Brushes.Black;
            Regex regexDate = new Regex("([0-9]{0,2})[\\/\\- ]([0-9]{0,2})[\\/\\- ]([0-9]{1,4})");
            string date = dateRecherche.Text;
            if (regexDate.IsMatch(date))
            {
                date = date.Replace("00/", "");
                ICollectionView animaux = CollectionViewSource.GetDefaultView(gridAnimaux.ItemsSource);
                animaux.Filter = new Predicate<object>(a => (a as Animal).DatePrelevement.ToString().Contains(date));
            }
            else
            {
                dateRecherche.Foreground = Brushes.Red;
            }
        }

        private void resetFilter(object sender, RoutedEventArgs e)
        {
            dateRecherche.Text = "";
            ICollectionView animaux = CollectionViewSource.GetDefaultView(gridAnimaux.ItemsSource);
            animaux.Filter = null;
        }
    }
}
