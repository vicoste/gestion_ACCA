﻿using Projet_tut_ACCA.Metier;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Interaction logic for WAttribuerPoste.xaml
    /// </summary>
    public partial class WAttribuerPoste : Window
    {
        private ObservableCollection<Poste> postes;
        private Dictionary<Poste,Adherent> dico;
        public Poste selectedPoste;

        public WAttribuerPoste(ObservableCollection<Poste> postes, Dictionary<Poste, Adherent> dico, string nomChasseur)
        {
            this.postes = postes;
            this.dico = dico;
            InitializeComponent();

            cBoxPostes.ItemsSource = remplirComboBox();

            this.Title += nomChasseur;
        }

        private IEnumerable<Poste> remplirComboBox()
        {
            IEnumerable<Poste> modifPostes = postes.Where(p => !dico.Keys.Contains(p));
            return modifPostes;
        }

        private void rechercheByNom(object sender, RoutedEventArgs e)
        {
            if (!textSearch.Text.Equals(""))
            {
                cBoxPostes.Items.Filter = null;
                cBoxPostes.Items.Filter = (i => (i as Poste).Libelle.Contains(textSearch.Text));
            }
            else
                cBoxPostes.Items.Filter = null;
        }

        private void annulerClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void validerClick(object sender, RoutedEventArgs e)
        {
            if (cBoxPostes.SelectedItem != null)
            {
                selectedPoste = (Poste)cBoxPostes.SelectedItem;
                DialogResult = true;
            }
        }
    }
}
