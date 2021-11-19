using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos
{
    class Conexion
    {
        public static string Cadena
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Capa_Vista.Properties.Settings.Conexion"].ConnectionString;
            }
        }
    }
}
