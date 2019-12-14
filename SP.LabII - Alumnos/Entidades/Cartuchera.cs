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

        public delegate void DelegadoEventoPrecio(object sender, EventArgs e);
        public event DelegadoEventoPrecio EventoPrecio;

        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach (T elemento in this.Elementos)
                {
                    precioTotal += elemento.precio;
                }

                return precioTotal;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Capacidad: " + this.capacidad);
            datos.AppendLine("Cantidad de elementos: " + this.Elementos.Count);
            datos.AppendLine("Precio total: " + this.PrecioTotal);
            datos.AppendLine("Elementos en la cartuchera: ");
            foreach (Utiles util in this.Elementos)
            {
                datos.AppendLine(util.ToString());
            }

            return datos.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T util)
        {
            if (cartuchera.capacidad > cartuchera.Elementos.Count)
            {
                cartuchera.Elementos.Add(util);
                if (cartuchera is Cartuchera<Goma>)
                {
                    if (cartuchera.PrecioTotal > 85)
                    {
                        cartuchera.EventoPrecio(cartuchera, new EventArgs());
                    }
                }
            }
            else
            {
                throw new CartucheraLlenaException();
            }

            return cartuchera;
        }
    }
}