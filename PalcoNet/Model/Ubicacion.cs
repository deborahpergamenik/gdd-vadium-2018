using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Ubicacion
    {
        public Publicacion publicacion { get; set; }
        public int UbicacionId { get; set; }
        public string fila { get; set; }
        public int asiento { get; set; }
        public bool sinNumerar { get; set; }
        public int precio { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public int codigoTipoubicacion { get; set; }
        public int codigoEspectaculo { get; set; }
        public string Tipo
        {
            get
            {
                return TipoUbicacion.descripcion;
            }

        }
      


        internal object save(int esp)
        {
             
            List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fila", fila); //traer codigo de cliente
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@asiento", asiento);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@sinNumerar", sinNumerar);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@precio", precio);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codigoTipoubicacion", codigoTipoubicacion);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codigoEspectaculo", esp);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@compra_id", null);

            DataTable tabla = SqlConnector.obtenerDataTable("VADIUM.AgregarUbicacion", "SP", parametrosGuardarTarjeta);
            int? val = null;
            try { val = Convert.ToInt32(tabla.Rows[0].ItemArray[0]); }
            catch{ }

            return val;
        }
    }

    public class TipoUbicacion
    {
       
        public TipoUbicacion(int cod, string desc)
        {
            // TODO: Complete member initialization
            this.id = cod;
            this.descripcion = desc;
        }
        public int id { get; set; }
        public string descripcion { get; set; }

    }

}
