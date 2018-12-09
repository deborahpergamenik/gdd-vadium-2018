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

namespace PalcoNet.Abm_Cliente
{
    public partial class frmModificarCliente : Form
    {
        public frmBuscarCliente frmBuscarCliente { get; set; }

        public int usuario_id { get; set; }

        public string Usuario { get; set; }
        public string Passoword { get; set; }
        public int usuario_activo { get; set; }

        public int tipoDocumentoumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string CUIL { get; set; }
        public string Localidad { get; set; }
        public string NroPiso { get; set; }
        public string Departamento { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public frmModificarCliente(int _usuario_id)
        {
            this.usuario_id = _usuario_id;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosCliente();
            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.Usuario = txtUsuario.Text;
            this.Passoword = txtpassword.Text;
            this.usuario_activo = cmbusuario_activo.SelectedIndex;

            this.tipoDocumentoumento = cmbtipoDocumentoumento.SelectedIndex;
            this.NumeroDocumento = txtNumeroDocumento.Text;
            this.nombre = txtnombre.Text;
            this.apellido = txtapellido.Text;
            this.mail = txtmail.Text;
            this.telefono = txttelefono.Text;
            this.direccion = txtdireccion.Text;
            this.cod_postal = txtcod_postal.Text;
            this.Departamento = txtDepartamento.Text;
            this.NroPiso = txtNroPiso.Text;
            this.CUIL = txtCUIL.Text;
            this.Localidad = txtLocalidad.Text;
            this.Dia = cmbDia.SelectedIndex;
            this.Mes = cmbMes.SelectedIndex;
            this.Ano = cmbAno.SelectedIndex;
        }

        public void setearComboBoxes()
        {
            llenarCbDia();
            llenarCbMes();
            llenarCbAno();
            llenarCbtipoDocumento();
            llenarCbHabilitado();
        }

        public void llenarCbtipoDocumento()
        {
            this.cmbtipoDocumentoumento.Items.Add("DU");
            this.cmbtipoDocumentoumento.Items.Add("CI");
            this.cmbtipoDocumentoumento.Items.Add("LC");
        }

        public void llenarCbHabilitado()
        {
            this.cmbusuario_activo.Items.Add("No");
            this.cmbusuario_activo.Items.Add("Sí");
        }

        public void llenarCbDia()
        {
            int i;
            for (i = 0; i <= 31; i++)
            {
                this.cmbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCbMes()
        {
            int i;
            for (i = 0; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCbAno()
        {
            int i;
            for (i = 1000; i <= 2014; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosCliente()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT tipoDocumento, numeroDocumento, CUIL, nombre, apellido, mail, telefono, direccion, cod_postal, DAY(fechaNacimiento) AS fechaNacimiento_Dia, MONTH(fechaNacimiento) AS fechaNacimiento_Mes, YEAR(fechaNacimiento) AS fechaNacimiento_Ano FROM VADIUM.CLIENTE WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            if (Convert.ToString(lector["tipoDocumentoumento"]) == "DU")
            {
                cmbtipoDocumentoumento.SelectedIndex = 0;
            }

            if (Convert.ToString(lector["tipoDocumentoumento"]) == "CI")
            {
                cmbtipoDocumentoumento.SelectedIndex = 1;
            }

            if (Convert.ToString(lector["tipoDocumentoumento"]) == "LC")
            {
                cmbtipoDocumentoumento.SelectedIndex = 2;
            }

            txtNumeroDocumento.Text = Convert.ToInt64(lector["numeroDocumento"]).ToString();
            txtnombre.Text = Convert.ToString(lector["nombre"]);
            txtapellido.Text = Convert.ToString(lector["apellido"]);
            txtmail.Text = Convert.ToString(lector["mail"]);

            if (lector["telefono"] != DBNull.Value)
            {
                txttelefono.Text = Convert.ToInt64(lector["telefono"]).ToString();
            }
            else
            {
                txttelefono.Text = "";
            }

            txtdireccion.Text = Convert.ToString(lector["direccion"]);
            txtcod_postal.Text = Convert.ToString(lector["cod_postal"]);

            cmbDia.SelectedIndex = Convert.ToInt32(lector["fechaNacimiento_Dia"]);
            cmbMes.SelectedIndex = Convert.ToInt32(lector["fechaNacimiento_Mes"]);
            cmbAno.SelectedIndex = Convert.ToInt32(lector["fechaNacimiento_Ano"]) - 1000;

            SqlConnector.cerrarConexion();
        }

        public void cargarDatosUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_username, usuario_activo FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtUsuario.Text = Convert.ToString(lector["usuario_username"]);

            if (Convert.ToInt32(lector["usuario_activo"]) == 0)
            {
                cmbusuario_activo.SelectedIndex = 0;
            }
            else
            {
                cmbusuario_activo.SelectedIndex = 1;
            }

            SqlConnector.cerrarConexion();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            string resumenModificaciones = "Se han modificado los campos:";
            string resumenErrores = "No se han podido modificar los campos:";

            Boolean modificacion = false;
            Boolean error = false;

            if (cambioString(this.Usuario, txtUsuario.Text))
            {
                if (usernameValido())
                {
                    cambiarStringUsuarios("usuario_username", txtUsuario.Text);
                    resumenModificaciones = resumenModificaciones + "\nnombre de usuario";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("nombre de usuario inválido.", "Error");
                    resumenErrores = resumenErrores + "\nnombre de usuario (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.Passoword, txtpassword.Text))
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtpassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
                SqlConnector.agregarParametro(listaParametros, "@password", password);
                SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET password = @password, primera_vez = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                resumenModificaciones = resumenModificaciones + "\nContraseña";
                modificacion = true;
            }

            if (cambioInt(this.usuario_activo, cmbusuario_activo.SelectedIndex))
            {
                cambiarIntUsuarios("usuario_activo", cmbusuario_activo.SelectedIndex);
                resumenModificaciones = resumenModificaciones + "\nusuario_activo";
                modificacion = true;
            }


            if (cambioString(this.CUIL, txtCUIL.Text))
            {
                if (!txtCUIL.Text.Equals("") && !SqlConnector.existeString(txtCUIL.Text, "VADIUM.CLIENTE", "cuil") && txtCUIL.Text.Length <= 50)
                {
                    cambiarStringClientes("cuil", txtCUIL.Text);
                    resumenModificaciones = resumenModificaciones + "\ncuil";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("cuil inválido.", "Error");
                    resumenErrores = resumenErrores + "\ncuil (no ingresado o ya existente)";
                    error = true;
                }
            }


            if (cambioInt(this.tipoDocumentoumento, cmbtipoDocumentoumento.SelectedIndex))
            {
                if (numeroDeDocumentoValido())
                {
                    if (!SqlConnector.existenSimultaneamente(cmbtipoDocumentoumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "VADIUM.CLIENTE", "tipoDocumentoumento", "numeroDocumento"))
                    {
                        switch (cmbtipoDocumentoumento.SelectedIndex)
                        {
                            case 0:
                                cambiarStringClientes("tipoDocumentoumento", "DU");
                                break;
                            case 1:
                                cambiarStringClientes("tipoDocumentoumento", "CI");
                                break;
                            case 2:
                                cambiarStringClientes("tipoDocumentoumento", "LC");
                                break;
                        }
                        resumenModificaciones = resumenModificaciones + "\nTipo de documento";
                        modificacion = true;
                    }
                    else
                    {
                        resumenErrores = resumenErrores + "\nTipo de documento (ya existente)";
                        error = true;
                    }
                }
                else
                {
                    //MessageBox.Show("Tipo y/o número de documento inválido/s.", "Error");
                    resumenErrores = resumenErrores + "\nTipo de documento (número de documento no ingresado o inválido)";
                    error = true;
                }
            }

            if (cambioString(this.NumeroDocumento, txtNumeroDocumento.Text))
            {
                if (numeroDeDocumentoValido())
                {
                    if (!SqlConnector.existenSimultaneamente(cmbtipoDocumentoumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "VADIUM.CLIENTE", "tipoDocumentoumento", "numeroDocumento"))
                    {
                        cambiarLongIntClientes("numeroDocumento", Convert.ToInt64(txtNumeroDocumento.Text));
                        resumenModificaciones = resumenModificaciones + "\nNúmero de documento";
                        modificacion = true;
                    }
                    else
                    {
                        resumenErrores = resumenErrores + "\nNúmero de documento (ya existente)";
                        error = true;
                    }
                }
                else
                {
                    //MessageBox.Show("Número de documento inválido.", "Error");
                    resumenErrores = resumenErrores + "\nNúmero de documento (no ingresado o inválido)";
                    error = true;
                }
            }

            if (cambioString(this.nombre, txtnombre.Text))
            {
                if (!txtnombre.Text.Equals(""))
                {
                    cambiarStringClientes("nombre", txtnombre.Text);
                    resumenModificaciones = resumenModificaciones + "\nnombre";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nnombre (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.apellido, txtapellido.Text))
            {
                if (!txtapellido.Text.Equals(""))
                {
                    cambiarStringClientes("apellido", txtapellido.Text);
                    resumenModificaciones = resumenModificaciones + "\napellido";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\napellido (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.mail, txtmail.Text))
            {
                if (!txtmail.Text.Equals(""))
                {
                    cambiarStringClientes("mail", txtmail.Text);
                    resumenModificaciones = resumenModificaciones + "\nE-mail";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nE-mail (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.telefono, txttelefono.Text))
            {
                if (txttelefono.Text.Equals("") || ((Interfaz.esNumerico(txttelefono.Text, System.Globalization.NumberStyles.Integer)) && (txttelefono.Text.Length <= 18)))
                {
                    if (txttelefono.Text.Equals(""))
                    {
                        cambiarNullClientes("telefono");
                        resumenModificaciones = resumenModificaciones + "\nTeléfono";
                        modificacion = true;
                    }
                    else
                    {
                        if (!SqlConnector.existeString(txttelefono.Text, "VADIUM.CLIENTE", "telefono"))
                        {
                            cambiarLongIntClientes("telefono", Convert.ToInt64(txttelefono.Text));
                            resumenModificaciones = resumenModificaciones + "\nTeléfono";
                            modificacion = true;
                        }
                        else
                        {
                            resumenErrores = resumenErrores + "\nTeléfono (ya existente)";
                            error = true;
                        }
                    }
                }
                else
                {
                    resumenErrores = resumenErrores + "\nTeléfono (valor no numérico o muy grande)";
                    error = true;
                }
            }

            if (cambioString(this.direccion, txtdireccion.Text))
            {
                if (!txtdireccion.Text.Equals(""))
                {
                    cambiarStringClientes("direccion", txtdireccion.Text);
                    resumenModificaciones = resumenModificaciones + "\nDirección";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDirección (no ingresada)";
                    error = true;
                }
            }

            if (cambioString(this.cod_postal, txtcod_postal.Text))
            {
                if (!txtcod_postal.Text.Equals(""))
                {
                    if (txtcod_postal.Text.Length <= 50)
                    {
                        cambiarStringClientes("cod_postal", txtcod_postal.Text);
                        resumenModificaciones = resumenModificaciones + "\nCódigo Postal";
                        modificacion = true;
                    }
                    else
                    {
                        MessageBox.Show("Código postal inválido.", "Error");
                        resumenErrores = resumenErrores + "\nCódigo postal (valor muy grande)";
                        error = true;
                    }
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCódigo Postal (no ingresado)";
                    error = true;
                }
            }

            if (cambioInt(Dia, cmbDia.SelectedIndex) || cambioInt(Mes, cmbMes.SelectedIndex) || cambioInt(Ano, cmbAno.SelectedIndex))
            {
                cambiarFecha("FechaNacimiento", fecha(cmbDia.SelectedItem.ToString(), cmbMes.SelectedItem.ToString(), cmbAno.SelectedItem.ToString()));
                resumenModificaciones = resumenModificaciones + "\nFecha de nacimiento";
                modificacion = true;
            }

            if (modificacion)
            {
                MessageBox.Show(resumenModificaciones);

            }

            if (error)
            {
                MessageBox.Show(resumenErrores);
            }

            if (modificacion || error)
            {
                this.Close();
                frmBuscarCliente.Show();
            }
        }

        public Boolean cambioString(string string1, string string2)
        {
            return !string1.Equals(string2);
        }

        public Boolean cambioInt(int int1, int int2)
        {
            if (int1 == int2)
            {
                return false;
            }
            else
            {
                return true;
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

        public void cambiarStringUsuarios(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarStringClientes(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.CLIENTE SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarIntUsuarios(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarIntClientes(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.CLIENTE SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarLongIntClientes(string columna, long valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.CLIENTE SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarNullClientes(string columna)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", DBNull.Value);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.CLIENTE SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarFecha(string columna, DateTime fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", fecha);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.CLIENTE SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public string hashear(string valor)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(valor));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        public Boolean usernameValido()
        {
            if (!txtUsuario.Text.Equals("") && !SqlConnector.existeString(txtUsuario.Text, "VADIUM.USUARIO", "usuario_username"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean numeroDeDocumentoValido()
        {
            if (!txtNumeroDocumento.Text.Equals("") && (Interfaz.esNumerico(txtNumeroDocumento.Text, System.Globalization.NumberStyles.Integer)) && (txtNumeroDocumento.Text.Length <= 18))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (e.KeyChar < 65 || e.KeyChar > 122)
            {
                e.Handled = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
