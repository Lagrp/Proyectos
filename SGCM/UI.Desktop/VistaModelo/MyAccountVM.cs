using Sgcm.UI.Desktop.Vistas;
using System.Windows.Controls;
using WpfCtrls;

namespace Sgcm.UI.Desktop.VistaModelo
{
    internal class MyAccountVM
    {
        public MyAccountVM()
        {
        }

        public void MyAccountSelectionChanged(object sender, Frame frNavConf)
        {
            OptButton? btn = sender as OptButton;

            switch (btn.Tag.ToString())
            {
                case "MiPerfil":
                    frNavConf.Navigate(new ProfileView());
                    break;

                case "Usuarios":
                    frNavConf.Navigate(new UsersView());
                    break;

                case "Organizacion":
                    frNavConf.Navigate(new OrganizacionView());
                    break;

                case "Configuracion":
                    frNavConf.Navigate(new ConfiguracionView());
                    break;

                case "Mantenimiento":
                    //frNavConf.Navigate(new EditPersonView());
                    break;

                default:
                    frNavConf.Navigate(null);
                    break;
            }
        }
    }
}