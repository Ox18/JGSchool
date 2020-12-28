using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    class NotasCN
    {
        // Crear
        public int Crear(NotasCE notasCE)
        {
            NotasCD notasCD = new NotasCD();
            int nuevoId = notasCD.Crear(notasCE);
            return nuevoId;
        }
        // Leer
        public List<NotasCE> Leer()
        {
            NotasCD notasCD = new NotasCD();
            List<NotasCE> notasCEs = notasCD.Leer();
            return notasCEs;
        }
        // Actualizar
        public int Actualizar(NotasCE notasCE)
        {
            NotasCD notasCD = new NotasCD();
            int numFilas = notasCD.Actualizar(notasCE);
            return numFilas;
        }
        // Eliminar
        public int Eliminar(NotasCE notasCE)
        {
            NotasCD notasCD = new NotasCD();
            int numFilas = notasCD.Eliminar(notasCE);
            return numFilas;
        }
    }
}
