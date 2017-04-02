using System.Windows;

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
