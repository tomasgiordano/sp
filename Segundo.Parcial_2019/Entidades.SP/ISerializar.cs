﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    //ISerializar -> Xml(string):bool
    public interface ISerializar
    {
        bool Xml(string texto);
    }
}
