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
    public partial class UCListeAdherent : UserControl
    {
        public ObservableCollection<Fonctionnaire> persons { get; set; }

        public UCListeAdherent(ObservableCollection<Fonctionnaire> ps)
        {
            persons = ps;
            this.DataContext = this;
            InitializeComponent();           
        }
        
        private void button_ajout_Click(object sender, RoutedEventArgs e)
        {
            WAjoutMembre lol = new WAjoutMembre(persons);
            lol.ShowDialog();
        }
    }
}
