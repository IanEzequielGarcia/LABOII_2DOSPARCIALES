using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta:Utiles
    {
        //Sacapunta-> deMetal:bool(público); 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        public bool deMetal;
        public Sacapunta(string marca, double precio) : base(marca, precio)
        {
            this.PreciosCuidados = false;
        }
        public Sacapunta(bool deMetal, double precio,string marca) : this(marca, precio)
        {
            this.PreciosCuidados = true;
            this.deMetal = deMetal;
        }
        public override string ToString()
        {
            return $"{base.UtilesToString()} - DeMetal{this.deMetal}\n";
        }
    }
}
