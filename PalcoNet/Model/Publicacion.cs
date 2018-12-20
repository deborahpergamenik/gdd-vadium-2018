using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Publicacion
    {
        public int CodigoPublicacion { get; set; }
        public string Descripcion { get; set; }
        
        public DateTime FechaPublicacion { get; set; } 
        public DateTime FechaEspectaculo { get; set; }  
        public Rubro Rubro { get; set; }
        public int rubro_id { get; set; }
        public string direccionEspectaculo { get; set; }
        public Grado GradoPublicacion { get; set; }
        public int grado_id { get; set; }
        public int empresaId { get; set; }//la publicacion tiene asociada una empresa
        public Estado estado { get; set; }
        public int estado_id { get; set; }
        public int stock { get; set; }
        public int precio { get; set; }
        public List<Ubicacion> ubicaiones { get;set;}
        internal int? save()
        {

            try
            {
                List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@desc", Descripcion); //traer codigo de cliente
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fechEsp", FechaEspectaculo);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fechaPub", FechaPublicacion);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@estado_id", estado_id);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@direccion", direccionEspectaculo);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@rubro_id", rubro_id);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@grado_id", grado_id); //traer codigo de cliente
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@empresa_id", empresaId);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@stock", 0);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@precio", precio);

                DataTable tabla = SqlConnector.obtenerDataTable("VADIUM.AgregarPublicacion", "SP", parametrosGuardarTarjeta);
                int? val = null;
                 val = Convert.ToInt32(tabla.Rows[0].ItemArray[0]);
                 if (val != null)
                     Ubicaciones.AgregarLote(this.ubicaiones, (int)val);
                return val;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Publicacion()
        {
            ubicaiones = new List<Ubicacion>();
        }
        internal int save(List<DateTime> espectaculos)
        {
            int cantOk = 0;
            foreach (DateTime date in espectaculos)
            {
                FechaEspectaculo = date;
                int? id;
                if ((id = save()) != null)
                {
                    cantOk++;
                }
                
            }

            return cantOk;
        }

        internal int? update()
        {
            try
            {
                List<SqlParameter> parametrosGuardarTarjeta = new List<SqlParameter>();
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@desc", Descripcion); //traer codigo de cliente
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fechEsp", FechaEspectaculo);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@fechaPub", FechaPublicacion);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@estado_id", estado_id);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@direccion", direccionEspectaculo);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@rubro_id", rubro_id);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@grado_id", grado_id); 
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@precio", precio);
                SqlConnector.agregarParametro(parametrosGuardarTarjeta, "@codigo", CodigoPublicacion);

                DataTable tabla = SqlConnector.obtenerDataTable("VADIUM.ModificarPublicacion", "SP", parametrosGuardarTarjeta);
               
                return 1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
