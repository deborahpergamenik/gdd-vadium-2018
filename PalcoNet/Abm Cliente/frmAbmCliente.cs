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
        public string usuario_username { get; set; }
        public string password { get; set; }
        public int usuario_intentosLogin { get; set; }
        public int usuario_activo { get; set; }
        public int primera_vez { get; set; }

        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string CUIL { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public long telefono { get; set; }
        public string direccion { get; set; }
        public int nroPiso { get; set; }
        public string localidad { get; set; }
        public string departamento { get; set; }
        public string cod_postal { get; set; }
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
            llenarCmbtipoDocumento();
            formatearDataGrid();
            CargarDatos(string.Empty, string.Empty, string.Empty, string.Empty);
        }


        public void CargarDatos(string nombre, string apellido, string dni, string mail)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@NOMBRE", nombre);
            SqlConnector.agregarParametro(listaParametros, "@APELLIDO", apellido);
            SqlConnector.agregarParametro(listaParametros, "@DNI", dni);
            SqlConnector.agregarParametro(listaParametros, "@mail", mail);


            String commandtext = "VADIUM.LISTADO_SELECCION_CLIENTE";
            DataTable table = SqlConnector.obtenerDataTable(commandtext, "SP", listaParametros);
            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                dgResultados.DataSource = table;
            }
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
            for (i = 1914; i <= 2018; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCmbtipoDocumento()
        {
            this.cmbTipoDocumento.Items.Add("DNI");
            this.cmbTipoDocumento.Items.Add("CI");
            this.cmbTipoDocumento.Items.Add("LC");
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
            if (!campoVacio(txtNombre) && !campoVacio(txtApellido) && !campoVacio(txtNumeroDocumento) && !campoVacio(txtCUIL) && !campoVacio(txtMail) && !campoVacio(txtDireccion) && !campoVacio(txtCodPostal) && !cboxVacio(cmbTipoDocumento) && !cboxVacio(cmbDia) && !cboxVacio(cmbMes) && !cboxVacio(cmbAno))
            {
                if (campoNumerico(txtNumeroDocumento) && (campoVacio(txtTelefono) || (!campoVacio(txtTelefono) && campoNumerico(txtTelefono))))
                {
                    if (!SqlConnector.existenSimultaneamente(cmbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "VADIUM.CLIENTE", "tipoDocumento", "numeroDocumento"))
                    {
                        if (!SqlConnector.existeString(txtCUIL.Text, "VADIUM.CLIENTE", "CUIL"))
                        {
                            if (!campoVacio(txtTelefono))
                            {
                                this.telefono = Convert.ToInt64(txtTelefono.Text);
                            }
                            else
                            {
                                this.telefono = -1;
                            }
                            this.tipoDocumento = cboxString(cmbTipoDocumento);
                            this.numeroDocumento = txtNumeroDocumento.Text;
                            this.CUIL = txtCUIL.Text;
                            this.nombre = txtNombre.Text;
                            this.apellido = txtApellido.Text;
                            this.mail = txtMail.Text;
                            this.direccion = txtDireccion.Text;
                            this.cod_postal = txtCodPostal.Text;
                            this.localidad = txtLocalidad.Text;
                            this.nroPiso = Convert.ToInt32(txtNroPiso.Text);
                            this.departamento = txtDepartamento.Text;
                            this.fechaNacimiento = fecha(cboxString(cmbDia), cboxString(cmbMes), cboxString(cmbAno));
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cuil ya existente.", "Error");
                            return false;
                        }
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
            this.usuario_username = randomUser();
            this.password = randompassword();
            this.usuario_intentosLogin = 0;
            this.usuario_activo = 1;
            this.primera_vez = 1;

            if (chequearCampos())
            {
                cargarUsuario();
                cargarCliente();
                new frmConfirmacionCliente(this.usuario_username, this.passwordNoHash).Show();
                CargarDatos(string.Empty, string.Empty, string.Empty, string.Empty);
                dgResultados.Refresh();
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
            string random = "PalcoNet_Cliente_" + randomString(10);
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
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
            string password = bytesDeHasheoToString(bytesDeHasheo);

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlConnector.agregarParametro(listaParametros, "@usuario_password", this.password);
            SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", this.usuario_intentosLogin);
            SqlConnector.agregarParametro(listaParametros, "@usuario_activo", this.usuario_activo);
            SqlConnector.agregarParametro(listaParametros, "@primera_vez", this.primera_vez);
            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO (usuario_username, usuario_password, usuario_intentosLogin, usuario_activo, primera_vez) VALUES (@usuario_username, @usuario_password, @usuario_intentosLogin, @usuario_activo, @primera_vez)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cargarCliente()
        {
            List<SqlParameter> listaParametros= new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["usuario_id"]);
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@usuario_id", idUser);
            SqlConnector.agregarParametro(listaParametros2, "@tipoDocumento", this.tipoDocumento);
            SqlConnector.agregarParametro(listaParametros2, "@numeroDocumento", Convert.ToInt32(this.numeroDocumento));
            SqlConnector.agregarParametro(listaParametros2, "@CUIL", this.CUIL);
            SqlConnector.agregarParametro(listaParametros2, "@nombre", this.nombre);
            SqlConnector.agregarParametro(listaParametros2, "@apellido", this.apellido);
            SqlConnector.agregarParametro(listaParametros2, "@mail", this.mail);
            SqlConnector.agregarParametro(listaParametros2, "@calle", this.direccion);
            SqlConnector.agregarParametro(listaParametros2, "@cod_postal", this.cod_postal);
            SqlConnector.agregarParametro(listaParametros2, "@fechaNacimiento", this.fechaNacimiento);
            SqlConnector.agregarParametro(listaParametros2, "@fechaCreacion", Configuration.getActualDate());
            SqlConnector.agregarParametro(listaParametros2, "@tarjetaCredito", 1); //cambiar este campo
            SqlConnector.agregarParametro(listaParametros2, "@localidad", this.localidad);
            SqlConnector.agregarParametro(listaParametros2, "@depto", this.departamento);

            if (this.telefono.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros2, "@telefono", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros2, "@telefono", Convert.ToInt64(this.telefono));
            }

            if (this.nroPiso.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros2, "@piso", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros2, "@piso", Convert.ToInt64(this.nroPiso));
            }

            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.CLIENTE (usuario_id, tipoDocumento, numeroDocumento, CUIL, nombre ,apellido, mail, telefono, calle, cod_postal, fechaNacimiento, fechaCreacion, tarjetaCredito,localidad, piso, depto)" +
                                       "VALUES(@usuario_id, @tipoDocumento, @numeroDocumento, @CUIL, @nombre, @apellido, @mail, @telefono, @calle, @cod_postal, @fechaNacimiento, @fechaCreacion, @tarjetaCredito, @localidad, @piso, @depto)", listaParametros2, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();


            int idRol = Rol.obtenerID("Cliente");
            Roles.AgregarRolEnUsuario(idUser, idRol);
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

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargarDatos(txtNameFilter.Text, txtLastNameFilter.Text, txtFilterDoc.Text, txtmailFilter.Text);
        }

        public void formatearDataGrid()
        {
            int widthBotones = 80;

            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewButtonColumn botonesModificar = new DataGridViewButtonColumn();
            botonesModificar.HeaderText = "";
            botonesModificar.Text = "Modificar";
            botonesModificar.Name = "btnModificar";
            botonesModificar.Width = widthBotones;
            botonesModificar.UseColumnTextForButtonValue = true;
            botonesModificar.Resizable = DataGridViewTriState.False;

            DataGridViewButtonColumn botonesEliminar = new DataGridViewButtonColumn();
            botonesEliminar.HeaderText = "";
            botonesEliminar.Text = "Eliminar";
            botonesEliminar.Name = "btnEliminar";
            botonesEliminar.Width = widthBotones;
            botonesEliminar.UseColumnTextForButtonValue = true;
            botonesEliminar.Resizable = DataGridViewTriState.False;

            dgResultados.Columns.Add(botonesModificar);
            dgResultados.Columns.Add(botonesEliminar);
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResultados.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        frmModificarCliente frmCliente = new frmModificarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[3].Value), this);
                        frmCliente.Show();
                        break;
                    case 1:
                        DialogResult result = MessageBox.Show("Se inhabilitará al cliente " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[5].Value) + ", " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[4].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            eliminarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[3].Value));
                        }
                        CargarDatos(string.Empty, string.Empty, string.Empty, string.Empty);
                        dgResultados.Refresh();
                        break;
                }
            }
        }

        public void eliminarCliente(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inhabilitado.");
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

        private void textboxcuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

    }
}
