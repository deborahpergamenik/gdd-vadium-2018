using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace PalcoNet.Model
{
    class Globals
    {
        public static string username = "";
        private static List<int> funcionalidades = new List<int>();

        private static string connectionString = ConfigurationManager.ConnectionStrings["GD2C2018"].ConnectionString;

        public static string getConnectionString()
        {
            return connectionString;
        }

        public static string getFechaSistema()
        {
            return ConfigurationManager.AppSettings["fechaSistema"];
        }

        public static DateTime getDateFechaSistema()
        {
            return Convert.ToDateTime(ConfigurationManager.AppSettings["fechaSistema"]);
        }

        public static DateTime getFechaSistemaEnTipoDate()
        {
            return DateTime.Today;
        }

        public static void setUser(string userName, List<int> funcs, int rol)
        {
            username = userName;
            funcionalidades = funcs;
        }

        public static bool tieneFuncionalidad(int idFun)
        {
            return funcionalidades.Contains(idFun);
        }

        public static void cerrarSesion()
        {
            username = "";
            funcionalidades = new List<int>();
        }

        public static DataTable intsToDataTable(List<int> ints)
        {
            DataTable Data = new DataTable();
            Data.Columns.Add("ITEM");

            foreach (int num in ints)
            {
                var row = Data.NewRow();

                row["ITEM"] = Convert.ToString(num);

                Data.Rows.Add(row);
            }
            return Data;
        }
    }
}
