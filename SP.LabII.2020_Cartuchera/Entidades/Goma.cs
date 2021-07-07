using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma:Utiles
    {
        //Goma-> soloLapiz:bool(público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        public bool soloLapiz;
        public Goma(string marca, double precio) : base(marca, precio)
        {
            this.PreciosCuidados = true;
        }
        public Goma(bool soloLapiz,string marca, double precio ) : this(marca, precio)
        {
            this.PreciosCuidados = true;
            this.soloLapiz = soloLapiz;
        }
        public override string ToString()
        {
            return $"{base.UtilesToString()} - SoloLapiz{this.soloLapiz}\n";
        }
    }
}
