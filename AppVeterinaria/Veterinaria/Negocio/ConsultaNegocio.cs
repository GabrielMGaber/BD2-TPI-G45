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