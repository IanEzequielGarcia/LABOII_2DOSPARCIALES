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
    public enum ETipoTrazo { Fino, Grueso, Medio };
    public class Lapiz:Utiles,ISerializa,IDeserializa
    {
        //Lapiz-> color:ConsoleColor(público); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        public ConsoleColor color;
        public ETipoTrazo trazo;
        public Lapiz()
        {
        }
        public Lapiz(string marca,double precio):base(marca,precio)
        {
            this.PreciosCuidados = true;
        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo,string marca, double precio) :this(marca,precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override string ToString()
        {
            return $"{base.UtilesToString()} - Color:{this.color} - Trazo{this.trazo}\n";
        }
        public string Path => @"C:\Users\Ianch\OneDrive\Escritorio\GARCIA.IAN.LAPIZ.xml";
        public bool XML()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
                XmlTextWriter writer = new XmlTextWriter(this.Path, Encoding.UTF8);
                ser.Serialize(writer, this);
                //this=(Dato)ser.Deserialize(reader);
                writer.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Xml(out Lapiz lapiz)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(this.Path);

                XmlSerializer ser = new XmlSerializer(typeof(Lapiz)); 

                lapiz = (Lapiz)ser.Deserialize(reader);

                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                lapiz = null;
                return false;
            }
        }
    }
}
