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
    class ListadoMayorCantCompras
    {

        public int? anio { get; set; }
        public int? mes { get; set; }

        public ListadoMayorCantCompras(int? anio, int? mes)
        {
            this.anio = anio;
            this.mes = mes;
        }

        public DataTable obtenerListado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@year", this.anio);
            SqlConnector.agregarParametro(listaParametros, "@moth", this.mes);

            //revisar query
            String commandtext = "realizar query";

            return SqlConnector.obtenerDataTable(commandtext, "T", listaParametros);

        }
    }
}
