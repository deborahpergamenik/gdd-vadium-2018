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
        public string NombreUsuario { get; set; }
        public string password { get; set; }
        public int intentos { get; set; }
        public int estado { get; set; }
        public int primeraVez { get; set; }

        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string email { get; set; }
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
            this.cmbFiltro.Items.Add("CUIT");
            this.cmbFiltro.Items.Add("Email");
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
            if (!campoVacio(txtRazonSocial) && !campoVacio(txtEmail) && !campoVacio(txtDireccion) && !campoVacio(txtCodigoPostal) && !campoVacio(txtCuit))
            {
                if (campoVacio(txtTelefono) || (!campoVacio(txtTelefono) && campoNumerico(txtTelefono)))
                {
                    if (!SqlConnector.existeString(txtRazonSocial.Text, "PalcoNet.Empresa", "RazonSocial") && !SqlConnector.existeString(txtCuit.Text, "PalcoNet.Empresa", "CUIT"))
                    {

                        if (!campoVacio(txtTelefono))
                        {
                            this.telefono = Convert.ToInt32(txtTelefono.Text);
                        }
                        else
                        {
                            this.telefono = -1;
                        }

                        if (!campoVacio(txtCiudad))
                        {
                            this.ciudad = txtCiudad.Text;
                        }
                        else
                        {
                            this.ciudad = "";
                        }

                        this.razonSocial = txtRazonSocial.Text;
                        this.cuit = txtCuit.Text;
                        this.direccion = txtDireccion.Text;
                        this.codigoPostal = txtCodigoPostal.Text;
                        this.email = txtEmail.Text;
                        this.localidad = txtLocalidad.Text;
                        this.nroPiso = txtNroPiso.Text;
                        this.departamentro = txtDepartamento.Text;                        
                        this.fechaCreacion = Interfaz.obtenerFecha();

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Razón social y/o CUIT ya existente/s.", "Error");
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
            if (!SqlConnector.existeString(random, "PalcoNet.Usuario", "NombreUsuario"))
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

        public string randomPassword()
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
            SqlConnector.agregarParametro(listaParametros, "@NombreUsuario", this.NombreUsuario);
            SqlConnector.agregarParametro(listaParametros, "@Password", this.password);
            SqlConnector.agregarParametro(listaParametros, "@Intentos", this.intentos);
            SqlConnector.agregarParametro(listaParametros, "@Estado", this.estado);
            SqlConnector.agregarParametro(listaParametros, "@Primeravez", this.primeraVez);
            SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Usuario VALUES (@NombreUsuario, @Password, @Intentos, @Habilitado, @PrimeraVez, 0)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cargarEmpresa()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@NombreUsuario", this.NombreUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Usuarios WHERE NombreUsuario = @NombreUsuario", listaParametros2, SqlConnector.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["IdUsuario"]);
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", idUser);
            SqlConnector.agregarParametro(listaParametros, "@RazonSocial", this.razonSocial);
            SqlConnector.agregarParametro(listaParametros, "@CUIT", this.cuit);

            if (this.telefono == -1)
            {
                SqlConnector.agregarParametro(listaParametros, "@Telefono", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@Telefono", this.telefono);
            }

            SqlConnector.agregarParametro(listaParametros, "@Direccion", this.direccion);
            SqlConnector.agregarParametro(listaParametros, "@CodigoPostal", this.codigoPostal);

            if (this.ciudad.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros, "@Ciudad", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@Ciudad", this.ciudad);
            }

            SqlConnector.agregarParametro(listaParametros, "@Email", this.email);    
            SqlConnector.agregarParametro(listaParametros, "@FechaCreacion", this.fechaCreacion);

            SqlConnector.agregarParametro(listaParametros, "@Localidad", this.localidad);
            SqlConnector.agregarParametro(listaParametros, "@NroPiso", this.nroPiso);
            SqlConnector.agregarParametro(listaParametros, "@departamento", this.departamentro);

            SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Empresa VALUES (@IdUsuario, @RazonSocial, @CUIT, @Telefono, @Direccion, @Codigo_Postal, @Ciudad, @Email, @FechaCreacion, @Localidad, @NroPiso, @ Departamento)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();

            //Obteniendo la ID_Rol del cliente
            int idRol = Rol.obtenerID("Empresa");

            Roles.AgregarRolEnUsuario(idUser, idRol);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.NombreUsuario = randomUser();
            this.password = randomPassword();
            this.intentos = 0;
            this.estado = 1;
            this.primeraVez = 1;

            if (chequearCampos())
            {
                cargarUsuario();
                cargarEmpresa();
                new Abm_Cliente.frmConfirmacionCliente(this.NombreUsuario, this.passwordNoHash).Show();
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
                case 1: // CUIT
                    if (!tBusqueda.Text.Equals(""))
                    {
                        if (tBusqueda.Text.Length <= 50)
                        {
                            frmBuscarEmpresa form1 = new frmBuscarEmpresa('C', tBusqueda.Text);
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("CUIT inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                    }
                    break;
                case 2: // EMAIL
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

        private void textboxCUIT_KeyPress(object sender, KeyPressEventArgs e)
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
