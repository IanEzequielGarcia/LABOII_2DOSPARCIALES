using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Crear, en class library, la clase Caja<T> 
    //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
    //Propiedades:
    //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    //PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
    //Constructor
    //Caja(), Caja(int); 
    //El constructor por default es el único que se encargará de inicializar la lista.
    //Métodos:
    //ToString: Mostrará en formato de tipo string: 
    //el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
    //de todos los elementos contenidos en la misma. Reutilizar código.
    //Sobrecarga de operadores:
    //(+) Será el encargado de agregar elementos a la caja, 
    //siempre y cuando no supere la capacidad máxima de la misma.
    public delegate void Delegado(object sender, EventArgs e);
    public class Caja<T>where T:Objetos
    {
        public event Delegado EventoPrecio;

        protected int capacidad;
        protected List<T> elementos;
        public List<T> Elementos { get { return this.elementos; } }
        public double PrecioTotal
        {
            get
            {
                double aux = 0;
                foreach (Objetos objetos in this.elementos)
                {
                    if (objetos != null)
                    {
                        aux += objetos.precio;
                    }
                }
                return aux;
            }
        }
        public Caja()
        {
            this.elementos = new List<T>();
        }
        public Caja(int cantidad) : this()
        {
            this.capacidad = cantidad;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Capacidad:{this.capacidad}");
            stringBuilder.AppendLine($"De tipo  :{this.elementos.GetType().Name}");
            stringBuilder.AppendLine($"Cantidad :{this.elementos.Count}");
            foreach (object objeto in this.elementos)
            {
                if (!ReferenceEquals(objeto, null))
                {
                    stringBuilder.AppendLine(objeto.ToString());
                }
            }
            return stringBuilder.ToString();
        }
        public static Caja<T> operator +(Caja<T> objetos, object objeto)
        {
            if (objeto != null && objetos.capacidad >= objetos.elementos.Count + 1)
            {
                objetos.elementos.Add((T)objeto);
                if (objetos.PrecioTotal > 120)
                {
                    if (objetos.EventoPrecio != null)
                        objetos.EventoPrecio(objetos, EventArgs.Empty);
                }
            }
            else { throw new CajaLlenaException("ta llena"); }
            return objetos;
        }
    }
}
