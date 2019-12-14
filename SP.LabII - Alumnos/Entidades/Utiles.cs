using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        public abstract bool PreciosCuidados
        {
            get;
        }

        public Utiles(string marca,double precio)
        {
            this.precio = precio;
            this.marca = marca;
        }

        protected virtual string UtilesToString()
        {
            return this.marca + " " + this.precio.ToString(); 
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
