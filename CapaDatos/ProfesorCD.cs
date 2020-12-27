using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;
namespace CapaDatos
{
    public class ProfesorCD
    {
        public ProfesorCE BuscarID(int idBuscado)
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "SELECT * FROM Profesor " +
                "WHERE id = @id";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@id", idBuscado);

            // Ejecutar comando / select
            SqlDataReader dataReader = command.ExecuteReader();

            // Declarar variables para los datos;
            int id;
            string nombre;
            int dni;
            DateTime fechaNac;
            int telefono;
            string correo;

            if (dataReader.Read())
            {
                // Si la fila existe
                id = Convert.ToInt32(dataReader["id"]);
                nombre = dataReader["nombre"].ToString();
                dni = Convert.ToInt32(dataReader["dni"]);
                fechaNac = Convert.ToDateTime(dataReader["fechaNac"]);
                telefono = Convert.ToInt32(dataReader["telefono"]);
                correo = dataReader["correo"].ToString();

            }
            else
            {
                // Si la fila no existe
                id = 0;
                nombre = "";
                dni = 0;
                fechaNac = DateTime.Now;
                telefono = 0;
                correo = "";
            }
            // Cerramos la conexion
            connection.Close();

            // Asignamos los valores a un objeto
            ProfesorCE profesorCE = new ProfesorCE(id, nombre, dni, fechaNac, telefono, correo);

            // Retornar el profesor
            return profesorCE;
        }
        public List<ProfesorCE> BuscarNombre(string nombreBuscar)
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "SELECT * FROM Profesor " +
                "WHERE nombre like '%' + @nombre + '%'";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@nombre", nombreBuscar);

            // Ejecutar comando / select
            SqlDataReader dataReader = command.ExecuteReader();

            // Declara lista
            List<ProfesorCE> profesorCEs = new List<ProfesorCE>();

            // revisar todos los resultados

            while (dataReader.Read())
            {
                // Si la fila existe capturar datos
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();
                int dni = Convert.ToInt32(dataReader["dni"]);
                DateTime fechaNac = Convert.ToDateTime(dataReader["fechaNac"]);
                int telefono = Convert.ToInt32(dataReader["telefono"]);
                string correo = dataReader["correo"].ToString();

                // Instanciar nuevo objeto
                ProfesorCE profesorCE = new ProfesorCE(id, nombre, dni, fechaNac, telefono, correo);

                profesorCEs.Add(profesorCE);
            }

            // Cerramos la conexion
            connection.Close();

            // Retornar el profesor
            return profesorCEs;
        }

        public int Insertar(ProfesorCE profesorCE)
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "INSERT INTO Profesor (nombre, dni, fechaNac, telefono, correo) " +
                "VALUES (@nombre, @dni, @fechaNac, @telefono, @correo)";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@nombre", profesorCE.Nombre);
            command.Parameters.AddWithValue("@dni", profesorCE.Dni);
            command.Parameters.AddWithValue("@fechaNac", profesorCE.FechaNac.ToLocalTime());
            command.Parameters.AddWithValue("@telefono", profesorCE.Telefono);
            command.Parameters.AddWithValue("@correo", profesorCE.Correo);


            // Ejecutar comando / insert
            int numFilas = command.ExecuteNonQuery();

            // Declarar variable nuevo ID
            int nuevoID;

            if (numFilas > 0)
            {
                // Asignar nuevo SQL
                command.CommandText = "Select max(id) as nuevoId from Profesor " +
                    "where nombre = @nombre";
                // Actualizar el parametro
                command.Parameters["@nombre"].Value = profesorCE.Nombre;

                // Ejecutar el comando
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    // consulta exitosa
                    nuevoID = Convert.ToInt32(dataReader["nuevoId"]);
                }
                else
                {
                    // Consulta fallida
                    nuevoID = 0;
                }

            }
            else
            {
                // no se registro la consulta
                nuevoID = 0;
            }

            
            // Cerramos la conexion
            connection.Close();
            
            // Retornar el nuevo id
            return nuevoID;
        }
        public int Actualizar(ProfesorCE profesor)
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "UPDATE Profesor SET "+
                "nombre = @nombre, dni = @dni, fechaNac = @fechaNac, telefono = @telefono, correo = @correo " +
                "where id = @id";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@dni", profesor.Dni);
            command.Parameters.AddWithValue("@fechaNac", profesor.FechaNac);
            command.Parameters.AddWithValue("@telefono", profesor.Telefono);
            command.Parameters.AddWithValue("@correo", profesor.Correo);
            command.Parameters.AddWithValue("@id", profesor.Id);


            // Ejecutar comando / insert
            int numFilas = command.ExecuteNonQuery();
          


            // Cerramos la conexion
            connection.Close();

            // Retornar el nuevo id
            return numFilas;
        }
        public int Eliminar(ProfesorCE profesor)
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "DELETE FROM Profesor WHERE id = @id";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@id", profesor.Id);


            // Ejecutar comando / delete
            int numFilas = command.ExecuteNonQuery();
            


            // Cerramos la conexion
            connection.Close();

            // Retornar el nuevo id
            return numFilas;
        }

        public List<ProfesorCE> Listar()
        {
            // Crear la conexion
            SqlConnection connection = ConexionCD.conectarBD();

            // Abrir la conexion
            connection.Open();

            // Crear comando
            SqlCommand command = connection.CreateCommand();

            // Definir tipo de comando
            command.CommandType = CommandType.Text;

            // Asignar Consulta SQL
            command.CommandText = "SELECT * FROM Profesor";

            // Ejectuar comando
            SqlDataReader dataReader = command.ExecuteReader();

            // Declarar lista
            List<ProfesorCE> profesoresCE = new List<ProfesorCE>();

            // ejecutar un read
            while (dataReader.Read())
            {
                // Si existe fila leer datos
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();
                int dni = Convert.ToInt32(dataReader["dni"]);
                DateTime fechaNac = Convert.ToDateTime(dataReader["fechaNac"]);
                int telefono = Convert.ToInt32(dataReader["telefono"]);
                string correo = dataReader["correo"].ToString();

                // Instanciar objeto
                ProfesorCE profesor = new ProfesorCE(id, nombre, dni, fechaNac, telefono, correo);

                // Agregar a lista
                profesoresCE.Add(profesor);
            }
           
            // Cerramos la conexion
            connection.Close();

            // Retornar el nuevo id
            return profesoresCE;
        }

    }
}
