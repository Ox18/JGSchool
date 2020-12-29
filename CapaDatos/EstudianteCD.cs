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
    public class EstudianteCD
    {
        // Crear
        public int Crear(EstudianteCE estudianteCE)
        {
            // Establecemos conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Establecer tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer consulta
            cmd.CommandText = "insert into Estudiante(nombre, dni, fechaNac, telefono, correo, nivel, grado)" +
                " values(@nombre, @dni, @fechaNac, @telefono, @correo, @nivel, @grado)";

            // Agregamos los parametros con sus valores
            cmd.Parameters.AddWithValue("@nombre", estudianteCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", estudianteCE.Dni);
            cmd.Parameters.AddWithValue("@fechaNac", estudianteCE.FechaNac.ToLocalTime());
            cmd.Parameters.AddWithValue("@telefono", estudianteCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", estudianteCE.Correo);
            cmd.Parameters.AddWithValue("@nivel", estudianteCE.Nivel);
            cmd.Parameters.AddWithValue("@grado", estudianteCE.Grado);

            // Ejecutamos la consulta
            int numFilas = cmd.ExecuteNonQuery();

            // Definimos el nuevo id
            int nuevoID;

            // Extraeremos el nuevo id
            if (numFilas > 0)
            {
                // Establecemos la nueva consulta
                cmd.CommandText = "select max(id) as nuevoId from Estudiante where nombre = @nombre";

                // Editamos el parametro
                cmd.Parameters["@nombre"].Value = estudianteCE.Nombre;

                // Ejecutamos parametro
                SqlDataReader dataReader = cmd.ExecuteReader();

                // lectura de nuevo id
                if (dataReader.Read())
                {
                    nuevoID = Convert.ToInt32(dataReader["nuevoId"]);
                }
                else
                {
                    nuevoID = 0;
                }
            }
            else {
                // si no se cumple el id sera 0
                nuevoID = 0;
            }

            // cerramos la conexion
            cn.Close();

            // Retornamos el nuevo id
            return nuevoID;
        }

        // Leer
        public List<EstudianteCE> Leer()
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comanod
            cmd.CommandType = CommandType.Text;

            // Definir la consulta
            cmd.CommandText = "select * from Estudiante";

            // Ejecutar la consulta
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Creamos lista de almacenamiento
            List<EstudianteCE> estudianteCEs = new List<EstudianteCE>();

            // Lectura de filas
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();
                int dni = Convert.ToInt32(dataReader["dni"]);
                DateTime fechaNac = Convert.ToDateTime(dataReader["fechaNac"]);
                int telefono = Convert.ToInt32(dataReader["telefono"]);
                string correo = dataReader["correo"].ToString();
                string nivel = dataReader["nivel"].ToString();
                int grado = Convert.ToInt32(dataReader["grado"]);

                EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechaNac, telefono, correo, nivel, grado);

                estudianteCEs.Add(estudianteCE);
            }

            // Cerramos la conexion
            cn.Close();

            // retornamos lista
            return estudianteCEs;
        }

        // Actualizar
        public int Actualizar(EstudianteCE estudianteCE)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer consulta
            cmd.CommandText = "update Estudiante set " +
                "nombre = @nombre, dni = @dni, fechaNac = @fechaNac, telefono = @telefono, correo = @correo, nivel = @nivel, grado = @grado" +
                " where id = @id";

            // Agregar los parametros
            cmd.Parameters.AddWithValue("@nombre", estudianteCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", estudianteCE.Dni);
            cmd.Parameters.AddWithValue("@fechaNac", estudianteCE.FechaNac);
            cmd.Parameters.AddWithValue("@telefono", estudianteCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", estudianteCE.Correo);
            cmd.Parameters.AddWithValue("@nivel", estudianteCE.Nivel);
            cmd.Parameters.AddWithValue("@grado", estudianteCE.Grado);
            cmd.Parameters.AddWithValue("@id", estudianteCE.Id);

            // Ejecutamos la consulta
            int numFilas = cmd.ExecuteNonQuery();

            // Cerramos la conexion
            cn.Close();

            // retornamos el numero de filas afectadas
            return numFilas;
        }

        // Eliminar
        public int Eliminar(EstudianteCE estudianteCE)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer consulta
            cmd.CommandText = "delete from Estudiante where id = @id";

            // Agregar los parametros
            cmd.Parameters.AddWithValue("@id", estudianteCE.Id);

            // Ejecutamos la consulta
            int numFilas = cmd.ExecuteNonQuery();

            // Cerramos la conexion
            cn.Close();

            // retornamos el numero de filas afectadas
            return numFilas;
        }

        // Buscar por Nombre
        public List<EstudianteCE> BusquedaNombre(string nombreBuscar)
        {
            // Establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comanod
            cmd.CommandType = CommandType.Text;

            // Definir la consulta
            cmd.CommandText = "select * from Estudiante" +
                " where nombre like '%' + @nombre + '%'";

            // Agregar parametros
            cmd.Parameters.AddWithValue("@nombre", nombreBuscar);

            // Ejecutar la consulta
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Creamos lista de almacenamiento
            List<EstudianteCE> estudianteCEs = new List<EstudianteCE>();

            // Lectura de filas
            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();
                int dni = Convert.ToInt32(dataReader["dni"]);
                DateTime fechaNac = Convert.ToDateTime(dataReader["fechaNac"]);
                int telefono = Convert.ToInt32(dataReader["telefono"]);
                string correo = dataReader["correo"].ToString();
                string nivel = dataReader["nivel"].ToString();
                int grado = Convert.ToInt32(dataReader["grado"]);

                EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechaNac, telefono, correo, nivel, grado);

                estudianteCEs.Add(estudianteCE);
            }

            // Cerramos la conexion
            cn.Close();

            // retornamos lista
            return estudianteCEs;
        }

    }
}
