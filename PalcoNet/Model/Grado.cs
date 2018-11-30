using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class Grado
    {
        public string TipoGrado { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo_Publicacion { get; set; }

        public Grado(string grado, string descripcion, decimal costoPublicacion)
        {
            this.TipoGrado = grado;
            this.Descripcion = descripcion;
            this.Costo_Publicacion = costoPublicacion;
        }

        public static List<Grado> ObtenerTodosLosGrados()
        {
            List<Grado> grados = new List<Grado>();

            string commandText = "SELECT * FROM PalcoNet.Grados";

            SqlDataReader lector = SqlConnector.ejecutarReader(commandText, SqlConnector.iniciarConexion());


            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Grado unGrado = new Grado((string)lector["TipoGrado"],
                                                    (string)lector["Descripcion"],
                                                    (decimal)lector["CostoPublicacion"]);
                    grados.Add(unGrado);
                }
            }
            SqlConnector.cerrarConexion();
            return grados;
        }


    }
}
