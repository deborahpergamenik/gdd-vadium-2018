using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Grado;
using PalcoNet.Abm_Rol;
using PalcoNet.Abm_Rubro;
using PalcoNet.Canje_Puntos;
using PalcoNet.Common;
using PalcoNet.Comprar;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Generar_Rendicion_Comisiones;
using PalcoNet.Historial_Cliente;
using PalcoNet.Listado_Estadistico;
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
    public partial class frmSeleccionFuncionalidades : Form
    {
        public Usuario usuario { get; set; }
        public Rol rolActual { get; set; }

        public class itemComboBox
        {
            public string Descripcion { get; set; }
            public int funcionalidad_id { get; set; }

            public itemComboBox(string descripcion, int id)
            {
                Descripcion = descripcion;
                funcionalidad_id = id;
            }
            public override string ToString()
            {
                return Descripcion;
            }
        }

        public frmSeleccionFuncionalidades(Usuario usuario, int rol_id, Boolean bypass)
        {
            //Genera el diccionario de tipoPublicacion, usuario_activoPublicacion, tipoOperacion y Visibilidades
            //Interfaz.generarDiccionarios();
            this.usuario = usuario;
            var rolQuery = from rol in this.usuario.Roles where rol.Id == rol_id select rol;
            foreach (var item in rolQuery)
            {
                this.rolActual = item;
            }

            InitializeComponent();
            cmbFuncionalidades.DisplayMember = "Descripcion";
            cmbFuncionalidades.ValueMember = "funcionalidad_id";
            listarFuncionalidades();

            if (!bypass)
            {
                btnAtras.Visible = true;
            }
            else
            {
                btnAtras.Visible = false;
            }
        }

        public void listarFuncionalidades()
        {
            if (rolActual.Funcionalidades.Count != 0)
            {
                cmbFuncionalidades.Items.Add(new itemComboBox("Cambiar Contraseña", -2));
                for (int i = 0; i < rolActual.Funcionalidades.Count; i++)
                {
                    if (rolActual.Funcionalidades[i].Id == 1)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Clientes", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 2)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Empresas", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 3)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Grado", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 4)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Roles", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 5)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Rubro", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 6)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Puntos", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 7)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Compras", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 8)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Editar Publicación", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 9)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Generar Publicación", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 10)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Generar Rendiciones por Comisión", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 11)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Historial de Cliente", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 12)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Listado Estadístico", rolActual.Funcionalidades[i].Id));
                    }
                }
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbFuncionalidades.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una funcionalidad.", "Error");
            }
            else
            {
                itemComboBox seleccion = cmbFuncionalidades.SelectedItem as itemComboBox;
                switch (seleccion.funcionalidad_id)
                {
                    case -2:
                        frmCambiarpassword formPass = new frmCambiarpassword(false);
                        formPass.Show();
                        break;
                    case 1:
                        frmAbmCliente form1 = new frmAbmCliente(this);
                        this.Hide();
                        form1.Show();
                        break;
                    case 2:
                        frmAbmEmpresa form2 = new frmAbmEmpresa(this);
                        this.Hide();
                        form2.Show();
                        break;
                    case 3:
                        frmGrado form3 = new frmGrado();
                        this.Hide();
                        form3.ShowDialog();
                        this.Show();
                        break;
                    case 4:
                        frmRol form4 = new frmRol(this);
                        this.Hide();
                        form4.Show();
                        break;
                    case 5:
                        frmRubro form5 = new frmRubro(this);
                        this.Hide();
                        form5.ShowDialog();
                        this.Show();
                        break;
                    case 6:
                        frmCanjePuntos form6 = new frmCanjePuntos(this.usuario.usuario_id, this);
                        this.Hide();
                        form6.ShowDialog();
                        this.Show();
                        break;
                    case 7:
                        frmComprar form7 = new frmComprar(this);
                        this.Hide();
                        form7.ShowDialog();
                        this.Show();
                        break;
                    case 8:
                        frmEditarPublicacion form8 = new frmEditarPublicacion();
                        this.Hide();
                        form8.ShowDialog();
                        this.Show();
                        break;
                    case 9:
                        string modo = "Nuevo";
                        frmGenerarPublicacion form9 = new frmGenerarPublicacion(modo);
                        this.Hide();
                        form9.ShowDialog();
                        this.Show();
                        break;
                    case 10:
                        frmGenerarRendicionesComisiones form10 = new frmGenerarRendicionesComisiones();
                        this.Hide();
                        form10.ShowDialog();
                        this.Show();
                        break;
                    case 11:
                        frmHistorialCliente form11 = new frmHistorialCliente(this);
                        this.Hide();
                        form11.ShowDialog();
                        this.Show();
                        break;
                    case 12:
                        frmListadoEstadistico form12 = new frmListadoEstadistico();
                        this.Hide();
                        form12.Show();
                        break;
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmSeleccionRoles formRoles = new frmSeleccionRoles(Interfaz.usuario);
            this.Hide();
            formRoles.Show();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                Environment.Exit(0);
            }
        }
    }
}
