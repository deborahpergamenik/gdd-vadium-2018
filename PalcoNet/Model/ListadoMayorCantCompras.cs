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

        public int anio { get; set; }
        public int mesMinimo { get; set; }
        public int mesMaximo { get; set; }

        public ListadoMayorCantCompras(int trimestreMinimo, int anio)
        {
            this.anio = anio;
            this.mesMinimo = trimestreMinimo;
            this.mesMaximo = trimestreMinimo + 2;
        }

        public DataTable obtenerListado()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlConnector.agregarParametro(listaParametros, "@Año", this.anio);
            SqlConnector.agregarParametro(listaParametros, "@mesMinimo", this.mesMinimo);
            SqlConnector.agregarParametro(listaParametros, "@mesMaximo", this.mesMaximo);

            //revisar query
            String commandtext = "realizar query";

            return SqlConnector.obtenerDataTable(commandtext, "T", listaParametros);

        }
    }
}
