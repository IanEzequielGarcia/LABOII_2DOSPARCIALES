using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
    //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
    public class Banana:Fruta
    {
        protected string _paisOrigen;
        public string Nombre { get { return "Banana"; } }
        public override bool TieneCarozo { get { return false; } }
        public Banana()
        {

        }
        public Banana(string color, double peso, string origen) : base(color, peso)
        {
            this._paisOrigen = origen;
        }

        public override string ToString()
        {
            return $"{this.Nombre} - {this.FrutaToString()} - {this._paisOrigen}";
        }
    }
}
