using Sgcm.UI.Desktop.VistaModelo;
using System.Windows;
using System.Windows.Controls;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para MiCuenta.xaml
    /// </summary>
    public partial class MyAccountView : Page
    {
        private MyAccountVM _myAccountVM = new();

        public MyAccountView()
        {
            InitializeComponent();
            this.DataContext = _myAccountVM;
        }

        private void Nav_Checked(object sender, RoutedEventArgs e)
        {
            _myAccountVM.MyAccountSelectionChanged(sender, frNavConf);
        }
    }
}