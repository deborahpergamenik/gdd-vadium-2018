using PalcoNet.Common;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Model
{
    class Funcionalidades
    {
        public static List<Funcionalidad> obtenerTodasLasFuncionalidades(SqlConnection conexion)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();

            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT funcionalidad_id, Descripcion FROM PalcoNet.Funcionalidades", conexion);

            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad((int)(decimal)lectorFuncionalidades["funcionalidad_id"], (string)lectorFuncionalidades["Descripcion"]);
                    listaFuncionalidades.Add(unaFuncionalidad);
                }
            }
            SqlConnector.cerrarConexion();
            return listaFuncionalidades;
        }

        public static List<Funcionalidad> obtenerFuncionalidades(SqlConnection conexion, int rol_id)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@rol_id", rol_id);
            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT f.funcionalidad_id, f.nombre FROM PalcoNet.Funcionalidades f, VADIUM.ROL_POR_FUNCIONALIDAD fr WHERE fr.rol_id = @rol_id AND fr.funcionalidad_id = f.funcionalidad_id", listaParametros, conexion);

            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad((int)(decimal)lectorFuncionalidades["funcionalidad_id"], (string)lectorFuncionalidades["Descripcion"]);
                    listaFuncionalidades.Add(unaFuncionalidad);
                }
            }
            SqlConnector.cerrarConexion();
            return listaFuncionalidades;
        }

        public static void AgregarFuncionalidadEnRol(string descripcionRol, Funcionalidad funcionalidad)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol", descripcionRol));
            ListaParametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Descripcion));

            SqlConnector.ExecStoredProcedureSinRet("PalcoNet.AgregarFuncionalidad", ListaParametros);
            SqlConnector.cerrarConexion();

        }

        public static void BorrarFuncionalidadEnRol(string descripcionRol, string funcionalidad)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol", descripcionRol));
            ListaParametros.Add(new SqlParameter("@funcionalidad", funcionalidad));

            SqlConnector.ExecStoredProcedureSinRet("PalcoNet.QuitarFuncionalidad", ListaParametros);
            SqlConnector.cerrarConexion();
        }
    }
}
