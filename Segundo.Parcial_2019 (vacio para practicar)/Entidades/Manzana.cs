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
    //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
    //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
    public class Manzana : Fruta,ISerializar,IDeserializar
    {
        protected string _provinciaOrigen;
 
        public string Nombre { get {return "Manzana"; }}
        public override bool TieneCarozo { get { return true; } }
        public Manzana()
        {
        }
        public Manzana(string color,double peso,string origen):base(color,peso)
        {
            this._provinciaOrigen = origen;
        }
        public override string ToString()
        {
            return $"{this.Nombre} - {this.FrutaToString()} - {this._provinciaOrigen}";
        }
        public bool Xml(string Path)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(@"C:\Users\Ianch\Desktop\" + Path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Manzana));
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
        bool IDeserializar.Xml(string path, out Fruta fruta)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(@"C:\Users\Ianch\Desktop\" + path);

                XmlSerializer ser = new XmlSerializer(typeof(Manzana));

                fruta = (Manzana)ser.Deserialize(reader);

                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                fruta = null;
                return false;
            }
        }
    }
}
