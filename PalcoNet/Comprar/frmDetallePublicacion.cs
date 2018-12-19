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
        List<int> ubicacionesSeleccionadas = new List<int>();
        int codPublicacionActual = 0;
        int stockActual;
        public frmDetallePublicacion(int codPublicacion)
        {
            InitializeComponent();
            this.codPublicacionActual = codPublicacion;
        }

        private void frmDetallePublicacion_Load(object sender, EventArgs e)
        {
            //COMBOBOX
            dgvUbicaciones.DataSource = Ubicaciones.ObtenerUbicacionesLibresPorPublicacio(codPublicacionActual, null);
            
            List<TipoUbicacion> tiposUbicaciones = Ubicaciones.ObtenerTipoDeUbicaciones();
            tiposUbicaciones.ForEach(x => cmbTipo.Items.Add(new ComboBoxItem { Text = x.descripcion, Value = x.id }));
            lblPrecio.Text = "0";
        }


        //private void cargarUbicaciones(int? tipoUbicacion)
        //{
        //    //AGREAGR PARAMETROS QUE HAGAN FALTA PARA OBTENER LAS UBICACIONES

        //    List<SqlParameter> parametros = new List<SqlParameter>();
        //    SqlConnector.agregarParametro(parametros, "@codigoPublicacion", codPublicacionActual);
        //    SqlConnector.agregarParametro(parametros, "@tipoUbicacion", tipoUbicacion.Value);
        //    SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.ObtenerUbicacionesNoVendidas", "SP", parametros);

        //    if (lector.HasRows)
        //    {
        //        lector.Read();
        //        ubicacionesDisponibles.Load(lector);
        //        SqlConnector.cerrarConexion();
        //        ubicacionesDisponibles.PrimaryKey = new DataColumn[] { ubicacionesDisponibles.Columns["nro_ubicacion"] };
        //        dgvUbicaciones.DataSource = ubicacionesDisponibles;
        //        dgvUbicaciones.Columns["nro_ubicacion"].Visible = false;

        //        ubicacionesSeleccionadas = ubicacionesDisponibles.Clone();
        //        ubicacionesSeleccionadas.PrimaryKey = new DataColumn[] { ubicacionesSeleccionadas.Columns["nro_ubicacion"] };
        //    }
        //}

        private void dgvUbicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int tipoUbi = Convert.ToInt32(((ComboBoxItem)cmbTipo.SelectedValue).Value);
            dgvUbicaciones.DataSource = Ubicaciones.ObtenerUbicacionesLibresPorPublicacio(codPublicacionActual, tipoUbi);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (UserInstance.getUserInstance().clienteId == null)
            {
                MessageBox.Show("Este usuario no puede comprar porque no tiene asignado los datos de un cliente");
                return;
            }
            string codigoTarjeta;
            if (ubicacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("No se seleccionaron ubicaciones para comprar");
            }
            else if (MessageBox.Show("Desea confirmar la compra?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)//!String.IsNullOrWhiteSpace((codigoTarjeta = chequearTarjeta())) &&
            {
                generarCompra("Tarjeta");
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

            //List<SqlParameter> parametrosValidarTarjeta = new List<SqlParameter>();
            //SqlConnector.agregarParametro(parametrosValidarTarjeta, "@codCliente", UserInstance.getUserInstance().clienteId); //traer codigo de cliente
            //SqlConnector.agregarParametro(parametrosValidarTarjeta, "@fechaActual", Configuration.getActualDate());
            //SqlDataReader lectorTarjeta = SqlConnector.ObtenerDataReader("VADIUM.VALIDAR_TARJETA", "SP", parametrosValidarTarjeta);

            //if (!lectorTarjeta.HasRows)
            //{
            //    Tarjeta tarjeta = null;
            //    MessageBox.Show("No tiene una tarjeta de credito asociada, por favor, registre una para continuar la compra");
            //    if (new Abm_Cliente.frmAgregarTarjetaDeCredito(tarjeta).DialogResult == DialogResult.OK)
            //    {
            //        UTF8Encoding encoderHash = new UTF8Encoding();
            //        SHA256Managed hasher = new SHA256Managed();
            //        byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(tarjeta.NumeroTarjeta));
            //        string tarjetaNumero = bytesDeHasheoToString(bytesDeHasheo);

            //        List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codCliente", "codigoDeCliente"); //traer codigo de cliente
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@nroTarjeta", tarjetaNumero);
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@ultimosDigitos", tarjeta.Numero.Substring(tarjeta.Numero.Length - 4, 4));
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codSeguridad", tarjeta.CodigoSeguridad);
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@mesVencimiento", tarjeta.Mes);
            //        SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@anioVencimiento", tarjeta.Anio);
            //        SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.GUARDAR_TARJETA", "SP", parametrosGuardarTarjeta);

            //        lector["codigoTarjeta"].ToString();
            //    }
            //}
            //else
            //{
            //    codigoTarjeta = lectorTarjeta["codigoTarjeta"].ToString();
            //}

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
            double montoTotal = Convert.ToDouble(lblPrecio.Text);
            int cantidad = ubicacionesSeleccionadas.Count;
            bool allBuy = dgvUbicaciones.Rows.Count == cantidad;
            
            List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codCliente", UserInstance.getUserInstance().clienteId); //traer codigo de cliente
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@FormaPago", codigoTarjeta);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fecha", Configuration.getStringActualDate());
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@monto", montoTotal);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@cantidad", cantidad);
            DataTable tabla = SqlConnector.obtenerDataTable("VADIUM.COMPRAR", "SP", parametrosGuardarTarjeta);
            SqlConnector.cerrarConexion();
            int? val = null;
            var compraId = tabla.Rows[0].ItemArray[0];
            if (compraId != null)
            { 
                val = Convert.ToInt32(compraId);
                Ubicaciones.comprarUbicaciones(ubicacionesSeleccionadas, (int)val);
                MessageBox.Show("Se han comprado " + cantidad + " entradas");
                this.Hide();
            }
            if (allBuy)
            {
                Publicaciones.PublicacionFinalizada(codPublicacionActual);
            }
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvUbicaciones_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var val = dgvUbicaciones[e.ColumnIndex, e.RowIndex];
                double precioActual = Convert.ToDouble(lblPrecio.Text);
                if (dgvUbicaciones[e.ColumnIndex, e.RowIndex].Value == null ? false : (bool)dgvUbicaciones[e.ColumnIndex, e.RowIndex].Value)
                {
                    var idUbi = dgvUbicaciones[1, e.RowIndex].Value;
                    ubicacionesSeleccionadas.Remove(Convert.ToInt32(idUbi));
                    precioActual -= Convert.ToDouble(dgvUbicaciones[4, e.RowIndex].Value);
                }
                else
                {
                    var idUbi = dgvUbicaciones[1, e.RowIndex].Value;
                    ubicacionesSeleccionadas.Add(Convert.ToInt32(idUbi));
                    precioActual += Convert.ToDouble(dgvUbicaciones[5, e.RowIndex].Value);
                }
                lblPrecio.Text = precioActual.ToString();

            }
        }
    }
}
