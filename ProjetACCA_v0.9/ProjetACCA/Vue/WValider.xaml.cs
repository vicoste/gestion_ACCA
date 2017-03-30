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
using System.Windows.Shapes;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Interaction logic for WValider.xaml
    /// </summary>
    public partial class WValider : Window
    {
        public WValider()
        {
            InitializeComponent();
        }

        private void oui_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void non_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
