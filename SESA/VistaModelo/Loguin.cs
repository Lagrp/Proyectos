using SESA.Modelo;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace SESA.VistaModelo
{
    internal class Loguin
    {
        private Usuarios usuario = new Usuarios();

        public string Usuario { get => usuario.Usuario; set => usuario.Usuario = value.ToUpper(); }
        public string Nombre { get => usuario.Nombre; set => usuario.Nombre = value; }
        public string Password { get => usuario.Password; set => usuario.Password = generarSHA1(value); }
        public string ConPassword { get => usuario.ConPassword; set => usuario.ConPassword = generarSHA1(value); }
        public string Acceso { get => usuario.Acceso; set => usuario.Acceso = value; }

        public string ctrlRegistro()
        {
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuario.Password == usuario.ConPassword)
                {
                    HExcel ex = new HExcel();
                    double cT = ex.UbicarExl(Globals.ThisWorkbook.Worksheets["Config"], "UsuariosSistema").Columna;
                    double fu =ex.UbicarExl(Globals.ThisWorkbook.Worksheets["Config"], usuario.Usuario, porColumna: cT, OrdenBusqueda: Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns ).Fila;
                    if (fu > 0)
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        ex.GrabarExl("Usuario", usuario.Usuario);
                        ex.GrabarExl("Nombre", usuario.Nombre);
                        ex.GrabarExl("Pasword", usuario.Password);
                        ex.GrabarExl("ConPasword", usuario.ConPassword);
                        ex.GrabarExl("Acceso", "A");
                        ex.GrabarExl(Globals.ThisWorkbook.Worksheets["Config"], "Usuario", usuario.Usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseña no coinciden";
                }
            }
            return respuesta;
        }

        public string ctrlLogin(string usuario, string password)
        {
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                HExcel he = new HExcel();
                List<exlCelda> filaU = he.LeerFilaExl(Globals.ThisWorkbook.Worksheets["Config"], "Usuario", usuario);
                if (filaU == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    Usuarios DUsuario = new Usuarios();

                    DUsuario.Usuario = filaU[0].Valor.ToString();
                    DUsuario.Nombre = filaU[1].Valor.ToString();
                    DUsuario.Password = filaU[2].Valor.ToString();
                    DUsuario.ConPassword = filaU[3].Valor.ToString();
                    DUsuario.Acceso = filaU[4].Valor.ToString();

                    if (DUsuario.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        respuesta = "";
                        //Session.id = datosUsuario.Id;
                        //Session.usuario = usuario;
                        //Session.nombre = datosUsuario.Nombre;
                        //Session.id_tipo = datosUsuario.Id_tipo;
                    }
                }
            }
            return respuesta;
        }


        private string generarSHA1(string cadena)
        {
            System.Text.UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("*"));
            }

            return sb.ToString();
        }
    }
}