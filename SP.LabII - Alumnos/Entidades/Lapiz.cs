using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Lapiz:Utiles,ISerializa,IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public string Path
        {
            get { return (Environment.GetFolderPath(Environment.SpecialFolder.Desktop))+ @"\Giordano.Tomas.lapiz.xml"; }
        }

        public Lapiz(ConsoleColor color,ETipoTrazo trazo,string marca, double precio) :base(marca,precio)
        {
            this.color = color;
            this.trazo = trazo;
        }
        public Lapiz():base("",0)
        {

        }

        public override string ToString()
        {
            return base.ToString()+" "+color.ToString()+" "+trazo.ToString();
        }

        public bool Xml()
        {
            bool aux = false;
            XmlSerializer ser = new XmlSerializer(typeof(Lapiz));

            try
            {
                using (StreamWriter writer = new StreamWriter(this.Path, false))
                {
                    ser.Serialize(writer, this);
                    aux = true;
                }
            }
            catch (Exception)
            {

            }

            return aux;
        }

        bool IDeserializa.Xml(out Lapiz l)
        {
            bool Flag = false;
            XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
            Lapiz aux = new Lapiz();
            try
            {
                using (StreamReader reader = new StreamReader(this.Path))
                {
                    aux = (Lapiz)ser.Deserialize(reader);
                    Flag = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                l = aux;
            }

            return Flag;
        }
    }
}
