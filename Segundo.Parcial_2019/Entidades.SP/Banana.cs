using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
    //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
    public class Banana:Fruta
    {
        protected string _paisOrigen;

        public override string Color { get { return this._color; } set { this._color = value; } }
        public override double Peso { get { return this._peso; } set { this._peso = value; } }

        public string Nombre
        {
            get { return "Banana"; }
        }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public override string ToString()
        {
            return base.FrutaToString() + " " + this._paisOrigen;
        }

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }
    }
}
