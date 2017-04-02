using System.Windows;
using System.Windows.Controls;
using Projet_tut_ACCA.Metier;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Interaction logic for UCInfoPers.xaml
    /// </summary>
    public partial class UCInfoPers : UserControl
    {
        public Fonctionnaire currentUser { get; set; }
        public UCInfoPers(Fonctionnaire cF)
        {
            this.DataContext = this;
            currentUser = cF;

            InitializeComponent();
            infoFonction.Text = Adherent.getAllFonction(currentUser.Adherent.IdAdherent);
        }

        private void button_changeMdp_click(object sender, RoutedEventArgs e)
        {
            if(ancien.Password.Equals(currentUser.Adherent.Mdp))
            {
                if(!newM.Password.Equals("") && newM.Password.Equals(newMR.Password))
                {
                    currentUser.Adherent.Mdp = newM.Password;
                    currentUser.IsModified = true;
                    ancien.Password = "";
                    newM.Password = "";
                    newMR.Password = "";
                    MessageBox.Show("Mot de passe modifié !");
                }
                else
                {
                    MessageBox.Show("Les deux mots de passe sont différents !");
                }
            }
            else
            {
                MessageBox.Show("Pas le bon mot de passe !");
            }
        }
    }
}
