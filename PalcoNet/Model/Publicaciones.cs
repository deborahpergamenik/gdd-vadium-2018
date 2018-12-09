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
    class Publicaciones
    {

        public static List<Publicacion> obtenerPublicacionesPaginadas(int start, int finish, string rubro, string  desc, DateTime desde, DateTime hasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@desde", desde);
            SqlConnector.agregarParametro(listaParametros, "@hasta", hasta);
            SqlConnector.agregarParametro(listaParametros, "@rubro", hasta);
            SqlConnector.agregarParametro(listaParametros, "@descripcion", hasta);
            SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.ObtenerPublicaciones", "SP", listaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Publicacion publi = new Publicacion();

                    publi.CodigoPublicacion = Convert.ToInt32(lector["codigoEspectaculo"]);
                    publi.Descripcion = lector["descripcion"].ToString();

                    //publi.Ubicacion.CodigoPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    //publi.Ubicacion.Asiento = Convert.ToInt32(lector["asiento"]);
                    //publi.Ubicacion.Fila = lector["fila"].ToString();
                    //publi.Ubicacion.Precio = Convert.ToInt32(lector["precio"]);
                    //publi.Ubicacion.EmpresaId = Convert.ToInt32(lector["empresa_id"]);
                    //publi.Ubicacion.SinNumerar = Convert.ToBoolean(lector["sinNumerar"]);
                    //publi.Ubicacion.UbicacionId = Convert.ToInt32(lector["ubicacion_id"]);

                    //publi.Ubicacion.TipoUbicacion.id = Convert.ToInt32(lector["tipoUbicacion_id"]);
                    //publi.Ubicacion.TipoUbicacion.descripcion = lector["tipoUbicacion_descripcion"].ToString();
                    //publi.Ubicacion.TipoUbicacion.codigo = Convert.ToDecimal(lector["tipoUbicacion_codigo"]);

                    publi.FechaPublicacion = Convert.ToDateTime(lector["fecha_publicacion"]);
                    publi.FechaEspectaculo = Convert.ToDateTime(lector["fecha_espectaculo"]);

                    publi.Rubro = new Rubro(Convert.ToInt32(lector["rubro_id"]), lector["rubro_descripcion"].ToString());
             

                    publi.direccionEspectaculo = lector["direccionEspectaculo"].ToString();

                    publi.GradoPublicacion = new Grado(lector["grado_descripcion"].ToString(),Convert.ToDecimal(lector["comision"]), Convert.ToInt32(lector["grado_id"]));

                    publi.empresaId = Convert.ToInt32(lector["empresa_id"]);
                    publi.usuario_activo = new Estado(Convert.ToInt32(lector["usuario_activo_id"]),lector["usuario_activo_descripcion"].ToString());
                    publicaciones.Add(publi);
                }
            }
            publicaciones = publicaciones.Skip(start).Take(finish).ToList();
            SqlConnector.cerrarConexion();
            return publicaciones;
        }

        public static DataTable obtenerPublicaiones(int start, int finish, string rubro, string desc, DateTime? desde, DateTime? hasta)
        {
            try{
                List<Publicacion> publicaciones = new List<Publicacion>();

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@desde", desde);
                SqlConnector.agregarParametro(listaParametros, "@hasta", hasta);
                SqlConnector.agregarParametro(listaParametros, "@rubro", hasta);
                SqlConnector.agregarParametro(listaParametros, "@descripcion", hasta);
                DataTable table = SqlConnector.obtenerDataTable("VADIUM.ObtenerPublicaciones", "SP", listaParametros);
                return table;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
