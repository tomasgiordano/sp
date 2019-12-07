using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    //IDeserializar -> Xml(string, out Fruta):bool
    public interface IDeserializar
    {
        bool Xml(string texto,out Fruta f);
    }
}
