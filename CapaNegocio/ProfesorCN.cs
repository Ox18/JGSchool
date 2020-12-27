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
            ProfesorCD profesorCD = new ProfesorCD();

            ProfesorCE profesorCE = profesorCD.BuscarID(idBuscado);

            return profesorCE;
        }
        public List<ProfesorCE> BuscarNombre(string nombreBuscar)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            List<ProfesorCE> profesorCEs = profesorCD.BuscarNombre(nombreBuscar);

            return profesorCEs;

        }
        public List<ProfesorCE> Listar()
        {
            ProfesorCD profesorCD = new ProfesorCD();
            List<ProfesorCE> profesorCEs = profesorCD.Listar();

            return profesorCEs;

        }

        public int Insertar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int idNuevo = profesorCD.Insertar(profesorCE);

            return idNuevo;

        }
        public int Actualizar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int filasAfectadas = profesorCD.Actualizar(profesorCE);

            return filasAfectadas;

        }
        public int Eliminar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int filasAfectadas = profesorCD.Eliminar(profesorCE);

            return filasAfectadas;

        }

    }
}
