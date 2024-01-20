using SESA.Vistas;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SESA
{
    public partial class ThisWorkbook
    {
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            HExcel he = new HExcel();
            exlCelda cU = new exlCelda();

            Excel.Worksheet h = Globals.ThisWorkbook.Worksheets["Config"];
            cU = he.UbicarExl(h, "UsuariosSistema");
            int nu = h.Range[he.nCol(cU.Columna) + h.Rows.Count].End[Excel.XlDirection.xlUp].Row;
            nu = nu - (int)cU.Fila;
            if (nu < 2)
            {
                frmRegistro fl = new frmRegistro();
                fl.ShowDialog();
            }
            else
            {
                frmLoguin fr = new frmLoguin();
                fr.ShowDialog();
            }
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
            Application.Quit();
        }

        #region Código generado por el Diseñador de VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion Código generado por el Diseñador de VSTO
    }
}