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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class frmModificarEmpresa : Form
    {
        public frmBuscarEmpresa frmBuscarEmpresa { get; set; }

        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int Estado { get; set; }

        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public string Localidad { get; set; }
        public string NroPiso { get; set; }
        public string Departamento { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }


        public frmModificarEmpresa(int _idUsuario, frmBuscarEmpresa _frmBuscarEmpresa)
        {
            this.IdUsuario = _idUsuario;
            this.frmBuscarEmpresa = _frmBuscarEmpresa;

            InitializeComponent();
            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosEmpresa();
            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.NombreUsuario = txtUsuario.Text;
            this.Password = txtPassword.Text;
            this.Estado = cmbEstado.SelectedIndex;

            this.RazonSocial = txtRazonSocial.Text;
            this.CUIT = txtCuit.Text;
            this.Telefono = txtTelefono.Text;
            this.Direccion = txtDireccion.Text;
            this.CodigoPostal = txtCodigoPostal.Text;
            this.Ciudad = txtCiudad.Text;
            this.Email = txtEmail.Text;
            this.Localidad = txtLocalidad.Text;
            this.Departamento = txtDepartamento.Text;
            this.NroPiso = txtNroPiso.Text;

            this.Dia = cmbDia.SelectedIndex;
            this.Mes = cmbMes.SelectedIndex;
            this.Ano = cmbAno.SelectedIndex;

        }

        public void setearComboBoxes()
        {
            llenarCmbDia();
            llenarCmbMes();
            llenarCmbAno();
            llenarCmbEstado();
        }

        public void llenarCmbEstado()
        {
            this.cmbEstado.Items.Add("No");
            this.cmbEstado.Items.Add("Sí");
        }

        public void llenarCmbDia()
        {
            int i;
            for (i = 0; i <= 31; i++)
            {
                this.cmbDia.Items.Add(i.ToString());
            }
        }

        public void llenarCmbMes()
        {
            int i;
            for (i = 0; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCmbAno()
        {
            int i;
            for (i = 1000; i <= 2014; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT RazonSocial, CUIT, Telefono, Direccion, CodigoPostal, Ciudad, Email, DAY(FechaCreacion) AS FechaCreacion_Dia, MONTH(FechaCreacion) AS FechaCreacion_Mes, YEAR(FechaCreacion) AS FechaCreacion_Ano  FROM PalcoNet.Empresa WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtRazonSocial.Text = Convert.ToString(lector["RazonSocial"]);
            txtCuit.Text = Convert.ToString(lector["Cuit"]);

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

            if (lector["Ciudad"] != DBNull.Value)
            {
                txtCiudad.Text = Convert.ToString(lector["Ciudad"]);
            }
            else
            {
                txtCiudad.Text = "";
            }

            txtEmail.Text = Convert.ToString(lector["Email"]);

            txtDepartamento.Text = Convert.ToString(lector["Departamento"]);
            txtNroPiso.Text = Convert.ToString(lector["NroPiso"]);
            txtLocalidad.Text = Convert.ToString(lector["Localidad"]);

            cmbDia.SelectedIndex = Convert.ToInt32(lector["FechaCreacion_Dia"]);
            cmbMes.SelectedIndex = Convert.ToInt32(lector["FechaCreacion_Mes"]);
            cmbAno.SelectedIndex = Convert.ToInt32(lector["FechaCreacion_Ano"]) - 1000;

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
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarStringEmpresas(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Empresa SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
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

        public void cambiarIntEmpresas(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Empresa SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarLongIntEmpresas(string columna, long valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Empresa SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarNullEmpresas(string columna)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", DBNull.Value);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Empresa SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarFecha(string columna, DateTime fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", fecha);
            SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Empresa SET " + columna + " = @Valor WHERE IdUsuario = @IdUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
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

        public string hashear(string valor)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(valor));
            return bytesDeHasheoToString(bytesDeHasheo);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string resumenModificaciones = "Se han modificado los campos:";
            string resumenErrores = "No se han podido modificar los campos:";

            Boolean modificacion = false;
            Boolean error = false;

            if (cambioString(this.NombreUsuario, txtUsuario.Text))
            {
                if (NombreUsuarioValido())
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

            if (cambioString(this.Password, txtPassword.Text))
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtPassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@IdUsuario", this.IdUsuario);
                SqlConnector.agregarParametro(listaParametros, "@Password", password);

                MessageBox.Show("IdUsuario: " + this.IdUsuario + "\nPASSWORD: " + txtPassword.Text + "\nHASH: " + password);

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

            if (cambioString(this.RazonSocial, txtRazonSocial.Text))
            {
                if (!txtRazonSocial.Text.Equals("") && !SqlConnector.existeString(txtRazonSocial.Text, "PalcoNet.Empresa", "RazonSocial"))
                {
                    cambiarStringEmpresas("RazonSocial", txtRazonSocial.Text);
                    resumenModificaciones = resumenModificaciones + "\nRazón Social";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nRazón Social (no ingresada o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.CUIT, txtCuit.Text))
            {
                if (!txtCuit.Text.Equals("") && !SqlConnector.existeString(txtCuit.Text, "PalcoNet.Empresa", "CUIT") && txtCuit.Text.Length <= 50)
                {
                    cambiarStringEmpresas("CUIT", txtCuit.Text);
                    resumenModificaciones = resumenModificaciones + "\nCUIT";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("CUIT inválido.", "Error");
                    resumenErrores = resumenErrores + "\nCUIT (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.Telefono, txtTelefono.Text))
            {
                if (txtTelefono.Text.Equals("") || ((Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer)) && (txtTelefono.Text.Length <= 18)))
                {
                    if (txtTelefono.Text.Equals(""))
                    {
                        cambiarNullEmpresas("Telefono");
                        resumenModificaciones = resumenModificaciones + "\nTeléfono";
                        modificacion = true;
                    }
                    else
                    {
                        if (!SqlConnector.existeString(txtTelefono.Text, "PalcoNet.Empresa", "Telefono"))
                        {
                            cambiarLongIntEmpresas("Telefono", Convert.ToInt64(txtTelefono.Text));
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
                    cambiarStringEmpresas("Direccion", txtDireccion.Text);
                    resumenModificaciones = resumenModificaciones + "\nDirección";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDireccion (no ingresada)";
                    error = true;
                }
            }

            if (cambioString(this.CodigoPostal, txtCodigoPostal.Text))
            {
                if (!txtCodigoPostal.Text.Equals("") && txtCodigoPostal.Text.Length <= 50)
                {
                    cambiarStringEmpresas("CodigoPostal", txtCodigoPostal.Text);
                    resumenModificaciones = resumenModificaciones + "\nCódigo postal";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCódigo postal (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.Ciudad, txtCiudad.Text))
            {
                if (txtCiudad.Text.Equals("") || txtCiudad.Text.Length <= 50)
                {
                    if (txtCiudad.Text.Equals(""))
                    {
                        cambiarNullEmpresas("Ciudad");
                        resumenModificaciones = resumenModificaciones + "\nCiudad";
                        modificacion = true;
                    }
                    else
                    {
                        cambiarStringEmpresas("Ciudad", txtCiudad.Text);
                        resumenModificaciones = resumenModificaciones + "\nCiudad";
                        modificacion = true;
                    }
                }
                else
                {
                    //MessageBox.Show("Ciudad inválida.", "Error");
                    resumenErrores = resumenErrores + "\nCiudad (valor muy grande)";
                    error = true;
                }
            }

            if (cambioString(this.Email, txtEmail.Text))
            {
                if (!txtEmail.Text.Equals(""))
                {
                    cambiarStringEmpresas("Email", txtEmail.Text);
                    resumenModificaciones = resumenModificaciones + "\nE-mail";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nE-mail (no ingresado)";
                    error = true;
                }
            }


            if (cambioInt(Dia, cmbDia.SelectedIndex) || cambioInt(Mes, cmbMes.SelectedIndex) || cambioInt(Ano, cmbAno.SelectedIndex))
            {
                cambiarFecha("FechaCreacion", fecha(cmbDia.SelectedItem.ToString(), cmbMes.SelectedItem.ToString(), cmbAno.SelectedItem.ToString()));
                resumenModificaciones = resumenModificaciones + "\nFecha de creación";
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
                frmBuscarEmpresa.Show();
            }
        }

        public Boolean NombreUsuarioValido()
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

        private void textboxCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.frmBuscarEmpresa.Show();
        }
    }
}
