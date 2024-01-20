using System.Windows;
using System.Windows.Controls;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var frm = new PersonEditView(EditUIModeEnum.Usuario);
            frm.ShowDialog();
        }
    }
}