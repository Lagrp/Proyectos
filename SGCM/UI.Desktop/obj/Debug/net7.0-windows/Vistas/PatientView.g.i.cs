// Updated by XamlIntelliSenseFileGenerator 19/11/2023 09:03:33
#pragma checksum "..\..\..\..\Vistas\PatientView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED5DE672EE27F66B6A35D069FD2DEAD8E3780232"
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


namespace Sgcm.UI.Desktop.Vistas
{


    /// <summary>
    /// PatientView
    /// </summary>
    public partial class PatientView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 31 "..\..\..\..\Vistas\PatientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.PhTextBox txtSearch;

#line default
#line hidden


#line 34 "..\..\..\..\Vistas\PatientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.IcoButton btnSearch;

#line default
#line hidden


#line 38 "..\..\..\..\Vistas\PatientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCtrls.ImgButton btnNewPatient;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.14.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sgcm.UI.Desktop;component/vistas/patientview.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Vistas\PatientView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txtSearch = ((WpfCtrls.PhTextBox)(target));
                    return;
                case 2:
                    this.btnSearch = ((WpfCtrls.IcoButton)(target));
                    return;
                case 3:
                    this.btnNewPatient = ((WpfCtrls.ImgButton)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.DataGrid dgPatient;
    }
}
