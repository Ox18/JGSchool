using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    class EstudianteCN
    {
        // crear
        public int Crear(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();

            int nuevoId = estudianteCD.Crear(estudianteCE);

            return nuevoId;
        }

        // Leer
        public List<EstudianteCE> Leer()
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            List<EstudianteCE> estudianteCEs = estudianteCD.Leer();
            return estudianteCEs;
        }

        // Actualizar
        public int Actualizar(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            int numFilas = estudianteCD.Actualizar(estudianteCE);
            return numFilas;
        }

        // Eliminar
        public int Eliminar(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            int numFilas = estudianteCD.Eliminar(estudianteCE);
            return numFilas;
        }

        // Busqueda nombre
        public List<EstudianteCE> BusquedaNombre(string nombre)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            List<EstudianteCE> estudianteCEs = estudianteCD.BusquedaNombre(nombre);
            return estudianteCEs;
        }
    }
}
