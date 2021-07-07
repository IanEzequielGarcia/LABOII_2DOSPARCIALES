using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Crear la siguiente jerarquía de clases:
    //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
    //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;
        public abstract bool TieneCarozo { get; }
        public string Color { get { return this._color; } set { } }
        public double Peso { get { return this._peso; } set { } }
        public Fruta()
        {

        }
        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }
        protected virtual string FrutaToString()
        {
            return $"{this.Color} - {this.Peso} - {this.TieneCarozo}";
        }
    }
}
