using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public bool usuario_activo { get; set; }
        public List<Funcionalidad> Funcionalidades = new List<Funcionalidad>();

        public Rol(int id, string nombre, bool usuario_activo)
        {
            this.Id = id;
            this.nombre = nombre;
            this.usuario_activo = usuario_activo;
        }

        public void obtenerFuncionalidades(SqlConnection conexion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@rol_id", this.Id);
            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT funcionalidad_id FROM VADIUM.ROL_POR_FUNCIONALIDAD WHERE rol_id = @rol_id", listaParametros, conexion);
            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad funcionalidad = new Funcionalidad(Convert.ToInt32(lectorFuncionalidades["funcionalidad_id"]));
                    this.Funcionalidades.Add(funcionalidad);
                }
            }
        }

        public static int obtenerID(string nombreRol)
        {
            int rol_id;
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            listaParametros.Clear();

            SqlConnector.agregarParametro(listaParametros, "@nombre", "Cliente");

            string commandText = "SELECT rol_id FROM VADIUM.ROL WHERE nombre = @nombre";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                rol_id = Convert.ToInt32(lector["rol_id"]);

            }
            else
                rol_id = -1;

            SqlConnector.cerrarConexion();
            return rol_id;
        }
    }
}
