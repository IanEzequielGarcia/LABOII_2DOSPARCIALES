using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajonLlenoException:Exception
    {
        public CajonLlenoException(string mensaje) : base(mensaje)
        { }
    }
    public static class CajonLlenoExceptionExtendido
    {
        public static string InformarNovedad(this CajonLlenoException a)
        {
            return a.Message;
        }
    }
}
