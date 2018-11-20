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

            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT IdFuncionalidad, Descripcion FROM PalcoNet.Funcionalidades", conexion);

            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad((int)(decimal)lectorFuncionalidades["IdFuncionalidad"], (string)lectorFuncionalidades["Descripcion"]);
                    listaFuncionalidades.Add(unaFuncionalidad);
                }
            }
            SqlConnector.cerrarConexion();
            return listaFuncionalidades;
        }

        public static List<Funcionalidad> obtenerFuncionalidades(SqlConnection conexion, int idRol)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@IdRol", idRol);
            SqlDataReader lectorFuncionalidades = SqlConnector.ejecutarReader("SELECT f.IdFuncionalidad, f.Nombre FROM PalcoNet.Funcionalidades f, PalcoNet.Funcionalidad_Rol fr WHERE fr.IdRol = @IdRol AND fr.IdFuncionalidad = f.IdFuncionalidad", listaParametros, conexion);

            if (lectorFuncionalidades.HasRows)
            {
                while (lectorFuncionalidades.Read())
                {
                    Funcionalidad unaFuncionalidad = new Funcionalidad((int)(decimal)lectorFuncionalidades["IdFuncionalidad"], (string)lectorFuncionalidades["Descripcion"]);
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
