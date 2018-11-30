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

        public int IdUsuario { get; set; }

        public string Usuario { get; set; }
        public string Passoword { get; set; }
        public int Estado { get; set; }

        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Cuil { get; set; }
        public string Localidad { get; set; }
        public string NroPiso { get; set; }
        public string Departamento { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public frmModificarCliente(int _idUsuario, frmBuscarCliente _frmBuscarCliente)
        {
            this.IdUsuario = _idUsuario;
            this.frmBuscarCliente = _frmBuscarCliente;

            InitializeComponent();

            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosCliente();
            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.Usuario = txtUsuario.Text;
            this.Passoword = txtPassword.Text;
            this.Estado = cmbEstado.SelectedIndex;

            this.TipoDocumento = cmbTipoDocumento.SelectedIndex;
            this.NumeroDocumento = txtNumeroDocumento.Text;
            this.Nombre = txtNombre.Text;
            this.Apellido = txtApellido.Text;
            this.Email = txtEmail.Text;
            this.Telefono = txtTelefono.Text;
            this.Direccion = txtDireccion.Text;
            this.CodigoPostal = txtCodigoPostal.Text;
            this.Departamento = txtDepartamento.Text;
            this.NroPiso = txtNroPiso.Text;
            this.Cuil = txtCuil.Text;
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
            llenarCbTipoDoc();
            llenarCbHabilitado();
        }

        public void llenarCbTipoDoc()
        {
            this.cmbTipoDocumento.Items.Add("DU");
            this.cmbTipoDocumento.Items.Add("CI");
            this.cmbTipoDocumento.Items.Add("LC");
        }

        public void llenarCbHabilitado()
        {
            this.cmbEstado.Items.Add("No");
            this.cmbEstado.Items.Add("Sí");
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
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT TipoDoc, NumDoc, Cuil, Nombre, Apellido, Mail, Telefono, Direccion, CodigoPostal, DAY(Fecha_Nacimiento) AS Fecha_Nacimiento_Dia, MONTH(Fecha_Nacimiento) AS Fecha_Nacimiento_Mes, YEAR(Fecha_Nacimiento) AS Fecha_Nacimiento_Ano FROM PalcoNet.Cliente WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            if (Convert.ToString(lector["TipoDoc"]) == "DU")
            {
                cmbTipoDocumento.SelectedIndex = 0;
            }

            if (Convert.ToString(lector["TipoDoc"]) == "CI")
            {
                cmbTipoDocumento.SelectedIndex = 1;
            }

            if (Convert.ToString(lector["TipoDoc"]) == "LC")
            {
                cmbTipoDocumento.SelectedIndex = 2;
            }

            txtNumeroDocumento.Text = Convert.ToInt64(lector["NumDoc"]).ToString();
            txtNombre.Text = Convert.ToString(lector["Nombre"]);
            txtApellido.Text = Convert.ToString(lector["Apellido"]);
            txtEmail.Text = Convert.ToString(lector["Mail"]);

            if (lector["Telefono"] != DBNull.Value)
            {
                txtTelefono.Text = Convert.ToInt64(lector["Telefono"]).ToString();
            }
            else
            {
                txtTelefono.Text = "";
            }

            txtDireccion.Text = Convert.ToString(lector["Direccion"]);
            txtCodigoPostal.Text = Convert.ToString(lector["CodigoPostal"]);

            cmbDia.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Dia"]);
            cmbMes.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Mes"]);
            cmbAno.SelectedIndex = Convert.ToInt32(lector["Fecha_Nacimiento_Ano"]) - 1000;

            SqlConnector.cerrarConexion();
        }

        public void cargarDatosUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT NombreUsuario, Estado FROM PalcoNet.Usuario WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtUsuario.Text = Convert.ToString(lector["NombreUsuario"]);

            if (Convert.ToInt32(lector["Estado"]) == 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
            else
            {
                cmbEstado.SelectedIndex = 1;
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
                    cambiarStringUsuarios("NombreUsuario", txtUsuario.Text);
                    resumenModificaciones = resumenModificaciones + "\nNombre de usuario";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("Nombre de usuario inválido.", "Error");
                    resumenErrores = resumenErrores + "\nNombre de usuario (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.Passoword, txtPassword.Text))
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtPassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
                SqlConnector.agregarParametro(listaParametros, "@Password", password);
                SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Password = @Password, PrimeraVez = 0 WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                resumenModificaciones = resumenModificaciones + "\nContraseña";
                modificacion = true;
            }

            if (cambioInt(this.Estado, cmbEstado.SelectedIndex))
            {
                cambiarIntUsuarios("Estado", cmbEstado.SelectedIndex);
                resumenModificaciones = resumenModificaciones + "\nEstado";
                modificacion = true;
            }



            if (cambioInt(this.TipoDocumento, cmbTipoDocumento.SelectedIndex))
            {
                if (numeroDeDocumentoValido())
                {
                    if (!SqlConnector.existenSimultaneamente(cmbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "PalcoNet.Cliente", "TipoDoc", "NumDoc"))
                    {
                        switch (cmbTipoDocumento.SelectedIndex)
                        {
                            case 0:
                                cambiarStringClientes("TipoDoc", "DU");
                                break;
                            case 1:
                                cambiarStringClientes("TipoDoc", "CI");
                                break;
                            case 2:
                                cambiarStringClientes("TipoDoc", "LC");
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
                    if (!SqlConnector.existenSimultaneamente(cmbTipoDocumento.SelectedItem.ToString(), txtNumeroDocumento.Text, "PalcoNet.Cliente", "TipoDoc", "NumDoc"))
                    {
                        cambiarLongIntClientes("Num_Doc", Convert.ToInt64(txtNumeroDocumento.Text));
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

            if (cambioString(this.Nombre, txtNombre.Text))
            {
                if (!txtNombre.Text.Equals(""))
                {
                    cambiarStringClientes("Nombre", txtNombre.Text);
                    resumenModificaciones = resumenModificaciones + "\nNombre";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nNombre (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.Apellido, txtApellido.Text))
            {
                if (!txtApellido.Text.Equals(""))
                {
                    cambiarStringClientes("Apellido", txtApellido.Text);
                    resumenModificaciones = resumenModificaciones + "\nApellido";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nApellido (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.Email, txtEmail.Text))
            {
                if (!txtEmail.Text.Equals(""))
                {
                    cambiarStringClientes("Email", txtEmail.Text);
                    resumenModificaciones = resumenModificaciones + "\nE-mail";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nE-mail (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.Telefono, txtTelefono.Text))
            {
                if (txtTelefono.Text.Equals("") || ((Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer)) && (txtTelefono.Text.Length <= 18)))
                {
                    if (txtTelefono.Text.Equals(""))
                    {
                        cambiarNullClientes("Telefono");
                        resumenModificaciones = resumenModificaciones + "\nTeléfono";
                        modificacion = true;
                    }
                    else
                    {
                        if (!SqlConnector.existeString(txtTelefono.Text, "PalcoNet.Clientes", "Telefono"))
                        {
                            cambiarLongIntClientes("Telefono", Convert.ToInt64(txtTelefono.Text));
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

            if (cambioString(this.Direccion, txtDireccion.Text))
            {
                if (!txtDireccion.Text.Equals(""))
                {
                    cambiarStringClientes("Direccion", txtDireccion.Text);
                    resumenModificaciones = resumenModificaciones + "\nDirección";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDirección (no ingresada)";
                    error = true;
                }
            }

            if (cambioString(this.CodigoPostal, txtCodigoPostal.Text))
            {
                if (!txtCodigoPostal.Text.Equals(""))
                {
                    if (txtCodigoPostal.Text.Length <= 50)
                    {
                        cambiarStringClientes("CodigoPostal", txtCodigoPostal.Text);
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
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarStringClientes(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@ID_User", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Clientes SET " + columna + " = @Valor WHERE ID_User = @ID_User", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarIntUsuarios(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarIntClientes(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Cliente SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarLongIntClientes(string columna, long valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Cliente SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarNullClientes(string columna)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", DBNull.Value);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Cliente SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarFecha(string columna, DateTime fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", fecha);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Cliente SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
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
            if (!txtUsuario.Text.Equals("") && !SqlConnector.existeString(txtUsuario.Text, "PalcoNet.Usuario", "NombreUsuario"))
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
            this.frmBuscarCliente.Show();
        }
    }
}
