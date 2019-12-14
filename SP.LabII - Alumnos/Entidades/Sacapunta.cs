using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public override bool PreciosCuidados
        {
            get
            {
                return false;
            }
        }

        public Sacapunta(bool deMetal, double precio, string marca)
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(base.ToString());
            datos.AppendLine("De metal: " + this.deMetal);
            datos.AppendLine("Precios Cuidados: " + this.PreciosCuidados);

            return datos.ToString();
        }
    }
}
