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
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string nroPiso { get; set; }
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
        }


        public class ResultadoClientes
        {
            public int usuario_id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }

            public ResultadoClientes(int usuario_id, string nombre, string apellido)
            {
                usuario_id = usuario_id;
                nombre = nombre;
                apellido = apellido;
            }
        }

        public List<ResultadoClientes> resultados = new List<ResultadoClientes>();

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

        public void llenarCmbtipoDocumento()
        {
            this.cmbTipoDocumentoumento.Items.Add("DU");
            this.cmbTipoDocumentoumento.Items.Add("CI");
            this.cmbTipoDocumentoumento.Items.Add("LC");
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
            if (!campoVacio(txtNombre) && !campoVacio(txtApellido) && !campoVacio(txtNumeroDocumento) && !campoVacio(txtCUIL) && !campoVacio(txtMail) && !campoVacio(txtDireccion) && !campoVacio(txtCodPostal) && !cboxVacio(cmbTipoDocumentoumento) && !cboxVacio(cmbDia) && !cboxVacio(cmbMes) && !cboxVacio(cmbAno))
            {
                if (campoNumerico(txtNumeroDocumento) && (campoVacio(txtTelefono) || (!campoVacio(txtTelefono) && campoNumerico(txtTelefono))))
                {
                    if (!SqlConnector.existenSimultaneamente(cmbTipoDocumentoumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "VADIUM.CLIENTE", "tipoDocumentoumento", "numeroDocumento"))
                    {
                        if (!SqlConnector.existeString(txtCUIL.Text, "VADIUM.CLIENTE", "CUIL"))
                        {
                            if (!campoVacio(txtTelefono))
                            {
                                this.telefono = Convert.ToInt32(txtTelefono.Text);
                            }
                            else
                            {
                                this.telefono = -1;
                            }
                            this.tipoDocumento = cboxString(cmbTipoDocumentoumento);
                            this.numeroDocumento = txtNumeroDocumento.Text;
                            this.CUIL = txtCUIL.Text;
                            this.nombre = txtNombre.Text;
                            this.apellido = txtApellido.Text;
                            this.mail = txtMail.Text;
                            this.direccion = txtDireccion.Text;
                            this.cod_postal = txtCodPostal.Text;
                            this.localidad = txtLocalidad.Text;
                            this.nroPiso = txtNroPiso.Text;
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
            this.nombre = randomUser();
            this.password = randompassword();
            this.usuario_intentosLogin = 0;
            this.usuario_activo = 1;
            this.primera_vez = 1;

            if (chequearCampos())
            {
                cargarUsuario();
                cargarCliente();
                new frmConfirmacionCliente(this.usuario_username, this.passwordNoHash).Show();
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
            SqlConnector.agregarParametro(listaParametros, "@primera_vez", this.primera_vez);

            SqlConnector.agregarParametro(listaParametros, "@mail", this.mail);
            SqlConnector.agregarParametro(listaParametros, "@direccion", this.direccion);
            if (telefono.Equals(""))
            {
                SqlConnector.agregarParametro(listaParametros, "@telefono", DBNull.Value);
            }
            else
            {
                SqlConnector.agregarParametro(listaParametros, "@telefono", Convert.ToInt64(this.telefono));
            }

            SqlConnector.agregarParametro(listaParametros, "@NroPiso", this.nroPiso);
            SqlConnector.agregarParametro(listaParametros, "@Departamento", this.departamento);
            SqlConnector.agregarParametro(listaParametros, "@Localidad", this.localidad);
            SqlConnector.agregarParametro(listaParametros, "@cod_postal", this.cod_postal);
            SqlConnector.agregarParametro(listaParametros, "@usuario_activo", this.usuario_activo);

            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO VALUES (usuario_username, usuario_password, usario_usuario_intentosLoginLogin, primera_vez, calle, piso, depto, localidad, cod_postal, usuario_activo) VALUES (@usuario_username, @password, @usuario_intentosLogin, @primera_vez, @direccion, @NroPiso, @Departamento, @Localidad, @cod_postal, @usuario_activo)", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cargarCliente()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@usuario_username", this.nombre);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros2, SqlConnector.iniciarConexion());
            lector.Read();
            int usuario_id = Convert.ToInt32(lector["usuario_id"]);
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", usuario_id);
            SqlConnector.agregarParametro(listaParametros, "@nombre", this.nombre);
            SqlConnector.agregarParametro(listaParametros, "@apellido", this.apellido);
            SqlConnector.agregarParametro(listaParametros, "@tipoDocumento", this.tipoDocumento);
            SqlConnector.agregarParametro(listaParametros, "@numeroDocumento", this.numeroDocumento);
            SqlConnector.agregarParametro(listaParametros, "@CUIL", this.CUIL);
            SqlConnector.agregarParametro(listaParametros, "@FechaNacimiento", fechaNacimiento);
            SqlConnector.agregarParametro(listaParametros, "@fechaCreacion", Configuration.getActualDate());

            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.CLIENTE (usuario_id,nombre,apellido,tipoDocumentoumento,numeroDocumento,CUIL,fechaNacimiento,fechaCreacion) VALUES(@usuario_id, @nombre, @apellido, @tipoDocumento, @numeroDocumento, @CUIL, @FechaNacimiento, @fechaCreacion)", listaParametros, SqlConnector.iniciarConexion());
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

        private void textboxcuilKeyPress(object sender, KeyPressEventArgs e)
        {

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
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);

            SqlConnector.agregarParametro(listaParametros, "@nombre", txtNameFilter.Text);
            SqlConnector.agregarParametro(listaParametros, "@apellido", txtLastNameFilter.Text);
            SqlConnector.agregarParametro(listaParametros, "@DNI", txtFilterDoc.Text);
            SqlConnector.agregarParametro(listaParametros, "@mail", txtmailFilter.Text);

            //revisar query
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

        public void formatearDataGrid()
        {
            int widthnombre = 100;
            int widthapellido = 120;
            int widthBotones = 80;

            dgResultados.DataSource = resultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_usuario_id = dgResultados.Columns[0];
            col_usuario_id.Visible = false;

            DataGridViewColumn col_nombre = dgResultados.Columns[1];
            col_nombre.Resizable = DataGridViewTriState.False;
            col_nombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_nombre.Width = widthnombre;

            DataGridViewColumn col_apellido = dgResultados.Columns[2];
            col_apellido.Resizable = DataGridViewTriState.False;
            col_apellido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_apellido.Width = widthapellido;

            DataGridViewButtonColumn botonesModificar = new DataGridViewButtonColumn();
            botonesModificar.HeaderText = "";
            botonesModificar.Text = "Modificar";
            botonesModificar.Name = "bMod";
            botonesModificar.Width = widthBotones;
            botonesModificar.UseColumnTextForButtonValue = true;
            botonesModificar.Resizable = DataGridViewTriState.False;

            DataGridViewButtonColumn botonesEliminar = new DataGridViewButtonColumn();
            botonesEliminar.HeaderText = "";
            botonesEliminar.Text = "Eliminar";
            botonesEliminar.Name = "bElim";
            botonesEliminar.Width = widthBotones;
            botonesEliminar.UseColumnTextForButtonValue = true;
            botonesEliminar.Resizable = DataGridViewTriState.False;

            dgResultados.Columns.Add(botonesModificar);
            dgResultados.Columns.Add(botonesEliminar);
        }

        public void eliminarCliente(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inhabilitado.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarCliente frmCliente = new frmModificarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    frmCliente.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará al cliente " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value) + ", " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[4].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarCliente(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }
    }
}
