using PalcoNet.Common;
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
                this.cbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 1; i <= 12; i++)
            {
                this.cbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCbAno()
        {
            int i;
            for (i = 1914; i <= 2014; i++)
            {
                this.cbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCbtipoDocumento()
        {
            this.cbtipoDocumentoumento.Items.Add("DU");
            this.cbtipoDocumentoumento.Items.Add("CI");
            this.cbtipoDocumentoumento.Items.Add("LC");
        }

        public Boolean registrarCliente(string username, string passwordNoHash, string tipoDocumentoumento, string numeroDocumento, string CUIL, string nombre, string apellido, string mail, string telefono, string direccion, string cod_postal, string nroPiso, string departamento, string localidad, DateTime fechaNacimiento)
        {
            try
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@usuario_username", username);
                SqlConnector.agregarParametro(listaParametros, "@password", password);
                SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", 0);
                SqlConnector.agregarParametro(listaParametros, "@primera_vez", 0);

                SqlConnector.agregarParametro(listaParametros, "@mail", mail);                
                SqlConnector.agregarParametro(listaParametros, "@direccion", direccion);
                if (telefono.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros, "@telefono", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros, "@telefono", Convert.ToInt64(telefono));
                }

                SqlConnector.agregarParametro(listaParametros, "@NroPiso", nroPiso);
                SqlConnector.agregarParametro(listaParametros, "@Departamento", departamento);
                SqlConnector.agregarParametro(listaParametros, "@Localidad", localidad);
                SqlConnector.agregarParametro(listaParametros, "@cod_postal", cod_postal);
                SqlConnector.agregarParametro(listaParametros, "@usuario_activo", 1);

                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO (usuario_username, password, usuario_intentosLogin, primera_vez, mail, direccion, telefono, NroPiso, Departamento, Localidad, cod_postal, usuario_activo) VALUES (@usuario_username, @password, @usuario_intentosLogin, @primera_vez, @mail, @direccion, @telefono, @NroPiso, @Departamento, @Localidad, @cod_postal, @usuario_activo)", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@usuario_username", username);
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@usuario_id", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@nombre", nombre);
                SqlConnector.agregarParametro(listaParametros3, "@apellido", apellido);
                SqlConnector.agregarParametro(listaParametros3, "@tipoDocumento", tipoDocumentoumento);
                SqlConnector.agregarParametro(listaParametros3, "@numeroDocumento", numeroDocumento);
                SqlConnector.agregarParametro(listaParametros3, "@CUIL", CUIL);
                SqlConnector.agregarParametro(listaParametros3, "@FechaNacimiento", fechaNacimiento);
                SqlConnector.agregarParametro(listaParametros3, "@fechaCreacion", DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null));

                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.CLIENTE (usuario_id,nombre,apellido,tipoDocumento,numeroDocumento,CUIL,FechaNacimiento,fechaCreacion) VALUES(@usuario_id, @nombre, @apellido, @tipoDocumento, @numeroDocumento, @CUIL, @FechaNacimiento, @fechaCreacion)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@nombre", "Cliente");
                SqlDataReader lector1 = SqlConnector.ejecutarReader("SELECT rol_id FROM VADIUM.ROL WHERE nombre = @nombre", listaParametros4, SqlConnector.iniciarConexion());
                lector1.Read();
                int rol_id = Convert.ToInt32(lector1["rol_id"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros5 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros5, "@rol_id", rol_id);
                SqlConnector.agregarParametro(listaParametros5, "@usuario_id", idUser);
                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.ROL_POR_USUARIO VALUES(@usuario_id, @rol_id)", listaParametros5, SqlConnector.iniciarConexion());
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
            if (cbtipoDocumentoumento.SelectedIndex != -1 && !txtNumeroDocumento.Text.Equals("") && !txtCUIL.Text.Equals("") && !txtnombre.Text.Equals("") && !txtapellido.Text.Equals("") && !txtmail.Text.Equals("") && !txtdireccion.Text.Equals("") && !txtcod_postal.Text.Equals("") && cbDia.SelectedIndex != -1 && cbMes.SelectedIndex != -1 && cbAno.SelectedIndex != -1)
            {
                if (Interfaz.esNumerico(txtNumeroDocumento.Text, System.Globalization.NumberStyles.Integer))
                {
                    if (!SqlConnector.existenSimultaneamente(txtNumeroDocumento.Text, cbtipoDocumentoumento.SelectedItem.ToString(), "VADIUM.CLIENTEs", numeroDocumento, "Tipo_Doc"))
                    {
                        if (Interfaz.esNumerico(txttelefono.Text, System.Globalization.NumberStyles.Integer) || txttelefono.Text.Equals(""))
                        {
                            if (!SqlConnector.existetelefono(Convert.ToInt32(txttelefono.Text)))
                            {
                                registrarCliente(username, password, cbtipoDocumentoumento.SelectedItem.ToString(), txtNumeroDocumento.Text, txtCUIL.Text, txtnombre.Text, txtapellido.Text, txtmail.Text, txttelefono.Text, txtdireccion.Text, txtcod_postal.Text, txtNroPiso.Text, txtDepartamento.Text, txtLocalidad.Text, fechaNacimiento(cbDia.SelectedItem.ToString(), cbMes.SelectedItem.ToString(), cbAno.SelectedItem.ToString()));
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
    }
}
