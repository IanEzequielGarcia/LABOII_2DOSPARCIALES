using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
namespace Entidades
{
    //Crear la clase Cajon<T>
    //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
    //Propiedades
    //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de _elementos).

    //Constructor
    //Cajon(), Cajon(int), Cajon(double, int); 
    //El por default: es el único que se encargará de inicializar la lista.
    //Métodos
    //ToString: Mostrará en formato de tipo string, la _capacidad, la cantidad total de _elementos, el precio total 
    //y el listado de todos los _elementos contenidos en el cajón. Reutilizar código.
    //Sobrecarga de operador
    //(+) Será el encargado de agregar _elementos al cajón, siempre y cuando no supere la _capacidad del mismo.

    public class Cajon<T> where T : Fruta
    {
        public delegate void Delegado();
        public event Delegado EventoPrecio;

        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        public List<T> Elementos { get { return this._elementos; } }
        public double PrecioUnitario { get { return _precioUnitario * this._elementos.Count; } }

        public Cajon()
        {
            this._elementos = new List<T>();
        }
        public Cajon(int _capacidad):this()
        {
            this._capacidad = _capacidad;
        }
        public Cajon(double precio,int _capacidad) : this(_capacidad)
        {
            this._precioUnitario = precio;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Fruta frutas in this.Elementos)
            {
                if(!ReferenceEquals(frutas,null))
                {
                    stringBuilder.AppendLine(frutas.ToString());
                }
            }
            return stringBuilder.ToString();
        }
        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        public static Cajon<T> operator +(Cajon<T> cajon, Fruta util)
        {
            if (util != null)
            {
                if (cajon._capacidad >= cajon._elementos.Count + 1)
                {
                    cajon._elementos.Add((T)util);
                    if (cajon.PrecioUnitario > 55)
                    {
                        if (cajon.EventoPrecio != null)
                            cajon.EventoPrecio();
                    }
                }
                else { throw new CajonLlenoException("ta llena"); }
            }
            return cajon;
        }
        public bool Xml(string Path)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(@"C:\Users\Ianch\Desktop\" + Path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Cajon<T>));
                    ser.Serialize(writer, this);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }

        }
        public void Guardar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Ianch\Documents\Cajon.txt"))
                //using maneja el archivo, encargándose de cerrarlo al finalizar
                {
                    sw.WriteLine($"{DateTime.Now}");
                    sw.WriteLine($"{this.PrecioUnitario}");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public static class CajonExtendido
    {
        public static bool EliminarFruta<T>(this Cajon<T> cajon,int numero) where T : Fruta
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=sp_lab_II_frutas;Integrated Security = True"))
                {
                    string strConsulta;
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = connection;
                    strConsulta = $"DELETE FROM frutas WHERE id= {numero}";

                    comando.CommandText = strConsulta;
                    connection.Open();
                    if (comando.ExecuteNonQuery() > 0)
                        return true;
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
