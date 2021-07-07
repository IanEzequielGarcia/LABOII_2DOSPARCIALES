using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Objetos
    {
        public string tipo;
        public string marca;
        public float precio;
        public override string ToString()
        {
            return $"{this.tipo} - {this.marca} - {this.precio}";
        }
        public Objetos()
        {
        }
        public Objetos(string tipo, string marca, float precio)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.precio = precio;
        }
    }
}
