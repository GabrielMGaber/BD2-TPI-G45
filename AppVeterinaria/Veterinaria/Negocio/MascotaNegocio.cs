using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Dominio;

namespace Veterinaria.Negocio
{
    public class MascotaNegocio
    {
        public List<Mascota> listar()
        {
            List<Mascota> lista = new List<Mascota>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMascota, Nombre, FechaNacimiento FROM Mascotas ORDER BY Nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mascota aux = new Mascota();
                    aux.Id = (int)datos.Lector["IdMascota"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    // FechaNacimiento admite NULL en la base
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];

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