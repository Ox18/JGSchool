using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CursoCN
    {
        // Crear curso
        public int Crear(CursoCE cursoCE) {
            // Instanciamos obj de capa datos
            CursoCD cursoCD = new CursoCD();
            // Instanciamos una variable para almacenar el nuevo id
            int nuevoID = cursoCD.Crear(cursoCE);
            // retonarmos el nuevo id
            return nuevoID;
        }

        // Leer todos los cursos
        public List<CursoCE> Leer() {
            // Instanciamos obj de capa datos
            CursoCD cursoCD = new CursoCD();

            // Creamos una lista de cursos
            List<CursoCE> cursoCEs = cursoCD.Leer();

            // retornamos nuestro resultado
            return cursoCEs;
        }

        // Actualizar curso
        public int Actualizar(CursoCE cursoCE) {
            // Instanciamos a la capa de conexion
            CursoCD cursoCD = new CursoCD();
            // Llamamos al metodo y lo almacenamos
            int numFilas = cursoCD.Actualizar(cursoCE);

            // retornamos nuestro resultado
            return numFilas;
        }

        // Eliminar curso
        public int Eliminar(CursoCE cursoCE) {
            // Instanciamos la clase que tiene la conexion
            CursoCD cursoCD = new CursoCD();

            // Llamar al metodo y almacenarlo
            int numFilas = cursoCD.Eliminar(cursoCE);

            // retornamos nuestro resultado
            return numFilas;
        }

        // Busqueda por nombre
        public List<CursoCE> LeerNombre(string nombre) {
            // Instanciamos la clase que tiene nuestra conexion
            CursoCD cursoCD = new CursoCD();

            // Llamar al metodo y lo almacenamos
            List<CursoCE> cursoCEs = cursoCD.LeerNombre(nombre);

            // Retornamos nuestro resultado
            return cursoCEs;
        }
    }
}
