using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Encriptacion
    {
        public static string getSHA256(string input)
        {
            var hash = SHA256.Create();

            // Convertir la cadena en un array de bytes y calcular hash
            var Data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Copiar cada elemento del array a un
            // StringBuilder en formato hexadecimal

            var sBuilder = new StringBuilder();
            for (int i = 0; i < Data.Length; i++)
            {
                sBuilder.Append(Data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
