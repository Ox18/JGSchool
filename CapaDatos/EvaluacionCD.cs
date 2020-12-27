using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class EvaluacionCD
    {
        // Crear
        public int Crear(EvaluacionCE evaluacionCE)
        {
            // Establecemos la conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrimos conexion
            cn.Open();

            // Creamos comando de consulta
            SqlCommand cmd = cn.CreateCommand();

            // Especificamos que tipo de comando sera
            cmd.CommandType = CommandType.Text;

            // Especificamos consulta
            cmd.CommandText = "insert into Evaluacion (descripcion) "+
                "values (@descripcion)";

            // Especificamos los parametros
            cmd.Parameters.AddWithValue("@descripcion", evaluacionCE.Descripcion);

            // Ejecutamos la consulta y extraemos la cantidad de filas afectadas
            int numFilas = cmd.ExecuteNonQuery();

            // instanciamos el nuevo id sin valor
            int nuevoID;

            // Condicionalmente definiremos el valor de nuevo id
            if (numFilas > 0)
            {
                // Especificamos otra consulta
                cmd.CommandText = "select max(id) as nuevoId from Evaluacion"+
                    " where descripcion = @descripcion";

                // Editamos el parametro
                cmd.Parameters["@descripcion"].Value = evaluacionCE.Descripcion;

                // Ejecutamos la consulta
                SqlDataReader dataReader = cmd.ExecuteReader();

                // Verificamos si existe la fila
                if (dataReader.Read())
                {
                    // Extraemos el nuevo id obtenido
                    nuevoID = Convert.ToInt32(dataReader["nuevoId"]);
                }
                else
                {
                    // Como no existe fila el valor sera 0
                    nuevoID = 0;
                }
            }
            else
            {
                nuevoID = 0;
            }
            // Cerramos la conexion
            cn.Close();

            // Retornarmos el valor obtenido, el nuevo id
            return nuevoID;
        }

        // Leer (todos)
        public List<EvaluacionCE> Leer()
        {
            // Establecemos la conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrimos la conexion
            cn.Open();

            // Instanciamos nuestro comando
            SqlCommand cmd = cn.CreateCommand();

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecemos nuestra consulta 
            cmd.CommandText = "select * from Evaluacion";

            // Ejecutamos la consulta
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Creamos una lista de Evaluaciones
            List<EvaluacionCE> evaluacionCEs = new List<EvaluacionCE>();

            // Leemos todas las filas capturadas
            while (dataReader.Read())
            {
                // Capturamos los valores
                int id = Convert.ToInt32(dataReader["id"]);
                string descripcion = dataReader["descripcion"].ToString();

                // Creamos un nuevo objeto
                EvaluacionCE evaluacionCE = new EvaluacionCE(id, descripcion);

                // Agregamos el objeto a nuestra lista
                evaluacionCEs.Add(evaluacionCE);
            }

            // Cerramos nuestra conexion
            cn.Close();

            // Retornamos nuestra lista
            return evaluacionCEs;
        }

        // Actualizar
        public int Actualizar(EvaluacionCE evaluacionCE)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Creamos nuestro comando
            SqlCommand cmd = cn.CreateCommand();

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecemos la consulta
            cmd.CommandText = "update Evaluacion set descripcion = @descripcion where id = @id";

            // Agregamos parametros con valores
            cmd.Parameters.AddWithValue("@id", evaluacionCE.Id);
            cmd.Parameters.AddWithValue("@descripcion", evaluacionCE.Descripcion);

            // Ejecutamos la consulta
            int numFilas = cmd.ExecuteNonQuery();

            // cerramos la conexion
            cn.Close();

            // Retornamos la cantidad de filas afectadas
            return numFilas;

        }

        // Eliminar
        public int Eliminar(EvaluacionCE evaluacionCE)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Creamos el comando
            SqlCommand cmd = cn.CreateCommand();

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecemos la consulta
            cmd.CommandText = "delete from Evaluacion where id = @id";

            // Agregamos los parametros
            cmd.Parameters.AddWithValue("@id", evaluacionCE.Id);

            // Ejecutamos la consulta
            int numFilas = cmd.ExecuteNonQuery();

            // cerramos la conexion
            cn.Close();

            // Retornamos la cantidad de filas afectadas
            return numFilas;

        }

        // Buscar por descripcion
        public List<EvaluacionCE> BuscarDescripcion(string nombreBuscar)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecemos la consulta
            cmd.CommandText = "Select * from Evaluacion" +
                " where descripcion like '%' + @descripcion + '%'";

            // ejecutamos la consulta
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Creamos nuesta lista de productos
            List<EvaluacionCE> evaluacionCEs = new List<EvaluacionCE>();

            // Leemos todas las filas
            while (dataReader.Read())
            {
                // Capturamos filas
                int id = Convert.ToInt32(dataReader["id"]);
                string descripcion = dataReader["descripcion"].ToString();

                // Creamos nuevo objeto
                EvaluacionCE evaluacionCE = new EvaluacionCE(id, descripcion);

                // Agregamos obj a lista
                evaluacionCEs.Add(evaluacionCE);
            }

            // Cerramos la conexion
            cn.Close();

            // Retornamos la lista
            return evaluacionCEs;
        }
    }
}
