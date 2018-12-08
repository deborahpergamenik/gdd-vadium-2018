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
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT * FROM VADIUM.ROL", SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol((int)(decimal)lector["rol_id"], (string)lector["nombre"], (bool)lector["usuario_activo"]);
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

        public static void updatearRol(string nombre, List<Funcionalidad> listaNuevasFunc, bool estaChecked, int rol_id)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(new SqlParameter("@rol_id", rol_id));
            ListaParametros.Add(new SqlParameter("@nombreRol", nombre));
            ListaParametros.Add(new SqlParameter("@usuario_activo", estaChecked));

            int ret = SqlConnector.ejecutarQuery("UPDATE VADIUM.ROL SET rol_nombre = @nombreRol, usuario_activo = @usuario_activo WHERE rol_id = @rol_id", ListaParametros, SqlConnector.iniciarConexion());
            if (ret == -1)
                MessageBox.Show("Falló al actualizar el rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void deshabilitarRol(int rol_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@rol_id", rol_id);
            int resultado = SqlConnector.ejecutarQuery("UPDATE VADIUM.ROL SET usuario_activo = 0 WHERE rol_id = @rol_id", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al actualizar el rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void eliminarUsuariosPorRol(int rol_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@rol_id", rol_id);
            int resultado = SqlConnector.ejecutarQuery("DELETE FROM VADIUM.ROL_POR_USUARIO WHERE rol_id = @rol_id", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static List<Rol> obtenerRolesUsuario(int idUser)
        {
            List<Rol> roles = new List<Rol>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", idUser);

            SqlDataReader lectorRolesUsuario = SqlConnector.ejecutarReader("SELECT r.rol_id, rol_nombre, usuario_activo " +
                                                                    "FROM VADIUM.ROL r " +
                                                                    "JOIN VADIUM.ROL_POR_USUARIO ru ON r.rol_id = ru.rol_id " +
                                                                    "WHERE ru.usuario_id = @usuario_id",
                                                                    listaParametros, SqlConnector.iniciarConexion());
            if (lectorRolesUsuario.HasRows)
            {
                while (lectorRolesUsuario.Read())
                {
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["rol_id"]),
                                           Convert.ToString(lectorRolesUsuario["nombre"]),
                                           Convert.ToBoolean(lectorRolesUsuario["usuario_activo"])
                                           );
                    roles.Add(nuevoRol);
                }
            }

            SqlConnector.cerrarConexion();
            return roles;
        }

        public static void BorrarRolEnUsuario(int idUser, int rol_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@rol_id", rol_id);
            SqlConnector.agregarParametro(parametros, "@usuario_id", idUser);

            int resultado = SqlConnector.ejecutarQuery("DELETE FROM VADIUM.ROL_POR_USUARIO WHERE rol_id = @rol_id AND usuario_id = @usuario_id", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al eliminar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

        public static void AgregarRolEnUsuario(int idUser, int rol_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(parametros, "@rol_id", rol_id);
            SqlConnector.agregarParametro(parametros, "@usuario_id", idUser);

            int resultado = SqlConnector.ejecutarQuery("INSERT INTO VADIUM.ROL_POR_USUARIO (usuario_id, rol_id) VALUES ( @usuario_id ,  @rol_id )", parametros, SqlConnector.iniciarConexion());

            if (resultado == -1)
                MessageBox.Show("Falló al insertar Usuarios por Rol", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SqlConnector.cerrarConexion();
        }

    }
}
