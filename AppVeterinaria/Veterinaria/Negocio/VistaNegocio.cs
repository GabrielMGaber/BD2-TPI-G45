using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Negocio
{
    public class VistaNegocio
    {
        public DataTable listar(string vista)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("SELECT * FROM " + vista);
                return datos.obtenerTabla();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}