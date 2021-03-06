﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Projet_tut_ACCA.Metier;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Projet_tut_ACCA.Vue
{
    public partial class UCAccueil : UserControl
    {
        bool rech = true;
        private WAccueil a;
        public ObservableCollection<Evenement> LesEvents { get; set; }
        private List<Fonctionnaire> chefs;
        private ObservableCollection<Zone> zones;

        private ICollectionView srcEv;

        public UCAccueil(WAccueil a, ObservableCollection<Evenement> l, bool isPresident, List<Fonctionnaire> chefs, ObservableCollection<Zone> zones)
        {
            this.DataContext = this;
            this.a = a;
            this.chefs = chefs;
            this.zones = zones;
            LesEvents = l;

            InitializeComponent();

            buttonAddEvent.Visibility = isPresident ? Visibility.Visible : Visibility.Hidden;
            srcEv = CollectionViewSource.GetDefaultView(LesEvents);
            Reset_Click(null, null);

            ListeB.ItemsSource = LesEvents;
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            ListeB.SelectedIndex = ListeB.SelectedIndex + 1;
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            if (ListeB.SelectedIndex != 0)
            {
                ListeB.SelectedIndex = ListeB.SelectedIndex - 1;
            }
        }

        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            if (rech)
            {
                tex.Visibility = Visibility.Visible;
                comboBox.Visibility = Visibility.Hidden;
                rech = false;
            }
            else
            {
                tex.Text.ToLower();
                if (tex.Text != null)
                {
                    srcEv.Filter = new Predicate<object>(n => (n as Evenement).Titre.ToLower().Contains(tex.Text.ToLower()));
                }
                tex.Visibility = Visibility.Hidden;
                comboBox.Visibility = Visibility.Visible;
                rech = true;
            }
        }

        private void btnparticiper_Click(object sender, RoutedEventArgs e)
        {
            Evenement eve = (Evenement)ListeB.SelectedItem;

            if (eve != null && eve.Participants.Count(ad => ad.IdAdherent == a.CurrentUser.Adherent.IdAdherent) == 0)
            {
                eve.participerEvenement(a.CurrentUser.Adherent);
            }
        }


        private void btnAnnulerParticip_Click(object sender, RoutedEventArgs e)
        {
            Evenement eve = (Evenement)ListeB.SelectedItem;

            if (eve != null)
            {
                eve.annulerParticipation(a.CurrentUser.Adherent);
            }
        }

        private void Filtre_Click(object sender, RoutedEventArgs e)
        {
            switch (comboBox.Text)
            {
                case "Type":
                    Reset_Click(sender, e);
                    srcEv.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
                    srcEv.SortDescriptions.Add(new SortDescription("Type", ListSortDirection.Ascending));
                    break;
                case "Nom":
                    Reset_Click(sender, e);
                    srcEv.SortDescriptions.Add(new SortDescription("Titre", ListSortDirection.Ascending));
                    break;
                default: break;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            srcEv.GroupDescriptions.Clear();
            srcEv.SortDescriptions.Clear();
            srcEv.Filter = (ev => ((Evenement)ev).DateEvent > DateTime.Today);
        }

        private void buttonAddEvent_Click(object sender, RoutedEventArgs e)
        {
            WAjoutEvent w = new WAjoutEvent(LesEvents, chefs, zones);
            w.ShowDialog();
        }
    }
}