using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fosforo:Objetos
    {
        //Fosforo-> tipo:string (público); marca:string; (público); precio:float (público); 
        //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).

        public Fosforo()
        {

        }
        public Fosforo(string tipo, string marca, float precio):base(tipo,marca,precio)
        {
        }
    }
}
