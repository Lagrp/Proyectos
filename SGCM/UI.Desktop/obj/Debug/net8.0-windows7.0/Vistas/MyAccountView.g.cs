﻿#pragma checksum "..\..\..\..\Vistas\MyAccountView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "538E07931909DE466A3A6E7E8F1F24212BEE779E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfCtrls;


namespace Sgcm.UI.Desktop.Vistas {
    
    
    /// <summary>
    /// MyAccountView
    /// </summary>
    public partial class MyAccountView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.OptButton optMiPerfil;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.OptButton optUsuarios;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.OptButton optOrganizacion;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.OptButton optConfiguracion;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.OptButton optMantenimiento;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Vistas\MyAccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frNavConf;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sgcm.UI.Desktop;component/vistas/myaccountview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\MyAccountView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.optMiPerfil = ((WpfCtrls.OptButton)(target));
            
            #line 18 "..\..\..\..\Vistas\MyAccountView.xaml"
            this.optMiPerfil.Checked += new System.Windows.RoutedEventHandler(this.Nav_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.optUsuarios = ((WpfCtrls.OptButton)(target));
            
            #line 25 "..\..\..\..\Vistas\MyAccountView.xaml"
            this.optUsuarios.Checked += new System.Windows.RoutedEventHandler(this.Nav_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.optOrganizacion = ((WpfCtrls.OptButton)(target));
            
            #line 32 "..\..\..\..\Vistas\MyAccountView.xaml"
            this.optOrganizacion.Checked += new System.Windows.RoutedEventHandler(this.Nav_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.optConfiguracion = ((WpfCtrls.OptButton)(target));
            
            #line 39 "..\..\..\..\Vistas\MyAccountView.xaml"
            this.optConfiguracion.Checked += new System.Windows.RoutedEventHandler(this.Nav_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.optMantenimiento = ((WpfCtrls.OptButton)(target));
            
            #line 46 "..\..\..\..\Vistas\MyAccountView.xaml"
            this.optMantenimiento.Checked += new System.Windows.RoutedEventHandler(this.Nav_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.frNavConf = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
