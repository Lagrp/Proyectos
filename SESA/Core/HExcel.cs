using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SESA
{
    public enum emHExUSelector
    { Igual_a, Contiene, No_Contiene, Empieza_Por, Terminar_por };

    public enum emHExCoorCel
    { nfila, nColum };

    public class exlCelda
    {
        private string _Nombre;
        private object _Valor;
        private double _Columna;
        private double _Fila;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public object Valor { get => _Valor; set => _Valor = value; }
        public double Columna { get => _Columna; set => _Columna = value; }
        public double Fila { get => _Fila; set => _Fila = value; }

        public exlCelda(string nombre = "", object valor = null, double columna = 0, double fila = 0)
        {
            _Nombre = nombre;
            _Valor = valor;
            _Columna = columna;
            _Fila = fila;
        }

        public exlCelda()
        {
        }
    }

    internal class HExcel
    {
        private List<exlCelda> _Celda = new List<exlCelda>();

        public void GrabarExl(string nCampo = "", object valor = null)
        {
            if (nCampo != "")
            {
                exlCelda celda = new exlCelda { Nombre = nCampo, Valor = valor, Columna = 0, Fila = 0 };
                _Celda.Add(celda);
            }
        }

        public void GrabarExl(Worksheet nHoja, string CampoId = "", string ValorID = "")
        {
            if (_Celda.Count > 0)
            {
                if (nHoja != null & CampoId != "" && ValorID != "")
                {
                    double cID = UbicarExl(nHoja, CampoId, OrdenBusqueda: XlSearchOrder.xlByColumns).Columna;
                    double nF;
                    if (cID > 0)
                    {
                        double fID = UbicarExl(nHoja, ValorID, porColumna: cID).Fila;
                        nF = fID > 0 ? fID : nHoja.Range[nCol(cID) + nHoja.Rows.Count].End[XlDirection.xlUp].Row + 1;

                        for (int i = 0; i < _Celda.Count; i++)
                        {
                            double nC = UbicarExl(nHoja, _Celda[i].Nombre.ToString(), OrdenBusqueda: XlSearchOrder.xlByColumns).Columna;
                            if (cID == 0)
                            {
                                MessageBox.Show("No existe el campoId");
                                return;
                            }
                            else
                            {
                                nHoja.Cells[nF, nC].Value = _Celda[i].Valor.ToString();
                            }
                        }
                        Globals.ThisWorkbook.Save();
                        _Celda.Clear();
                    }
                    else
                    {
                        MessageBox.Show("el campoID no existe");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha ingresado los campos o valores");
                }
            }
            else
            {
                MessageBox.Show("No hay datos para gravar");
            }
        }

        public exlCelda LeerCeldaExl(Worksheet nHoja, string nCampo, string valorID)
        {
            exlCelda celda = new exlCelda();
            //double nC = UbicarExl(nHoja, nCampo).Columna;
            //if (nC > 0)
            //{
            //    double nf = UbicarExl(nHoja, valorID, porColumna: nC, OrdenBusqueda: XlSearchOrder.xlByColumns).Fila;
            //    if (nf > 0)
            //    {
            //        celda.Nombre = nHoja.Cells[nf, nC].value();
            //        celda.Valor = nHoja.Cells[nf + 1, nC].value();
            //        celda.Columna = nHoja.Cells[nf + 1, nC].Column();
            //        celda.Fila = nHoja.Cells[nf + 1, nC].Row();
            //    }
            //    else
            //    {
            //        celda.Nombre = null;
            //        celda.Valor = null;
            //        celda.Columna = 0;
            //        celda.Fila = 0;
            //    }
            //}
            return celda;
        }

        public List<exlCelda> LeerFilaExl(Worksheet nHoja, string nCampo, string ValorID)
        {
            exlCelda celdaID = UbicarExl(nHoja, nCampo);
            double cID = celdaID.Columna;
            if (cID > 0)
            {
                double fID = UbicarExl(nHoja, ValorID, porColumna: cID).Fila;
                if (fID > 0)
                {
                    do
                    {
                        exlCelda celda = new exlCelda(nHoja.Cells[celdaID.Fila, cID].Value, nHoja.Cells[fID, cID].Value, cID, fID);
                        _Celda.Add(celda);
                        cID++;
                    } while (!String.IsNullOrEmpty(nHoja.Cells[fID, cID].Value));
                    return _Celda;
                }
                else
                {
                    MessageBox.Show("ValorID no existe", "HExcel.LeerFilaExl");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("nCampo no existe", "HExcel.LeerFilaExl");
                return null;
            }
        }

        public exlCelda UbicarExl(Worksheet nHoja,
                              string criterio = "",
                              emHExUSelector selector = emHExUSelector.Igual_a,
                              double porFila = 1,
                              double porColumna = 1,
                              XlFindLookIn BuscarEn = XlFindLookIn.xlValues,
                              XlLookAt MirarEn = XlLookAt.xlWhole,
                              XlSearchOrder OrdenBusqueda = XlSearchOrder.xlByRows,
                              XlSearchDirection DireccionBusqueda = XlSearchDirection.xlNext,
                              bool MatchCase = false,
                              bool MatchByte = false,
                              bool BuscarFormato = false)
        {
            Range vBusq;
            string mCriterio;
            exlCelda celda = new exlCelda();

            switch (selector)
            {
                case emHExUSelector.Contiene: mCriterio = $"*{criterio}*"; break;
                case emHExUSelector.No_Contiene: mCriterio = $"NOT [{criterio}*]"; break;
                case emHExUSelector.Empieza_Por: mCriterio = $"{ criterio}*"; break;
                case emHExUSelector.Terminar_por: mCriterio = $"*{criterio}"; break;
                default: mCriterio = criterio; break;
            }

            try
            {
                vBusq = nHoja.Cells.Find(mCriterio, nHoja.Cells[porFila, porColumna], BuscarEn, MirarEn, OrdenBusqueda, DireccionBusqueda, MatchCase, MatchByte, BuscarFormato);
                celda.Valor = vBusq.Value;
                celda.Columna = vBusq.Column;
                celda.Fila = vBusq.Row;
                celda.Nombre = nCol(celda.Columna);
            }
            catch
            {
                celda.Nombre = null;
                celda.Valor = null;
                celda.Columna = 0;
                celda.Fila = 0;
            }
            return celda;
        }

        public string nCol(double idColum)
        {
            int i = 0, x = 0, y = 0, z = 0;
            string ncol1, ncol2, ncol3;

            for (i = 1; i <= idColum; i++)
            {
                x++;
                if (x > 26)
                {
                    x = 1;
                    y++;
                    if (y > 26)
                    {
                        y = 1;
                        z++;
                    }
                }
            }
            ncol1 = z > 0 ? Convert.ToChar(z + 64).ToString() : "";
            ncol2 = y > 0 ? Convert.ToChar(y + 64).ToString() : "";
            ncol3 = x > 0 ? Convert.ToChar(x + 64).ToString() : "";

            return ncol1 + ncol2 + ncol3;
        }

        public void CopiarHoja()
        {
        }

        ~HExcel()
        {
            _Celda.Clear();
            _Celda = null;
        }
    }
}