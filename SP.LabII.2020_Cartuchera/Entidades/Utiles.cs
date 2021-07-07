using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
namespace Entidades
{
    //[XmlInclude(typeof(Lapiz))]
    //[XmlInclude(typeof(Goma))]
    //[XmlInclude(typeof(Sacapunta))]
    public abstract class Utiles
    {
        //Utiles-> marca:string y precio:double (públicos); PreciosCuidados:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)

        public string marca;
        public double precio;
        public bool preciosCuidados;

        //public string Marca { get { return this.marca; } set { this.marca = value; } }
        //public double Precio { get { return this.precio; } set { this.precio = value; } }
        public bool PreciosCuidados { get { return this.preciosCuidados; } set { this.preciosCuidados = value; } }
        public Utiles()
        {

        }
        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }
        protected virtual string UtilesToString()
        {
            return $"Marca{this.marca} - Precio{this.precio} - PreciosCuidados{this.preciosCuidados}";
        }
        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
