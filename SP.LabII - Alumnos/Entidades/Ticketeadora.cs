using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Ticketeadora
    {
        public static bool ImprimirTicket(Cartuchera<Goma> c)
        {
            bool aux = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + "tickets.log", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(c.PrecioTotal);
                    aux = true;
                }
            }
            catch (Exception)
            {

            }
            return aux;
        }
    }
}
