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
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int Intentos { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Calle { get; set; }
        public string NroPiso { get; set; }
        public string Depto { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }        
        public bool Estado { get; set; }


        public List<Rol> Roles = new List<Rol>();

        public Usuario(int idUsuario, string nombreUsuario, string password)
        {
            this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
            Interfaz.usuarioLogeado(this);
        }


        public Boolean esAdmin()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);

            string commandText = "SELECT IdRol FROM PalcoNet.Rol_Usuario WHERE IdUsuario = @idUsuario";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);
            if (lector.HasRows)
            {
                lector.Read();

                int idRol = Convert.ToInt32(lector["IdRol"]);
                SqlConnector.cerrarConexion();


                listaParametros.Clear();
                SqlConnector.agregarParametro(listaParametros, "@idRol", idRol);

                commandText = "SELECT Nombre FROM PalcoNet.Rol WHERE ID_ROL = @idRol";

                lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

                if (lector.HasRows)
                {
                    lector.Read();

                    string nombre = Convert.ToString(lector["Nombre"]);
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
            SqlConnector.agregarParametro(listaParametros, "@nombreUsuario", this.NombreUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdUsuario FROM PalcoNet.Usuario WHERE NombreUsuario = @nombreUsuario", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                this.IdUsuario = Convert.ToInt32(lector["IdUsuario"]);
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
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT Estado FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            if (Convert.ToInt32(lector["Estado"]) == 1)
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

      
        public int primeraVez()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT Primera_Vez FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int pVez = Convert.ToInt32(lector["Primera_Vez"]);
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
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT Password FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            if (password == Convert.ToString(lector["Password"]))
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
            SqlConnector.agregarParametro(listaParametros, "@Username", this.NombreUsuario);
            SqlConnector.agregarParametro(listaParametros, "@password", this.Password);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT NombreUsuario, Password FROM PalcoNet.Usuario WHERE Username = @Username AND Password = @password", listaParametros, SqlConnector.iniciarConexion());
            Boolean res = lector.HasRows;
            SqlConnector.cerrarConexion();
            return res;
        }

        public void ResetearIntentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Intentos = 0 WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void sumarIntentoFallido()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Intentos = (Intentos+1) WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public int intentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT Intentos FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            lector.Read();
            int res = Convert.ToInt32(lector["Intentos"]);
            SqlConnector.cerrarConexion();
            return res;
        }

        public int cantidadIntentosFallidos()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT Intentos FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int resultado = Convert.ToInt32(lector["Intentos"]);
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
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Estado = 0 WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            SqlConnector.cerrarConexion();
        }

        public void cambiarPassword(string nuevoPass)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(nuevoPass));
            string password = bytesDeHasheoToString(bytesDeHasheo);

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", this.IdUsuario);
            SqlConnector.agregarParametro(listaParametros, "@password", password);
            SqlConnector.ejecutarQuery("UPDATE PalcoNet.Usuario SET Password = @password, Primera_Vez = 0 WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
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
            SqlConnector.agregarParametro(listaParametros1, "@idUsuario", this.IdUsuario);
            SqlConnection conexion = SqlConnector.iniciarConexion();
            SqlDataReader lectorRolesUsuario = SqlConnector.ejecutarReader("SELECT IdRol FROM PalcoNet.Rol_Usuario WHERE IdUsuario = @idUsuario", listaParametros1, conexion);
            if (lectorRolesUsuario.HasRows)
            {
                while (lectorRolesUsuario.Read())
                {
                    List<SqlParameter> listaParametros2 = new List<SqlParameter>();
                    SqlConnector.agregarParametro(listaParametros2, "@idRol", Convert.ToInt32(lectorRolesUsuario["IdRol"]));
                    SqlDataReader lectorRoles = SqlConnector.ejecutarReader("SELECT Nombre, Estado FROM PalcoNet.Rol WHERE ID_Rol = @idRol", listaParametros2, conexion);
                    lectorRoles.Read();
                    Rol nuevoRol = new Rol(Convert.ToInt32(lectorRolesUsuario["IdRol"]), lectorRoles["Nombre"].ToString(), (bool)lectorRoles["Estado"]);
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
       

        public static bool controlarRol(int idUsuario)
        {
            bool resultado = false;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter("@idUsuario", idUsuario));
            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT IdRol FROM PalcoNet.Rol_Usuario WHERE IdUsuario = @idUsuario", listaParametros, SqlConnector.iniciarConexion());
            if (lector.HasRows)
            {
                lector.Read();
                int rol = Convert.ToInt32(lector["IdRol"]);
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
            string str = "SELECT IdUsuario, NombreUsuario from PalcoNet.Usuario";

            DataTable DataTable = SqlConnector.obtenerDataTable(str, "T");

            return DataTable;
        }

        public static string obtenerUsername(int idUsuario)
        {
            string username = "";

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@idUsuario", idUsuario);
            SqlConnection conexion = SqlConnector.iniciarConexion();

            SqlDataReader lector = SqlConnector.ejecutarReader("SELECT NombreUsuario FROM PalcoNet.Usuario WHERE IdUsuario = @idUsuario", listaParametros, conexion);
            lector.Read();

            username = Convert.ToString(lector["NombreUsuario"]);

            SqlConnector.cerrarConexion();
            return username;
        }        

        public static int obteneridUsuario(string username)
        {
            int idUsuario;

            List<SqlParameter> listaParametros = new List<SqlParameter>();

            SqlConnector.agregarParametro(listaParametros, "@nombreUsuario", username);

            string commandText = "SELECT IdUsuario FROM PalcoNet.Usuario WHERE Username = @nombreUsuario";

            SqlDataReader lector = SqlConnector.ObtenerDataReader(commandText, "T", listaParametros);

            if (lector.HasRows)
            {
                lector.Read();
                idUsuario = Convert.ToInt32(lector["IdUsuario"]);
                SqlConnector.cerrarConexion();
                return idUsuario;
            }
            else
                return -1;
        }

    }
}
