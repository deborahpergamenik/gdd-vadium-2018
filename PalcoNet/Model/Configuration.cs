using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public static class Configuration
    {
        public static DateTime actualDate;
        public static DateTime getActualDate()
        {
            string date = ConfigurationManager.AppSettings["Fecha"];
            actualDate = Convert.ToDateTime(date);
            return actualDate;
        }
    }
}
