using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Veterinaria.Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private string mensajes;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public string Mensajes
        {
            get { return mensajes; }
        }

public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=TPI_Grupo45_Veterinaria; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string nombre)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = nombre;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion;

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet obtenerDataSet()
        {
            DataSet conjunto = new DataSet();
            comando.Connection = conexion;

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(conjunto);
                return conjunto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object ejecutarEscalar()
        {
            comando.Connection = conexion;
            mensajes = "";

            // Los PRINT del procedimiento no llegan como error:
            // la conexion los avisa con el evento InfoMessage y los juntamos aca.
            conexion.InfoMessage += (sender, e) => mensajes += e.Message;

            try
            {
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}

