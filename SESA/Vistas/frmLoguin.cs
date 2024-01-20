using SESA.VistaModelo;
using System;
using System.Windows.Forms;

namespace SESA.Vistas
{
    public partial class frmLoguin : Form
    {
        public frmLoguin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.ToUpper();
            string password = txtPassword.Text;

            try
            {
                Loguin ctrl = new Loguin();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "btnAceptar_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnAceptar_Click_Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistro frm = new frmRegistro();    
            frm.ShowDialog();
            this.Close();

        }
    }
}