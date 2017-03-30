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
using System.Windows.Shapes;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Logique d'interaction pour WAccueil.xaml
    /// </summary>
    public partial class WAccueil : Window
    {
        private Metier.Application app;
        private Fonctionnaire currentUser;
        public Fonctionnaire CurrentUser { get { return currentUser; } }
        public ObservableCollection<string> listeFct;

        private void changeVisibility()
        {
            ObservableCollection<string> l = currentUser.Fonction.Fonctions;
            for (int i = 0; i < l.Count; i++)
            {
                
                
                listFonction.Items.Add(l[i]);
            }
            ResourceDictionary mystyles = new ResourceDictionary();

            mystyles.Source = new Uri("/Vue/Dictionar_listBox1.xaml",
                    UriKind.RelativeOrAbsolute);

            listFonction.ItemContainerStyle = mystyles["ThemeListBox"] as Style;
        }

        public void loadUC(UserControl uc)
        {
            gridAccueil.Children.Remove(UCglobal);
            UCglobal = uc;
            Grid.SetColumn(UCglobal, 1);
            gridAccueil.Children.Add(UCglobal);
        }

        private void Deconnexion(object sender, RoutedEventArgs e)
        {
            app.deconnexion();
            WConnexion wAcc = new WConnexion();
            this.Close();
            wAcc.Show();
        }

        public WAccueil(Metier.Application a, Fonctionnaire f)
        {
            InitializeComponent();
            
            app = a;
            currentUser = f;
            listeFct = currentUser.Fonction.Fonctions;

            this.DataContext = this;
            //changeVisibility();

            loadUC(new UCAccueil( this, app.ListEvents, currentUser.Fonction.Role.Equals("President") || currentUser.Fonction.Role.Equals("Dev") ? true : false, new List<Fonctionnaire>(app.ListFonctionnaires.Where(fo => fo.Fonction.Role.Equals("Chef_de_Battue"))), app.PosteDeChasse.Zones));
        }

        private void listeClick(object sender, MouseButtonEventArgs e)
        {
            string s = (string)listFonction.SelectedItem;
            switch (s)
            {
                case "Accueil":
                    loadUC(new UCAccueil(this, app.ListEvents, currentUser.Fonction.Role.Equals("President") || currentUser.Fonction.Role.Equals("Dev") ? true : false, new List<Fonctionnaire>(app.ListFonctionnaires.Where(fo => fo.Fonction.Role.Equals("Chef_de_Battue"))), app.PosteDeChasse.Zones));
                    break;
                case "Les Adhérents":
                    loadUC(new UCListeAdherent(app.ListFonctionnaires));
                    break;
                case "Cotisation":
                    loadUC(new UCCotisation(app));
                    break;
                case "Infos Personelles":
                    loadUC(new UCInfoPers(currentUser));
                    break;
                case "Plan de Chasse":
                    loadUC(new UCPlanChasse(app.PlanDeChasse, app.PosteDeChasse));
                    break;
                case "Les Zones":
                    loadUC(new UCPosteChasse(app.PosteDeChasse.Zones));
                    break;
                case "Les Battues":
                    loadUC(new UCCarnetBattue(new ObservableCollection<Evenement>(app.ListEvents.Where(ev => ev.Type.Equals("Battue")))));
                    break;
                case "Partir":
                    Adherent.notifierDepart(currentUser);
                    break;
            }
        }

        private void DeconnexionCroix(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // app.deconnexion();
        }
    }
}
