using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Dominio;

namespace Veterinaria.Negocio
{
    public class MedicamentoNegocio
    {
        public List<Medicamento> listar()
        {
            List<Medicamento> lista = new List<Medicamento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMedicamento, Nombre, Stock, Precio FROM Medicamentos ORDER BY Nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medicamento aux = new Medicamento();
                    aux.Id = (int)datos.Lector["IdMedicamento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
