using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionCD
    {
        public static SqlConnection conectarBD()
        {
            // Instanciar Clase que facilita la insercion de datos de conexion
            SqlConnectionStringBuilder generadorCadena = new SqlConnectionStringBuilder();

            // Complementar las propiedades

            // Punto de direccion
            generadorCadena.DataSource = "localhost";

            // Nombre de base de datos
            generadorCadena.InitialCatalog = "BD_FINAL_MACURI";

            // Autenticacion de windows
            generadorCadena.IntegratedSecurity = true;


            // Recoger la cadena de conexion
            string cadenaConexion = generadorCadena.ConnectionString;


            // Instanciar conexion a base de datos
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);

            // Retornar conexion
            return sqlConnection;
        }
    }
}
