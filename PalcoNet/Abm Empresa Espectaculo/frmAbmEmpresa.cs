using PalcoNet.Common;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class frmAbmEmpresa : Form
    {
        public string usuario_username { get; set; }
        public string password { get; set; }
        public int usuario_intentosLogin { get; set; }
        public int usuario_activo { get; set; }
        public int primera_vez { get; set; }

        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string ciudad { get; set; }
        public string mail { get; set; }
        public string departamentro { get; set; }
        public string nroPiso { get; set; }
        public string localidad { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string passwordNoHash { get; set; }

        public Login.frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmAbmEmpresa(Login.frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            InitializeComponent();
            llenarCbFiltro();
        }

        public void llenarCbFiltro()
        {
            this.cmbFiltro.Items.Add("Razón social");
            this.cmbFiltro.Items.Add("cuit");
            this.cmbFiltro.Items.Add("mail");
        }        

       
        public Boolean campoVacio(TextBox textbox)
        {
            return textbox.Text.Equals("");
        }

        public Boolean cboxVacio(ComboBox combobox)
        {
            if (combobox.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean campoNumerico(TextBox textbox)
        {
            return Interfaz.esNumerico(textbox.Text, System.Globalization.NumberStyles.Integer);
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(txtrazonSocial) && !campoVacio(txtmail) && !campoVacio(txtdireccion) && !campoVacio(txtcod_postal) && !campoVacio(txtcuit))
            {
                if (campoVacio(txttelefono) || (!campoVacio(txttelefono) && campoNumerico(txttelefono)))
                {
                    if (!SqlConnector.existeString(txtrazonSocial.Text, "VADIUM.EMPRESA", "razonSocial") && !SqlConnector.existeString(txtcuit.Text, "VADIUM.EMPRESA", "cuit"))
                    {

                        if (!campoVacio(txttelefono))
                        {
                            this.telefono = Convert.ToInt32(txttelefono.Text);
                        }
                        else
                        {
                            this.telefono = -1;
                        }

                        if (!campoVacio(txtciudad))
                        {
                            this.ciudad = txtciudad.Text;
                        }
                        else
                        {
                            this.ciudad = "";
                        }

                        this.razonSocial = txtrazonSocial.Text;
                        this.cuit = txtcuit.Text;
                        this.direccion = txtdireccion.Text;
                        this.cod_postal = txtcod_postal.Text;
                        this.mail = txtmail.Text;
                        this.localidad = txtLocalidad.Text;
                        this.nroPiso = txtNroPiso.Text;
                        this.departamentro = txtDepartamento.Text;                        
                        this.fechaCreacion = Interfaz.obtenerFecha();

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Razón social y/o cuit ya existente/s.", "Error");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Teléfono inválido", "Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                return false;
            }
        }

        public string randomString(int caracteres)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return (new string(
                Enumerable.Repeat(chars, caracteres)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray()));
        }

        public string randomUser()
        {
            string random = "PalcoNet_" + randomString(10);
            if (!SqlConnector.existeString(random, "VADIUM.USUARIO", "usuario_username"))
            {
                return random;
            }
            else
            {
                return randomUser();
            }
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        public string randompassword()
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            this.passwordNoHash = randomString(20);
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(this.passwordNoHash));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        public void cargarUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlConnector.agregarParametro(listaParametros, "@password", this.password);
            SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", this.usuario_intentosLogin);
            SqlConnector.agregarParametro(listaParametros, "@usuario_activo", this.usuario_activo);
            SqlConnector.agregarParametro(listaParametros, "@primera_vez", this.primera_vez);
            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO VALUES (@usuario_username, @password, @usuario_intentosLogin, @Habilitado, @primera_vez, 0)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cargarEmpresa()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@usuario_username", this.usuario_username);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros2, SqlConnector.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["usuario_id"]);
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", idUser);
            SqlConnector.agregarParametro(listaParametros, "@razonSocial", this.razonSocial);
            SqlConnector.agregarParametro(listaParametros, "@cuit", this.cuit);

            if (this.telefono == -1)
            {
                SqlConnector.agregarParametro(listaParametros, "@telefono", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@telefono", this.telefono);
            }

            SqlConnector.agregarParametro(listaParametros, "@direccion", this.direccion);
            SqlConnector.agregarParametro(listaParametros, "@cod_postal", this.cod_postal);

            if (this.ciudad.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros, "@ciudad", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@ciudad", this.ciudad);
            }

            SqlConnector.agregarParametro(listaParametros, "@mail", this.mail);    
            SqlConnector.agregarParametro(listaParametros, "@fechaCreacion", this.fechaCreacion);

            SqlConnector.agregarParametro(listaParametros, "@Localidad", this.localidad);
            SqlConnector.agregarParametro(listaParametros, "@NroPiso", this.nroPiso);
            SqlConnector.agregarParametro(listaParametros, "@departamento", this.departamentro);

            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.EMPRESA VALUES (@usuario_id, @razonSocial, @cuit, @telefono, @direccion, @cod_postal, @ciudad, @mail, @fechaCreacion, @Localidad, @NroPiso, @ Departamento)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();

            //Obteniendo la rol_id del cliente
            int rol_id = Rol.obtenerID("Empresa");

            Roles.AgregarRolEnUsuario(idUser, rol_id);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.usuario_username = randomUser();
            this.password = randompassword();
            this.usuario_intentosLogin = 0;
            this.usuario_activo = 1;
            this.primera_vez = 1;

            if (chequearCampos())
            {
                cargarUsuario();
                cargarEmpresa();
                new Abm_Cliente.frmConfirmacionCliente(this.usuario_username, this.passwordNoHash).Show();
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cmbFiltro.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Debe seleccionar un criterio de búsqueda.", "Error");
                    break;
                case 0: // Razón Social
                    if (!tBusqueda.Text.Equals(""))
                    {
                        frmBuscarEmpresa form0 = new frmBuscarEmpresa('R', tBusqueda.Text);
                        form0.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
                case 1: // cuit
                    if (!tBusqueda.Text.Equals(""))
                    {
                        if (tBusqueda.Text.Length <= 50)
                        {
                            frmBuscarEmpresa form1 = new frmBuscarEmpresa('C', tBusqueda.Text);
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("cuit inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
                case 2: // mail
                    if (!tBusqueda.Text.Equals(""))
                    {
                        frmBuscarEmpresa form2 = new frmBuscarEmpresa('E', tBusqueda.Text);
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
            }
        }

        private void textboxNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar)
                   )
            {
                e.Handled = true;
            }
        }

        private void textboxNoNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }
        }

        private void textboxcuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeleccionFuncionalidades.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Interfaz.limpiarInterfaz(this);
        }
    }
}
