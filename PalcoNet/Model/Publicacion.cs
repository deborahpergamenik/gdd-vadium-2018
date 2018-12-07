using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Publicacion
    {
        public int CodigoPublicacion { get; set; }
        public string Descripcion { get; set; }
        //public Ubicacion Ubicacion { get; set; } una publicacion  no tiene solo una ubicacion
        public DateTime FechaPublicacion { get; set; } 
        public DateTime FechaEspectaculo { get; set; }  
        public Rubro Rubro { get; set; }
        public string DireccionEspectaculo { get; set; }
        public Grado GradoPublicacion { get; set; }
        public int userId { get; set; }
        public int empresaId { get; set; }//la publicacion tiene asociada una empresa
        //public int EstadoPublicacion { get; set; } el estado es una entidad y te va a convenir traete el id con la descripcion
        public Estado estado { get; set; }
    }
}
