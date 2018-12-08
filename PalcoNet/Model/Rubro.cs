using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Rubro
    {
        public int Id { get; set; } 
        public string Descripcion { get; set; }

        public Rubro(int idRubro, string descripcion)
        {
            this.Id = idRubro;
            this.Descripcion = descripcion;
        }

     

    }
}
