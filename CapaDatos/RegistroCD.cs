using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class RegistroCD
    {
        // Crear
        public int Crear(RegistroCE registroCE)
        {
            // establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear el comanod
            SqlCommand cmd = cn.CreateCommand();

            // Establecer el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer la consulta
            cmd.CommandText = "insert Registro " +
                "into (idProfesor, idCurso, fechaInicio, fechaTermino) " +
                "values (@idProfesor, @idCurso, @fechaInicio, @fechaTermino)";

            // Agregar parametros
            cmd.Parameters.AddWithValue("@idProfesor", registroCE.IdProfesor);
            cmd.Parameters.AddWithValue("@idCurso", registroCE.IdCurso);
            cmd.Parameters.AddWithValue("@fechaInicio", registroCE.FechaInicio.ToLocalTime());
            cmd.Parameters.AddWithValue("@fechaTermino", registroCE.FechaTermino.ToLocalTime());

            // Ejecutar consulta
            int numFilas = cmd.ExecuteNonQuery();

            // Definir el nuevo id
            int nuevoID;

            // Condicionar filas afectadas
            if (numFilas > 0)
            {
                // Creamos la nueva consulta
                cmd.CommandText = "select max(id) as nuevoId from Registro" +
                    " where idProfesor = @idProfesor";

                // Editar parametro
                cmd.Parameters["@idProfesor"].Value = registroCE.IdProfesor;

                // Ejecutar consulta
                SqlDataReader dataReader = cmd.ExecuteReader();

                // Leer reader
                if (dataReader.Read())
                {
                    nuevoID = (int)dataReader["nuevoId"];
                }
                else
                {
                    nuevoID = 0;
                }
            }
            else
            {
                nuevoID = 0;
            }
            
            // Cerrar la conexion
            cn.Close();

            // Retornamos el nuevo id
            return nuevoID;
        }

        // Leer
        public List<RegistroCE> Leer()
        {
            // establecer conexion
            SqlConnection cn = ConexionCD.conectarBD();

            // Abrir conexion
            cn.Open();

            // Crear comando
            SqlCommand cmd = cn.CreateCommand();

            // Definir el tipo de comando
            cmd.CommandType = CommandType.Text;

            // Establecer consulta
            cmd.CommandText = "select * from Registro";

            // Instanciar ejecucion de filas
            SqlDataReader dataReader = cmd.ExecuteReader();

            // crear lista
            List<RegistroCE> registroCEs = new List<RegistroCE>();

            // Rellenar registros
            while (dataReader.Read())
            {
                int id = (int)dataReader["id"];
                int idProfesor = (int)dataReader["idProfesor"];
                int idCurso = (int)dataReader["idCurso"];
                DateTime fechaInicio = (DateTime)dataReader["fechaInicio"];
                DateTime fechaTermino = (DateTime)dataReader["fechaTermino"];

                // instanciar objeto
                RegistroCE registroCE = new RegistroCE(id, idProfesor, idCurso, fechaInicio, fechaTermino);

                // agregar a lista
                registroCEs.Add(registroCE);
            }

            // Cerrar conexion
            cn.Close();

            // Retornar lista
            return registroCEs;
        }
        
        // Actualizar
        public int Actualizar(RegistroCE registroCE)
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
            cmd.CommandText = "update Registro set" +
                " idProfesor = @idProfesor, idCurso = @idCurso, fechaInicio = @fechaInicio, fechaTermino = @fechaTermino" +
                " where id = @id";

            // Definir los parametros
            cmd.Parameters.AddWithValue("@idProfesor", registroCE.IdProfesor);
            cmd.Parameters.AddWithValue("@idCurso", registroCE.IdCurso);
            cmd.Parameters.AddWithValue("@fechaInicio", registroCE.FechaInicio);
            cmd.Parameters.AddWithValue("@fechaTermino", registroCE.FechaTermino);
            cmd.Parameters.AddWithValue("@id", registroCE.Id);

            // Ejecutar comando
            int numFilas = cmd.ExecuteNonQuery();

            // cerrar conexion
            cn.Close();

            // retornar cantidad de filas afectadas
            return numFilas;
        }

        // Eliminar
        public int Eliminar(RegistroCE registroCE)
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
            cmd.CommandText = "delete from Registro where id = @id";

            // Definir los parametros
            cmd.Parameters.AddWithValue("@id", registroCE.Id);

            // Ejecutar comando
            int numFilas = cmd.ExecuteNonQuery();

            // cerrar conexion
            cn.Close();

            // retornar cantidad de filas afectadas
            return numFilas;
        }
    }
}
