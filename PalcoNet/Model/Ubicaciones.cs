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
                    string val = lector["codigoTipoUbicacion"].ToString();
                    val = lector["descripcion"].ToString();
                    tipoUbicaciones.Add(new TipoUbicacion(Convert.ToInt32(lector["codigoTipoUbicacion"].ToString()), lector["descripcion"].ToString()));
                }
            }
            SqlConnector.cerrarConexion();

            return tipoUbicaciones;
        }
        public static void comprarUbicaciones (List<int> ubicaciones, int compraId)
        {
            string filtro = Configuration.createFilter(ubicaciones, "ubicacion_id");
            SqlDataReader lector = SqlConnector.ejecutarReader("UPDATE VADIUM.UBICACION  SET compra_id = " + compraId + " WHERE " + filtro , SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }
        public static void AgregarLote(List<Ubicacion> ubicaciones, int codPubli)
        {
            if (ubicaciones.Count > 0)
            {
                DataTable tableUbi = new DataTable();
                tableUbi = ConvertListToDataTable(ubicaciones, codPubli);
                List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros2, "@items", tableUbi);
                SqlConnector.ExecStoredProcedureSinRet("VADIUM.AgregarLoteUbicaiones", listaParametros2);
                SqlConnector.cerrarConexion();
            }
        }
        public static DataTable ConvertListToDataTable(List<Ubicacion> ubicaciones, int codPubli)
        {
            DataTable tableUbi = new DataTable();
            int count = 0;
            tableUbi.Columns.Add("fila");
            tableUbi.Columns.Add("asiento");
            tableUbi.Columns.Add("sinNumerar");
            tableUbi.Columns.Add("precio");
            tableUbi.Columns.Add("codigoTipoubicacion");
            tableUbi.Columns.Add("codigoEspectaculo");
            tableUbi.Columns.Add("compra_id");
            foreach (Ubicacion ubic in ubicaciones)
            {
                DataRow row = tableUbi.NewRow();
                row[0] = ubic.fila;
                row[1] = ubic.asiento;
                row[2] = ubic.sinNumerar;
                row[3] = ubic.precio;
                row[4] = ubic.codigoTipoubicacion;
                row[5] = codPubli;
                row[6] = null;
                tableUbi.Rows.Add(row);
                count++;
            }
            return tableUbi;
        }
       
        
    }
}
