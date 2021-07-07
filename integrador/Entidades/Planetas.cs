using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Planetas:ISerializable
    {
        public string nombre;
        public int satelites;
        public double gravedad;

        string ISerializable.Path { get { return "planetaSerializado.Xml"; } }

        public Planetas()
        {

        }
        public Planetas(string nombre,int satelites,double gravedad):base()
        {
            this.nombre = nombre;
            this.satelites = satelites;
            this.gravedad = gravedad;
        }
        private string Mostrar()
        {
            return $"{this.nombre} - {this.satelites} - {this.gravedad}\n";
        }
        public override string ToString()
        {
            return this.Mostrar();
        }

        bool ISerializable.SerializarXML()
        {
            bool auxBool = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter( ((ISerializable)this).Path, Encoding.UTF8) )
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Planetas));
                    ser.Serialize(writer, this);
                    auxBool = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return auxBool;
        }
        string ISerializable.DeserializarXML()
        {
            string aux = "";
            try
            {
                //me tira error con ((ISerializable)this).Path
                using (XmlTextReader reader = new XmlTextReader( ((ISerializable)this).Path) )
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Planetas));
                    aux = ( (Planetas)ser.Deserialize(reader) ).ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return aux;
        }
    }

}
