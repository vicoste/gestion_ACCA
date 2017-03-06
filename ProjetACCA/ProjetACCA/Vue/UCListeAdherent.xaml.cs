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
    public partial class UCListeAdherent : UserControl
    {
        public ObservableCollection<Fonctionnaire> persons { get; set; }

        public UCListeAdherent(ObservableCollection<Fonctionnaire> ps)
        {
            persons = ps;
            this.DataContext = this;
            InitializeComponent();
            comboSocietaire.ItemsSource = new ObservableCollection<string>(Enum.GetNames(typeof(ESocietaire)));
        }
        
        private void button_ajout_Click(object sender, RoutedEventArgs e)
        {
            WAjoutMembre lol = new WAjoutMembre(persons);
            lol.ShowDialog();
        }

        private void supprAdherent(object sender, RoutedEventArgs e)
        {
            Fonctionnaire f = (Fonctionnaire) tabAdherent.SelectedItem;
            Console.WriteLine(f.Adherent.Nom);
            //TODO -- Suppression BDD ? Ou juste une modification pour plus qu'il ne n'affiche
        }

        private void saveModifAdherent(object sender, RoutedEventArgs e)
        {
            Fonctionnaire f = (Fonctionnaire)tabAdherent.SelectedItem;
            f.IsModified = true;
        }
    }
}
