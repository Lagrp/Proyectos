﻿#pragma checksum "..\..\..\..\Vistas\LoginView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C37F13B0F60D5066900D3D8CC0295BC0DF5349D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Sgcm.UI.Desktop.VistaModelo;
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
    /// LoginView
    /// </summary>
    public partial class LoginView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.IcoButton btnClose;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.PhTextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.PhPasswordBox pswPassword;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbError;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.ImgButton btLogin;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Vistas\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.ImgLinkButton lblRestauraPwd;
        
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
            System.Uri resourceLocater = new System.Uri("/Sgcm.UI.Desktop;V1.0.0.0;component/vistas/loginview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\LoginView.xaml"
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
            
            #line 17 "..\..\..\..\Vistas\LoginView.xaml"
            ((Sgcm.UI.Desktop.Vistas.LoginView)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((WpfCtrls.IcoButton)(target));
            
            #line 65 "..\..\..\..\Vistas\LoginView.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtUserName = ((WpfCtrls.PhTextBox)(target));
            return;
            case 4:
            this.pswPassword = ((WpfCtrls.PhPasswordBox)(target));
            return;
            case 5:
            this.txbError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btLogin = ((WpfCtrls.ImgButton)(target));
            return;
            case 7:
            this.lblRestauraPwd = ((WpfCtrls.ImgLinkButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

