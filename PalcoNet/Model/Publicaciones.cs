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

        public static List<Publicacion> obtenerPublicacionesPaginadas(int start, int finish, string rubro, string  desc, DateTime? desde, DateTime? hasta)
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

        public static DataTable obtenerPublicaiones(int start, int finish, List<int> rubros, string desc, DateTime? desde, DateTime? hasta)
        {
            try{
                List<Publicacion> publicaciones = new List<Publicacion>();
                string query = obtenerQuerySinFiltros();
                string filtros = armarquery(start, finish, rubros, desc, desde, hasta);
                
                if (!String.IsNullOrEmpty(filtros))
                {
                    query = query + " WHERE " + filtros;
                }
                query = AgregarOrderBy(query);
                int cant = finish - start;
                query = agregarPaginacion(query, start, cant);
                //List<SqlParameter> listaParametros = new List<SqlParameter>();
                //SqlConnector.agregarParametro(listaParametros, "@desde", desde);
                //SqlConnector.agregarParametro(listaParametros, "@hasta", hasta);
                //SqlConnector.agregarParametro(listaParametros, "@rubros", rubros);
                //SqlConnector.agregarParametro(listaParametros, "@descripcion", hasta);
                DataTable table = SqlConnector.obtenerDataTable(query, "T" );
                return table;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        private static string agregarPaginacion(string query, int start, int cant)
        {

            string paginacion = "offset " + start + " rows fetch next " + cant + " rows only";
            query = query + " " + paginacion;
            return paginacion;
        }

        private static string AgregarOrderBy(string query)
        {
            string orderBy = " order by gr.comision DESC ";
            query = query + " " + orderBy;
            return query;
        }
        private static string armarquery(int start, int finish, List<int> rubros, string desc, DateTime? desde, DateTime? hasta)
        {
            string filtro = "";
            filtro += filtrosRubro(rubros);
          

            if (!String.IsNullOrEmpty(desc))
            {
                if (filtro != "")
                    filtro += " AND ";
                filtro += " p.descripcion LIKE  '%" + desc + "%' ";
            }


            if (desde!= null)
            {
                if (!string.IsNullOrEmpty(filtro))
                    filtro += " AND ";

                filtro += " p.fecha >= " + desde;
            }

            if (hasta!= null)
            {
                if (!string.IsNullOrEmpty(filtro))
                    filtro += " AND ";
                filtro += " p.fecha <= " + hasta;
            }

            return filtro;
        }

        private static string obtenerQuerySinFiltros()
        {
            return "SELECT pub.codigoEspectaculo, pub.descripcion,pub.fecha, pub.fechaVencimiento, rub.rubro_id, rub.descripcion as rubro_descripcion, " +
                    "pub.direccion as direccionEspectaculo, gr.descripcion as grado_descripcion, gr.comision as comision, gr.grado_id as grado_id, " +
                    "pub.empresa_id, es.codigo as estado_id, es.descripcion as estado_descripcion " +
                     "FROM VADIUM.PUBLICACION pub JOIN ESTADO es ON (pub.estado_id = es.codigo) " +
                                        "JOIN RUBRO rub ON (pub.rubro_id = rub.rubro_id) " +
                                        "JOIN GRADO gr ON (pub.grado_id = gr.grado_id)";
        }

        private static string filtrosRubro(List<int> rubros)
        {
            string filtro = "";
            if (rubros != null )
            {
                for (int i = 0; i < rubros.Count; i++)
                {
                   
                    if (i == 0)
                        filtro += " (";
                    else filtro += " or ";

                    filtro = filtro + "r.rubro_id = " + rubros[i];

                    if (i == rubros.Count - 1)
                        filtro += " ) ";
                }
            }
            return filtro;
        }
    }
}
