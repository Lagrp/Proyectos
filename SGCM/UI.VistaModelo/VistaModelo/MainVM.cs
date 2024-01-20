using AppServices;
using System.Windows;
using System.Windows.Controls;
using UI.Desktop.Vistas;
using WpfCtrls;
using Dominio.Modelo.Entidades;
using AppDTO;
using AppServices.Servicios;

namespace UI.Desktop.VistaModelo
{
    public class MainVM : NotifyVM
    {
        private static UsuarioDto? usuarioActivo;

        public MainVM(int id)
        {
            usuarioActivo = new MainViewServicio().GetUsuarioActivo(id);
        }

        public MainVM()
        {
        }

        #region PROPIEDADES

        public UsuarioDto? UsuarioActivo
        {
            get => usuarioActivo;

            set
            {
                usuarioActivo = value;
                OnPropertyChanged(nameof(UsuarioActivo));
            }
        }

        #endregion PROPIEDADES

        public void MainViewSelectionChanged(object sender, Frame navigationFrame)
        {
            OptButton? btn = sender as OptButton;
            switch (btn.Tag.ToString())
            {
                //    case "Pizarra":
                //        navegador.Navigate(new Pizarra());
                //        break;

                //    case "Pacientes":
                //        navegador.Navigate(new Pacientes());
                //        break;

                //    case "Agenda":
                //        navegador.Navigate(new Agenda());
                //        break;

                //    case "Gestión":
                //        navegador.Navigate(new Gestion());
                //        break;

                //    case "Reportes":
                //        navegador.Navigate(new Reportes());
                //        break;

                case "MiCuenta":
                    navigationFrame.Navigate(new MiCuenta(UsuarioActivo.Usu_iD));
                    break;

                //    case "CerrarSesion":
                //        EstadoUser = "Inactivo";
                //        break;

                default:
                    navigationFrame.Navigate(null);
                    MessageBox.Show("opcion no esxiste");
                    break;
            }
        }
    }
}