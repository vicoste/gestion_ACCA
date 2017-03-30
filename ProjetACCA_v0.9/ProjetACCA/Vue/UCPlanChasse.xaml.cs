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
    }
}
