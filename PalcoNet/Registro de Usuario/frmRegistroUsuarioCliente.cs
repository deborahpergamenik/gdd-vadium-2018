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
            llenarCbTipoDoc();
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

        public void llenarCbTipoDoc()
        {
            this.cbTipoDocumento.Items.Add("DU");
            this.cbTipoDocumento.Items.Add("CI");
            this.cbTipoDocumento.Items.Add("LC");
        }

        public Boolean registrarCliente(string username, string passwordNoHash, string tipoDocumento, string numeroDocumento, string nombre, string apellido, string email, string telefono, string direccion, string codigoPostal, string nroPiso, string departamento, string localidad, DateTime fechaNacimiento)
        {
            try
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(passwordNoHash));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@NombreUsuario", username);
                SqlConnector.agregarParametro(listaParametros, "@Password", password);
                SqlConnector.agregarParametro(listaParametros, "@Intentos", 0);
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
                SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Usuario WHERE NombreUsuario = @NombreUsuario", listaParametros2, SqlConnector.iniciarConexion());
                lector.Read();
                int idUser = Convert.ToInt32(lector["IdUsuario"]);
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros3 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros3, "@IdUsuario", idUser);
                SqlConnector.agregarParametro(listaParametros3, "@Nombre", nombre);
                SqlConnector.agregarParametro(listaParametros3, "@Apellido", apellido);
                SqlConnector.agregarParametro(listaParametros3, "@TipoDoc", tipoDocumento);
                SqlConnector.agregarParametro(listaParametros3, "@NumDoc", numeroDocumento);
                SqlConnector.agregarParametro(listaParametros3, "@Cuil", direccion);
                SqlConnector.agregarParametro(listaParametros3, "@FechaNacimiento", fechaNacimiento);
                SqlConnector.agregarParametro(listaParametros3, "@FechaCreacion", DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null));

                SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Cliente (IdUsuario,Nombre,Apellido,TipoDoc,NumDoc,Cuil,FechaNacimiento,FechaCreacion) VALUES(@IdUsuario, @Nombre, @Apellido, @TipoDoc, @NumDoc, @Cuil, @FechaNacimiento, @FechaCreacion)", listaParametros3, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                List<SqlParameter> listaParametros4 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros4, "@Nombre", "Cliente");
                SqlDataReader lector1 = SqlConnector.ejecutarReader("SELECT IdRol FROM PalcoNet.Rol WHERE Nombre = @Nombre", listaParametros4, SqlConnector.iniciarConexion());
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
            if (cbTipoDocumento.SelectedIndex != -1 && !txtNumeroDocumento.Text.Equals("") && !txtNombre.Text.Equals("") && !txtApellido.Text.Equals("") && !txtEmail.Text.Equals("") && !txtDireccion.Text.Equals("") && !txtCodigoPostal.Text.Equals("") && cbDia.SelectedIndex != -1 && cbMes.SelectedIndex != -1 && cbAno.SelectedIndex != -1)
            {
                if (Interfaz.esNumerico(txtNumeroDocumento.Text, System.Globalization.NumberStyles.Integer))
                {
                    if (!SqlConnector.existenSimultaneamente(txtNumeroDocumento.Text, cbTipoDocumento.SelectedItem.ToString(), "PalcoNet.Clientes", "Num_Doc", "Tipo_Doc"))
                    {
                        if (Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer) || txtTelefono.Text.Equals(""))
                        {
                            if (!SqlConnector.existeTelefono(Convert.ToInt32(txtTelefono.Text)))
                            {
                                registrarCliente(username, password, cbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text, txtDireccion.Text, txtCodigoPostal.Text, txtNroPiso.Text, txtDepartamento.Text, txtLocalidad.Text, fechaNacimiento(cbDia.SelectedItem.ToString(), cbMes.SelectedItem.ToString(), cbAno.SelectedItem.ToString()));
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
    }
}
