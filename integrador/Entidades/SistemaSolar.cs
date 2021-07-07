using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaSolar<T> where T : Planetas
    {
        public List<T> lista;
        protected int capacidad;
        public SistemaSolar()
        {
            this.lista = new List<T>();
        }
        public SistemaSolar(List<T> Lista, int capacidad) : base()
        {
            this.lista = Lista;
            this.capacidad = capacidad;
        }
        public bool AgregarPlaneta(T planeta)
        {
            bool aux = false;
           try
           {
               if(this.capacidad>this.lista.Count)
                {
                    this.lista.Add(planeta);
                    aux = true;
                }
                else { throw new NoHayEspacio(); }

           }
           catch(NoHayEspacio ex)
           {
                throw new NoHayEspacio(); 
           }
           return aux;
        }

    }
}
