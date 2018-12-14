using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class UserInstance
    {
        public static UserInstance userInstance = null;
        public Usuario usuario = null;
        public int? clienteId = null;
        public int? empresaId = null;
        public Rol rol;
        public static void createUserInstance()
        {
            userInstance = new UserInstance();
        }
        public static UserInstance getUserInstance()
        {
            if (userInstance == null)
            {
                createUserInstance();
            }
            return userInstance;
        }
        public void loadInformation(Usuario user, Rol rol)
        {
            this.rol = rol;
            this.usuario = user;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", user.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT c.cliente_id " +
                                                                "FROM VADIUM.CLIENTE c " +
                                                                "JOIN VADIUM.USUARIO u ON u.usuario_id = c.usuario_id " +
                                                                "WHERE c.usuario_id = @usuario_id AND u.usuario_activo = 1", listaParametros, SqlConnector.iniciarConexion());

            if (lector.HasRows)
            {
                lector.Read();
                clienteId = Convert.ToInt32(lector["cliente_id"]);
            }
                
            SqlConnector.cerrarConexion();

            List<SqlParameter> listaParametros2 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros2, "@usuario_id", user.usuario_id);
            SqlDataReader lector2 = SqlConnector.ejecutarReader("SELECT e.empresa_id " +
                                                                "FROM VADIUM.EMPRESA e " +
                                                                "JOIN VADIUM.USUARIO u ON u.usuario_id = e.usuario_id " +
                                                                "WHERE e.usuario_id = @usuario_id AND u.usuario_activo = 1 ", listaParametros2, SqlConnector.iniciarConexion());

            if (lector2.HasRows)
            {
                lector2.Read();
                this.empresaId = Convert.ToInt32(lector2["empresa_id"]);
            }

            SqlConnector.cerrarConexion();
        }

    }
}
