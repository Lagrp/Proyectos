using SESA.VistaModelo;
using System;
using System.Windows.Forms;

namespace SESA.Vistas
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loguin usuario = new Loguin
            {
                Usuario = txtUsuario.Text.ToUpper(),
                Password = txtPassword.Text,
                ConPassword = txtConPassword.Text,
                Nombre = txtNombre.Text
            };

            try
            {
                string respuesta = usuario.ctrlRegistro();

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLoguin frmLoguin = new frmLoguin();
                    frmLoguin.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}