using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Entidades.SP
{
    public static class Extension
    {
        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id)
        {
            bool seElimino = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM [sp_lab_II].[dbo].[frutas] WHERE id = " + id;

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read() != false)
                {
                    lector.Close();
                    comando.CommandText = "DELETE FROM [sp_lab_II].[dbo].[frutas] WHERE id = " + id;
                    comando.ExecuteNonQuery();
                    seElimino = true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                conexion.Close();
            }

            return seElimino;
        }
    }
}
