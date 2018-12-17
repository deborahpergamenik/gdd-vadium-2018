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

namespace PalcoNet.Abm_Rol
{
    public partial class frmAsignarRolesUsuario : Form
    {
        public frmAsignarRolesUsuario()
        {
            InitializeComponent();
            this.cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            dgvUsuarios.DataSource = Usuario.obtenerUsuarios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsuarios.CurrentRow;

                int idUser = Convert.ToInt32(row.Cells[0].Value);
                string username = Convert.ToString(row.Cells[1].Value);

                frmRolesUsuarioDialog rolesUsuarioDlg = new frmRolesUsuarioDialog(idUser, username);

                rolesUsuarioDlg.ShowDialog();
            }
        }

        private void frmAsignarRolesUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
