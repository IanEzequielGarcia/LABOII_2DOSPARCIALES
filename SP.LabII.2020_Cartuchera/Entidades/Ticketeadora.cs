using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Ticketeadora
    {
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano 
        //indicando si se pudo escribir o no.
        public static bool ImprimirTicket<T>(Cartuchera<T> cartuchera) where T: Utiles
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Ianch\Documents\tickets.log"))
                //using maneja el archivo, encargándose de cerrarlo al finalizar
                {
                    sw.WriteLine($"{DateTime.Now}");
                    sw.WriteLine($"{cartuchera.PrecioTotal}");
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
