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

        public Boolean registrarEmpresa(string username, string passwordNoHash, string razonSocial, string cuit, string telefono, string direccion, string codigoPostal, string ciudad, string email, string localidad, string nroPiso, string departamento, DateTime fechaCreacion)
        {
            try
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@Username", username);
                SqlConnector.agregarParametro(listaParametros, "@Password", password);
                SqlConnector.agregarParametro(listaParametros, "@Intentos", 0);
                SqlConnector.agregarParametro(listaParametros, "@Estado", 1);
                SqlConnector.agregarParametro(listaParametros, "@Primera_Vez", 0);

                SqlConnector.agregarParametro(listaParametros, "@Email", email);
                SqlConnector.agregarParametro(listaParametros, "@Direccion", direccion);
                if (telefono.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros, "@Telefono", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros, "@Telefono", Convert.ToInt64(telefono));
                }

                SqlConnector.agregarParametro(listaParametros, "@NroPiso", nroPiso);
                SqlConnector.agregarParametro(listaParametros, "@Departamento", departamento);
                SqlConnector.agregarParametro(listaParametros, "@Localidad", localidad);
                SqlConnector.agregarParametro(listaParametros, "@CodigoPostal", codigoPostal);
                SqlConnector.agregarParametro(listaParametros, "@Estado", 1);

                SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Usuario (NombreUsuario, Password, Intentos, Primera_Vez, Email, Direccion, Telefono, NroPiso, Departamento, Localidad, CodigoPostal, Estado) VALUES (@NombreUsuario, @Password, @Intentos, @Primera_Vez, @Email, @Direccion, @Telefono, @NroPiso, @Departamento, @Localidad, @CodigoPostal, @Estado)", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@NombreUsuario", username);
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Usuario WHERE Username = @Username", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["IdUsuario"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@IdUsuario", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@RazonSocial", razonSocial);
                SqlConnector.agregarParametro(listaParametros3, "@CUIT", cuit);

                if (ciudad.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros3, "@Ciudad", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros3, "@Ciudad", ciudad);
                }

                SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Empresa VALUES(@IdUsuario, @RazonSocial, @Cuit, @Ciudad)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@Nombre", "Empresa");
                SqlDataReader lector1 = SqlConnector.ejecutarReader("SELECT ID_Rol FROM PalcoNet.Rol WHERE Nombre = @Nombre", listaParametros4, SqlConnector.iniciarConexion());
                lector1.Read();
                int idRol = Convert.ToInt32(lector1["IdRol"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros5 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros5, "@IdRol", idRol);
                SqlConnector.agregarParametro(listaParametros5, "@IdUsuario", idUser);
                SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Rol_Usuario VALUES(@IdUsuario, @IdRol)", listaParametros5, SqlConnector.iniciarConexion());
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
            if (!txtRazonSocial.Text.Equals("") && !txtCuil.Text.Equals("") && !txtDireccion.Text.Equals("") && !txtCodigoPostal.Text.Equals("") && !txtEmail.Text.Equals(""))
            {
                if (!SqlConnector.existeString(txtRazonSocial.Text, "PalcoNet.Empresas", "Razon_Social"))
                {
                    if (!SqlConnector.existeString(txtCuil.Text, "PalcoNet.Empresas", "CUIT"))
                    {
                        if (Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer) || txtTelefono.Text.Equals(""))
                        {
                            if (!SqlConnector.existeTelefono(Convert.ToInt32(txtTelefono.Text)))
                            {
                                registrarEmpresa(username, password, txtRazonSocial.Text, txtCuil.Text, txtTelefono.Text, txtDireccion.Text, txtCodigoPostal.Text, txtCiudad.Text, txtEmail.Text, txtLocalidad.Text,txtNroPiso.Text, txtDepartamento.Text, DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null));
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
                        MessageBox.Show("CUIT ya existente.", "Error");
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
