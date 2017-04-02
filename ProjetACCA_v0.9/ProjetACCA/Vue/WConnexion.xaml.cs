using Projet_tut_ACCA.Metier;
using System.Windows;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class WConnexion : Window
    {
        private Metier.Application app = new Metier.Application();
        public WConnexion()
        {            
            InitializeComponent();
        }

        private void ConnecterBouton(object sender, RoutedEventArgs e)
        {
            Fonctionnaire user = app.connexion(login.Text, mdp.Password);
            if (user != null)
            {
                WAccueil wAcc = new WAccueil(app, user);
                this.Close();
                wAcc.Show();
            }
            else
            {
                erreurConnex.Visibility = Visibility.Visible;
            }
        }
    }
}
