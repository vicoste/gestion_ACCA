﻿using System;
using System.Windows;
using System.Collections.ObjectModel;
using Projet_tut_ACCA.Metier;
using System.Text.RegularExpressions;

namespace Projet_tut_ACCA.Vue
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WAjoutMembre : Window
    {
        private ObservableCollection<Fonctionnaire> listeFontionnaires;

        public WAjoutMembre(ObservableCollection<Fonctionnaire> l)
        {
            InitializeComponent();
            listeFontionnaires = l;

            comboBox_fonction.ItemsSource = new ObservableCollection<string>(Enum.GetNames(typeof(EFonction)));
            comboBox_societaire.ItemsSource = new ObservableCollection<string>(Enum.GetNames(typeof(ESocietaire)));
        }

        private void button_valider_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_nom.Text.ToString().Equals("")) { MessageBox.Show("Erreur : le Nom est vide !"); return; }
            if (textBox_prenom.Text.ToString().Equals("")) { MessageBox.Show("Erreur : le Prenom est vide !"); return; }
            if (textBox_telephone.Text.ToString().Equals("") || textBox_telephone.Text.ToString().Length > 10) { MessageBox.Show("Erreur : le numero de telephone est vide !"); return; }
            if (textBox_adresse.Text.ToString().Equals("")) { MessageBox.Show("Erreur : l'adresse est vide !"); return; }
            if (textBox_mdp.Text.ToString().Equals("")) { MessageBox.Show("Erreur : Mot de passe vide !"); return; }

            string login = genererIdentifiant(textBox_nom.Text, textBox_prenom.Text);
            string statut = comboBox_societaire.SelectedItem.ToString();
           
            Adherent adherent = new Adherent(0, login, textBox_mdp.Text, textBox_nom.Text, textBox_prenom.Text, statut, textBox_adresse.Text, textBox_telephone.Text, textBox_mail.Text);

            Fonction fonction = new Fonction(comboBox_fonction.SelectedItem.ToString());

            Fonctionnaire f = new Fonctionnaire(adherent, fonction, DateTime.Today);
            f.IsNew = true;

            listeFontionnaires.Add(f);
            
            this.Close();           
        }

        private void button_annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string replaceAccent(string pattern, string input, string replacement)
        {
            Regex rgx = new Regex(@"" + pattern);
            return rgx.Replace(input, replacement);
        }

        private String genererIdentifiant(String nom, String prenom)  //2premieres lettres du prenom, 6premieres lettre du nom --EDIT-- en minuscule --EDIT-- sans accent
        {
            nom = nom.ToLower();
            prenom = prenom.ToLower();

            nom = replaceAccent("[àâä]", nom, "a");
            prenom = replaceAccent("[àâä]", prenom, "a");
            nom = replaceAccent("[éèêë]", nom, "e");
            prenom = replaceAccent("[éèêë]", prenom, "e");
            nom = replaceAccent("[îï]", nom, "i");
            prenom = replaceAccent("[îï]", prenom, "i");

            int i = 0;
            string s1;
            if (prenom.Length < 2) s1 = prenom;
            else s1 = prenom.Substring(0, 2);

            string res = s1 + nom;
            foreach(Fonctionnaire f in listeFontionnaires)
            {
                if (f.Adherent.Login.Equals(res))
                {
                    i++;
                    res = res + i;
                }
            }
            return res;
        }
    }
}
