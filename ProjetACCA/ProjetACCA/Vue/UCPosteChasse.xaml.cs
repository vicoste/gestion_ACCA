﻿using Projet_tut_ACCA.Metier;
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
    public partial class UCPosteChasse : UserControl
    {
        public ObservableCollection<Zone> lesZones { get; set; }

        public UCPosteChasse(ObservableCollection<Zone> zones)
        {
            this.DataContext = this;
            lesZones = zones;    

            InitializeComponent();
        }
    }
}