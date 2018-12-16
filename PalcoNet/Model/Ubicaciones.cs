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
    class Ubicaciones
    {
        public static DataTable ObtenerUbicacionesLibresPorPublicacio(int? PublicacionId, int? tipoUbicacionId)
        {
            //UBICACIONES_NO_VENDIDAS
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@publicacion_id", PublicacionId));
            listaParametros.Add(new SqlParameter("@tipoUbicacionId", tipoUbicacionId));
            
            DataTable table = SqlConnector.obtenerDataTable("VADIUM.UBICACIONES_NO_VENDIDAS","SP", listaParametros);
            return table;
        }
        public static List<TipoUbicacion> ObtenerTipoDeUbicaciones()
        {
            List<TipoUbicacion> tipoUbicaciones = new List<TipoUbicacion>();
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT * FROM VADIUM.TIPOUBICACION", SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    tipoUbicaciones.Add(new TipoUbicacion(Convert.ToInt32(lector["rubro_id"]), lector["descripcion"].ToString()));
                }
            }
            SqlConnector.cerrarConexion();

            return tipoUbicaciones;
        }
    }
}
