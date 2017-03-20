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
        private ObservableCollection<Animal> lesAnimaux;
        public Animal newA;

        public WAjoutAnimal(ObservableCollection<Autorisation> a, ObservableCollection<Animal> l, ObservableCollection<Zone> z)
        {
            InitializeComponent();
            autorisations = a;
            lesAnimaux = l;

            foreach (Autorisation au in autorisations)
                comboBoxType.Items.Add(au.Key);
            comboBoxType.Items.Add("Nouveau Type");

            comboBoxZone.ItemsSource = z;
        }

        private void button_valider_Click(object sender, RoutedEventArgs e)
        {
            string type = comboBoxType.SelectedItem.ToString();
            if (type.Equals("Nouveau Type"))
            {
                type = textBoxDefType.Text;
                autorisations.Add(new Autorisation(type, -1, 0));
            }

            if (type.Equals("")) { MessageBox.Show("Erreur : le nouveau type est vide !"); return; }

            if (textBoxMasse.Text.ToString().Equals("")) { MessageBox.Show("Erreur : la Masse est vide !"); return; }
            int masse;
            if(!Int32.TryParse(textBoxMasse.Text.ToString(), out masse)) { MessageBox.Show("Erreur : la Masse n'est pas un nombre !"); return; }

            if(comboBoxPoste.SelectedItem == null) { MessageBox.Show("Erreur : le poste de chasse est vide !"); return; }
            string idPoste = ((Poste)comboBoxPoste.SelectedItem).Numero;

            string obs = textBoxObs.Text.ToString();
            if (obs.Equals("")) { MessageBox.Show("Erreur : l'Observation est vide !"); return; }

            string sexe = (bool)rbSexeM.IsChecked ? "M" : "F";

            DateTime datePrelev;
            if (datePick.SelectedDate != null)
                datePrelev = (DateTime)datePick.SelectedDate;
            else
            {
                MessageBox.Show("Erreur : la date est vide !"); return;
            }

            int numBague, tBague;
            bool rParse;
            rParse = Int32.TryParse(boxBague.Text.ToString(), out numBague);
            tBague = testBague(type, numBague);

            if (rParse == false || tBague == -1 && numBague != -1) { MessageBox.Show("Erreur : le numéro de bague est invalide !"); return; }

            if (tBague == 0)
            {
                newA = new Animal(type, numBague, datePrelev, sexe, masse, obs, idPoste);
                newA.IsNew = true;
                DialogResult = true;
                return;
            }

            Animal a = lesAnimaux.First(an => an.NumBague == numBague);
            a.DatePrelevement = datePrelev;
            a.Sexe = sexe;
            a.Observation = obs;
            a.Masse = masse;
            a.IdPoste = idPoste;
            a.IsNew = true;

            DialogResult = false;
        }

        private void button_annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private int testBague(string type, int bague)
        {
            if (autorisations.First(a => a.Key.Equals(type)).Value == -1)
                return 0;

            if (lesAnimaux.Count(a => a.NumBague == bague) == 0)
                return -1;

            var l = lesAnimaux.Where(a => a.Type.Equals(type) && a.NumBague == bague);
            if (l.Count() == 1)
                return l.ElementAt(0).Observation.Equals("Non rempli") ? 1 : -1;

            return 0;
        }
    }
}
