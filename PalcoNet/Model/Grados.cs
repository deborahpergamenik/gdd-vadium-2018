using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Grados
    {
        public static List<Grado> ObtenerTodosLosGrados()
        {
            List<Grado> grados = new List<Grado>();

            string commandText = "SELECT * FROM PalcoNet.GRADO";

            SqlDataReader lector = SqlConnector.ejecutarReader(commandText, SqlConnector.iniciarConexion());


            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Grado unGrado = new Grado((string)lector["descripcion"],
                                                    (decimal)lector["comision"], (int)lector["grado_id"]);
                    grados.Add(unGrado);
                }
            }
            SqlConnector.cerrarConexion();
            return grados;
        }
    }
}
