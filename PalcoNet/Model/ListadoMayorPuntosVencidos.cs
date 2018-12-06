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
    class ListadoMayorPuntosVencidos
    {
        public int? anio { get; set; }
        public int? mes { get; set; }

        public ListadoMayorPuntosVencidos(int? mes, int? anio)
        {
             this.anio = anio;
            this.mes = mes;
        }

        public DataTable obtenerListado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@year", this.anio);
            SqlConnector.agregarParametro(listaParametros, "@month", this.mes);

            //revisar query
            String commandtext = "VADIUM.ClientesPuntosVencidos";

            return SqlConnector.obtenerDataTable(commandtext, "SP", listaParametros);

        }
    }
}
