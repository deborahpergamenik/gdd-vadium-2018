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
using System.Text.RegularExpressions;
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
        public long telefono { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string ciudad { get; set; }
        public string mail { get; set; }
        public string departamento { get; set; }
        public string nroPiso { get; set; }
        public string localidad { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string passwordNoHash { get; set; }

        public frmSeleccionFuncionalidades frmSeleccionFuncionalidades { get; set; }

        public frmAbmEmpresa(Login.frmSeleccionFuncionalidades _frmSeleccionFuncionalidades)
        {
            this.frmSeleccionFuncionalidades = _frmSeleccionFuncionalidades;
            InitializeComponent();
            formatearDataGrid();
            CargarDatos(string.Empty, string.Empty, string.Empty);
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
            if (!campoVacio(txtRazonSocial) && !campoVacio(txtMail) && !campoVacio(txtDireccion) && !campoVacio(txtCodPostal) && !campoVacio(txtCuit))
            {
                if (campoVacio(txtTelefono) || (!campoVacio(txtTelefono) && campoNumerico(txtTelefono)))
                {
                    if (!SqlConnector.existeString(txtRazonSocial.Text, "VADIUM.EMPRESA", "razonSocial"))
                    {
                        if (!SqlConnector.existeString(txtCuit.Text, "VADIUM.EMPRESA", "cuit"))
                        {

                            if (!campoVacio(txtTelefono))
                            {
                                this.telefono = Convert.ToInt64(txtTelefono.Text);
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
                            this.cod_postal = txtCodPostal.Text;
                            this.mail = txtMail.Text;
                            this.localidad = txtLocalidad.Text;
                            this.nroPiso = txtNroPiso.Text;
                            this.departamento = txtDepartamento.Text;
                            this.fechaCreacion = Configuration.getActualDate();

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cuit ya existente.", "Error");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Razón social ya existente.", "Error");
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
            string random = "PalcoNet_Empresa_" + randomString(10);
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

        public void cargarEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int idUser = Convert.ToInt32(lector["usuario_id"]);
            SqlConnector.cerrarConexion();

            
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@usuario_id", idUser);
            SqlConnector.agregarParametro(listaParametros2, "@razonSocial", this.razonSocial);
            SqlConnector.agregarParametro(listaParametros2, "@cuit", this.cuit);
            SqlConnector.agregarParametro(listaParametros2, "@calle", this.direccion);
            SqlConnector.agregarParametro(listaParametros2, "@cod_postal", this.cod_postal);
            SqlConnector.agregarParametro(listaParametros2, "@mail", this.mail);
            SqlConnector.agregarParametro(listaParametros2, "@fechaCreacion", this.fechaCreacion);
            SqlConnector.agregarParametro(listaParametros2, "@ciudad", this.ciudad);
            SqlConnector.agregarParametro(listaParametros2, "@depto", this.departamento);
            SqlConnector.agregarParametro(listaParametros2, "@localidad", this.localidad);

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
                SqlConnector.agregarParametro(listaParametros2, "@piso", this.nroPiso);
            }


            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.EMPRESA (usuario_id,razonSocial,cuit,calle, cod_postal, mail, fechaCreacion, piso, depto ,localidad, telefono, ciudad)" +
                                       "VALUES(@usuario_id,@razonSocial,@cuit,@calle, @cod_postal, @mail, @fechaCreacion, @piso, @depto ,@localidad, @telefono, @ciudad)", listaParametros2, SqlConnector.iniciarConexion());
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
                new Abm_Cliente.frmConfirmacionCliente(this.usuario_username, this.passwordNoHash).Show(); //reutilizo el formulario de confirmación de ABM Clientes
                CargarDatos(string.Empty, string.Empty, string.Empty);
                dgResultados.Refresh();
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

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargarDatos(txtFilterRazonSocial.Text, txtFilterCuit.Text, txtFilterEmail.Text);
        }

        public void CargarDatos(string razonSocial, string cuit, string mail)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@razonSocial", razonSocial);
            SqlConnector.agregarParametro(listaParametros, "@CUIT", cuit);
            SqlConnector.agregarParametro(listaParametros, "@mail", mail);


            String commandtext = "VADIUM.LISTADO_SELECCION_EMPRESA";
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
            int widthBotones = 85;

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
                        frmModificarEmpresa frmEmpresa = new frmModificarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[3].Value), this);
                        frmEmpresa.Show();
                        break;
                    case 1:
                        DialogResult result = MessageBox.Show("Se inhabilitará a la empresa " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[5].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            eliminarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[3].Value));
                        }
                        CargarDatos(string.Empty, string.Empty, string.Empty);
                        dgResultados.Refresh();
                        break;
                }         
            }
        }

        public void eliminarEmpresa(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inhabilitado.");
        }

        private void frmAbmEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
