using System.Windows;
using System.Collections.ObjectModel;
using Projet_tut_ACCA.Metier;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WGestionBague : Window
    {
        public ObservableCollection<Autorisation> autorisations { get; set; }

        public WGestionBague(ObservableCollection<Autorisation> a)
        {
            this.DataContext = this;
            autorisations = new ObservableCollection<Autorisation>();
            foreach (Autorisation aut in a)
                autorisations.Add(new Autorisation(aut.Key, 0, 0));

            InitializeComponent();
        }

        private void button_valider_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void button_annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void button_ajouterType_Click(object sender, RoutedEventArgs e)
        {
            if(!newType.Text.Equals("") && !newType.Text.Equals(" "))
                autorisations.Add(new Autorisation(newType.Text, 0, 0));
        }
    }
}
