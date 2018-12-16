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

        public int usuario_id { get; set; }
        public string usuario_username { get; set; }
        public string password { get; set; }
        public int usuario_activo { get; set; }

        public string razonSocial { get; set; }
        public string cuit { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string ciudad { get; set; }
        public string mail { get; set; }
        public string localidad { get; set; }
        public string nroPiso { get; set; }
        public string departamento { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public frmAbmEmpresa frmAbmEmpresa { get; set; }

        public frmModificarEmpresa(int _usuario_id, frmAbmEmpresa _frmAbmEmpresa)
        {
            this.usuario_id = _usuario_id;
            this.frmAbmEmpresa = _frmAbmEmpresa;

            InitializeComponent();
            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosEmpresa();
            cargarDatosViejos();
        }


        public void cargarDatosViejos()
        {
            this.usuario_username = txtUsername.Text;
            this.password = txtpassword.Text;
            this.usuario_activo = cmbusuario_activo.SelectedIndex;

            this.razonSocial = txtRazonSocial.Text;
            this.cuit = txtCuit.Text;
            this.telefono = txtTelefono.Text;
            this.direccion = txtDireccion.Text;
            this.cod_postal = txtCodPostal.Text;
            this.ciudad = txtCiudad.Text;
            this.mail = txtEmail.Text;
            this.localidad = txtLocalidad.Text;
            this.departamento = txtDepartamento.Text;
            this.nroPiso = txtNroPiso.Text;

            this.Dia = cmbDia.SelectedIndex;
            this.Mes = cmbMes.SelectedIndex;
            this.Ano = cmbAno.SelectedIndex;

        }

        public void setearComboBoxes()
        {
            llenarCmbDia();
            llenarCmbMes();
            llenarCmbAno();
            llenarCmbusuario_activo();
        }

        public void llenarCmbusuario_activo()
        {
            this.cmbusuario_activo.Items.Add("No");
            this.cmbusuario_activo.Items.Add("Sí");
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
            for (i = 1000; i <= 2018; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT empresa_id, usuario_id, razonSocial, cuit, mail, telefono, calle, piso, depto, cod_postal, localidad, ciudad, DAY(fechaCreacion) AS fechaCreacion_Dia, MONTH(fechaCreacion) AS fechaCreacion_Mes, YEAR(fechaCreacion) AS fechaCreacion_Ano  FROM VADIUM.EMPRESA WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtRazonSocial.Text = Convert.ToString(lector["razonSocial"]);
            txtCuit.Text = Convert.ToString(lector["cuit"]);

            if (lector["telefono"] != DBNull.Value)
            {
                txtTelefono.Text = Convert.ToInt64(lector["telefono"]).ToString();
            }
            else
            {
                txtTelefono.Text = "";
            }

            txtDireccion.Text = Convert.ToString(lector["calle"]);
            txtCodPostal.Text = Convert.ToString(lector["cod_postal"]);

            if (lector["ciudad"] != DBNull.Value)
            {
                txtCiudad.Text = Convert.ToString(lector["ciudad"]);
            }
            else
            {
                txtCiudad.Text = "";
            }

            txtEmail.Text = Convert.ToString(lector["mail"]);

            txtDepartamento.Text = Convert.ToString(lector["depto"]);
            txtNroPiso.Text = Convert.ToString(lector["piso"]);
            txtLocalidad.Text = Convert.ToString(lector["localidad"]);

            cmbDia.SelectedIndex = Convert.ToInt32(lector["fechaCreacion_Dia"]);
            cmbMes.SelectedIndex = Convert.ToInt32(lector["fechaCreacion_Mes"]);
            cmbAno.SelectedIndex = Convert.ToInt32(lector["fechaCreacion_Ano"]) - 1000;

            SqlConnector.cerrarConexion();
        }

        public void cargarDatosUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_username, usuario_activo FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtUsername.Text = Convert.ToString(lector["usuario_username"]);

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

        public void cambiarStringEmpresas(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.EMPRESA SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
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

        public void cambiarIntEmpresas(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.EMPRESA SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarLongIntEmpresas(string columna, long valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.EMPRESA SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarNullEmpresas(string columna)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", DBNull.Value);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.EMPRESA SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarFecha(string columna, DateTime fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", fecha);
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.EMPRESA SET " + columna + " = @Valor WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
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

            if (cambioString(this.usuario_username, txtUsername.Text))
            {
                if (usuario_usernameValido())
                {
                    cambiarStringUsuarios("usuario_username", txtUsername.Text);
                    resumenModificaciones = resumenModificaciones + "\nNombre de usuario";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("nombre de usuario inválido.", "Error");
                    resumenErrores = resumenErrores + "\nnombre de usuario (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.password, txtpassword.Text))
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtpassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
                SqlConnector.agregarParametro(listaParametros, "@usuario_password", password);

                //MessageBox.Show("usuario_id: " + this.usuario_id + "\npassword: " + txtpassword.Text + "\nHASH: " + password);

                SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_password = @usuario_password, primera_vez = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
                SqlConnector.cerrarConexion();

                resumenModificaciones = resumenModificaciones + "\nContraseña";
                modificacion = true;
            }

            if (cambioInt(this.usuario_activo, cmbusuario_activo.SelectedIndex))
            {
                cambiarIntUsuarios("usuario_activo", cmbusuario_activo.SelectedIndex);
                resumenModificaciones = resumenModificaciones + "\nHabilitado";
                modificacion = true;
            }

            if (cambioString(this.razonSocial, txtRazonSocial.Text))
            {
                if (!txtRazonSocial.Text.Equals("") && !SqlConnector.existeString(txtRazonSocial.Text, "VADIUM.EMPRESA", "razonSocial"))
                {
                    cambiarStringEmpresas("razonSocial", txtRazonSocial.Text);
                    resumenModificaciones = resumenModificaciones + "\nRazón Social";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nRazón Social (no ingresada o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.cuit, txtCuit.Text))
            {
                if (!txtCuit.Text.Equals("") && !SqlConnector.existeString(txtCuit.Text, "VADIUM.EMPRESA", "cuit") && txtCuit.Text.Length <= 50)
                {
                    cambiarStringEmpresas("cuit", txtCuit.Text);
                    resumenModificaciones = resumenModificaciones + "\nCuit";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCuit (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.mail, txtEmail.Text))
            {
                if (!txtEmail.Text.Equals(""))
                {
                    cambiarStringEmpresas("mail", txtEmail.Text);
                    resumenModificaciones = resumenModificaciones + "\nE-mail";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nE-mail (no ingresado)";
                    error = true;
                }
            }


            if (cambioString(this.telefono, txtTelefono.Text))
            {
                if (txtTelefono.Text.Equals("") || ((Interfaz.esNumerico(txtTelefono.Text, System.Globalization.NumberStyles.Integer)) && (txtTelefono.Text.Length <= 18)))
                {
                    if (txtTelefono.Text.Equals(""))
                    {
                        cambiarNullEmpresas("telefono");
                        resumenModificaciones = resumenModificaciones + "\nTeléfono";
                        modificacion = true;
                    }
                    else
                    {
                        if (!SqlConnector.existeString(txtTelefono.Text, "VADIUM.EMPRESA", "telefono"))
                        {
                            cambiarLongIntEmpresas("telefono", Convert.ToInt64(txtTelefono.Text));
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

            if (cambioString(this.direccion, txtDireccion.Text))
            {
                if (!txtDireccion.Text.Equals(""))
                {
                    cambiarStringEmpresas("calle", txtDireccion.Text);
                    resumenModificaciones = resumenModificaciones + "\nDirección";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDireccion (no ingresada)";
                    error = true;
                }
            }


            if (cambioString(this.nroPiso, txtNroPiso.Text))
            {
                if (!txtNroPiso.Text.Equals(""))
                {
                    cambiarLongIntEmpresas("piso", Convert.ToInt64(txtNroPiso.Text));
                    resumenModificaciones = resumenModificaciones + "\nPiso";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nPiso (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.localidad, txtLocalidad.Text))
            {
                if (!txtLocalidad.Text.Equals(""))
                {
                    cambiarStringEmpresas("localidad", txtLocalidad.Text);
                    resumenModificaciones = resumenModificaciones + "\nLocalidad";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nLocalidad (no ingresada)";
                    error = true;
                }
            }

            if (cambioString(this.departamento, txtDepartamento.Text))
            {
                if (!txtDepartamento.Text.Equals(""))
                {
                    cambiarStringEmpresas("depto", txtDepartamento.Text);
                    resumenModificaciones = resumenModificaciones + "\nDepartamento";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nDepartamento (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.cod_postal, txtCodPostal.Text))
            {
                if (!txtCodPostal.Text.Equals("") && txtCodPostal.Text.Length <= 50)
                {
                    cambiarStringEmpresas("cod_postal", txtCodPostal.Text);
                    resumenModificaciones = resumenModificaciones + "\nCódigo postal";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCódigo postal (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.ciudad, txtCiudad.Text))
            {
                if (txtCiudad.Text.Equals("") || txtCiudad.Text.Length <= 50)
                {
                    if (txtCiudad.Text.Equals(""))
                    {
                        cambiarNullEmpresas("ciudad");
                        resumenModificaciones = resumenModificaciones + "\nciudad";
                        modificacion = true;
                    }
                    else
                    {
                        cambiarStringEmpresas("ciudad", txtCiudad.Text);
                        resumenModificaciones = resumenModificaciones + "\nciudad";
                        modificacion = true;
                    }
                }
                else
                {
                    //MessageBox.Show("ciudad inválida.", "Error");
                    resumenErrores = resumenErrores + "\nciudad (valor muy grande)";
                    error = true;
                }
            }

            if (cambioInt(Dia, cmbDia.SelectedIndex) || cambioInt(Mes, cmbMes.SelectedIndex) || cambioInt(Ano, cmbAno.SelectedIndex))
            {
                cambiarFecha("fechaCreacion", fecha(cmbDia.SelectedItem.ToString(), cmbMes.SelectedItem.ToString(), cmbAno.SelectedItem.ToString()));
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
                frmAbmEmpresa.CargarDatos(string.Empty, string.Empty, string.Empty);
                this.Close();
            }
        }

        public Boolean usuario_usernameValido()
        {
            if (!txtUsername.Text.Equals("") && !SqlConnector.existeString(txtUsername.Text, "VADIUM.USUARIO", "usuario_username"))
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
        }

        private void frmModificarEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
