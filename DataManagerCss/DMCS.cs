using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace DMCSv7
{
    #region ENUMERACIONES DE SELECCION PUBLICAS

    public enum emTConecc
    { tc_MySQL, tc_SQL, tc_SQLite, tc_ODBC, tc_OLDB, tc_Excel, tc_Texto };

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
        Es_Entre
    };          //15

    public enum emPredicadoSQL
    { TODO, LOS_PRIMEROS_10, DISTINTOS, SIN_DUPLICADOS };

    public enum emOperadorSQL
    { NINGUNO, SUMA, RESTA, MULTIPLICACION, DIVISION, PROMEDIO, CUENTA, MINIMO, MAXIMO };

    public enum emOrdenSQL
    { NINGUNO, ASENDENTE, DESENDENTE };

    public enum emTipoDatoSQL
    { tdTexto, tdEntero, tdDecimal, tdFecha_aa_mm_dd, tdCriterio1 };

    #endregion ENUMERACIONES DE SELECCION PUBLICAS

    public class DM
    {
        #region VARIABLES MIEMBRO PRIVADAS

        private object _Cnn;
        private emTConecc _tConec;

        //private ArrayList mTablas = new ArrayList();
        private ArrayList _Campo = new ArrayList();

        private ArrayList _Valor = new ArrayList();

        #endregion VARIABLES MIEMBRO PRIVADAS

        // METODOS Y FUNCIONES MIEMBRO PUBLICAS

        #region CONECCION

        public void ConeccionBD(string nBaseDatos, string Pwd = "", string Servidor = "localhost", string UserId = "root", emTConecc TipoConeccion = emTConecc.tc_MySQL)
        {
            _tConec = TipoConeccion;
            try
            {
                switch (_tConec)
                {
                    case emTConecc.tc_MySQL:
                        _Cnn = new MySqlConnection("Database=" + nBaseDatos + "; Data Source=" + Servidor + "; User Id= " + UserId + "; Password=" + Pwd + "");
                        break;

                    case emTConecc.tc_SQL:
                        //_Cnn = new SqlConnection("Provider=MSDASQL.1;Persist Security Info=True;Extended Properties=&quot;DSN=MS Access Database;DBQ=" + nBaseDatos);
                        _Cnn = null;
                        break;

                    case emTConecc.tc_SQLite:
                        _Cnn = null;
                        break;

                    case emTConecc.tc_OLDB:
                        //_Cnn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Password = " + Pwd + "; User ID = " + UserId + "; Data Source = " + nBaseDatos);
                        _Cnn = null;
                        break;

                    case emTConecc.tc_ODBC:
                        //_Cnn = new OdbcConnection();
                        _Cnn = null;
                        break;

                    case emTConecc.tc_Excel:
                        _Cnn = null;
                        break;

                    case emTConecc.tc_Texto:
                        _Cnn = null;
                        break;

                    default:
                        _Cnn = null;
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                _Cnn = null;
            }
        }

        public void ConeccionBD(string nCadenaConex, emTConecc TipoConeccion = emTConecc.tc_MySQL)
        {
            _tConec = TipoConeccion;
            try
            {
                switch (_tConec)
                {
                    case emTConecc.tc_MySQL:
                        _Cnn = new MySqlConnection(nCadenaConex);
                        break;

                    case emTConecc.tc_SQL:
                        _Cnn = new SqlConnection(nCadenaConex);
                        break;

                    case emTConecc.tc_SQLite:
                        _Cnn = null;
                        break;

                    case emTConecc.tc_OLDB:
                        _Cnn = new OleDbConnection(nCadenaConex);
                        break;

                    case emTConecc.tc_ODBC:
                        _Cnn = new OdbcConnection(nCadenaConex);
                        break;

                    case emTConecc.tc_Excel:
                        _Cnn = null;
                        break;

                    case emTConecc.tc_Texto:
                        _Cnn = null;
                        break;

                    default:
                        _Cnn = null;
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                _Cnn = null;
            }
        }

        #endregion CONECCION

        #region INGRESO CAMPOS Y SUS VALORES

        public void CampoBD(string nCampo, object valor, emTipoDatoSQL tipoDato = emTipoDatoSQL.tdTexto)
        {
            if (nCampo != "")
            {
                _Campo.Add(nCampo);
                _Valor.Add(tdValor((string)valor, tipoDato));
            }
        }

        #endregion INGRESO CAMPOS Y SUS VALORES

        /////////    C R U D  { CREAR, LEER, ACTUALIZAR, BORRAR }   /////////

        #region C R E A R

        public void Crear(string nTabla,
                          string nBaseDatos = "",
                          string Pwd = "",
                          string Servidor = "",
                          string UserId = "",
                          emTConecc TipoConeccion = emTConecc.tc_MySQL)
        {
            //'INSERT INTO Tabla (campo1, campo2, .., campoN) VALUES (valor1, valor2, ..., valorN)
            if (nBaseDatos != "" & Servidor != "" & UserId != "")
            {
                ConeccionBD(nBaseDatos, Pwd, Servidor, UserId, TipoConeccion);
            }
            else if (nBaseDatos != "" & Servidor == "" & UserId == "")
            {
                ConeccionBD(nBaseDatos, TipoConeccion);
            }

            string myTxtSQL, campos = "", valores = "";
            for (int i = 0; i < _Campo.Count; i++)
            {
                campos = campos + ((campos == "") ? "" : ", ") + _Campo[i];
                valores = valores + ((valores == "") ? "" : ", ") + _Valor[i];
            }

            myTxtSQL = "INSERT INTO " + nTabla + " (" + campos + ") VALUES (" + valores + ")";

            EjecutarSQL(myTxtSQL, _tConec);
        }

        #endregion C R E A R

        public object Leer()
        {
            return null;
        }

        #region A C T U A L I Z A R

        public void Actualizar(string nTabla,
                               string nCampoKey,
                               emSelectorSQL selector = emSelectorSQL.Es_Igual_a,
                               object valorKey = null,
                               emTipoDatoSQL tdKey = emTipoDatoSQL.tdTexto,
                               string nBaseDatos = "",
                               string Pwd = "",
                               string Servidor = "",
                               string UserId = "",
                               emTConecc TipoConeccion = emTConecc.tc_MySQL)
        {
            //'UPDATE Tabla SET Campo1=Valor1, Campo2=Valor2, ... CampoN=ValorN WHERE Criterio;
            if (nBaseDatos != "" & Servidor != "" & UserId != "")
            {
                ConeccionBD(nBaseDatos, Pwd, Servidor, UserId, TipoConeccion);
            }
            else if (nBaseDatos != "" & Servidor == "" & UserId == "")
            {
                ConeccionBD(nBaseDatos, TipoConeccion);
            }
            string myTxtSQL, campo = "";
            for (int i = 0; i < _Campo.Count; i++)
            {
                campo = campo + ((campo == "") ? "" : ", ") + _Campo[i] + " = " + _Valor[i];
            }
            myTxtSQL = "UPDATE " + nTabla + " SET " + campo + ClausulaSQL(nCampoKey, selector, tdValor(valorKey, tdKey));
            MessageBox.Show(myTxtSQL);
            EjecutarSQL(myTxtSQL, _tConec);
        }

        #endregion A C T U A L I Z A R

        #region E L I M I N A R

        public void Eliminar(string nTabla,
                            string nCampoKey,
                            emSelectorSQL selector = emSelectorSQL.Es_Igual_a,
                            object valorKey = null,
                            emTipoDatoSQL tdKey = emTipoDatoSQL.tdTexto,
                            string nBaseDatos = "",
                            string Pwd = "",
                            string Servidor = "",
                            string UserId = "",
                            emTConecc TipoConeccion = emTConecc.tc_MySQL)
        {
            //'DELETE FROM Tabla WHERE criterio
            if (nBaseDatos != "" & Servidor != "" & UserId != "")
            {
                ConeccionBD(nBaseDatos, Pwd, Servidor, UserId, TipoConeccion);
            }
            else if (nBaseDatos != "" & Servidor == "" & UserId == "")
            {
                ConeccionBD(nBaseDatos, TipoConeccion);
            }
            string myTxtSQL;
            myTxtSQL = "DELETE FROM " + nTabla + " WHERE " + ClausulaSQL(nCampoKey, selector, tdValor(valorKey, tdKey));
            EjecutarSQL(myTxtSQL, _tConec);
        }

        #endregion E L I M I N A R

        #region FUNCIONES MIEMBRO PRIVADAS

        //Funcion para ingreso de Valores y campos multiples
        private string tdValor(object Valor, emTipoDatoSQL TD)
        {
            string myTD;
            switch (TD)
            {
                case emTipoDatoSQL.tdTexto:
                    myTD = "'" + Valor + "'";
                    break;

                case emTipoDatoSQL.tdFecha_aa_mm_dd:
                    myTD = "#" + Valor + "#";
                    break;

                case emTipoDatoSQL.tdEntero:
                case emTipoDatoSQL.tdCriterio1:
                case emTipoDatoSQL.tdDecimal:
                default:
                    myTD = (string)Valor;
                    break;
            }
            return myTD;
        }

        private string ClausulaSQL(string Criterio, emSelectorSQL SelectorSQL, string Valor)
        {
            string mySel;

            switch (SelectorSQL)
            {
                //(`codigo` = '1')
                case emSelectorSQL.Ninguno: //0
                    mySel = Criterio;
                    break;

                case emSelectorSQL.Y: // 1
                    mySel = "((`" + Criterio + "`) AND (" + Valor + "))";
                    break;

                case emSelectorSQL.O: // 2
                    mySel = "((" + Criterio + ") OR (" + Valor + "))";
                    break;

                case emSelectorSQL.Es_Igual_a: //3
                    mySel = Criterio + " = '" + Valor + "'";
                    break;

                case emSelectorSQL.No_Igual_a:  //4
                    mySel = "NOT ( " + Criterio + " = '" + Valor + "')";
                    break;

                case emSelectorSQL.Contiene: //5
                    mySel = Criterio + " LIKE '*" + Valor + "*'";
                    break;

                case emSelectorSQL.No_Contiene: //6
                    mySel = Criterio + " NOT (LIKE '*" + Valor + "*')";
                    break;

                case emSelectorSQL.Mayor_Que: //7
                    mySel = Criterio + " > " + Valor;
                    break;

                case emSelectorSQL.Menor_Que: //8
                    mySel = Criterio + " < " + Valor;
                    break;

                case emSelectorSQL.Mayor_Igual_Que: //9
                    mySel = Criterio + " >= " + Valor;
                    break;

                case emSelectorSQL.Menor_Igual_Que: //10
                    mySel = Criterio + " <= " + Valor;
                    break;

                case emSelectorSQL.Comienza_Por: // 11
                    mySel = Criterio + " LIKE '" + Valor + "*'";
                    break;

                case emSelectorSQL.No_Comienza_Por: //12
                    mySel = Criterio + "NOT (LIKE '" + Valor + "*')";
                    break;

                case emSelectorSQL.Termina_Por: //13
                    mySel = Criterio + "LIKE '*" + Valor + "'";
                    break;

                case emSelectorSQL.No_Termina_Por: //14
                    mySel = Criterio + "NOT (LIKE '*" + Valor + "')";
                    break;

                default:
                    mySel = "";
                    break;
            }

            return mySel == "" ? mySel : " WHERE " + mySel;
        }

        private void EjecutarSQL(string txtSQL, emTConecc TConecc)
        {
            switch (TConecc)
            {
                case emTConecc.tc_MySQL:
                    MySqlConnection cnMySql = _Cnn as MySqlConnection;
                    cnMySql.Open();
                    try
                    {
                        MySqlCommand cmMySql = new MySqlCommand(txtSQL, cnMySql);
                        cmMySql.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        cnMySql.Close();
                        MessageBox.Show("finality");
                    }
                    break;

                case emTConecc.tc_SQL:
                    //    SqlConnection cnSql = _Cnn as SqlConnection;
                    //    cnSql.Open();
                    //    try
                    //    {
                    //        SqlCommand cmSql = new SqlCommand(txtSQL, cnSql);
                    //        cmSql.ExecuteNonQuery();
                    //    }
                    //    catch (SqlException ex)
                    //    {
                    //        MessageBox.Show("Error: " + ex.Message);
                    //    }
                    //    finally
                    //    {
                    //        cnSql.Close();
                    //    }
                    break;
            }
            _Campo.Clear();
            _Valor.Clear();
        }

        #endregion FUNCIONES MIEMBRO PRIVADAS
    }
}

// 'Comandos DLL
//'CREATE  Utilizado para crear nuevas tablas, campos e Ã­ndices
//'DROP    Empleado para eliminar tablas e Ã­ndices
//'ALTER   Utilizado para modificar las tablas agregando campos o cambiando la definiciÃ³n de los campos.

//'Comandos DML
//'SELECT campos FROM tabla WHERE criterio GROUP BY campos del grupo

//'DROP TABLE `sgcmdb`.`user`;

/*
private void btnBuscar_Click(object sender, EventArgs e)
{
    String codigo = txtCodigo.Text;
    MySqlDataReader reader = null;

    string sql = "SELECT id, codigo, nombre, descripcion, precio_publico, existencias FROM productos WHERE codigo LIKE '" + codigo + "' LIMIT 1";
    MySqlConnection conexionBD = Conexion.conexion();
    conexionBD.Open();

    try
    {
        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
        reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                txtId.Text = reader.GetString(0);
                txtCodigo.Text = reader.GetString(1);
                txtNombre.Text = reader.GetString(2);
                txtDescripcion.Text = reader.GetString(3);
                txtPrecioPublico.Text = reader.GetString(4);
                txtExistencias.Text = reader.GetString(5);
            }
        }
        else
        {
            MessageBox.Show("No se encontraron registros");
        }
    }
    catch (MySqlException ex)
    {
        MessageBox.Show("Error al buscar " + ex.Message);
    }
    finally
    {
        conexionBD.Close();
    }
}

private void btnEliminar_Click(object sender, EventArgs e)
{
    String id = txtId.Text;

    string sql = "DELETE FROM productos WHERE id='" + id + "'";

    MySqlConnection conexionBD = Conexion.conexion();
    conexionBD.Open();

    try
    {
        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
        comando.ExecuteNonQuery();
        MessageBox.Show("Registro eliminado");
        limpiar();
    }
    catch (MySqlException ex)
    {
        MessageBox.Show("Error al eliminar: " + ex.Message);
    }
    finally
    {
        conexionBD.Close();
    }
}

*/

//Funciones para manejo de lenguaje SQL

/*
        private string fPredicadoSQL(emPredicadoSQL TPred)
        {
            /*
            ALL         Devuelve todos los campos de la tabla
            TOP         Devuelve un determinado número de registros de la tabla
            DISTINCT    Omite los registros cuyos campos seleccionados coincidan totalmente
            DISTINCTROW Omite los registros duplicados basandose en la totalidad del registro y no sólo en los campos seleccionados.
            */
/* string myTPred;

 switch (TPred)
 {
     case emPredicadoSQL.TODO:
         myTPred = " ";
         break;

     case emPredicadoSQL.LOS_PRIMEROS_10:
         myTPred = " TOP 10 ";
         break;

     case emPredicadoSQL.DISTINTOS:
         myTPred = " DISTINCT ";
         break;

     case emPredicadoSQL.SIN_DUPLICADOS:
         myTPred = " DISTINCTROW ";
         break;

     default:
         myTPred = " ";
         break;
 }
 return myTPred;
}

private string fOperadorSQL(emOperadorSQL Operador, string Campo)
{
 string myOP;
 switch (Operador)
 {
     case emOperadorSQL.SUMA:
         myOP = "Sum(" + Campo + ") AS " + Campo;
         break;

     case emOperadorSQL.CUENTA:
         myOP = "Count(" + Campo + ") AS " + Campo;
         break;

     case emOperadorSQL.MAXIMO:
         myOP = "Max(" + Campo + ") AS " + Campo;
         break;

     case emOperadorSQL.MINIMO:
         myOP = "Min(" + Campo + ") AS " + Campo;
         break;

     case emOperadorSQL.PROMEDIO:
         myOP = "Avg(" + Campo + ") AS " + Campo;
         break;

     case emOperadorSQL.RESTA:
     case emOperadorSQL.DIVISION:
     case emOperadorSQL.MULTIPLICACION:
     default:
         myOP = Campo;
         break;
 }

 return myOP;
}

/*
public bool Buscar(string nValorBuscado,
                string nTabla,
                string nCampo,
                emSelectorSQL nSelector = emSelectorSQL.Es_Igual_a,
                string nBD = "",
                emTConecc nTCn = emTConecc.tc_ODBC)
{
 string myTextoSQL;
 string myDato;
 if (nBD != "") { ConeccionBD(nBD, nTCn); }
 myTextoSQL = fConsultaSQL(emComandoSQL.SELECCION, nCampo, nTabla, nCampo, nValorBuscado, nSelector);
 myDato = EjecutarSQL(myTextoSQL, nCampo, nTCn);
 return (myDato == "") ? true : false;
}

public string Leer(string nTextoSQL,
        string nCampo = "",
        string nBD = "",
        emTConecc nTCn = emTConecc.tc_ODBC)
{
 string myConsSQL;
 if (nCampo != "")
 {
     myConsSQL = EjecutarSQL(nTextoSQL, nCampo, nTCn);
     return myConsSQL;
 }
 else
 {
     EjecutarSQL(nTextoSQL, nTCn);
     return "";
 }
}

public string Leer(string nTabla,
                string nCampo,
                string nCriterio,
                emSelectorSQL nSelector = emSelectorSQL.Es_Igual_a,
                string nValorC = "",
                string nBD = "",
                emTConecc nTCn = emTConecc.tc_ODBC,
                emPredicadoSQL nPre = emPredicadoSQL.TODO,
                emOperadorSQL nOpe = emOperadorSQL.NINGUNO)
{
 string myTextoSQL;
 string myConsSQL;

 if (nBD != "") { ConeccionBD(nBD, nTCn); }
 myTextoSQL = fConsultaSQL(emComandoSQL.SELECCION, nCampo, nTabla, nCriterio, nValorC, nSelector, nPre, nOpe);
 myConsSQL = EjecutarSQL(myTextoSQL, nCampo, nTCn);
 return myConsSQL;
}

public void Editar(string nCampo = "",
                 string nValor = "",
                 string nTabla = "",
                 string nCriterio = "",
                 string nValorC = "",
                 string nBD = "",
                 emSelectorSQL Selector = emSelectorSQL.Es_Igual_a,
                 emTConecc nTCn = emTConecc.Tc_OLDB,
                 emTipoDato nTDV = emTipoDato.tdTexto)
{
 string myTextoSQL;

 if (nCampo != "")
 {
     mCampos.Add(nCampo);
     mValores.Add(tdValor(nValor, nTDV));
 }
 if (nBD != "") { ConeccionBD(nBD, nTCn); }
 if (nTabla != "" & nCriterio == "" & nValorC == "")
 {
     myTextoSQL = fConsultaSQL(emComandoSQL.INSERTAR, nCampo, nTabla);
 }
 else if (nTabla != "" & nCriterio != "" & nValorC != "")
 {
     myTextoSQL = fConsultaSQL(emComandoSQL.ACTUALIZAR, nCampo, nTabla, nCriterio, nValorC, Selector);
 }
}

public void Eliminar(string nTabla,
                    string nCriterio,
                    emSelectorSQL Selector = emSelectorSQL.Es_Igual_a,
                    string nValorC = "",
                    string nBD = "",
                    emTConecc nTCn = emTConecc.Tc_OLDB)
{
 string myTextoSQL;

 myTextoSQL = fConsultaSQL(emComandoSQL.BORRAR, nTabla: nTabla, Criterio: nCriterio, ValorC: nValorC, SelectorSQL: Selector);
 EjecutarSQL(myTextoSQL, nTCn);
}

//funcion para ejecutar consultas que devuelven valores simples
private void EjecutarSQL(string txtSQL, emTConecc TConecc)
{
 try
 {
     OleDbDataReader myDR;
     OleDbCommand myCmm = new OleDbCommand(txtSQL, cnnOLDB);

     cnnOLDB.Open();
     myDR = myCmm.ExecuteReader();
     cnnOLDB.Close();
 }
 catch (Exception)
 {
 }
}

*/