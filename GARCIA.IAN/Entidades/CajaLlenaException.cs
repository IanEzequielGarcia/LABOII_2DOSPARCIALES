using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class CajaLlenaException : Exception
    {
        //Agregar, para la clase CajaLlenaException, un método de extensión (InformarNovedad():string)
        //que retorne el mensaje de error
        public CajaLlenaException(string mensaje) : base(mensaje)
        { }
    }
    public static class CartucheraLlenaExceptionExtendida
    {
        public static string InformarNovedad(this CajaLlenaException a)
        {
            return a.Message;
        }
    }
}
