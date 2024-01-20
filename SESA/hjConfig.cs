using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using SESA.Vistas;

namespace SESA
{
    public partial class Configuracion
    {
        private void Hoja1_Startup(object sender, System.EventArgs e)
        {
        }

        private void Hoja1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Código generado por el Diseñador de VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Startup += new System.EventHandler(this.Hoja1_Startup);
            this.Shutdown += new System.EventHandler(this.Hoja1_Shutdown);

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            frmLoguin loguin = new frmLoguin();
            loguin.ShowDialog();
        }
    }
}
