using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Dominio;

namespace Veterinaria.Negocio
{
    public class DetalleConsultaNegocio
    {
        public List<DetalleConsulta> listar(int idConsulta)
        {
            List<DetalleConsulta> lista = new List<DetalleConsulta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT D.IdDetalle, D.Cantidad, M.IdMedicamento, M.Nombre FROM DetalleConsulta D INNER JOIN Medicamentos M ON M.IdMedicamento = D.IdMedicamento WHERE D.IdConsulta = @IdConsulta");
                datos.setearParametro("@IdConsulta", idConsulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleConsulta aux = new DetalleConsulta();
                    aux.Id = (int)datos.Lector["IdDetalle"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Medicamento = new Medicamento();
                    aux.Medicamento.Id = (int)datos.Lector["IdMedicamento"];
                    aux.Medicamento.Nombre = (string)datos.Lector["Nombre"];

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

        // Al insertar se dispara el trigger de INSERT, que descuenta el stock
        public void agregar(int idConsulta, int idMedicamento, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DetalleConsulta (IdConsulta, IdMedicamento, Cantidad) VALUES (@IdConsulta, @IdMedicamento, @Cantidad)");
                datos.setearParametro("@IdConsulta", idConsulta);
                datos.setearParametro("@IdMedicamento", idMedicamento);
                datos.setearParametro("@Cantidad", cantidad);
                datos.ejecutarAccion();
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

        // Al borrar se dispara el trigger de DELETE, que devuelve las unidades al stock
        public void eliminar(int idDetalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM DetalleConsulta WHERE IdDetalle = @IdDetalle");
                datos.setearParametro("@IdDetalle", idDetalle);
                datos.ejecutarAccion();
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
