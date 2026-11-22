using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Negocio
{
    public class HistorialNegocio
    {
        public DataSet listar(int idMascota, DateTime? desde, DateTime? hasta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_HistorialMascota");
                datos.setearParametro("@IdMascota", idMascota);

                // Sin fecha se manda NULL: el procedimiento lo toma como "sin limite"
                if (desde == null)
                    datos.setearParametro("@FechaDesde", DBNull.Value);
                else
                    datos.setearParametro("@FechaDesde", desde.Value.Date);

                if (hasta == null)
                    datos.setearParametro("@FechaHasta", DBNull.Value);
                else
                    datos.setearParametro("@FechaHasta", hasta.Value.Date);

                return datos.obtenerDataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}