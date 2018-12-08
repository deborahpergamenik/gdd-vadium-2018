using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class usuario_activo
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public usuario_activo(int cod, string desc)
        {
            this.codigo = cod;
            this.descripcion = desc;
        }
       
        
    }
}
