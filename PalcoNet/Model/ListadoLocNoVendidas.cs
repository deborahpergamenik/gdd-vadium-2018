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
    class ListadoLocNoVendidas
    {
        public int? anio { get; set; }
        public int? mes { get; set; }
        public int? grado { get; set; }

        public ListadoLocNoVendidas(int? mes, int? anio, int? grado)
        {
            this.anio = anio;
            this.mes = mes;
            this.grado = grado;
        }


        public DataTable obtenerListado()
        {
            
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlConnector.agregarParametro(listaParametros, "@year", this.anio);
                SqlConnector.agregarParametro(listaParametros, "@month", this.mes);
                if(this.grado == null)
                    SqlConnector.agregarParametro(listaParametros, "@grado", -1);
                else
                    SqlConnector.agregarParametro(listaParametros, "@grado", this.grado);


                //revisar query
                String commandtext = "VADIUM.MayorCantLocalidadesNoVendidos";

                return SqlConnector.obtenerDataTable(commandtext, "SP", listaParametros);
          
        }
    }
}
