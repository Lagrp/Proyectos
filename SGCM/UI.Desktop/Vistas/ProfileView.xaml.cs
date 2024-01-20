using Microsoft.Win32;
using Sgcm.InfraSoporte.Autentificacion;
using Sgcm.UI.Desktop.VistaModelo;
using System.Windows;
using System.Windows.Controls;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class ProfileView : Page
    {
        public ProfileView()
        {
            InitializeComponent();
            this.DataContext = new ProfileVM(ActiveUser.UserId);
        }

        private void ibtnEditPass_Click(object sender, RoutedEventArgs e)
        {
            EditPasswordView edp = new();
            edp.ShowDialog();
        }

        private void btiSearchPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archivos de imagenes | *.*";
            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                DocFoto.Fill = ImageTool.LoadImageBrush(fileDialog.FileName);
            }
        }
    }
}