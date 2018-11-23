using PalcoNet.Common;
using PalcoNet.Login;
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

namespace PalcoNet.Abm_Cliente
{
    public partial class frmAbmCliente : Form
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public int intentos { get; set; }
        public int estado { get; set; }
        public int primeraVez { get; set; }

        public string tipoDoc { get; set; }
        public string numDoc { get; set; }
        public string cuil { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string nroPiso { get; set; }
        public string localidad { get; set; }
        public string departamento { get; set; }
        public string codigoPostal { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string passwordNoHash { get; set; }

        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmAbmCliente(frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            InitializeComponent();

            llenarCmbDia();
            llenarCmbMes();
            llenarCmbAno();
            llenarCmbTipoDoc();
            llenarCmbFiltro();
            llenarCmbFiltroTipoDoc();
        }

        public void llenarCmbDia()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                this.cmbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCmbMes()
        {
            int i;
            for (i = 1; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCmbAno()
        {
            int i;
            for (i = 1914; i <= 2014; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCmbTipoDoc()
        {
            this.cmbTipoDocumento.Items.Add("DU");
            this.cmbTipoDocumento.Items.Add("CI");
            this.cmbTipoDocumento.Items.Add("LC");
        }

        public void llenarCmbFiltro()
        {
            this.cmbFiltro.Items.Add("Nombre");
            this.cmbFiltro.Items.Add("Apellido");
            this.cmbFiltro.Items.Add("Tipo de documento");
            this.cmbFiltro.Items.Add("Número de documento");
            this.cmbFiltro.Items.Add("Email");
        }

        public void llenarCmbFiltroTipoDoc()
        {
            this.cmbFiltroTipoDocumento.Items.Add("DU");
            this.cmbFiltroTipoDocumento.Items.Add("CI");
            this.cmbFiltroTipoDocumento.Items.Add("LC");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cmbFiltro.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Debe seleccionar un criterio de búsqueda.", "Error");
                    break;
                case 0: // Nombre
                    if (!tBusqueda.Text.Equals(""))
                    {
                        frmBuscarCliente frmBuscar = new frmBuscarCliente('N', tBusqueda.Text);
                        frmBuscar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 1: // Apellido
                    if (!tBusqueda.Text.Equals(""))
                    {
                        frmBuscarCliente frmBuscar = new frmBuscarCliente('A', tBusqueda.Text);
                        frmBuscar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 2: // Tipo de documento
                    if (cmbFiltroTipoDocumento.SelectedIndex != -1)
                    {
                        frmBuscarCliente frmBuscar = new frmBuscarCliente('T', cmbFiltroTipoDocumento.SelectedItem.ToString());
                        frmBuscar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 3: // Número de documento
                    if (!tBusqueda.Text.Equals(""))
                    {
                        if (Interfaz.esNumerico(tBusqueda.Text, System.Globalization.NumberStyles.Integer))
                        {
                            frmBuscarCliente frmBuscar = new frmBuscarCliente('D', tBusqueda.Text);
                            frmBuscar.Show();
                        }
                        else
                        {
                            MessageBox.Show("Número de documento inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
                case 4: // Email
                    if (!tBusqueda.Text.Equals(""))
                    {
                        frmBuscarCliente frmBuscar = new frmBuscarCliente('E', tBusqueda.Text);
                        frmBuscar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar los campos solicitados", "Error");
                    }
                    break;
            }
        }


        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox CB = (ComboBox)sender;
            if (CB.SelectedIndex == 2)
            {
                cmbFiltroTipoDocumento.Visible = true;
                tBusqueda.Visible = false;
            }
            else
            {
                cmbFiltroTipoDocumento.Visible = false;
                tBusqueda.Visible = true;
            }
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

        public string cboxString(ComboBox combobox)
        {
            return combobox.SelectedItem.ToString();
        }

        public DateTime fecha(string dia, string mes, string ano)
        {
            if (Convert.ToInt32(dia) <= 9)
            {
                dia = "0" + dia;
            }
            if (Convert.ToInt32(mes) <= 9)
            {
                mes = "0" + mes;
            }
            return DateTime.ParseExact(dia + "/" + mes + "/" + ano, "dd/MM/yyyy", null);
        }

        public Boolean chequearCampos()
        {
            if (!campoVacio(txtNombre) && !campoVacio(txtApellido) && !campoVacio(txtNumeroDocumento) && !campoVacio(txtCuil) && !campoVacio(txtEmail) && !campoVacio(txtDireccion) && !campoVacio(txtCodigoPostal) && !cboxVacio(cmbTipoDocumento) && !cboxVacio(cmbDia) && !cboxVacio(cmbMes) && !cboxVacio(cmbAno))
            {
                if (campoNumerico(txtNumeroDocumento) && (campoVacio(txtTelefono) || (!campoVacio(txtTelefono) && campoNumerico(txtTelefono))))
                {
                    if (!SqlConnector.existenSimultaneamente(cmbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "PalcoNet.Cliente", "TipoDoc", "NumDoc"))
                    {
                        if (!campoVacio(txtTelefono))
                        {
                            this.telefono = Convert.ToInt32(txtTelefono.Text);
                        }
                        else
                        {
                            this.telefono = -1;
                        }
                        this.tipoDoc = cboxString(cmbTipoDocumento);
                        this.numDoc = txtNumeroDocumento.Text;
                        this.cuil = txtCuil.Text;
                        this.nombre = txtNombre.Text;
                        this.apellido = txtApellido.Text;
                        this.email = txtEmail.Text;
                        this.direccion = txtDireccion.Text;
                        this.codigoPostal = txtCodigoPostal.Text;
                        this.localidad = txtLocalidad.Text;
                        this.nroPiso = txtNroPiso.Text;
                        this.departamento = txtDepartamento.Text;
                        this.fechaNacimiento = fecha(cboxString(cmbDia), cboxString(cmbMes), cboxString(cmbAno));
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El tipo y número de documento ingresados ya fueron registrados.", "Error");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Número de documento y/o teléfono inválido/s", "Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos solicitados.", "Error");
                return false;
            }
        }


        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.nombre = randomUser();
            this.password = randomPassword();
            this.intentos = 0;
            this.estado = 1;
            this.primeraVez = 1;

            if (chequearCampos())
            {
                cargarUsuario();
                cargarCliente();
                new frmConfirmacionCliente(this.usuario, this.passwordNoHash).Show();
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
            if (!SqlConnector.existeString(random, "PalcoNet.Usuario", "Username"))
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

            SqlConnector.agregarParametro(listaParametros, "@NombreUsuario", this.usuario);
            SqlConnector.agregarParametro(listaParametros, "@Password", this.password);
            SqlConnector.agregarParametro(listaParametros, "@Intentos", this.intentos);
            SqlConnector.agregarParametro(listaParametros, "@PrimeraVez", this.primeraVez);

            SqlConnector.agregarParametro(listaParametros, "@Email", this.email);
            SqlConnector.agregarParametro(listaParametros, "@Direccion", this.direccion);
            if (telefono.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros, "@Telefono", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@Telefono", Convert.ToInt64(this.telefono));
            }

            SqlConnector.agregarParametro(listaParametros, "@NroPiso", this.nroPiso);
            SqlConnector.agregarParametro(listaParametros, "@Departamento", this.departamento);
            SqlConnector.agregarParametro(listaParametros, "@Localidad", this.localidad);
            SqlConnector.agregarParametro(listaParametros, "@CodigoPostal", this.codigoPostal);
            SqlConnector.agregarParametro(listaParametros, "@Estado", this.estado);

            SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Usuario VALUES (NombreUsuario, Password, Intentos, Primera_Vez, Email, Direccion, Telefono, NroPiso, Departamento, Localidad, CodigoPostal, Estado) VALUES (@NombreUsuario, @Password, @Intentos, @PrimeraVez, @Email, @Direccion, @Telefono, @NroPiso, @Departamento, @Localidad, @CodigoPostal, @Estado)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cargarCliente()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@nombreUsuario", this.nombre);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Usuario WHERE NombreUsuario = @nombreUsuario", listaParametros2, SqlConnector.iniciarConexion());
            lector.Read();
            int idUsuario = Convert.ToInt32(lector["IdUsuario"]);
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();     
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", idUsuario);
            SqlConnector.agregarParametro(listaParametros, "@Nombre", this.nombre);
            SqlConnector.agregarParametro(listaParametros, "@Apellido", this.apellido);
            SqlConnector.agregarParametro(listaParametros, "@TipoDoc", this.tipoDoc);
            SqlConnector.agregarParametro(listaParametros, "@NumDoc", this.numDoc);
            SqlConnector.agregarParametro(listaParametros, "@Cuil", this.cuil);
            SqlConnector.agregarParametro(listaParametros, "@FechaNacimiento", fechaNacimiento);
            SqlConnector.agregarParametro(listaParametros, "@FechaCreacion", DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null));

            SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Cliente (IdUsuario,Nombre,Apellido,TipoDoc,NumDoc,Cuil,FechaNacimiento,FechaCreacion) VALUES(@IdUsuario, @Nombre, @Apellido, @TipoDoc, @NumDoc, @Cuil, @FechaNacimiento, @FechaCreacion)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
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
