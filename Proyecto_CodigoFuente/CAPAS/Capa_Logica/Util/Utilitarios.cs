using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



/// <summary>
/// Clase Utilitarios, se encarga de mantener metodos para todo el proyecto
/// </summary>
public static class Utilitarios
{

    /// <summary>
    /// Elabrora el sifrado tipo Hash256
    /// </summary>
    public static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256   
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }



    /// <summary>
    /// Configura el CultureInfo de la Pc para fechas y decimales
    /// </summary>
    public static void CulturaInfo()
    {
        // Colocar Cultura Estandar para Costa Rica
        // esto me permite no tener problemas con (.) de los decimales
        CultureInfo Micultura = new CultureInfo("es-CR", false);
        Micultura.NumberFormat.CurrencySymbol = "¢";
        Micultura.NumberFormat.CurrencyDecimalDigits = 2;
        Micultura.NumberFormat.CurrencyDecimalSeparator = ".";
        Micultura.NumberFormat.CurrencyGroupSeparator = ",";
        int[] grupo = new int[] { 3, 3, 3 };
        Micultura.NumberFormat.CurrencyGroupSizes = grupo;
        Micultura.NumberFormat.NumberDecimalDigits = 2;
        Micultura.NumberFormat.NumberGroupSeparator = ",";
        Micultura.NumberFormat.NumberDecimalSeparator = ".";
        Micultura.NumberFormat.NumberGroupSizes = grupo;
        //Micultura.DateTimeFormat.
        Thread.CurrentThread.CurrentCulture = Micultura;

    }

   



}
