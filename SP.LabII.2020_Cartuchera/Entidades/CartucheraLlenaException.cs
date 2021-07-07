using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CartucheraLlenaException : Exception
    {
        //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
        //que retorne el mensaje de error
        public CartucheraLlenaException(string mensaje) : base(mensaje)
        { }
    }
    public static class CartucheraLlenaExceptionExtendida
    {
        public static string InformarNovedad(this CartucheraLlenaException a)
        {
            return a.Message;
        }
    }
}
