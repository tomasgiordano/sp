using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
    //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
    public class Manzana: Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string Nombre
        {
            get { return "Manzana"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public override string ToString()
        {
            return base.FrutaToString()+" "+this._provinciaOrigen;
        }

        public bool Xml(string path)
        {
            bool SeGuardo = true;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Manzana));
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    ser.Serialize(sw, this);
                }
            }
            catch (Exception)
            {
                SeGuardo = false;
            }
            return SeGuardo;
        }

        bool IDeserializar.Xml(string path, out Fruta f)
        {
            bool SeLeyo = true;
            f = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Manzana));
                using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    f = (Manzana)ser.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                SeLeyo = false;
            }
            return SeLeyo;
        }

        public Manzana(string color, double peso, string provincia) : base(color, peso)
        {
            this._provinciaOrigen = provincia;
        }
    }          
}
