using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Funcionalidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Funcionalidad(int id)
        {
            this.Id = id;
        }

        public Funcionalidad(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

    }
}
