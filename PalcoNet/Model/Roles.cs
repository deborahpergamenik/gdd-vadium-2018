using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Model
{
    class Roles
    {

        public static List<Rol> obtenerRoles()
        {
            List<Rol> roles = new List<Rol>();
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT * FROM PalcoNet.Rol", SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol((int)(decimal)lector["IdRol"], (string)lector["Nombre"], (bool)lector["Estado"]);
                    roles.Add(unRol);
                }
            }
            SqlConnector.cerrarConexion();
            return roles;
        }
        public static bool insertarNuevoRol(string nombre, List<Funcionalidad> lista)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(new SqlParameter("@nombreRol", nombre));
                SqlParameter paramRet = new SqlParameter("@ret", System.Data.SqlDbType.Decimal);
                paramRet.Direction = System.Data.ParameterDirection.Output;
                ListaParametros.Add(paramRet);

                //insert, devuelve ret = id rol insertado
                //TODO : Mega fino.. hacer que agregarRolNuevo haga primero select para ver si ya existe luego
                // el insert, como esta ahora NO inserta si ya existe, pero el identity suma +1 y queda "feo"
                // no afecta en nada, pero bueno, belleza. 
                // ej: inserta: id 4, nombre Rol1 SUCCES, inserta Rol1 de nuevo FAIL, no inserta, pero identity+1
                // inserta Rol22 SUCCES, pero queda id 6. 
                int ret = (int)SqlConnector.ExecStoredProcedure("PalcoNet.agregarRolNuevo", ListaParametros);
                SqlConnector.cerrarConexion();

                if (ret != 0)
                {
                    foreach (Funcionalidad unaFunc in lista)
                    {
                        //insert FUNCIONALIDAD_ROL 
                        Funcionalidades.AgregarFuncionalidadEnRol(nombre, unaFunc);
                    }
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public static void updatearRol(string nombre, List<Funcionalidad> listaNuevasFunc, bool estaChecked, int idRol)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@idRol", idRol));
            ListaParametros.Add(new SqlParameter("@nombreRol", nombre));
            ListaParametros.Add(new SqlParameter("@estado", estaChecked));

            int ret = SqlConnector.ejecutarQuery("UPDATE PalcoNet.Rol SET Nombre = @nombreRol, Estado = @estado WHERE IdRol = @idRol", ListaParametros, SqlConnector.iniciarConexion());
            if (ret == -1)
                MessageBox.Show("Falló al actualizar el rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void deshabilitarRol(int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@idRol", idRol);
            int resultado = SqlConnector.ejecutarQuery("UPDATE PalcoNet.Rol SET Estado = 0 WHERE IdRol = @idRol", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al actualizar el rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void eliminarUsuariosPorRol(int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@idRol", idRol);
            int resultado = SqlConnector.ejecutarQuery("DELETE FROM PalcoNet.Rol_Usuario WHERE IdRol = @idRol", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static List<Rol> obtenerRolesUsuario(int idUser)
        {
            List<Rol> roles = new List<Rol>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", idUser);

            SqlDataReader lectorRolesUsuario = SqlConnector.ejecutarReader("SELECT r.IdRol, Nombre, Estado " +
                                                                    "FROM PalcoNet.Rol r " +
                                                                    "JOIN PalcoNet.Rol_Usuario ru ON r.IdRol = ru.IdRol " +
                                                                    "WHERE ru.IdUsuario = @idUsuario",
                                                                    listaParametros, SqlConnector.iniciarConexion());
            if (lectorRolesUsuario.HasRows)
            {
                while (lectorRolesUsuario.Read())
                {
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["IdRol"]),
                                           Convert.ToString(lectorRolesUsuario["Nombre"]),
                                           Convert.ToBoolean(lectorRolesUsuario["Estado"])
                                           );
                    roles.Add(nuevoRol);
                }
            }

            SqlConnector.cerrarConexion();
            return roles;
        }

        public static void BorrarRolEnUsuario(int idUser, int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@idRol", idRol);
            SqlConnector.agregarParametro(parametros, "@idUsuario", idUser);

            int resultado = SqlConnector.ejecutarQuery("DELETE FROM PalcoNet.Rol_Usuario WHERE IdRol = @idRol AND IdUsuario = @idUsuario", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void AgregarRolEnUsuario(int idUser, int idRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@idRol", idRol);
            SqlConnector.agregarParametro(parametros, "@idUsuario", idUser);

            int resultado = SqlConnector.ejecutarQuery("INSERT INTO PalcoNet.Rol_Usuario (IdUsuario, IdRol) VALUES ( @idUsuario ,  @idRol )", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al insertar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

    }
}
