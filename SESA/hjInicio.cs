using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SESA
{
    public partial class hjInicio
    {
        private void hjInicio_Startup(object sender, System.EventArgs e)
        {
        }

        private void hjInicio_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Código generado por el Diseñador de VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(hjInicio_Startup);
            this.Shutdown += new System.EventHandler(hjInicio_Shutdown);
        }

        #endregion

    }
}
