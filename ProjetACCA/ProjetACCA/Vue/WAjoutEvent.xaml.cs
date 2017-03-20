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
using Projet_tut_ACCA.Metier;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Vue
{
   
    public partial class WAjoutEvent : Window
    {
        private ObservableCollection<Evenement> list;
        public WAjoutEvent(ObservableCollection<Evenement> l)
        {
            list = l;
            InitializeComponent();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (Titre.Text.Equals("") || Type.Text.Equals("") || Date.Text.Equals("") || HeureD.Text.Equals("") || HeureF.Text.Equals(""))
            {
                MessageBox.Show("Un champ obligatoire est vide");
                if (Titre.Text.Equals("")) { Titre.BorderBrush = Brushes.Red; }
                if (Type.Text.Equals("")) { Type.BorderBrush = Brushes.Red; }
                if (Date.Text.Equals("")) { Date.BorderBrush = Brushes.Red; }
                if (HeureD.Text.Equals("")) { HeureD.BorderBrush = Brushes.Red; }
                if (HeureF.Text.Equals("")) { HeureF.BorderBrush = Brushes.Red; }
            }
            else
            {
                string des = Description.Text.Equals("") ? "Pas de description" : Description.Text;
                Evenement newE = new Evenement(0, Titre.Text, DateTime.Parse(Date.Text), Type.Text, des, new ObservableCollection<Adherent>(), HeureD.Text + " Heure", HeureF.Text + " Heure");
                newE.ajouterEvenementBDD();
                list.Add(newE);
                Close();
            }        
        }

        private void Quitter_Click(Object sender,RoutedEventArgs e)
        {
            Close();
        }
    }
}
