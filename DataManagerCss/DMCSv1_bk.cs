using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;




namespace DMCS   
{
    public class DM
    {
        //ENUMERACIONES DE SELECCION PUBLICAS
        public enum emTConecc { tc_OLDB, tc_ODBC, tc_SQL, tc_MySQL, tc_Excel };
        public enum emTipoDato { tdTexto, tdNumerico, tdFecha_mm_dd_aa, tdCriterio1 };
        public enum emOperadorSQL { ninguno, Suma, Resta, Multiplicacion, Division, Promedio, Cuenta, Minimo, Maximo };
        public enum emOrdenSQL { Asendente, Desendente, Ningun_Orden };
        public enum emSelector
        {
            Ninguno, //0
            y, //1
            o, //2
            Es_Igual_a, //3
            No_Igual_a, //4
            Contiene, //5
            No_Contiene, //6
            Mayor_Que, //7
            Menor_Que, //8
            Mayor_Igual_Que, //9
            Menor_Igual_Que, //10
            Comienza_Por, //11
            No_Comienza_Por,//12
            Termina_Por, //13
            No_Termina_Por //14
        };
        public enum emComandoSQL { SELECCION, INSERTAR, ACTUALIZAR, BORRAR }
        public enum emPredicadoSQL { TODO, LOS_PRIMEROS_10, DISTINTOS, SIN_DUPLICADOS }

        //VARIABLES MIEMBRO PUBLICAS


        //VARIABLES MIEMBRO PRIVADAS
        private OleDbConnection cnnOLDB;
        private MySqlConnection cnnMySQL;

        
        private ArrayList mCampos = new ArrayList();
        private ArrayList mValores = new ArrayList();

        //PROPIEDADES MIEMBRO

        //FUNCIONES MIEMBRO PUBLICAS

        public DM() //Constructor
        {

        }

        public void ConeccionBD(string NombreBaseDatos, emTConecc TipoConeccion = emTConecc.tc_OLDB)
        {
            switch (TipoConeccion)
            {
                case emTConecc.tc_OLDB:
                    cnnOLDB = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + NombreBaseDatos);
                    break;
                case emTConecc.tc_ODBC:

                    break;
                case emTConecc.tc_SQL:
                    break;
                case emTConecc.tc_MySQL:
                    cnnMySQL = new MySqlConnection();
                    break;

                case emTConecc.tc_Excel:


                    break;

                default:
                    break;
            }
        }

        public bool Buscar(string nValorBuscado,
                           string nTabla,
                           string nCampo,
                           emSelector nSelector = emSelector.Es_Igual_a,
                           string nBD = "",
                           emTConecc nTCn = emTConecc.tc_OLDB)
        {
            string myTextoSQL;
            string myDato;
            if (nBD != "") { ConeccionBD(nBD, nTCn); }
            myTextoSQL = ConsultaSql(emComandoSQL.SELECCION, nCampo, nTabla, nCampo, nValorBuscado, nSelector);
            myDato = EjecutarSQL(myTextoSQL, nCampo, nTCn);
            return (myDato == "") ? true : false;
        }

        public string Leer(string nTextoSQL,
                   string nCampo="",
                   string nBD = "",
                   emTConecc nTCn = emTConecc.tc_OLDB)
        {
            string myConsSQL;
            if (nCampo !="")
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
                           emSelector nSelector = emSelector.Es_Igual_a,
                           string nValorC = "",
                           string nBD = "",
                           emTConecc nTCn = emTConecc.tc_OLDB,
                           emPredicadoSQL nPre = emPredicadoSQL.TODO,
                           emOperadorSQL nOpe = emOperadorSQL.ninguno)
        {
            string myTextoSQL;
            string myConsSQL;

            if (nBD != "") { ConeccionBD(nBD, nTCn); }
            myTextoSQL = ConsultaSql(emComandoSQL.SELECCION, nCampo, nTabla, nCriterio, nValorC, nSelector, nPre, nOpe);
            myConsSQL = EjecutarSQL(myTextoSQL, nCampo, nTCn);
            return myConsSQL;
        }

