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
    public class CursoCD
    {
        // Crear
        public int Crear(CursoCE cursoCE)
        {
            // Crear conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir tipo de comando
            cmd.CommandType = CommandType.Text;

            // Asignar consulta SQL
            cmd.CommandText = "INSERT INTO Curso(nombre) "+
                "VALUES(@nombre)";

            // Asignar parametros a consulta
            cmd.Parameters.AddWithValue("@nombre", cursoCE.Nombre);

            // Ejecutar comando
            int numFilas;

            using (SqlTransaction transaction = cn.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    numFilas = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    numFilas = 0;
                }
            }
             // Declarar variable nuevo id
             int nuevoID;

            if (numFilas > 0)
            {
                // Asignar nuevo SQL
                cmd.CommandText = "SELECT MAX(id) as nuevoId from Curso " +
                    "where nombre = @nombre";
                // Actualizar parametro
                cmd.Parameters["@nombre"].Value = cursoCE.Nombre;

                // Ejecutar el comando
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    // Consulta exitosa
                    nuevoID = Convert.ToInt32(dataReader["nuevoId"]);
                }
                else
                {
                    // Consulta Fallida
                    nuevoID = 0;
                }
            }
            else
            {
                nuevoID = 0;
            }

            // Cerramos la conexion
            cn.Close();

            // retornar nuevo id
            return nuevoID;
        }

        // Leer
        public List<CursoCE> Leer()
        {
            // Crear conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Asignar consulta SQL
            cmd.CommandText = "select * from curso";

            // Ejecutar comando
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Crear lista
            List<CursoCE> cursoCEs = new List<CursoCE>();

            // Leer todas las tablas
            while (dataReader.Read())
            {
                // Leer filas
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();
                
                // Crear nuevo obj
                CursoCE cursoCE = new CursoCE(id, nombre);

                // Agregar obj a lista
                cursoCEs.Add(cursoCE);
            }

            // Cerramos la conexion
            cn.Close();

            // retornar nuevo id
            return cursoCEs;
        }

        // Actualizar
        public int Actualizar(CursoCE cursoCE)
        {
            // Crear conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de conexion
            cmd.CommandType = CommandType.Text;

            // Establecer la consulta
            cmd.CommandText = "update Curso set "+
                "nombre = @nombre where id = @id";

            // Agregar los parametros
            cmd.Parameters.AddWithValue("@nombre", cursoCE.Nombre);
            cmd.Parameters.AddWithValue("@id", cursoCE.Id);

            // Ejecutar parametro
            int numFilas;

            using (SqlTransaction transaction = cn.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    numFilas = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    numFilas = 0;
                }
            }

            // Cerramos la conexion
            cn.Close();

            // Retornamos la cantidad de filas
            return numFilas;
        }

        // Eliminar
        public int Eliminar(CursoCE cursoCE)
        {
            // Creamos la conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrimos la conexion
            cn.Open();

            // Creamos el command
            SqlCommand cmd = cn.CreateCommand();

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Insertamos consulta
            cmd.CommandText = "delete from Curso where id = @id";

            // Definir parametros
            cmd.Parameters.AddWithValue("@id", cursoCE.Id);

            // Ejecutamos la consulta y la almacenamos en una variable de tipo entera
            int numFilas;

            using (SqlTransaction transaction = cn.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    numFilas = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    numFilas = 0;
                }
            }

            // Cerramos conexion
            cn.Close();

            // Retornamos la cantidad de filas afectadas
            return numFilas;
        }

        // Leer Todos
        public List<CursoCE> LeerNombre(string nombreBuscar)
        {
            // Crear conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer consulta
            cmd.CommandText = "select * from Curso "+
                "where nombre like '%' + @nombre + '%'";

            // Definir parametros
            cmd.Parameters.AddWithValue("@nombre", nombreBuscar);

            // Establecer ejecucion de comando
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Establecer lista
            List<CursoCE> cursoCEs = new List<CursoCE>();

            // Leer datos encontrados
            while (dataReader.Read())
            {
                // Capturar datos encontrado
                int id = Convert.ToInt32(dataReader["id"]);
                string nombre = dataReader["nombre"].ToString();

                // Instanciar obj
                CursoCE cursoCE = new CursoCE(id, nombre);

                // Agrupar obj
                cursoCEs.Add(cursoCE);
            }

            // Cerrar conexion
            cn.Close();

            // Retornar lista
            return cursoCEs;
        }

        // Leer Id
        public CursoCE LeerId(int idBuscado)
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
            command.CommandText = "select * from Curso " +
                "where id = @id";

            // Asignar valor al parametro
            command.Parameters.AddWithValue("@id", idBuscado);

            // Ejecutar comando / select
            SqlDataReader dataReader = command.ExecuteReader();

            // Declarar variables para los datos;
            int id;
            string nombre;

            if (dataReader.Read())
            {
                // Si la fila existe
                id = Convert.ToInt32(dataReader["id"]);
                nombre = dataReader["nombre"].ToString();

            }
            else
            {
                // Si la fila no existe
                id = 0;
                nombre = "";
            }
            // Cerramos la conexion
            connection.Close();

            // Asignamos los valores a un objeto
            CursoCE cursoCE = new CursoCE(id, nombre);

            // Retornar el objeto
            return cursoCE;
        }
    }
}
