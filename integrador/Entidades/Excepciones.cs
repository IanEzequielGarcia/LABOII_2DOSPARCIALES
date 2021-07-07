using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Excepciones:Exception
    {
        public Excepciones():base()
        { }
    }
    public class NoHayEspacio : Exception
    {
        public NoHayEspacio() : base("no hay mas lugar")
        { }
    }
}
