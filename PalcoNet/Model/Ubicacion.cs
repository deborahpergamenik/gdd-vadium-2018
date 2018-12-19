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
        public string Fila { get; set; }
        public int Asiento { get; set; }
        public bool SinNumerar { get; set; }
        public int Precio { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public int idTipoUbicacion { get; set; }
        public string Tipo
        {
            get
            {
                return TipoUbicacion.descripcion;
            }

        }
        public int CodigoPublicacion { get; set; }


        internal object save(int esp)
        {
             
            List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fila", Fila); //traer codigo de cliente
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@asiento", Asiento);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@sinNumerar", SinNumerar);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@precio", Precio);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codigoTipoubicacion", idTipoUbicacion);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codigoEspectaculo", esp);
            SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@compra_id", null);

            DataTable tabla = SqlConnector.obtenerDataTable("VADIUM.AgregarUbicacion", "SP", parametrosGuardarTarjeta);
            int? val = null;
            val = Convert.ToInt32(tabla.Rows[0].ItemArray[0]);

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
