﻿using System;
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
    public partial class WGestionBague : Window
    {
        public ObservableCollection<Autorisation> autorisations { get; set; }
        public Animal newA;

        public WGestionBague(ObservableCollection<Autorisation> a)
        {
            this.DataContext = this;
            autorisations = a;
            InitializeComponent();
        }

        private void button_valider_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}