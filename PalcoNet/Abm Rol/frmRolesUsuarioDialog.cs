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
    public partial class frmRolesUsuarioDialog : Form
    {
        int idUsuario;
        string usuarioNombre;
        List<Rol> todosLosRoles;
        List<Rol> rolesUsuario;

        public frmRolesUsuarioDialog(int _idUsuario, string _usuarioNombre)
        {
            InitializeComponent();
            idUsuario = _idUsuario;
            usuarioNombre = _usuarioNombre;

            cblRoles.DisplayMember = "rol_nombre";
            cblRoles.ValueMember = "rol_id";

            todosLosRoles = Roles.obtenerRoles();
            rolesUsuario = Roles.obtenerRolesUsuario(idUsuario);

            cargarCheckboxList();
            cargarRolesUsuario();

            txtIdUsuario.Text = Convert.ToString(idUsuario);
            txtUsuarioNombre.Text = usuarioNombre;
        }

        private void cargarCheckboxList()
        {
            for (int i = 0; i < todosLosRoles.Count(); i++)
            {
                cblRoles.Items.Add(new Rol(todosLosRoles[i].Id, todosLosRoles[i].Nombre, todosLosRoles[i].Estado));
            }
        }

        private void cargarRolesUsuario()
        {
            foreach (Rol rol in rolesUsuario)
            {
                for (int i = 0; i < cblRoles.Items.Count; i++)
                {
                    Rol unRol = cblRoles.Items[i] as Rol;

                    if (rol.Id == unRol.Id)
                    {
                        cblRoles.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private List<Rol> filtrarSeleccionadas()
        {
            List<Rol> rolesSeleccionados = new List<Rol>();

            for (int i = 0; i < cblRoles.Items.Count; i++)
            {
                if (cblRoles.GetItemChecked(i))
                {
                    Rol rol = cblRoles.Items[i] as Rol;
                    rolesSeleccionados.Add(rol);
                }
            }
            return rolesSeleccionados;
        }

        private bool sonIguales(List<Rol> rolesSeleccionados)
        {
            if (rolesUsuario.Count != rolesSeleccionados.Count)
                return false;

            for (int i = 0; i < rolesUsuario.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < rolesSeleccionados.Count; j++)
                {
                    if (rolesSeleccionados[j].Id == rolesUsuario[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    return false;
            }
            return true;
        }

        private void actualizarRolPorUsuario(List<Rol> rolesSeleccionados)
        {
            for (int i = 0; i < rolesUsuario.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < rolesSeleccionados.Count; j++)
                {
                    if (rolesSeleccionados[j].Id == rolesUsuario[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }

                if (!encontro)
                    //delete
                    Roles.BorrarRolEnUsuario(idUsuario, rolesUsuario[i].Id);
            }

            for (int i = 0; i < rolesSeleccionados.Count; i++)
            {
                bool encontro = false;

                for (int j = 0; j < rolesUsuario.Count; j++)
                {
                    if (rolesUsuario[j].Id == rolesSeleccionados[i].Id)
                    {
                        encontro = true;
                        break;
                    }
                }
                if (!encontro)
                    //agregar
                    Roles.AgregarRolEnUsuario(idUsuario, rolesSeleccionados[i].Id);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Rol> rolesSeleccionados = filtrarSeleccionadas();
            rolesUsuario = Roles.obtenerRolesUsuario(idUsuario);

            if (sonIguales(rolesSeleccionados))
            {
                MessageBox.Show("Por favor realice al menos un cambio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                actualizarRolPorUsuario(rolesSeleccionados);
                MessageBox.Show("Modificacion realizada con éxito!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
