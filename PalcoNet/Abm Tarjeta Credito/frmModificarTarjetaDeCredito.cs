using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Tarjeta_Credito
{
    public partial class frmModificarTarjetaDeCredito : Form
    {
        public int tarjeta_id { get; set; }
        public string numeroTarjeta { get; set; }
        public string banco { get; set; }
        public string codigoSeguridad { get; set; }
        public string tipo { get; set; }
        public int cliente_id { get; set; }
        public string mesVencimiento { get; set; }
        public string anioVencimiento { get; set; }


        public frmAbmTarjetaDeCredito frmAbmTarjetaDeCredito { get; set; }


        public frmModificarTarjetaDeCredito(int _tarjeta_id, int _cliente_id, frmAbmTarjetaDeCredito _frmAbmTarjetaDeCredito)
        {
            this.tarjeta_id = _tarjeta_id;
            this.cliente_id = _cliente_id;
            this.frmAbmTarjetaDeCredito = _frmAbmTarjetaDeCredito;

            InitializeComponent();
            setearComboBoxes();
            cargarDatosTarjeta();
            cargarDatosViejos();
        }

        public void setearComboBoxes()
        {
            llenarCmbMes();
            llenarCmbAno();
            llenarCmbTipos();
        }

        public void llenarCmbMes()
        {
            int i;
            for (i = 01; i <= 12; i++)
            {
                this.cmbMes.Items.Add(i.ToString());
            }
        }

        public void llenarCmbAno()
        {
            int i;
            for (i = 2018; i <= 2030; i++)
            {
                this.cmbAno.Items.Add(i.ToString());
            }
        }

        public void llenarCmbTipos()
        {
            this.cmbTipo.Items.Add("VISA");
            this.cmbTipo.Items.Add("MASTER CARD");
            this.cmbTipo.Items.Add("AMERICAN EXPRESS");
        }


        public void cargarDatosTarjeta()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@tarjeta_id", this.tarjeta_id);
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", this.cliente_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT tarjeta_id, nroTarjeta, banco, codSeguridad, tipo, cliente_id, mesVencimiento, anioVencimiento " +
                                                               "FROM VADIUM.TARJETADECREDITO " +
                                                               "WHERE tarjeta_id = @tarjeta_id AND cliente_id = @cliente_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();

            mskNumeroTarjeta.Text = Convert.ToString(lector["nroTarjeta"]);
            txtBanco.Text = Convert.ToString(lector["banco"]);
            mskCodSeguridad.Text = Convert.ToString(lector["codSeguridad"]);
            cmbTipo.SelectedItem = Convert.ToString(lector["tipo"]);
            cmbMes.SelectedItem = Convert.ToString(lector["mesVencimiento"]);
            cmbAno.SelectedItem = Convert.ToString(lector["anioVencimiento"]);


            SqlConnector.cerrarConexion();
        }


        public void cargarDatosViejos()
        {
            this.numeroTarjeta = mskNumeroTarjeta.Text;
            this.banco = txtBanco.Text;
            this.codigoSeguridad = mskCodSeguridad.Text;
            this.tipo = cmbTipo.SelectedItem.ToString();
            this.mesVencimiento = cmbMes.SelectedItem.ToString();
            this.anioVencimiento = cmbAno.SelectedItem.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string resumenModificaciones = "Se han modificado los campos:";
            string resumenErrores = "No se han podido modificar los campos:";

            Boolean modificacion = false;
            Boolean error = false;

            if (cambioString(this.numeroTarjeta, mskNumeroTarjeta.Text))
            {
                if (mskNumeroTarjeta.MaskCompleted && !SqlConnector.existeString(mskNumeroTarjeta.Text, "VADIUM.TARJETADECREDITO", "nroTarjeta"))
                {
                    cambiarStringTarjetas("nroTarjeta", mskNumeroTarjeta.Text);
                    resumenModificaciones = resumenModificaciones + "\nNúmero de Tarjeta";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nNúmero de Tarjeta (no ingresada completamente o ya existente)";
                    error = true;
                }
            }


            if (cambioString(this.banco, txtBanco.Text))
            {
                if (!txtBanco.Text.Equals(""))
                {
                    cambiarStringTarjetas("banco", txtBanco.Text);
                    resumenModificaciones = resumenModificaciones + "\nBanco";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nBanco (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.codigoSeguridad, mskCodSeguridad.Text))
            {
                if (mskCodSeguridad.MaskCompleted)
                {
                    cambiarStringTarjetas("codSeguridad", mskCodSeguridad.Text);
                    resumenModificaciones = resumenModificaciones + "\nCodigo de Seguridad";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nCodigo de Seguridad (no ingresado completamente)";
                    error = true;
                }
            }


            if (cambioString(this.tipo, cmbTipo.SelectedItem.ToString()))
            {
                if (cmbTipo.SelectedIndex != -1)
                {
                    cambiarStringTarjetas("tipo", cmbTipo.SelectedItem.ToString());
                    resumenModificaciones = resumenModificaciones + "\nTipo";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nTipo (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.mesVencimiento, cmbMes.SelectedItem.ToString()))
            {
                if (cmbMes.SelectedIndex != -1)
                {
                    cambiarStringTarjetas("mesVencimiento", cmbMes.SelectedItem.ToString());
                    resumenModificaciones = resumenModificaciones + "\nMes Vencimiento";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nMes Vencimiento (no ingresado)";
                    error = true;
                }
            }

            if (cambioString(this.anioVencimiento, cmbAno.SelectedItem.ToString()))
            {
                if (cmbAno.SelectedIndex != -1)
                {
                    cambiarStringTarjetas("anioVencimiento", cmbAno.SelectedItem.ToString());
                    resumenModificaciones = resumenModificaciones + "\nAño Vencimiento";
                    modificacion = true;
                }
                else
                {
                    resumenErrores = resumenErrores + "\nAño Vencimiento (no ingresado)";
                    error = true;
                }
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
                frmAbmTarjetaDeCredito.cargarGrillaTarjetas();
                this.Close();
            }
        }


        public void cambiarStringTarjetas(string columna, string valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", this.cliente_id);
            SqlConnector.agregarParametro(listaParametros, "@tarjeta_id", this.tarjeta_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.TARJETADECREDITO SET " + columna + " = @Valor WHERE cliente_id = @cliente_id AND tarjeta_id = @tarjeta_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarIntTarjetas(string columna, int valor)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Valor", valor);
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", this.cliente_id);
            SqlConnector.agregarParametro(listaParametros, "@tarjeta_id", this.tarjeta_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.TARJETADECREDITO SET " + columna + " = @Valor WHERE cliente_id = @cliente_id AND tarjeta_id = @tarjeta_id", listaParametros, SqlConnector.iniciarConexion());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmTarjetaDeCredito.Show();
        }
    }
}
