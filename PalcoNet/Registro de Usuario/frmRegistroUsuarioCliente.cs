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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class frmRegistroUsuarioCliente : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public frmRegistroUsuarioCliente(string user, string pass, int rol)
        {
            this.username = user;
            this.password = pass;
            this.rol = rol;
            InitializeComponent();

            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbtipoDocumento();
        }

        public void llenarCbDia()
        {
            int i;
            for (i = 1; i <= 31; i++)
            {
                this.cmbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 1; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCbAno()
        {
            int i;
            for (i = 1914; i <= 2014; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCbtipoDocumento()
        {
            this.cmbTipoDocumento.Items.Add("DU");
            this.cmbTipoDocumento.Items.Add("CI");
            this.cmbTipoDocumento.Items.Add("LC");
        }

        public Boolean registrarCliente(string username, string passwordNoHash, string tipoDocumentoumento, string numeroDocumento, string CUIL, string nombre, string apellido, string mail, string telefono, string direccion, string cod_postal, string nroPiso, string departamento, string localidad, DateTime fechaNacimiento)
        {
            try
            {
                //UTF8Encoding encoderHash = new UTF8Encoding();
                //SHA256Managed hasher = new SHA256Managed();
                //byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                //string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@usuario_username", username);
                SqlConnector.agregarParametro(listaParametros, "@usuario_password", passwordNoHash);
                SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", 0);
                SqlConnector.agregarParametro(listaParametros, "@usuario_activo", 1);
                SqlConnector.agregarParametro(listaParametros, "@primera_vez", 0);
                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO (usuario_username, usuario_password, usuario_intentosLogin, usuario_activo, primera_vez) VALUES (@usuario_username, CONVERT(BINARY(32), @usuario_password), @usuario_intentosLogin, @usuario_activo, @primera_vez)", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@usuario_username", username);
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();


                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@usuario_id", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@tipoDocumento", tipoDocumentoumento);
                SqlConnector.agregarParametro(listaParametros3, "@numeroDocumento", Convert.ToInt32(numeroDocumento));
                SqlConnector.agregarParametro(listaParametros3, "@CUIL", CUIL);
                SqlConnector.agregarParametro(listaParametros3, "@nombre", nombre);
                SqlConnector.agregarParametro(listaParametros3, "@apellido", apellido);
                SqlConnector.agregarParametro(listaParametros3, "@mail", mail);
                SqlConnector.agregarParametro(listaParametros3, "@calle", direccion);
                SqlConnector.agregarParametro(listaParametros3, "@cod_postal", cod_postal);
                SqlConnector.agregarParametro(listaParametros3, "@fechaNacimiento", fechaNacimiento);
                SqlConnector.agregarParametro(listaParametros3, "@fechaCreacion", Configuration.getActualDate());
                SqlConnector.agregarParametro(listaParametros3, "@tarjetaCredito", 1); //cambiar este campo
                SqlConnector.agregarParametro(listaParametros3, "@localidad", localidad);
                SqlConnector.agregarParametro(listaParametros3, "@piso", nroPiso);
                SqlConnector.agregarParametro(listaParametros3, "@depto", departamento);

                if (telefono.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros3, "@telefono", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros3, "@telefono", Convert.ToInt64(telefono));
                }

                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.CLIENTE (usuario_id, tipoDocumento, numeroDocumento, CUIL, apellido, nombre, mail, calle, cod_postal, fechaNacimiento, fechaCreacion, tarjetaCredito,localidad, piso, depto)" +
                                           "VALUES(@usuario_id, @tipoDocumento, @numeroDocumento, @CUIL, @nombre, @apellido, @mail, @calle, @cod_postal, @fechaNacimiento, @fechaCreacion, @tarjetaCredito,@localidad, @piso, @depto)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@rol_nombre", "CLIENTE");
                SqlDataReader lector1 = SqlConnector.ejecutarReader("SELECT rol_id FROM VADIUM.ROL WHERE rol_nombre = @rol_nombre", listaParametros4, SqlConnector.iniciarConexion());
                lector1.Read();
                int idRol = Convert.ToInt32(lector1["rol_id"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros5 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros5, "@rol_id", idRol);
                SqlConnector.agregarParametro(listaParametros5, "@usuario_id", idUser);
                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.ROL_POR_USUARIO(usuario_id, rol_id) VALUES(@usuario_id, @rol_id)", listaParametros5, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                return true;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message.ToString());
                return false;
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

        public DateTime fechaNacimiento(string dia, string mes, string ano)
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


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex != -1 && !txtNumeroDocumento.Text.Equals("") && !txtCUIL.Text.Equals("") && !txtNombre.Text.Equals("") && !txtApellido.Text.Equals("") && !txtMail.Text.Equals("") && !txtDireccion.Text.Equals("") && !txtCodPostal.Text.Equals("") && cmbDia.SelectedIndex != -1 && cmbMes.SelectedIndex != -1 && cmbAno.SelectedIndex != -1)
            {
                if (Interfaz.esNumerico(txtNumeroDocumento.Text, System.Globalization.NumberStyles.Integer))
                {
                    if (!SqlConnector.existenSimultaneamente(txtNumeroDocumento.Text, cmbTipoDocumento.SelectedItem.ToString(), "VADIUM.CLIENTE", "numeroDocumento", "tipoDocumento"))
                    {
                        if (Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer))
                        {
                            if (!SqlConnector.existetelefono(Convert.ToInt32(txtTelefono.Text)))
                            {
                                registrarCliente(username, password, cmbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, txtCUIL.Text, txtNombre.Text, txtApellido.Text, txtMail.Text, txtTelefono.Text, txtDireccion.Text, txtCodPostal.Text, txtNroPiso.Text, txtDepartamento.Text, txtLocalidad.Text, fechaNacimiento(cmbDia.SelectedItem.ToString(), cmbMes.SelectedItem.ToString(), cmbAno.SelectedItem.ToString()));
                                MessageBox.Show("Alta finalizada. Puede ingresar al sistema.", "Registro exitoso");
                                frmLogin frmLogin = new frmLogin();
                                this.Hide();
                                frmLogin.Show();
                            }
                            else
                            {
                                MessageBox.Show("Teléfono existente.", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Teléfono inválido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos identificatorios (Tipo de documento, Número de documento) ya existentes.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Número de documento inválido.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos solicitados.", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }


        private void textboxNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textboxNoNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }
        }

        private void txtCUIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
