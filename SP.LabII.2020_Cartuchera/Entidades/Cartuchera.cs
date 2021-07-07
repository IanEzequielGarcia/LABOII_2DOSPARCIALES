using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void Delegado(object sender, EventArgs e);

    public class Cartuchera<T> where T : Utiles
    {
        public event Delegado EventoPrecio;

        protected int capacidad;
        protected List<T> elementos;
        public List<T> Elementos { get { return this.elementos; } }
        public double PrecioTotal { 
            get 
            {
                double aux = 0;
                foreach(Utiles utiles in this.elementos)
                {
                    if(utiles!=null)
                    {
                        aux += utiles.precio;
                    }
                }
                return aux;
             } }
        public Cartuchera()
        {
            this.elementos = new List<T>();
        }
        public Cartuchera(int cantidad):this()
        {
            this.capacidad = cantidad;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Capacidad:{this.capacidad}");
            stringBuilder.AppendLine($"De tipo  :{this.elementos.GetType().Name}");
            stringBuilder.AppendLine($"Cantidad :{this.elementos.Count}");
            foreach(Utiles util in this.elementos)
            {
                if(!ReferenceEquals(util,null))
                {
                    stringBuilder.Append(util.ToString());
                }
            }
            return stringBuilder.ToString();
        }
        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera,Utiles util)
        {
            if(util!=null&&cartuchera.capacidad>=cartuchera.elementos.Count+1)
            {
                cartuchera.elementos.Add((T)util);
                if (cartuchera.PrecioTotal > 84)
                {
                    if (cartuchera.EventoPrecio != null)
                        cartuchera.EventoPrecio(cartuchera, EventArgs.Empty);
                }
            }
            else { throw new CartucheraLlenaException("ta llena"); }
            return cartuchera;
        }
    }
}
