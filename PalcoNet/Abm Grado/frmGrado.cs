using PalcoNet.Common;
using PalcoNet.Login;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class frmGrado : Form
    {
        public frmSeleccionFuncionalidades _frmSeleccionFuncionalidad { get; set; }

        public frmGrado()
        {
            InitializeComponent();
            this.cargarVisibilidades();
            Interfaz.bloquearDataGridView(this.dgvGrados);
        }


        private void cargarVisibilidades()
        {
            this.dgvGrados.DataSource = Grado.ObtenerTodosLosGrados();
            this.dgvGrados.Refresh();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmModificarGrado editForm = new frmModificarGrado(this.btnNuevo, this.dgvGrados);
            editForm.ShowDialog();

            this.cargarVisibilidades();
            this.dgvGrados.Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarGrado editForm = new frmModificarGrado(this.btnModificar, this.dgvGrados);
            editForm.ShowDialog();

            this.cargarVisibilidades();
            this.dgvGrados.Refresh();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
