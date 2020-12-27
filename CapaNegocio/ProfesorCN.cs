using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProfesorCN
    {
        public ProfesorCE BuscarID(int idBuscado)
        {
            ProfesorCN profesorCN = new ProfesorCN();

            ProfesorCE profesorCE = profesorCN.BuscarID(idBuscado);

            return profesorCE;
        }
        public List<ProfesorCE> BuscarNombre(string nombreBuscar)
        {
            ProfesorCN profesorCN = new ProfesorCN();
            List<ProfesorCE> profesorCEs = profesorCN.BuscarNombre(nombreBuscar);

            return profesorCEs;

        }
        public List<ProfesorCE> Listar()
        {
            ProfesorCN profesorCN = new ProfesorCN();
            List<ProfesorCE> profesorCEs = profesorCN.ListarProfesores();

            return profesorCEs;

        }

        public int Insertar(ProfesorCE profesorCE)
        {
            ProfesorCN profesorCN = new ProfesorCN();
            int idNuevo = profesorCN.Insertar(profesorCE);

            return idNuevo;

        }
        public int Actualizar(ProfesorCE profesorCE)
        {
            ProfesorCN profesorCN = new ProfesorCN();
            int filasAfectadas = profesorCN.Actualizar(profesorCE);

            return filasAfectadas;

        }
        public int Eliminar(ProfesorCE profesorCE)
        {
            ProfesorCN profesorCN = new ProfesorCN();
            int filasAfectadas = profesorCN.Eliminar(profesorCE);

            return filasAfectadas;

        }

    }
}
