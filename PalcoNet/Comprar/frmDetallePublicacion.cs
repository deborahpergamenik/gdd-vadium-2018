using PalcoNet.Abm_Cliente;
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
        public Tarjeta tarjetaAsociada = null;
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
            cargarTarjetas();
        }

        private void cargarTarjetas()
        {
          List<Tarjeta> tarjetas =  Tarjeta.ObtenerTodasLasTarjetas((int)UserInstance.getUserInstance().clienteId);
          if (tarjetas.Count == 0)
          {
              lblTarjetasAsocidas.Visible = false;
              cmbTarjetas.Visible = false;
              return;
          }
          else
          {
              lblTarjetasAsocidas.Visible = true;
              cmbTarjetas.Visible = true;
              tarjetas.ForEach(x => cmbTarjetas.Items.Add(x.NumeroTarjeta));
          }
        }



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
         
            if (ubicacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("No se seleccionaron ubicaciones para comprar");
                return;
            }
            if(!mskNumeroTarjeta.MaskCompleted)
            {
                MessageBox.Show("Debe asociar una tarjeta de credito para poder comprar");
                return;
            }
            else if (MessageBox.Show("Desea confirmar la compra?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                generarCompra(mskNumeroTarjeta.Text);
                ubicacionesSeleccionadas.Clear();
                ubicacionesDisponibles.Clear();
            }
            else
            {
                MessageBox.Show("Compra cancelada");
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

        private void generarCompra(string codigoTarjeta)
        {
            double montoTotal = Convert.ToDouble(lblPrecio.Text);
            int cantidad = ubicacionesSeleccionadas.Count;
            bool allBuy = dgvUbicaciones.Rows.Count == cantidad;


            if (tarjetaAsociada != null)
            {
                insertarTarjeta();
            }

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


        public void insertarTarjeta()
        {
            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@nroTarjeta", tarjetaAsociada.NumeroTarjeta);
            SqlConnector.agregarParametro(listaParametros2, "@banco", tarjetaAsociada.Banco);
            SqlConnector.agregarParametro(listaParametros2, "@codSeguridad", tarjetaAsociada.CodigoSeguridad);
            SqlConnector.agregarParametro(listaParametros2, "@tipo", tarjetaAsociada.Tipo);
            SqlConnector.agregarParametro(listaParametros2, "@cliente_id", UserInstance.getUserInstance().clienteId);
            SqlConnector.agregarParametro(listaParametros2, "@mesVencimiento", tarjetaAsociada.MesVencimiento);
            SqlConnector.agregarParametro(listaParametros2, "@anioVencimiento", tarjetaAsociada.AnioVencimiento);
            SqlConnector.ejecutarQuery("INSERT INTO VADIUM.TARJETADECREDITO (nroTarjeta, banco, codSeguridad, tipo, cliente_id, mesVencimiento, anioVencimiento) " +
                                       "VALUES (@nroTarjeta, @banco, @codSeguridad, @tipo, @cliente_id, @mesVencimiento, @anioVencimiento)", listaParametros2, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();

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

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            frmAgregarTarjetaDeCredito tarjeta = new frmAgregarTarjetaDeCredito(this);
            this.Hide();
            tarjeta.ShowDialog();
            if (tarjetaAsociada != null)
            {
                mskNumeroTarjeta.Text = tarjetaAsociada.NumeroTarjeta;
            }
        }

        private void cmbTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTarjetas.SelectedItem != null)
            {
                string tarj = cmbTarjetas.SelectedItem.ToString();
            }
        }
    }
}
