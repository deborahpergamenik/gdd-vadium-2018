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
        public string Localidad { get; set; }
        public string NroPiso { get; set; }
        public string Departamento { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }


        public frmModificarEmpresa(int _usuario_id)
        {
            this.usuario_id = _usuario_id;

            InitializeComponent();
            setearComboBoxes();
            cargarDatosUsuario();
            cargarDatosEmpresa();
            cargarDatosViejos();
        }

        public void cargarDatosViejos()
        {
            this.usuario_username = txtUsuario.Text;
            this.password = txtpassword.Text;
            this.usuario_activo = cmbusuario_activo.SelectedIndex;

            this.razonSocial = txtrazonSocial.Text;
            this.cuit = txtcuit.Text;
            this.telefono = txttelefono.Text;
            this.direccion = txtdireccion.Text;
            this.cod_postal = txtcod_postal.Text;
            this.ciudad = txtciudad.Text;
            this.mail = txtmail.Text;
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
            for (i = 1000; i <= 2014; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void cargarDatosEmpresa()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT razonSocial, cuit, telefono, direccion, cod_postal, ciudad, mail, DAY(fechaCreacion) AS fechaCreacion_Dia, MONTH(fechaCreacion) AS fechaCreacion_Mes, YEAR(fechaCreacion) AS fechaCreacion_Ano  FROM VADIUM.EMPRESA WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            txtrazonSocial.Text = Convert.ToString(lector["razonSocial"]);
            txtcuit.Text = Convert.ToString(lector["cuit"]);

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

            if (lector["ciudad"] != DBNull.Value)
            {
                txtciudad.Text = Convert.ToString(lector["ciudad"]);
            }
            else
            {
                txtciudad.Text = "";
            }

            txtmail.Text = Convert.ToString(lector["mail"]);

            txtDepartamento.Text = Convert.ToString(lector["Departamento"]);
            txtNroPiso.Text = Convert.ToString(lector["NroPiso"]);
            txtLocalidad.Text = Convert.ToString(lector["Localidad"]);

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

            if (cambioString(this.usuario_username, txtUsuario.Text))
            {
                if (usuario_usernameValido())
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

            if (cambioString(this.password, txtpassword.Text))
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(txtpassword.Text));
                string password = bytesDeHasheoToString(bytesDeHasheo);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
                SqlConnector.agregarParametro(listaParametros, "@password", password);

                MessageBox.Show("usuario_id: " + this.usuario_id + "\npassword: " + txtpassword.Text + "\nHASH: " + password);

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

            if (cambioString(this.razonSocial, txtrazonSocial.Text))
            {
                if (!txtrazonSocial.Text.Equals("") && !SqlConnector.existeString(txtrazonSocial.Text, "VADIUM.EMPRESA", "razonSocial"))
                {
                    cambiarStringEmpresas("razonSocial", txtrazonSocial.Text);
                    resumenModificaciones = resumenModificaciones + "\nRazón Social";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nRazón Social (no ingresada o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.cuit, txtcuit.Text))
            {
                if (!txtcuit.Text.Equals("") && !SqlConnector.existeString(txtcuit.Text, "VADIUM.EMPRESA", "cuit") && txtcuit.Text.Length <= 50)
                {
                    cambiarStringEmpresas("cuit", txtcuit.Text);
                    resumenModificaciones = resumenModificaciones + "\ncuit";
                    modificacion = true;
                }
                else
                {
                    //MessageBox.Show("cuit inválido.", "Error");
                    resumenErrores = resumenErrores + "\ncuit (no ingresado o ya existente)";
                    error = true;
                }
            }

            if (cambioString(this.telefono, txttelefono.Text))
            {
                if (txttelefono.Text.Equals("") || ((Interfaz.esNumerico(txttelefono.Text, System.Globalization.NumberStyles.Integer)) && (txttelefono.Text.Length <= 18)))
                {
                    if (txttelefono.Text.Equals(""))
                    {
                        cambiarNullEmpresas("telefono");
                        resumenModificaciones = resumenModificaciones + "\nTeléfono";
                        modificacion = true;
                    }
                    else
                    {
                        if (!SqlConnector.existeString(txttelefono.Text, "VADIUM.EMPRESA", "telefono"))
                        {
                            cambiarLongIntEmpresas("telefono", Convert.ToInt64(txttelefono.Text));
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
                    cambiarStringEmpresas("direccion", txtdireccion.Text);
                    resumenModificaciones = resumenModificaciones + "\nDirección";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\ndireccion (no ingresada)";
                    error = true;
                }
            }

            if (cambioString(this.cod_postal, txtcod_postal.Text))
            {
                if (!txtcod_postal.Text.Equals("") && txtcod_postal.Text.Length <= 50)
                {
                    cambiarStringEmpresas("cod_postal", txtcod_postal.Text);
                    resumenModificaciones = resumenModificaciones + "\nCódigo postal";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCódigo postal (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.ciudad, txtciudad.Text))
            {
                if (txtciudad.Text.Equals("") || txtciudad.Text.Length <= 50)
                {
                    if (txtciudad.Text.Equals(""))
                    {
                        cambiarNullEmpresas("ciudad");
                        resumenModificaciones = resumenModificaciones + "\nciudad";
                        modificacion = true;
                    }
                    else
                    {
                        cambiarStringEmpresas("ciudad", txtciudad.Text);
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

            if (cambioString(this.mail, txtmail.Text))
            {
                if (!txtmail.Text.Equals(""))
                {
                    cambiarStringEmpresas("mail", txtmail.Text);
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
                this.Close();
                frmBuscarEmpresa.Show();
            }
        }

        public Boolean usuario_usernameValido()
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
    }
}
