using PalcoNet.Common;
using PalcoNet.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class frmDetallePublicacion : Form
    {
        DataTable ubicacionesDisponibles = new DataTable();
        DataTable tiposUbicacion = new DataTable();
        DataTable ubicacionesSeleccionadas = new DataTable();
        Publicacion publi;

        public frmDetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();
            publi = unaPublicacion;
        }

        private void frmDetallePublicacion_Load(object sender, EventArgs e)
        {
            //COMBOBOX
            SqlDataReader lectorCombo = SqlConnector.ObtenerDataReader("VADIUM.ObtenerTiposUbicaciones", "SP");
            if (lectorCombo.HasRows)
            {
                lectorCombo.Read();
                tiposUbicacion.Load(lectorCombo);
                SqlConnector.cerrarConexion();
                dgvUbicaciones.DataSource = tiposUbicacion;
            }

            foreach (DataRow row in tiposUbicacion.Rows)
                cmbTipo.Items.Add(row["descripcion"].ToString());


            cargarUbicaciones(null);
        }


        private void cargarUbicaciones(Nullable<int> tipoUbicacion)
        {
            //AGREGAR PARAMETROS QUE HAGAN FALTA PARA OBTENER LAS UBICACIONES

            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@codigoPublicacion", publi.CodigoPublicacion);
            if (!tipoUbicacion.HasValue)
                SqlConnector.agregarParametro(parametros, "@tipoUbicacion", DBNull.Value);
            else
                SqlConnector.agregarParametro(parametros, "@tipoUbicacion", tipoUbicacion.Value);
            SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.ObtenerUbicaciones", "SP", parametros);

            if (lector.HasRows)
            {
                lector.Read();
                ubicacionesDisponibles.Load(lector);
                SqlConnector.cerrarConexion();
                ubicacionesDisponibles.PrimaryKey = new DataColumn[] { ubicacionesDisponibles.Columns["nro_ubicacion"] };
                dgvUbicaciones.DataSource = ubicacionesDisponibles;
                dgvUbicaciones.Columns["nro_ubicacion"].Visible = false;

                ubicacionesSeleccionadas = ubicacionesDisponibles.Clone();
                ubicacionesSeleccionadas.PrimaryKey = new DataColumn[] { ubicacionesSeleccionadas.Columns["nro_ubicacion"] };
            }
        }

        private void dgvUbicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgvUbicaciones[e.ColumnIndex, e.RowIndex].Value == null ? false : (bool)dgvUbicaciones[e.ColumnIndex, e.RowIndex].Value)
                    ubicacionesSeleccionadas.Rows.Remove(ubicacionesSeleccionadas.Rows.Find(dgvUbicaciones["nro_ubicacion", e.RowIndex].Value));
                else
                    ubicacionesSeleccionadas.ImportRow(ubicacionesSeleccionadas.Rows[e.RowIndex]);

            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarUbicaciones(cmbTipo.SelectedIndex == -1 ? null : (Nullable<int>)tiposUbicacion.Rows[cmbTipo.SelectedIndex][0]);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string codigoTarjeta;
            if (ubicacionesSeleccionadas.Rows.Count == 0)
            {
                MessageBox.Show("No se seleccionaron ubicaciones para comprar");
            }
            else if (!String.IsNullOrWhiteSpace((codigoTarjeta = chequearTarjeta())) &&
            MessageBox.Show("Desea confirmar la compra?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                generarCompra(codigoTarjeta);
                ubicacionesSeleccionadas.Clear();
                ubicacionesDisponibles.Clear();
            }
            else
            {
                MessageBox.Show("Compra cancelada");
            }
        }


        private string chequearTarjeta()
        {
            string codigoTarjeta = null;

            List<SqlParameter> parametrosValidarTarjeta = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametrosValidarTarjeta, "@codCliente", "codigoDeCliente"); //traer codigo de cliente
            SqlConnector.agregarParametro(parametrosValidarTarjeta, "@fechaActual", "fecha");
            SqlDataReader lectorTarjeta = SqlConnector.ObtenerDataReader("VADIUM.VALIDAR_TARJETA", "SP", parametrosValidarTarjeta);

            if (!lectorTarjeta.HasRows)
            {
                Tarjeta tarjeta = new Tarjeta();
                MessageBox.Show("No tiene una tarjeta de credito asociada, por favor, registre una para continuar la compra");
                if (new Abm_Cliente.frmAgregarTarjetaDeCredito(tarjeta).DialogResult == DialogResult.OK)
                {
                    UTF8Encoding encoderHash = new UTF8Encoding();
                    SHA256Managed hasher = new SHA256Managed();
                    byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(tarjeta.Numero));
                    string tarjetaNumero = bytesDeHasheoToString(bytesDeHasheo);

                    List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codCliente", "codigoDeCliente"); //traer codigo de cliente
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@nroTarjeta", tarjetaNumero);
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@ultimosDigitos", tarjeta.Numero.Substring(tarjeta.Numero.Length - 4, 4));
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codSeguridad", tarjeta.CodigoSeguridad);                    
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@mesVencimiento", tarjeta.Mes);
                    SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@anioVencimiento", tarjeta.Anio);
                    SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.GUARDAR_TARJETA", "SP", parametrosGuardarTarjeta);

                    lector["codigoTarjeta"].ToString();
                }
            }
            else
            {
                codigoTarjeta = lectorTarjeta["codigoTarjeta"].ToString();
            }

            return codigoTarjeta;
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

        private void generarCompra(string codigoTarjeta)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in ubicacionesSeleccionadas.Rows)
                builder.AppendFormat("{0} ", row["nro_ubicacion"].ToString());

            List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codCliente", "codigoDeCliente"); //traer codigo de cliente
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codTarjeta", codigoTarjeta);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codPublicacion", publi.CodigoPublicacion);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@ubicaciones", builder.ToString());
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fechaActual", Configuration.getActualDate());
            SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.COMPRAR", "SP", parametrosGuardarTarjeta);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
