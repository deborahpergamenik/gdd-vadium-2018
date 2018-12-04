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

namespace PalcoNet.Login
{
    public partial class frmSeleccionRoles : Form
    {
        public Usuario usuario { get; set; }

        public class itemComboBox
        {
            public string Nombre { get; set; }
            public int IdRol { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre = nombre;
                IdRol = id;
            }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public frmSeleccionRoles(Usuario usuarioLogin)
        {
            this.usuario = usuarioLogin;
            InitializeComponent();

            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "IdRol";
            completarCombo();
        }

        public void completarCombo()
        {
            for (int i = 0; i < usuario.Roles.Count(); i++)
            {
                if (usuario.Roles[i].Estado != false) // TOMANDO EN CUENTA QUE 1 ES HABILITADO
                {
                    cmbRoles.Items.Add(new itemComboBox(usuario.Roles[i].Nombre, usuario.Roles[i].Id));
                }
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error");
            }
            else
            {
                if (this.usuario.Roles[cmbRoles.SelectedIndex].Funcionalidades.Count != 0)
                {
                    itemComboBox seleccion = cmbRoles.SelectedItem as itemComboBox;
                    UserInstance.getUserInstance().loadInformation(usuario, usuario.Roles.Where(x => x.Id == seleccion.IdRol).FirstOrDefault());
                    frmSeleccionFuncionalidades formFuncionalidades = new frmSeleccionFuncionalidades(usuario, seleccion.IdRol, false);
                    this.Hide();
                    formFuncionalidades.Show();
                }
                else
                {
                    MessageBox.Show("El rol seleccionado no posee funcionalidades.", "Error");
                }
            }
        }
    }
}
