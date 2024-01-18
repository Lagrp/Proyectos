using MySql.Data.MySqlClient;
using System;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace DM
{
    public enum emComandoSQL { SELECCION, INSERTAR, ACTUALIZAR, BORRAR };

    public enum emSelectorSQL
    {
        Ninguno,            //0
        Y,                  //1
        O,                  //2
        Es_Igual_a,         //3
        No_Igual_a,         //4
        Contiene,           //5
        No_Contiene,        //6
        Mayor_Que,          //7
        Menor_Que,          //8
        Mayor_Igual_Que,    //9
        Menor_Igual_Que,    //10
        Comienza_Por,       //11
        No_Comienza_Por,    //12
        Termina_Por,        //13
        No_Termina_Por,     //14
        Es_Entre            //15
    };

    public enum emPredicadoSQL { TODO, LOS_PRIMEROS_10, DISTINTOS, SIN_DUPLICADOS };

    public enum emOperadorSQL { NINGUNO, SUMA, RESTA, MULTIPLICACION, DIVISION, PROMEDIO, CUENTA, MINIMO, MAXIMO };

    public enum emOrdenSQL { NINGUNO, ASENDENTE, DESENDENTE };

    public enum emTipoDato { tdTexto, tdNumerico, tdFecha_mm_dd_aa, tdCriterio1 };

/*
return conexion;
}
//public Connections(): base(new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("",LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2017),
//         "Data Source=ALEX17PDHN\\ALEX17PDHN;Database=sales_system;integrated security=true;") { }

*/

public enum emTConecc { tc_MySQL, tc_SQL, tc_SQLite, tc_ODBC, tc_OLDB };

    public class Dm
    {
        private object myCnn;

        public void ConeccionBD(string nBaseDatos, string pwd, emTConecc TipoConeccion = emTConecc.tc_MySQL, string servidor = "localhost", string puerto = "3306", string usuario = "root")
        {
            try
            {
                switch (TipoConeccion)
                {
                    case emTConecc.tc_MySQL:
                        myCnn = new MySqlConnection("server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + pwd + "; database=" + nBaseDatos);
                        break;
                    case emTConecc.tc_SQL:
                        myCnn = new SqlConnection("Data Source=ALEX17PDHN\\ALEX17PDHN;Database=sales_system;integrated security=true;");
                        break;

                    case emTConecc.tc_OLDB:
                        myCnn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Password = " + pwd + "; User ID = " + usuario + "; Data Source = " + nBaseDatos);
                        break;

                    case emTConecc.tc_ODBC:
                        myCnn = new OdbcConnection();
                        break;

                    case emTConecc.tc_SQLite:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                myCnn = null;
                MessageBox.Show(e.ToString());
            }
        }

        //string sql = "INSERT INTO productos (codigo, nombre, descripcion, precio_publico, existencias) VALUES ('" + codigo + "', '" + nombre + "','" + descripcion + "','" + precio_publico + "','" + existencias + "')";

        public void Insertar(string campo, string valor)
        {

        }

        public void Insertar(string nBaseDatos, string pwd, emTConecc TipoConeccion = emTConecc.tc_MySQL, string servidor = "localhost", string puerto = "3306", string usuario = "root")
        {

        }

        public void Leer()
        {
        }

        public void Actualizar()
        {
        }
        public void Eliminar()
        {
        }

        private void SQL()
        {
            
        }
    }
}