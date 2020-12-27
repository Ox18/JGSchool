using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EvaluacionCN
    {
        // Crear
        public int Crear(EvaluacionCE evaluacionCE)
        {
            // Instanciamos capa datos
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            // Almacenamos el valor del metodo
            int numFila = evaluacionCD.Crear(evaluacionCE);
            // Retornamos el valor
            return numFila;

        }

        // Leer
        public List<EvaluacionCE> Leer()
        {
            // Instanciamos capaDatos
            EvaluacionCD evaluacionCD = new EvaluacionCD();

            // Creamos lista
            List<EvaluacionCE> evaluacionCEs = evaluacionCD.Leer();

            // retornamos lista
            return evaluacionCEs;
        }

        // Actualizar
        public int Actualizar(EvaluacionCE evaluacionCE)
        {
            // llamamos al metodo que tiene la consulta
            EvaluacionCD evaluacionCD = new EvaluacionCD();

            // Almacenamos el restultado del metodo en variable
            int numFilas = evaluacionCD.Actualizar(evaluacionCE);

            // Retornamos valor
            return numFilas;
        }

        // Eliminar
        public int Eliminar(EvaluacionCE evaluacionCE)
        {
            // llamamos al metodo que tiene la consulta
            EvaluacionCD evaluacionCD = new EvaluacionCD();

            // Almacenamos el restultado del metodo en variable
            int numFilas = evaluacionCD.Eliminar(evaluacionCE);

            // Retornamos valor
            return numFilas;
        }

        // Buscar descripcion
        public List<EvaluacionCE> BuscarDescripcion(string descripcionBuscar)
        {
            // Establecemos conexion con la instancia
            EvaluacionCD evaluacionCD = new EvaluacionCD();

            // Almacenamos el resultado en una lista
            List<EvaluacionCE> evaluacionCEs = evaluacionCD.BuscarDescripcion(descripcionBuscar);

            // retornamos lista
            return evaluacionCEs;
        }
    }
}
