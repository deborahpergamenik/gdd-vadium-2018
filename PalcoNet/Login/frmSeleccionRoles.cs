﻿using PalcoNet.Model;
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
            public string nombre { get; set; }
            public int rol_id { get; set; }

            public itemComboBox(string nombre, int id)
            {
                nombre = nombre;
                rol_id = id;
            }
            public override string ToString()
            {
                return nombre;
            }
        }

        public frmSeleccionRoles(Usuario usuarioLogin)
        {
            this.usuario = usuarioLogin;
            InitializeComponent();
            completarCombo();
        }

        public void completarCombo()
        {
            usuario.Roles.Where(x => x.habilitado).ToList().ForEach(x => cmbRoles.Items.Add(new ComboBoxItem { Value = x.Id, Text = x.nombre }));
            //for (int i = 0; i < usuario.Roles.Count(); i++)
            //{
            //    if (usuario.Roles[i].habilitado) // TOMANDO EN CUENTA QUE 1 ES HABILITADO
            //    {
            //        cmbRoles.Items.Add(new itemComboBox(usuario.Roles[i].nombre, usuario.Roles[i].Id));
            //    }
            //}
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error");
            }
            else
            {
                UserInstance.getUserInstance().loadInformation(this.usuario, this.usuario.Roles[cmbRoles.SelectedIndex]);
                if (this.usuario.Roles[cmbRoles.SelectedIndex].Funcionalidades.Count != 0)
                {
                    ComboBoxItem seleccion = cmbRoles.SelectedItem as ComboBoxItem;
                    //UserInstance.getUserInstance().loadRol(usuario.Roles.Where(x => x.Id == seleccion.rol_id).FirstOrDefault());
                    frmSeleccionFuncionalidades formFuncionalidades = new frmSeleccionFuncionalidades(usuario, Convert.ToInt32(seleccion.Value), false);
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
