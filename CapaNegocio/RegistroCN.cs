using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class RegistroCN
    {
        // Crear
        public int Crear(RegistroCE registroCE)
        {
            RegistroCD registroCD = new RegistroCD();
            int nuevoID = registroCD.Crear(registroCE);
            return nuevoID;
        }

        // Leer
        public List<RegistroCE> Leer()
        {
            RegistroCD registroCD = new RegistroCD();
            List<RegistroCE> registroCEs = registroCD.Leer();
            return registroCEs;
        }

        // Actualizar
        public int Actualizar(RegistroCE registroCE)
        {
            RegistroCD registroCD = new RegistroCD();
            int numFilas = registroCD.Actualizar(registroCE);
            return numFilas;
        }

        // Eliminar
        public int Eliminar(RegistroCE registroCE)
        {
            RegistroCD registroCD = new RegistroCD();
            int numFilas = registroCD.Eliminar(registroCE);
            return numFilas;
        }
    }
}
