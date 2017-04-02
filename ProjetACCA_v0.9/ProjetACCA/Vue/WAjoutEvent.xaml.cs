using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Projet_tut_ACCA.Metier;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Vue
{
   
    public partial class WAjoutEvent : Window
    {
        private ObservableCollection<Evenement> list;
        public WAjoutEvent(ObservableCollection<Evenement> l, List<Fonctionnaire> chefs, ObservableCollection<Zone> zones)
        {
            list = l;
            InitializeComponent();

            comboBoxChef.ItemsSource = chefs;
            comboBoxZone.ItemsSource = zones;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (Titre.Text.Equals("")) { Titre.BorderBrush = Brushes.Red; return; }
            if (Type.Text.Equals("")) { Type.BorderBrush = Brushes.Red; return; }
            if (Date.Text.Equals("")) { Date.BorderBrush = Brushes.Red; return; }
            if (HeureD.Text.Equals("")) { HeureD.BorderBrush = Brushes.Red; return; }
            if (HeureF.Text.Equals("")) { HeureF.BorderBrush = Brushes.Red; return; }
            int hD = 0, hF = 0;
            if(!Int32.TryParse(HeureD.Text, out hD) || !Int32.TryParse(HeureF.Text, out hF) || hD >= hF)
            {
                HeureD.BorderBrush = Brushes.Red;
                HeureF.BorderBrush = Brushes.Red;
                return;
            }
            
            string des = Description.Text.Equals("") ? "Pas de description" : Description.Text;
            if (TypeCB.IsChecked == false)
            {
                Evenement newE = new Evenement(0, Titre.Text, DateTime.Parse(Date.Text), Type.Text, des, new ObservableCollection<Adherent>(), HeureD.Text + " Heure", HeureF.Text + " Heure");
                newE.ajouterEvenementBDD();
                list.Add(newE);
            }
            else {
                Evenement newE = new CarnetBattue(0, Titre.Text, DateTime.Parse(Date.Text), Type.Text, des, new ObservableCollection<Adherent>(), HeureD.Text + " Heure", HeureF.Text + " Heure", (Zone) comboBoxZone.SelectedItem, (Fonctionnaire) comboBoxChef.SelectedItem, new Dictionary<Poste, Adherent>());
                newE.ajouterEvenementBDD();
                list.Add(newE);
            }
            Close();
        }

        private void Quitter_Click(Object sender,RoutedEventArgs e)
        {
            Close();
        }
    }
}
