using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    //Crear la clase Cajon<T>
    //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
    //Propiedades
    //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
    //Constructor
    //Cajon(), Cajon(int), Cajon(double, int); 
    //El por default: es el único que se encargará de inicializar la lista.
    //Métodos
    //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
    //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
    //Sobrecarga de operador
    //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
    public class Cajon<T>:ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        public List<T> Elementos
        {
            get { return this._elementos; }
        }

        public double PrecioTotal
        {
            get { return this._capacidad * this._precioUnitario; }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precioUnitario,int capacidad):this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: "+this._capacidad);
            sb.AppendLine("Cantidad total de elementos: "+this._elementos.Count);
            sb.AppendLine("Precio total: "+this.PrecioTotal);
            sb.AppendLine("************************* LISTA *************************");
            foreach(T t in this.Elementos)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

        public bool Xml(string path)
        {
            bool aux = true;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Cajon<T>));
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    ser.Serialize(sw, this);
                }
            }
            catch (Exception)
            {
                aux = false;
            }
            return aux;
        }

        public static Cajon<T> operator +(Cajon<T> c,T elemento)
        {
            if(c.Elementos.Count<c._capacidad)
            {
                c.Elementos.Add(elemento);
            }
            else
            {
                throw new CajonLlenoException();
            }

            return c;
        }
    }
}
