using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;
        public delegate void EventoPrecio(object sender, EventArgs e);
        public event EventoPrecio eventoPrecio;

        public List<T> Elementos
        {
            get { return this.elementos; }
        }

        public float PrecioTotal
        {
            get
            {
                float acumulador = 0;
                foreach(T elemento in this.Elementos)
                {
                    acumulador= (float)(acumulador + elemento.precio);
                }
                return acumulador;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad):this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TIPO: "+(typeof(T)).ToString());
            sb.AppendLine("CAPACIDAD: "+this.capacidad);
            sb.AppendLine("CANT ELEMENTOS: "+this.Elementos.Count);
            sb.AppendLine("PRECIO TOTAL: $"+this.PrecioTotal);
            sb.AppendLine("*****************LISTA*****************");
            foreach(T elemento in this.Elementos)
            {
                sb.AppendLine(elemento.ToString());
            }
            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c,T elemento)
        {
            if(c.Elementos.Count<c.capacidad)
            {
                c.Elementos.Add(elemento);
            }
            else
            {
                throw new CartucheraLlenaException();
            }

            if (c is Cartuchera<Goma>)
            {
                if (c.PrecioTotal > 85)
                {
                    c.eventoPrecio(c, new EventArgs());
                }
            }

            return c;
        }
    }
}
