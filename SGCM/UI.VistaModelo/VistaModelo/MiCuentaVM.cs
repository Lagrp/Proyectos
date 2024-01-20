using AppDTO;
using System.Windows.Controls;
using UI.Desktop.Vistas;
using WpfCtrls;

namespace UI.Desktop.VistaModelo
{
    internal class MiCuentaVM
    {
        private static int idUsuarioActivo;

        public MiCuentaVM(int idUsuario)
        {
            idUsuarioActivo = idUsuario;
            //CargarPerfilUsuario(usuarioActivo.Usu_perfilId);
        }

        private void CargarPerfilUsuario(int idPerfil)
        {
        }

        public void MiCuentaSelectionChanged(object sender, Frame frNavConf)
        {
            OptButton? btn = sender as OptButton;

            switch (btn.Tag.ToString())
            {
                case "MiPerfil":
                    frNavConf.Navigate(new PerfilView(idUsuarioActivo));
                    break;

                case "Usuarios":
                    //frNavConf.Navigate(new Perfil(usuarioActivo));
                    break;

                case "Organizacion":
                    //frNavConf.Navigate(new UserControl1());
                    break;

                case "Configuracion":
                    //frNavConf.Navigate(new UserControl1());
                    break;

                case "Mantenimiento":
                    //frNavConf.Navigate(new Perfil(usuarioActivo));
                    break;

                default:
                    frNavConf.Navigate(null);
                    break;
            }
        }
    }
}