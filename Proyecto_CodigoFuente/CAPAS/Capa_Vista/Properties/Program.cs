using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////string num = "10,55";
            ////double lt = 20.0;
            ////double lng = Convert.ToDouble(num);
            ////double res = lt - lng;
            ////Console.WriteLine(res.ToString());
            //string num = "10,678";
            //string aux = num.Replace('.', ',');
            //Console.WriteLine(aux.ToString());


            //string str = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            //DateTime date = Convert.ToDateTime("21 / 09 / 2021 09:09:12");
            //Console.WriteLine(date +"   " +str);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
            
        }
    }
}
