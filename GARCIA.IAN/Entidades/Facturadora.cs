using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Entidades
{
    public class Facturadora
    {
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano 
        //indicando si se pudo escribir o no.
        public static bool ImprimirTicket<T>(Caja<T> objetos) where T : Objetos
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/facturas.log"))
                //using maneja el archivo, encargándose de cerrarlo al finalizar
                {
                    sw.WriteLine($"{DateTime.Now}");
                    sw.WriteLine($"{objetos.PrecioTotal}");
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
