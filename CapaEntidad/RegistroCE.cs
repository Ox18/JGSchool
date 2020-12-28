using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RegistroCE
    {
        private int id;
        private int idProfesor;
        private int idCurso;
        private DateTime fechaInicio;
        private DateTime fechaTermino;

        public RegistroCE() { }

        public RegistroCE(int id, int idProfesor, int idCurso, DateTime fechaInicio, DateTime fechaTermino)
        {
            this.Id = id;
            this.IdProfesor = idProfesor;
            this.IdCurso = idCurso;
            this.FechaInicio = fechaInicio;
            this.FechaTermino = fechaTermino;
        }

        public int Id { get => id; set => id = value; }
        public int IdProfesor { get => idProfesor; set => idProfesor = value; }
        public int IdCurso { get => idCurso; set => idCurso = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaTermino { get => fechaTermino; set => fechaTermino = value; }
    }
}
