﻿#pragma checksum "..\..\..\..\Vrsta\IzmjenaVrste.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4093EDA5CDE651F3B7BBF4F8FB78FAB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Projekat.Vrsta {
    
    
    /// <summary>
    /// IzmjenaVrste
    /// </summary>
    public partial class IzmjenaVrste : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOznaka;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIme;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOpis;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _tipTxt;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _etiketaTxt;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Ikonica;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat;component/vrsta/izmjenavrste.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
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
            
            #line 31 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPomoc_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtOznaka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtOpis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this._tipTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this._etiketaTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Ikonica = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            
            #line 74 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnIkonica_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 106 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPotvrdi_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 107 "..\..\..\..\Vrsta\IzmjenaVrste.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOdustani_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

