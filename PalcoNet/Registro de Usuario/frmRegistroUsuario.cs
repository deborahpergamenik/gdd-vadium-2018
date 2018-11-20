using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class frmRegistroUsuario : Form
    {

        public frmLogin _frmLogin { get; set; }

        public frmRegistroUsuario(frmLogin frmLogin)
        {
            this._frmLogin = frmLogin;
            InitializeComponent();
            cmbRol.Items.Add("Cliente");
            cmbRol.Items.Add("Empresa");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            _frmLogin.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreUsuario.Text) && !string.IsNullOrEmpty(txtContrasenia.Text) && cmbRol.SelectedIndex != -1)
            {
                if (!SqlConnector.existeString(txtNombreUsuario.Text, "PalcoNet.Usuario", "NombreUsuario"))
                {
                    if (cmbRol.SelectedIndex == 0)
                    {
                        frmRegistroUsuarioCliente frmAltaCliente = new frmRegistroUsuarioCliente(txtNombreUsuario.Text, txtContrasenia.Text, cmbRol.SelectedIndex);
                        this.Hide();
                        frmAltaCliente.Show();
                    }
                    else
                    {
                        frmRegistroUsuarioEmpresa frmAltaEmpresa = new frmRegistroUsuarioEmpresa(txtNombreUsuario.Text, txtContrasenia.Text, cmbRol.SelectedIndex);
                        this.Hide();
                        frmAltaEmpresa.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario ya existente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar el formulario.", "Error");
            }
        }
    }
}
