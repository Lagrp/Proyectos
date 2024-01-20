using MySql.Data.MySqlClient;

namespace Sgcm.InfraData.DbContext
{
    public abstract class Connection
    {
        private readonly string _cadenaConeccion;

        public Connection()
        {
            _cadenaConeccion = "Database=sgcmdb;DataSource=localhost;Port=3306;User Id=root;Password=LagrpSoft@@23";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_cadenaConeccion);
        }
    }
}