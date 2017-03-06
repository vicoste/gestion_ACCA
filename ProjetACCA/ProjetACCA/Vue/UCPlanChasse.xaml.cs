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
        public ObservableCollection<Animal> LesAnimaux { get; set; }

        public UCPlanChasse(PlanChasse p)
        {
            LesAnimaux = p.LesAnimaux;
            pc = p;
            this.DataContext = this;
            InitializeComponent();
        }

        private void ajouterBague(object sender, RoutedEventArgs e)
        {
            WAjoutAnimal a = new WAjoutAnimal(pc.Autorisations);
            if(a.ShowDialog() == true)
            {
                //ajouter à la liste des animaux pc.lesAnimaux (rajouter metier) depuis a.newA
                LesAnimaux.Add(a.newA);
            }
        }

        private void gestionBague(object sender, RoutedEventArgs e)
        {
            WGestionBague gb = new WGestionBague(pc.Autorisations);
            gb.ShowDialog();
        }
    }
}
