using Projet_tut_ACCA.Metier;
using Projet_tut_ACCA.Vue;
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
            login.Text = " ";
            mdp.Text = " ";
        }

        private void ConnecterBouton(object sender, RoutedEventArgs e)
        {
            Fonctionnaire user = app.connexion(login.Text, mdp.Text);
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
