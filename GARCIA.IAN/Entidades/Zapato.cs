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
    //Crear, en un class library, las siguientes clases:
    //Zapato-> tipo:string (público); marca:string; (público); precio:float (público); 
    //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Zapato : Objetos,ISerializa,IDeserializa
    {

        public Zapato()
        {

        }
        public Zapato(string tipo, string marca, float precio) : base(tipo, marca, precio)
        {
        }

        public string Path => $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}/garcia.ian.xml";
        public bool Xml()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Zapato));
                XmlTextWriter writer = new XmlTextWriter(this.Path, Encoding.UTF8);
                ser.Serialize(writer, this);
                //this=(Dato)ser.Deserialize(reader);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        bool IDeserializa.Xml(out Zapato obj)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(this.Path);

                XmlSerializer ser = new XmlSerializer(typeof(Zapato));

                obj = (Zapato)ser.Deserialize(reader);

                reader.Close();
                return true;
            }
            catch (Exception)
            {
                obj = null;
                return false;
            }
        }
    }
}
