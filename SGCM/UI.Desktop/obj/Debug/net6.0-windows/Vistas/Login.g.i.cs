﻿#pragma checksum "..\..\..\..\Vistas\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A89EAE4177559EACE705DC53C6478C151389B5D3"
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
using UI.Desktop.VistaModelo;
using WpfCtrls;


namespace UI.Desktop.Vistas {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.IcoButton btnClose;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.PhTextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.PhPasswordBox pswPassword;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbError;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.ImgButton btLogin;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Vistas\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.LinkButton lblRestauraPwd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI.Desktop;V1.0.0.0;component/vistas/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 17 "..\..\..\..\Vistas\Login.xaml"
            ((UI.Desktop.Vistas.Login)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((WpfCtrls.IcoButton)(target));
            
            #line 71 "..\..\..\..\Vistas\Login.xaml"
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
            this.lblRestauraPwd = ((WpfCtrls.LinkButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
