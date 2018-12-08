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
        

        public string TipoGrado { get; set; }
        public decimal Comision { get; set; }
        public int? id { get; set; }
        public Grado(string grado, decimal comision, int? id)
        {
            this.TipoGrado = grado;
            this.Comision = comision;
            this.id = id;
        }



        


    }
}
