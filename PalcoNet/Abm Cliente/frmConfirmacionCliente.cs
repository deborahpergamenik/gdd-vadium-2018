using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class frmConfirmacionCliente : Form
    {
        public string usuario { get; set; }
        public string password { get; set; }

        public frmConfirmacionCliente(string _usuario, string _password)
        {
            this.usuario = _usuario;
            this.password = _password;

            InitializeComponent();

            txtUsuario.Text = this.usuario;
            txtpassword.Text = this.password;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
