using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Dominio;

namespace Veterinaria.Negocio
{
    public class ConsultaNegocio
    {
        public List<Consulta> listar()
        {
            {
                List<Consulta> lista = new List<Consulta>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("SELECT C.IdConsulta, C.Fecha, M.IdMascota, M.Nombre FROM Consultas C INNER JOIN Mascotas M ON M.IdMascota = C.IdMascota ORDER BY C.Fecha DESC");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Consulta aux = new Consulta();
                        aux.Id = (int)datos.Lector["IdConsulta"];
                        aux.Fecha = (DateTime)datos.Lector["Fecha"];
                        aux.Mascota = new Mascota();
                        aux.Mascota.Id = (int)datos.Lector["IdMascota"];
                        aux.Mascota.Nombre = (string)datos.Lector["Nombre"];

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
        public int registrar(Consulta nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_RegistrarConsulta");
                datos.setearParametro("@IdMascota", nueva.Mascota.Id);
                datos.setearParametro("@IdVeterinario", nueva.Veterinario.Id);
                datos.setearParametro("@Fecha", nueva.Fecha);
                datos.setearParametro("@Motivo", nueva.Motivo);

                // Diagnostico y Observaciones son opcionales: si vienen vacios se manda NULL
                if (string.IsNullOrEmpty(nueva.Diagnostico))
                    datos.setearParametro("@Diagnostico", DBNull.Value);
                else
                    datos.setearParametro("@Diagnostico", nueva.Diagnostico);

                if (string.IsNullOrEmpty(nueva.Observaciones))
                    datos.setearParametro("@Observaciones", DBNull.Value);
                else
                    datos.setearParametro("@Observaciones", nueva.Observaciones);

                object id = datos.ejecutarEscalar();

                // Si el procedimiento rechazo el alta, no devuelve el Id y deja el motivo en Mensajes
                if (id == null)
                    throw new Exception(datos.Mensajes);

                return (int)id;
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