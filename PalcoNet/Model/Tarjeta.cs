using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Tarjeta
    {
        public string Numero = "";
        public string CodigoSeguridad = "";
        public int Mes;
        public int Anio;
        public Tarjeta()
        { }
        public Tarjeta(String _numero, String _codigoSeguridad, byte _mes, int _anio)
        {
            Numero = _numero;
            CodigoSeguridad = _codigoSeguridad;
            Mes = _mes;
            Anio = _anio;
        }

    }
}
