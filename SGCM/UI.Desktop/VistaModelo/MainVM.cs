using Sgcm.InfraSoporte.Autentificacion;
using Sgcm.UI.Desktop.Vistas;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfCtrls;

namespace Sgcm.UI.Desktop.VistaModelo
{
    public class MainVM : NotifyVM
    {
        //private MainService _mainViewService;

        public MainVM()
        {
            //navigationFrame.Navigate(new DashboardView());
        }

        #region PROPIEDADES

        public string ActiveUserName => ActiveUser.ShortName;
        public BitmapImage ActiveUserPhoto => ImageTool.ByteToImage(ActiveUser.User_Photo);

        #endregion PROPIEDADES

        public void MainViewSelectionChanged(object sender, Frame navigationFrame)
        {
            OptButton? btn = sender as OptButton;
            switch (btn.Tag.ToString())
            {
                case "Pacientes":
                    navigationFrame.Navigate(new PatientView());
                    break;

                case "Pizarra":
                    navigationFrame.Navigate(new DashboardView());
                    break;

                //case "Agenda":
                //    navigationFrame.Navigate(new Agenda());
                //    break;

                //case "Gestión":
                //    navigationFrame.Navigate(new Gestion());
                //    break;

                //case "Reportes":
                //    navigationFrame.Navigate(new Reportes());
                //    break;

                case "MiCuenta":
                    navigationFrame.Navigate(new MyAccountView());
                    break;

                case "CerrarSesion":
                    Application.Current.Shutdown();
                    break;

                default:
                    navigationFrame.Navigate(null);
                    MessageBox.Show("opcion no esxiste");
                    break;
            }
        }
    }
}