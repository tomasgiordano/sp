using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }

        public string Path
        {
            get
            {
                return "Passucci.Alan.lapiz.xml";
            }
        }

        public Lapiz()
            : this(ConsoleColor.Black, ETipoTrazo.Fino, "-", 0)
        {
        }

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(base.ToString());
            datos.AppendLine("Color: " + this.color);
            datos.AppendLine("Trazo: " + this.trazo);
            datos.AppendLine("Precios Cuidados: " + this.PreciosCuidados);

            return datos.ToString();
        }

        public bool Xml()
        {
            bool sePudo = false;
            XmlSerializer serializador = new XmlSerializer(typeof(Lapiz));

            try
            {
                using (TextWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    serializador.Serialize(escritor, this);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                sePudo = false;
                MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool sePudo = false;
            lapiz = null;
            XmlSerializer serializador = new XmlSerializer(typeof(Lapiz));

            try
            {
                using (TextReader lector = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    lapiz = (Lapiz)serializador.Deserialize(lector);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                sePudo = false;
                MessageBox.Show(error.Message, "Error al deserializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }
    }
}
