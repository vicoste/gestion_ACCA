using Projet_tut_ACCA.Metier;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Interaction logic for UCCarnetBattue.xaml
    /// </summary>
    public partial class UCCarnetBattue : UserControl
    {
        public ObservableCollection<Evenement> lesBattues { get; set; }

        public UCCarnetBattue(ObservableCollection<Evenement> lesBs)
        {
            lesBattues = lesBs;
            this.DataContext = this;

            InitializeComponent();
        }

        private void attribuerPoste(object sender, RoutedEventArgs e)
        {
            CarnetBattue battue = (CarnetBattue)listBattues.SelectedItem;
            Adherent a = (Adherent)gridPoste.SelectedItem;
            WAttribuerPoste w = new WAttribuerPoste(battue.Zone.ListPoste, battue.QuiVaOu, a.ToString());
            if(w.ShowDialog() == true)
            {
                Poste p = null;
                foreach (var v in battue.QuiVaOu)
                {
                    if(v.Value.IdAdherent == a.IdAdherent)
                    {
                        p = v.Key;
                    }
                }
                if (p != null)
                    battue.QuiVaOu.Remove(p);
                battue.QuiVaOu[w.selectedPoste] = a;
            }
        }

        private void imprimerBattue(object sender, RoutedEventArgs e)
        {
            CarnetBattue battue = (CarnetBattue)listBattues.SelectedItem;
            StreamWriter w = new StreamWriter(@"..\..\..\" + battue.Titre + "_impression.txt");
            w.WriteLine(battue.Chef);
            w.WriteLine(battue.DateEvent);
            w.WriteLine(battue.HeureDebut + "\t" + battue.HeureFin);
            w.WriteLine("Observation :");
            w.WriteLine(battue.Description);
            foreach (var kv in battue.QuiVaOu)
                w.WriteLine(kv.Key + "\t" + kv.Value);
            w.Close();
        }

        private void validerQuiVaOu(object sender, RoutedEventArgs e)
        {
            ((CarnetBattue)listBattues.SelectedItem).IsModified = true;
        }
    }
}
