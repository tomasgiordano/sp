using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Entidades.SP
{
    public class Manejadora<Fruta>
    {
        public void manejadoraPrecioTotal(Cajon<Fruta> c)
        {
            string mensaje = DateTime.Now.ToString() + " El total del precio del cajon supera los $55, con un precio de: " + c.PrecioTotal.ToString();
            MessageBox.Show(mensaje);

            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\punto5.txt");
            sw.WriteLine(mensaje);

            sw.Close();
        }
    }
}
