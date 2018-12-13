using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public string usuario_username { get; set; }
        public string password { get; set; }
        public int usuario_intentosLogin { get; set; }
        public bool usuario_activo { get; set; }
        public bool primeraVez { get; set; }

        public List<Rol> Roles = new List<Rol>();

        public Usuario(int usuario_id, string usuario_username, string password)
        {
            this.usuario_id = usuario_id;
            this.usuario_username = usuario_username;
            this.password = password;
            Interfaz.usuarioLogeado(this);
        }


        public Boolean esAdmin()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);

            string commandText = "SELECT rol_id FROM VADIUM.ROL_POR_USUARIO WHERE usuario_id = @usuario_id";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);
            if (lector.HasRows)
            {
                lector.Read();

                int rol_id = Convert.ToInt32(lector["rol_id"]);
                SqlConnector.cerrarConexion();


                listaParametros.Clear();
                SqlConnector.agregarParametro(listaParametros, "@rol_id", rol_id);

                commandText = "SELECT nombre FROM VADIUM.ROL WHERE rol_id = @rol_id";

                lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

                if (lector.HasRows)
                {
                    lector.Read();

                    string nombre = Convert.ToString(lector["nombre"]);
                    SqlConnector.cerrarConexion();

                    if (nombre == "Administrador General")
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }




        public Boolean obtenerPK()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_id FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                this.usuario_id = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();
                return true;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return false;
            }
        }

        public Boolean habilitado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_activo FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            if (Convert.ToInt32(lector["usuario_activo"]) == 1)
            {
                SqlConnector.cerrarConexion();
                return true;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return false;
            }
        }

      
        public int primera_vez()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT primera_vez FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int pVez = Convert.ToInt32(lector["primera_vez"]);
            if (pVez == 0)
            {
                SqlConnector.cerrarConexion();
                return pVez;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return pVez;
            }
        }

        public Boolean verificarContraseniaSinHash(string password)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_password FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            if (password == Convert.ToString(lector["usuario_password"]))
            {
                SqlConnector.cerrarConexion();
                return true;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return false;
            }

        }

        public Boolean verificarContrasenia()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_username", this.usuario_username);
            SqlConnector.agregarParametro(listaParametros, "@usuario_password", this.password);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_username, usuario_password FROM VADIUM.USUARIO WHERE usuario_username = @usuario_username AND usuario_password = @usuario_password", listaParametros, SqlConnector.iniciarConexion());
            Boolean res = lector.HasRows;
            SqlConnector.cerrarConexion();
            return res;
        }

        public void Resetearusuario_intentosLoginFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_intentosLogin = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void sumarIntentoFallido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_intentosLogin = (usuario_intentosLogin+1) WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public int usuario_intentosLoginFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_intentosLogin FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int res = Convert.ToInt32(lector["usuario_intentosLogin"]);
            SqlConnector.cerrarConexion();
            return res;
        }

        public int cantidadusuario_intentosLoginFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_intentosLogin FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int resultado = Convert.ToInt32(lector["usuario_intentosLogin"]);
                SqlConnector.cerrarConexion();
                return resultado;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return -1;
            }
        }

        public void inhabilitarUsuario()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_activo = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarpassword(string nuevoPass)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(nuevoPass));
            string password = bytesDeHasheoToString(bytesDeHasheo);


            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", this.usuario_id);
            SqlConnector.agregarParametro(listaParametros, "@password", password);
            SqlConnector.ejecutarQuery("UPDATE VADIUM.USUARIO SET usuario_password = @password, primera_vez = 0 WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        public Boolean obtenerRoles()
        {
            List<SqlParameter> listaParametros1 = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros1, "@usuario_id", this.usuario_id);
            SqlConnection conexion = SqlConnector.iniciarConexion();
            SqlDataReader lectorRolesUsuario = SqlConnector.ejecutarReader("SELECT rol_id FROM VADIUM.ROL_POR_USUARIO WHERE usuario_id = @usuario_id", listaParametros1, conexion);
            if (lectorRolesUsuario.HasRows)
            {
                while (lectorRolesUsuario.Read())
                {
                    List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                    SqlConnector.agregarParametro(listaParametros2, "@rol_id", Convert.ToInt32(lectorRolesUsuario["rol_id"]));
                    SqlDataReader lectorRoles = SqlConnector.ejecutarReader("SELECT rol_nombre, rol_habilitado FROM VADIUM.ROL WHERE rol_id = @rol_id", listaParametros2, conexion);
                    lectorRoles.Read();
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["rol_id"]), lectorRoles["rol_nombre"].ToString(), (bool)lectorRoles["rol_habilitado"]);
                    nuevoRol.obtenerFuncionalidades(conexion);
                    this.Roles.Add(nuevoRol);
                }
                SqlConnector.cerrarConexion();
                return true;
            }
            else
            {
                SqlConnector.cerrarConexion();
                return false;
            }
        }
       

        public static bool controlarRol(int usuario_id)
        {
            bool resultado = false;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@usuario_id", usuario_id));
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT rol_id FROM VADIUM.ROL_POR_USUARIO WHERE usuario_id = @usuario_id", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int rol = Convert.ToInt32(lector["rol_id"]);
                if (rol == 0)
                {
                    resultado = true;
                }
            }

            SqlConnector.cerrarConexion();
            return resultado;
        }

        public static DataTable obtenerUsuarios()
        {
            string str = "SELECT usuario_id, usuario_username from VADIUM.USUARIO";

            DataTable DataTable = SqlConnector.obtenerDataTable(str, "T");

            return DataTable;
        }

        public static string obtenerUsername(int usuario_id)
        {
            string username = "";

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@usuario_id", usuario_id);
            SqlConnection conexion = SqlConnector.iniciarConexion();

            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT usuario_username FROM VADIUM.USUARIO WHERE usuario_id = @usuario_id", listaParametros, conexion);
            lector.Read();

            username = Convert.ToString(lector["usuario_username"]);

            SqlConnector.cerrarConexion();
            return username;
        }        

        public static int obtenerusuario_id(string username)
        {
            int usuario_id;

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            SqlConnector.agregarParametro(listaParametros, "@usuario_username", username);

            string commandText = "SELECT usuario_id FROM VADIUM.USUARIO WHERE usario_username = @usuario_username";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                usuario_id = Convert.ToInt32(lector["usuario_id"]);
                SqlConnector.cerrarConexion();
                return usuario_id;
            }
            else
                return -1;
        }


        internal string LoguearUsuario(out bool resultado, out bool passwordMatched)
        {
            string mensaje = "";
            passwordMatched = false;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@user", this.usuario_username);
            SqlConnector.agregarParametro(listaParametros, "@pass", password);
            DataTable dataTable = SqlConnector.obtenerDataTable("VADIUM.VERIFICAR_USUARIO_PASSWORD", "SP", listaParametros);
            SqlConnector.cerrarConexion();
            if (dataTable.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                resultado = false;
                mensaje = dataTable.Rows[0].ItemArray[1].ToString();

            }
            else if (dataTable.Rows[0].ItemArray[0].ToString() == "")
            {
                resultado = false;
                mensaje = "Password o Usuario Incorrecto";

            }
            else
            {
                resultado = true;
                password = dataTable.Rows[0].ItemArray[0].ToString();
                usuario_username = dataTable.Rows[0].ItemArray[1].ToString();
                usuario_activo = Convert.ToBoolean(dataTable.Rows[0].ItemArray[2]);
                usuario_id = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
                usuario_intentosLogin = Convert.ToInt32(dataTable.Rows[0].ItemArray[4]);
                primeraVez = Convert.ToBoolean(dataTable.Rows[0].ItemArray[5]);
                string val = dataTable.Rows[0].ItemArray[6].ToString();
                passwordMatched = Convert.ToBoolean(Convert.ToInt32(dataTable.Rows[0].ItemArray[6].ToString()));
            }

            return mensaje;
        }

        internal void bloquear()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@user", this.usuario_username);
            SqlConnector.ObtenerDataReader("VADIUM.BLOQUEAR", "SP", listaParametros);
            SqlConnector.cerrarConexion();
        }

        internal void usuarioLogueado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@user", this.usuario_username);
            SqlConnector.ObtenerDataReader("VADIUM.USUARIO_LOGUEADO", "SP", listaParametros);
            SqlConnector.cerrarConexion();
        }
    }
}
