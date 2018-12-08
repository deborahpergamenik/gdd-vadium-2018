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

namespace PalcoNet.Abm_Rol
{
    public partial class frmRol : Form
    {

        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmRol(frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            InitializeComponent();
            cargarTodosLosRoles();
        }

        private void cargarTodosLosRoles()
        {
            dgvRoles.DataSource = Roles.obtenerRoles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmEditarRoles editForm = new frmEditarRoles("nuevo");
            editForm.ShowDialog();

            cargarTodosLosRoles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Rol unRol = dgvRoles.CurrentRow.DataBoundItem as Rol;
            frmEditarRoles editForm = new frmEditarRoles("modificar", unRol);
            editForm.ShowDialog();

            cargarTodosLosRoles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Rol unRol = dgvRoles.CurrentRow.DataBoundItem as Rol;
            string str;

            if (!unRol.usuario_activo)
            {
                str = string.Format("No se puede eliminar el rol {0}. Este ya esta deshabilitado. Puede volver a habilitarlo desde Modificar", unRol.nombre);
                MessageBox.Show(str, "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                str = string.Format("Esta seguro que desea eliminar el rol {0}? Esto implica la baja lógica del mismo", unRol.nombre);
                DialogResult result = MessageBox.Show(str, "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Roles.deshabilitarRol(unRol.Id);
                    Roles.eliminarUsuariosPorRol(unRol.Id);
                    cargarTodosLosRoles();
                }
            }
        }

        private void btnAsignarRoles_Click(object sender, EventArgs e)
        {
            frmAsignarRolesUsuario asignarForm = new frmAsignarRolesUsuario();
            asignarForm.ShowDialog();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }
    }
}
