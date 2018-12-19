using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Ubicacion
    {
        public Publicacion publicacion { get; set; }
        public int UbicacionId { get; set; }
        public string Fila { get; set; }
        public int Asiento { get; set; }
        public bool SinNumerar { get; set; }
        public double Precio { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public int idTipoUbicacion { get; set; }
        public string Tipo
        {
            get
            {
                return TipoUbicacion.descripcion;
            }

        }
        public int CodigoPublicacion { get; set; }
        
    }

    public class TipoUbicacion
    {
       
        public TipoUbicacion(int cod, string desc)
        {
            // TODO: Complete member initialization
            this.id = cod;
            this.descripcion = desc;
        }
        public int id { get; set; }
        public string descripcion { get; set; }

    }

}
