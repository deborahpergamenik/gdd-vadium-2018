using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class ListadoEstadistico
    {
        public int anio { get; set; }
        public int trimestre { get; set; }

        public ListadoEstadistico(int trimestre, int anio)
        {
            this.trimestre = this.obtenerRangoTrimestre(trimestre);
            this.anio = anio;
        }
          

        private int obtenerRangoTrimestre(int trimestre)
        {
            int rangoMinimo;

            switch (trimestre)
            {
                case 1:
                    rangoMinimo = 1;
                    break;
                case 2:
                    rangoMinimo = 4;
                    break;
                case 3:
                    rangoMinimo = 7;
                    break;
                default:
                    rangoMinimo = 10;
                    break;
            }
            return rangoMinimo;
        }

        public DataTable buscar(int opcionElegida)
        {
            if (opcionElegida == 1)
            {
                ListadoLocNoVendidas listadoEmpresas = new ListadoLocNoVendidas(trimestre, anio,null);
                return listadoEmpresas.obtenerListado();
            }
            else if (opcionElegida == 2)
            {
                ListadoMayorPuntosVencidos listadoClientes = new ListadoMayorPuntosVencidos(trimestre, anio);
                return listadoClientes.obtenerListado();
            }
            else if (opcionElegida == 3)
            {
                ListadoMayorCantCompras listadoClientes = new ListadoMayorCantCompras(trimestre, anio);
                return listadoClientes.obtenerListado();
            }
            else
                return null;

        }
    }
}
