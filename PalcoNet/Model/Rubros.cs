using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Common;
using System.Data.SqlClient;
namespace PalcoNet.Model
{
    public class Rubros
    {
        public static List<Rubro> obtenerRubros()
        {
            List<Rubro> rubros = new List<Rubro>();

            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT * FROM VADIUM.RUBRO", SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    rubros.Add(new Rubro(Convert.ToInt32(lector["rubro_id"]), lector["descripcion"].ToString()));
                }
            }
            SqlConnector.cerrarConexion();

            return rubros;
        }


        public static string obtenerStringRubros(int codPubli)
        {
            string rubros = "";

            List<Rubro> listaRubros = new List<Rubro>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@codigoEspectaculo", codPubli));

            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT r.descripcion FROM VADIUM.RUBRO r " +
                                                        "JOIN VADIUM.PUBLICACION p ON p.rubro_id = r.rubro_id " +
                                                        "WHERE rp.codigoEspectaculo = @codigoEspectaculo", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                bool primero = true;

                while (lector.Read())
                {
                    if (primero)
                    {
                        rubros += Convert.ToString(lector["descripcion"]);
                        primero = false;
                    }
                    else
                        rubros += ", " + Convert.ToString(lector["descripcion"]);
                }
            }

            SqlConnector.cerrarConexion();
            return rubros;

        }

        
    }
}
