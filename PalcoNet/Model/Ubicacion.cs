using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Ubicacion
    {
        public int UbicacionId { get; set; }
        public string Fila { get; set; }
        public int Asiento { get; set; }
        public bool SinNumerar { get; set; }
        public int Precio { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public string Tipo
        {
            get
            {
                return TipoUbicacion.descripcion;
            }

        }
        public int CodigoPublicacion { get; set; }
        public int EmpresaId { get; set; }
    }

    public class TipoUbicacion
    {
        public int id { get; set; }
        public decimal codigo { get; set; }
        public string descripcion { get; set; }

    }

}