        public void Editar(string nCampo = "",
                            string nValor = "",
                            string nTabla = "",
                            string nCriterio = "",
                            string nValorC = "",
                            string nBD = "",
                            emSelector Selector = emSelector.Es_Igual_a,
                            emTConecc nTCn = emTConecc.tc_OLDB,
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
                myTextoSQL = ConsultaSql(emComandoSQL.INSERTAR, nCampo, nTabla);
            }
            else if (nTabla != "" & nCriterio != "" & nValorC != "")
            {
                myTextoSQL = ConsultaSql(emComandoSQL.ACTUALIZAR, nCampo, nTabla, nCriterio, nValorC, Selector);
            }
        }

        public void Eliminar(string nTabla,
                               string nCriterio,
                               emSelector Selector = emSelector.Es_Igual_a,
                               string nValorC = "",
                               string nBD = "",
                               emTConecc nTCn = emTConecc.tc_OLDB)
        {
            string myTextoSQL;

            myTextoSQL = ConsultaSql(emComandoSQL.BORRAR, Tabla: nTabla, Criterio: nCriterio, ValorC: nValorC, SelectorSQL: Selector);
            EjecutarSQL(myTextoSQL,nTCn);
        }

        //FUNCIONES MIEMBRO PRIVADAS
        //Funciones para manejo de lenguaje SQL
        /* 
        Comandos DLL
        CREATE  Utilizado para crear nuevas tablas, campos e índices
        DROP    Empleado para eliminar tablas e índices
        ALTER   Utilizado para modificar las tablas agregando campos o cambiando la definición de los campos.

        Comandos DML
        SELECT  Utilizado para consultar registros de la base de datos que satisfagan un criterio determinado
        INSERT  Utilizado para cargar lotes de datos en la base de datos en una única operación.
        UPDATE  Utilizado para modificar los valores de los campos y registros especificados
        DELETE  Utilizado para eliminar registros de una tabla de una base de datos
        */

        private string ConsultaSql(emComandoSQL cmmSQL,
                                    string Campo="",
                                    string Tabla="",
                                    string Criterio="",
                                    string ValorC="",
                                    emSelector SelectorSQL=emSelector.Es_Igual_a,
                                    emPredicadoSQL TPred=emPredicadoSQL.TODO,
                                    emOperadorSQL Operador=emOperadorSQL.ninguno)
        {
            string myCmmSQL;
            string lCampo = "";
            string lValor = "";

            switch (cmmSQL)
            {
                case emComandoSQL.SELECCION:
                    myCmmSQL = "SELECT" + PredicadoSQL(TPred) + FuncionAgSQL(Operador, Campo) + " FROM " + Tabla + " " + ClausulaSQL(Criterio, SelectorSQL, ValorC); 
                    break;
                case emComandoSQL.INSERTAR:
                    for (int i = 0; i < mCampos.Count; i++)
                    {
                        lCampo = lCampo + ((lCampo == "")?"":", ") + mCampos[i]; 
                        lValor = lValor + ((lValor == "")?"": ", ") + mValores[i];
                    }
                    myCmmSQL = "INSERT INTO " + Tabla + " (" + lCampo + ") VALUES (" + lValor + ")";
                    break;
                case emComandoSQL.ACTUALIZAR:
                    for (int i = 0; i < mCampos.Count; i++)
                    {
                        lCampo = lCampo + ((lCampo == "") ? "" : ", ") + mCampos[i] + " = " + mValores[i];
                    }
                    myCmmSQL = "UPDATE " + Tabla + " SET " + lCampo + ClausulaSQL(Criterio, SelectorSQL, ValorC);
                    break;
                case emComandoSQL.BORRAR:
                    myCmmSQL = "DELETE *.* FROM " + Tabla + ClausulaSQL(Criterio, SelectorSQL, ValorC);
                    break;
                default:
                    myCmmSQL = "";
                    break;
            }
            mCampos.Clear();
            mCampos.TrimToSize();
            mValores.Clear();
            mValores.TrimToSize();
            return myCmmSQL;
        }

        private string PredicadoSQL(emPredicadoSQL TPred)
        {
            /*
            ALL         Devuelve todos los campos de la tabla
            TOP         Devuelve un determinado número de registros de la tabla
            DISTINCT    Omite los registros cuyos campos seleccionados coincidan totalmente
            DISTINCTROW Omite los registros duplicados basandose en la totalidad del registro y no sólo en los campos seleccionados.
            */
            string myTPred;

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
        private string ClausulaSQL(string Criterio, emSelector SelectorSQL, string Valor)
        {
            string mySel;

            switch (SelectorSQL)
            {
                case emSelector.Ninguno: //0 
                    mySel = Criterio;
                    break;
                case emSelector.y: // 1 
                    mySel = "((" + Criterio + ") AND (" + Valor + "))";
                    break;
                case emSelector.o: // 2 
                    mySel = "((" + Criterio + ") OR (" + Valor + "))";
                    break;
                case emSelector.Es_Igual_a: //3 
                    mySel = Criterio + " = '" + Valor + "'";
                    break;
                case emSelector.No_Igual_a:  //4 
                    mySel = "NOT ( " + Criterio + " = '" + Valor + "')";
                    break;
                case emSelector.Contiene: //5 
                    mySel = Criterio + " LIKE '*" + Valor + "*'";
                    break;
                case emSelector.No_Contiene: //6
                    mySel = Criterio + " NOT (LIKE '*" + Valor + "*')";
                    break;
                case emSelector.Mayor_Que: //7 
                    mySel = Criterio + " > " + Valor;
                    break;
                case emSelector.Menor_Que: //8 
                    mySel = Criterio + " < " + Valor;
                    break;
                case emSelector.Mayor_Igual_Que: //9 
                    mySel = Criterio + " >= " + Valor;
                    break;
                case emSelector.Menor_Igual_Que: //10 
                    mySel = Criterio + " <= " + Valor;
                    break;
                case emSelector.Comienza_Por: // 11 
                    mySel = Criterio + " LIKE '" + Valor + "*'";
                    break;
                case emSelector.No_Comienza_Por: //12
                    mySel = Criterio + "NOT (LIKE '" + Valor + "*')";
                    break;
                case emSelector.Termina_Por: //13
                    mySel = Criterio + "LIKE '*" + Valor + "'";
                    break;
                case emSelector.No_Termina_Por: //14
                    mySel = Criterio + "NOT (LIKE '*" + Valor + "')";
                    break;
                default:
                    mySel = "";
                    break;
            }

            if (mySel == "") return mySel; else return " WHERE " + mySel;
        }
        private string FuncionAgSQL(emOperadorSQL Operador, string Campo)
        {
            string myOP;
            switch (Operador)
            {
                case emOperadorSQL.Suma:
                    myOP = "Sum(" + Campo + ") AS " + Campo;
                    break;
                case emOperadorSQL.Cuenta:
                    myOP = "Count(" + Campo + ") AS " + Campo;
                    break;
                case emOperadorSQL.Maximo:
                    myOP = "Max(" + Campo + ") AS " + Campo;
                    break;
                case emOperadorSQL.Minimo:
                    myOP = "Min(" + Campo + ") AS " + Campo;
                    break;
                case emOperadorSQL.Promedio:
                    myOP = "Avg(" + Campo + ") AS " + Campo;
                    break;
                case emOperadorSQL.Resta:
                case emOperadorSQL.Division:
                case emOperadorSQL.Multiplicacion:
                default:
                    myOP = Campo;
                    break;
            }

            return myOP;
        }

        //Funcion para ingreso de Valores y campos multiples
        private string tdValor(string Valor, emTipoDato TD)
        {
            string myTD;
            switch (TD)
            {
                case emTipoDato.tdTexto:
                    myTD = "'" + Valor + "'";
                    break;
                case emTipoDato.tdFecha_mm_dd_aa:
                    myTD = "#" + Valor + "#";
                    break;
                case emTipoDato.tdNumerico:
                case emTipoDato.tdCriterio1:
                default:
                    myTD = Valor;
                    break;
            }
            return myTD;
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

        private string EjecutarSQL(string txtSQL, string nCampo, emTConecc TConecc)
        {
            string myResSQL;

            try
            {
                OleDbDataReader myDR;
                OleDbCommand myCmm = new OleDbCommand(txtSQL, cnnOLDB);

                cnnOLDB.Open();
                myDR = myCmm.ExecuteReader();
                myDR.Read();
                myResSQL = myDR[nCampo].ToString();
                cnnOLDB.Close();
            }
            catch (Exception)
            {
                myResSQL = "";
            }
            return myResSQL;
        }

        ~DM() //Destructor
        {

        }

    }
}
