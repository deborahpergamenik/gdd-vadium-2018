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
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public List<Funcionalidad> Funcionalidades = new List<Funcionalidad>();

        public Rol(int id, string nombre, bool estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = estado;
        }

        public void obtenerFuncionalidades(SqlConnection conexion)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idRol", this.Id);
            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT IdFuncionalidad FROM PalcoNet.Funcionalidad_Rol WHERE ID_Rol = @idRol", listaParametros, conexion);
            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad funcionalidad = new Funcionalidad(Convert.ToInt32(lectorFuncionalidades["IdFuncionalidad"]));
                    this.Funcionalidades.Add(funcionalidad);
                }
            }
        }

        public static int obtenerID(string nombreRol)
        {
            int idRol;
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            listaParametros.Clear();

            SqlConnector.agregarParametro(listaParametros, "@nombre", "Cliente");

            string commandText = "SELECT IdRol FROM PalcoNet.Rol WHERE Nombre = @nombre";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                idRol = Convert.ToInt32(lector["IdRol"]);

            }
            else
                idRol = -1;

            SqlConnector.cerrarConexion();
            return idRol;
        }
    }
}
