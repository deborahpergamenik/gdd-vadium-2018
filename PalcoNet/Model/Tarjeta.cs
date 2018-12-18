using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Tarjeta
    {
        public int? Id { get; set; }
        public string NumeroTarjeta { get; set; }
        public string Banco { get; set; }
        public string CodigoSeguridad { get; set; }
        public string Tipo { get; set; }
        public int Cliente_id { get; set; }
        public string MesVencimiento { get; set; }
        public string AnioVencimiento { get; set; }


        public Tarjeta(int? _id, string _nroTarjeta, string _banco, string _codigoSeguridad, string _tipo, int _cliente_id, string _mesVencimiento, string _anioVencimiento)
        {
            this.Id = _id;
            this.NumeroTarjeta = _nroTarjeta;
            this.Banco = _banco;
            this.CodigoSeguridad = _codigoSeguridad;
            this.Tipo = _tipo;
            this.Cliente_id = _cliente_id;
            this.MesVencimiento = _mesVencimiento;
            this.AnioVencimiento = _anioVencimiento;
        }



        public static List<Tarjeta> ObtenerTodasLasTarjetas(int cliente_id)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@cliente_id", cliente_id);
            string commandText = "SELECT * FROM VADIUM.TARJETADECREDITO WHERE cliente_id = @cliente_id";

            SqlDataReader lector = SqlConnector.ejecutarReader(commandText, listaParametros, SqlConnector.iniciarConexion());


            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Tarjeta unaTarjeta = new Tarjeta((int)lector["tarjeta_id"], 
                                                     (string)lector["nroTarjeta"], 
                                                     (string)lector["banco"],
                                                     (string)lector["codSeguridad"],
                                                     (string)lector["tipo"],
                                                     (int)lector["cliente_id"],
                                                     (string)lector["mesVencimiento"],
                                                     (string)lector["anioVencimiento"]);
                    tarjetas.Add(unaTarjeta);
                }
            }
            SqlConnector.cerrarConexion();
            return tarjetas;
        }

    }
}
