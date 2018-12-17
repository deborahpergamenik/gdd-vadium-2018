using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
   
}
