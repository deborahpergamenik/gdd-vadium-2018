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
                SqlConnector.agregarParametro(listaParametros, "@usuario_username", username);
                SqlConnector.agregarParametro(listaParametros, "@usuario_password", password);
                SqlConnector.agregarParametro(listaParametros, "@usuario_intentosLogin", 0);
                SqlConnector.agregarParametro(listaParametros, "@usuario_activo", 1);
                SqlConnector.agregarParametro(listaParametros, "@primera_vez", 0);
                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.USUARIO (usuario_username, usuario_password, usuario_intentosLogin, usuario_activo, primera_vez) VALUES (@usuario_username, @usuario_password, @usuario_intentosLogin, @usuario_activo, @primera_vez)", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@usuario_username", username);
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();


                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@usuario_id", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@razonSocial", razonSocial);
                SqlConnector.agregarParametro(listaParametros3, "@cuit", cuit);
                SqlConnector.agregarParametro(listaParametros3, "@calle", direccion);
                SqlConnector.agregarParametro(listaParametros3, "@cod_postal", cod_postal);
                SqlConnector.agregarParametro(listaParametros3, "@mail", mail);
                SqlConnector.agregarParametro(listaParametros3, "@fechaCreacion", fechaCreacion);
                SqlConnector.agregarParametro(listaParametros3, "@piso", nroPiso);
                SqlConnector.agregarParametro(listaParametros3, "@depto", departamento);
                SqlConnector.agregarParametro(listaParametros3, "@localidad", localidad);
               
                if (telefono.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros3, "@telefono", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros3, "@telefono", Convert.ToInt64(telefono));
                }
                
                if (ciudad.Equals(""))
                {
                    SqlConnector.agregarParametro(listaParametros3, "@ciudad", DBNull.Value);
                }
                else
                {
                    SqlConnector.agregarParametro(listaParametros3, "@ciudad", ciudad);
                }


                SqlConnector.ejecutarQuery("INSERT INTO VADIUM.EMPRESA (usuario_id,razonSocial,cuit,calle, cod_postal, mail, fechaCreacion, piso, depto ,localidad, telefono, ciudad)" +
                    "VALUES(@usuario_id,@razonSocial,@cuit,@calle, @cod_postal, @mail, @fechaCreacion, @piso, @depto ,@localidad, @telefono, @ciudad)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@rol_id", "EMPRESA");
                SqlDataReader lector1 = SqlConnector.ejecutarReader("SELECT rol_id FROM VADIUM.ROL WHERE rol_id = @rol_id", listaParametros4, SqlConnector.iniciarConexion());
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
                if (!SqlConnector.existeString(txtrazonSocial.Text, "VADIUM.EMPRESA", "Razon_Social"))
                {
                    if (!SqlConnector.existeString(txtcuit.Text, "VADIUM.EMPRESA", "cuit"))
                    {
                        if (Interfaz.esNumerico(txttelefono.Text, System.Globalization.NumberStyles.Integer) || txttelefono.Text.Equals(""))
                        {
                            if (!SqlConnector.existetelefono(Convert.ToInt32(txttelefono.Text)))
                            {
                                registrarEmpresa(username, password, txtrazonSocial.Text, txtcuit.Text, txttelefono.Text, txtdireccion.Text, txtcod_postal.Text, txtciudad.Text, txtmail.Text, txtLocalidad.Text,txtNroPiso.Text, txtDepartamento.Text, Configuration.getActualDate());
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
