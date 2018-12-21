using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Grado;
using PalcoNet.Abm_Rol;
using PalcoNet.Abm_Rubro;
using PalcoNet.Abm_Tarjeta_Credito;
using PalcoNet.Canje_Puntos;
using PalcoNet.Common;
using PalcoNet.Comprar;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Historial_Cliente;
using PalcoNet.Listado_Estadistico;
using PalcoNet.Model;
using PalcoNet.Comisiones;
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
        public frmLogin frmLogin { get; set; }
        public frmSeleccionRoles frmSeleccionRoles { get; set; }
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

        public frmSeleccionFuncionalidades(Usuario usuario, int rol_id, frmLogin _frmLogin)
        {
            this.frmLogin = _frmLogin;
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
        }


        public frmSeleccionFuncionalidades(Usuario usuario, int rol_id, Boolean bypass, frmSeleccionRoles _frmSeleccionRoles)
        {
            this.frmSeleccionRoles = _frmSeleccionRoles;
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
                        cmbFuncionalidades.Items.Add(new itemComboBox("Canje Premios", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 6)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Compras", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 7)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Publicaciones", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 8)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Generar Rendiciones por Comisión", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 9)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Historial de Cliente", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 10)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Listado Estadístico", rolActual.Funcionalidades[i].Id));
                    }

                    if (rolActual.Funcionalidades[i].Id == 11)
                    {
                        cmbFuncionalidades.Items.Add(new itemComboBox("Administrar Tarjeta Crédito", rolActual.Funcionalidades[i].Id));
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
                        frmGrado form3 = new frmGrado(this);
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
                        frmCanjePuntos form5 = new frmCanjePuntos(this.usuario.usuario_id, this);
                        this.Hide();
                        form5.ShowDialog();
                        this.Show();
                        break;
                    case 6:
                        frmComprar form6 = new frmComprar(this);
                        this.Hide();
                        form6.ShowDialog();
                        this.Show();
                        break;
                    case 7:
                        string modo = "Nuevo";
                        frmGenerarPublicacion form7 = new frmGenerarPublicacion(modo);
                        this.Hide();
                        form7.ShowDialog();
                        this.Show();
                        break;
                    case 8:
                        Comisiones.Comisiones form8 = new Comisiones.Comisiones(this);
                        this.Hide();
                        form8.ShowDialog();
                        this.Show();
                        break;
                    case 9:
                        frmHistorialCliente form9 = new frmHistorialCliente(this);
                        this.Hide();
                        form9.ShowDialog();
                        this.Show();
                        break;
                    case 10:
                        frmListadoEstadistico form10 = new frmListadoEstadistico();
                        this.Hide();
                        form10.ShowDialog();
                        this.Show();
                        break;
                    case 11:
                        frmAbmTarjetaDeCredito form11 = new frmAbmTarjetaDeCredito(this, (int)UserInstance.getUserInstance().clienteId);
                        this.Hide();
                        form11.ShowDialog();
                        this.Show();
                        break;
                }
            }
        }


        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.frmLogin != null)
            {
                this.Hide();
                this.frmLogin.Show();
            }
            else
            {
                this.Hide();
                this.frmSeleccionRoles.Show();
            }
        }
    }
}
