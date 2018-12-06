using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class Publicaciones
    {

        public static List<Publicacion> obtenerPublicacionesPaginadas(int desde, int hasta, string filtro, bool filtroRubros)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@desde", desde);
            SqlConnector.agregarParametro(listaParametros, "@hasta", hasta);
            SqlDataReader lector = SqlConnector.ObtenerDataReader("VADIUM.ObtenerPublicaciones", "SP", listaParametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Publicacion publi = new Publicacion();

                    publi.CodigoPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    publi.Descripcion = lector["descripcion"].ToString();

                    publi.Ubicacion.CodigoPublicacion = Convert.ToInt32(lector["Cod_Publicacion"]);
                    publi.Ubicacion.Asiento = Convert.ToInt32(lector["asiento"]);
                    publi.Ubicacion.Fila = lector["fila"].ToString();
                    publi.Ubicacion.Precio = Convert.ToInt32(lector["precio"]);
                    publi.Ubicacion.EmpresaId = Convert.ToInt32(lector["empresa_id"]);
                    publi.Ubicacion.SinNumerar = Convert.ToBoolean(lector["sinNumerar"]);
                    publi.Ubicacion.UbicacionId = Convert.ToInt32(lector["ubicacion_id"]);

                    publi.Ubicacion.TipoUbicacion.id = Convert.ToInt32(lector["tipoUbicacion_id"]);
                    publi.Ubicacion.TipoUbicacion.descripcion = lector["tipoUbicacion_descripcion"].ToString();
                    publi.Ubicacion.TipoUbicacion.codigo = Convert.ToDecimal(lector["tipoUbicacion_codigo"]);

                    publi.FechaPublicacion = Convert.ToDateTime(lector["fecha_publicacion"]);
                    publi.FechaEspectaculo = Convert.ToDateTime(lector["fecha_espectaculo"]);

                    publi.Rubro.Id = Convert.ToInt32(lector["rubro_id"]);
                    publi.Rubro.Descripcion = lector["rubro_descripcion"].ToString();

                    publi.DireccionEspectaculo = lector["direccionEspectaculo"].ToString();

                    publi.GradoPublicacion.id = Convert.ToInt32(lector["tipoGrado_id"]);
                    publi.GradoPublicacion.TipoGrado = lector["tipoGrado_descripcion"].ToString();

                    publi.userId = Convert.ToInt32(lector["user_id"]);
                    publi.EstadoPublicacion = Convert.ToInt32(lector["estadoPublicacion"]);
                }
            }

            SqlConnector.cerrarConexion();
            return publicaciones;
        }
    }
}
