﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
    //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
    public class Durazno:Fruta
    {
        protected int _cantPelusa;

        public string Nombre
        {
            get { return "Durazno"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public override string ToString()
        {
            return base.FrutaToString() + " " + this._cantPelusa;
        }

        public Durazno(string color, double peso, int pelusa) : base(color, peso)
        {
            this._cantPelusa = pelusa;
        }
    }
}
