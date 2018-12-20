using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public static class Configuration
    {
        private static DateTime actualDate;
        public static DateTime getActualDate()
        {
            string date = ConfigurationManager.AppSettings["Fecha"];
            actualDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //actualDate = Convert.ToDateTime(date);
            return actualDate;
        }
        public static string getStringActualDate()
        {
            return ((DateTime)getActualDate()).ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string  createFilter(List<int> values, string variable)
        {

            string filtro = " ";
            if (values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {

                    if (i == 0)
                        filtro += " ( ";
                    else filtro += " or ";

                    filtro = filtro + variable + "  = " + values[i] + " ";

                    if (i == values.Count - 1)
                        filtro += " ) ";
                }
            }
            return filtro;

        }

       
    }
   
}
