﻿#pragma checksum "..\..\..\Vue\WAjoutAnimal.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E8D8F0D2B7F589D1120053523FFB299"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Projet_tut_ACCA.Vue;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Projet_tut_ACCA.Vue {
    
    
    /// <summary>
    /// WAjoutAnimal
    /// </summary>
    public partial class WAjoutAnimal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_valider;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_annuler;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxType;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDefType;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSexeM;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSexeF;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePick;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxMasse;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxZone;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxPoste;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Vue\WAjoutAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxObs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjetACCA;component/vue/wajoutanimal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vue\WAjoutAnimal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.button_valider = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Vue\WAjoutAnimal.xaml"
            this.button_valider.Click += new System.Windows.RoutedEventHandler(this.button_valider_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button_annuler = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Vue\WAjoutAnimal.xaml"
            this.button_annuler.Click += new System.Windows.RoutedEventHandler(this.button_annuler_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.textBoxDefType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.rbSexeM = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbSexeF = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.datePick = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.textBoxMasse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.comboBoxZone = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.comboBoxPoste = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.textBoxObs = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

