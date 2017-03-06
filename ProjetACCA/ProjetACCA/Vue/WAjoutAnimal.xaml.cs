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
using System.Collections.ObjectModel;
using Projet_tut_ACCA.Metier;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WAjoutAnimal : Window
    {
        private ObservableCollection<Autorisation> autorisations;
        public Animal newA;

        public WAjoutAnimal(ObservableCollection<Autorisation> a)
        {
            InitializeComponent();
            autorisations = a;

            foreach (Autorisation au in autorisations)
                comboBoxType.Items.Add(au.Key);
        }

        private void button_valider_Click(object sender, RoutedEventArgs e)
        {
            string type = comboBoxType.SelectedItem.ToString();
            if (type.Equals("Nouveau Type"))
            {
                type = textBoxDefType.Text;
                autorisations.Add(new Autorisation(type, -1));
            }

            if (type.Equals("")) { MessageBox.Show("Erreur : le nouveau type est vide !"); return; }

            if (textBoxMasse.Text.ToString().Equals("")) { MessageBox.Show("Erreur : la Masse est vide !"); return; }
            float masse;
            if(!Single.TryParse(textBoxMasse.Text.ToString(), out masse)) { MessageBox.Show("Erreur : la Masse n'est pas un nombre !"); return; }

            string obs = textBoxObs.Text.ToString();
            if (obs.Equals("")) { MessageBox.Show("Erreur : l'Observation est vide !"); return; }

            char sexe = (bool)rbSexeM.IsChecked ? 'M' : 'F';

            DateTime datePrelev;
            if (datePick.SelectedDate != null)
                datePrelev = (DateTime)datePick.SelectedDate;
            else
            { MessageBox.Show("Erreur : la date est vide !"); return; }

            newA = new Animal(type, datePrelev, sexe, masse, obs);
            newA.NumBague = getBague(type);

            DialogResult = true;
        }

        private void button_annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private int getBague(string type)
        {
            int value;
            Autorisation autorisation = null;
            foreach (Autorisation a in autorisations)
                if (a.Key.Equals(type))
                {
                    autorisation = a;
                    break;
                }
            value = autorisation.Value;
            if (value != -1) autorisation.Value--;
            return value;
        }
    }
}
