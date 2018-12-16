using PalcoNet.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Grado
    {

        public int? Id { get; set; }
        public decimal Comision { get; set; }
        public string Descripcion { get; set; }

        public Grado(int? _id, decimal _comision, string _descripcion)
        {
            this.Id = _id;
            this.Comision = _comision;
            this.Descripcion = _descripcion;    
        }

    }
}
