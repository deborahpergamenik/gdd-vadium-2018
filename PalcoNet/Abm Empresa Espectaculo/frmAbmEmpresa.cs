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
            formatearDataGrid();
        }

        public class ResultadoEmpresa
        {
            public int usuario_id { get; set; }
            public string razonSocial { get; set; }

            public ResultadoEmpresa(int _usuario_id, string _razonSocial)
            {
                usuario_id = _usuario_id;
                razonSocial = _razonSocial;
            }
        }

        public List<ResultadoEmpresa> resultados = new List<ResultadoEmpresa>();

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
                            this.cod_postal = txtCodPostal.Text;
                            this.mail = txtMail.Text;
                            this.localidad = txtLocalidad.Text;
                            this.nroPiso = txtNroPiso.Text;
                            this.departamentro = txtDepartamento.Text;
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
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);

            SqlConnector.agregarParametro(listaParametros, "@razonSocial", txtFilterRazonSocial.Text);
            SqlConnector.agregarParametro(listaParametros, "@telefono", txtFilterTelefono.Text);
            SqlConnector.agregarParametro(listaParametros, "@mail", txtFilterEmail.Text);

            //revisar query
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
            int widthrazonSocial = 227;
            int widthBotones = 85;

            dgResultados.DataSource = dgResultados;
            dgResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResultados.RowHeadersVisible = false;

            DataGridViewColumn col_idUser = dgResultados.Columns[0];
            col_idUser.Visible = false;

            DataGridViewColumn col_razonSocial = dgResultados.Columns[1];
            col_razonSocial.Resizable = DataGridViewTriState.False;
            col_razonSocial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col_razonSocial.Width = widthrazonSocial;

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

        public void eliminarEmpresa(int id)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
            MessageBox.Show("Usuario inusuario_activo.");
        }

        private void dgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    frmModificarEmpresa frmEmpresa = new frmModificarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    frmEmpresa.Show();
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Se inhabilitará a la empresa " + Convert.ToString(dgResultados.Rows[e.RowIndex].Cells[3].Value) + ".\n\n¿Está seguro?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        eliminarEmpresa(Convert.ToInt32(dgResultados.Rows[e.RowIndex].Cells[2].Value));
                    }
                    break;
            }
        }


    }
}
