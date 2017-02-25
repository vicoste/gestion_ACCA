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

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Interaction logic for UCInfoPers.xaml
    /// </summary>
    public partial class UCInfoPers : UserControl
    {
        private WAccueil a;
        private Adherent CurentUser;
        public UCInfoPers(WAccueil a)
        {
            InitializeComponent();
            this.a = a;
            CurentUser = a.CurrentUser.Adherent;
            TextBoxNom.Content = CurentUser.Nom;
        }


    }



}
