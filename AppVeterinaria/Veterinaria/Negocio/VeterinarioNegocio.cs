using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Dominio;

namespace Veterinaria.Negocio
{
    public class VeterinarioNegocio
    {
        public List<Veterinario> listar()
        {
            List<Veterinario> lista = new List<Veterinario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdVeterinario, Nombre, Apellido, Matricula FROM Veterinarios ORDER BY Apellido, Nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Veterinario aux = new Veterinario();
                    aux.Id = (int)datos.Lector["IdVeterinario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Matricula = (string)datos.Lector["Matricula"];

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