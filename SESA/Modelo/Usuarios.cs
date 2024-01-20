namespace SESA.Modelo
{
    internal class Usuarios
    {
        private string acceso, usuario, password, conPassword, nombre;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public string ConPassword { get => conPassword; set => conPassword = value; }
        public string Acceso { get => acceso; set => acceso = value; }
    }


}