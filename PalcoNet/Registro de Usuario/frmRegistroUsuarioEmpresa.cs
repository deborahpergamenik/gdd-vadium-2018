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
    public partial class frmRegistroUsuarioEmpresa : Form
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public frmRegistroUsuarioEmpresa(string user, string pass, int rol)
        {
            this.username = user;
            this.password = pass;
            this.rol = rol;
            InitializeComponent();
        }

        public Boolean registrarEmpresa(string username, string passwordNoHash, string razonSocial, string cuit, string telefono, string direccion, string cod_postal, string ciudad, string mail, string localidad, string nroPiso, string departamento, DateTime fechaCreacion)
        {
            try
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@Username", username);
                SqlConnector.agregarParametro(listaParametros, "@password", password);
                SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", 0);
                SqlConnector.agregarParametro(listaParametros, "@usuario_activo", 1);
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
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE Username = @Username", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@usuario_id", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@razonSocial", razonSocial);
                SqlConnector.agregarParametro(listaParametros3, "@cuit", cuit);

                if (ciudad.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros3, "@ciudad", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros3, "@ciudad", ciudad);
                }

                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.EMPRESA VALUES(@usuario_id, @razonSocial, @cuit, @ciudad)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@nombre", "Empresa");
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!txtrazonSocial.Text.Equals("") && !txtcuit.Text.Equals("") && !txtdireccion.Text.Equals("") && !txtcod_postal.Text.Equals("") && !txtmail.Text.Equals(""))
            {
                if (!SqlConnector.existeString(txtrazonSocial.Text, "VADIUM.EMPRESAs", "Razon_Social"))
                {
                    if (!SqlConnector.existeString(txtcuit.Text, "VADIUM.EMPRESAs", "cuit"))
                    {
                        if (Interfaz.esNumerico(txttelefono.Text, System.Globalization.NumberStyles.Integer) || txttelefono.Text.Equals(""))
                        {
                            if (!SqlConnector.existetelefono(Convert.ToInt32(txttelefono.Text)))
                            {
                                registrarEmpresa(username, password, txtrazonSocial.Text, txtcuit.Text, txttelefono.Text, txtdireccion.Text, txtcod_postal.Text, txtciudad.Text, txtmail.Text, txtLocalidad.Text,txtNroPiso.Text, txtDepartamento.Text, DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null));
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
                            MessageBox.Show("Teléfono inválido existente.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("cuit ya existente.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Razón Social ya existente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos solicitados.", "Error");
            }
        }
    }
}
