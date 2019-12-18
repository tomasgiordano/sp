using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma:Utiles
    {
        public bool soloLapiz;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public Goma(bool soloLapiz,string marca, double precio) : base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }
        public Goma() : base("SinMarca", 0)
        {

        }

        public override string ToString()
        {
            return base.ToString() + " " + this.soloLapiz;
        }
    }
}
