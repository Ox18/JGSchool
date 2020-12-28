using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class NotasCE
    {
        private int id;
        private int idEstudiante;
        private int idEvaluacion;
        private double nota;

        public NotasCE() { }

        public NotasCE(int id, int idEstudiante, int idEvaluacion, double nota)
        {
            this.Id = id;
            this.IdEstudiante = idEstudiante;
            this.IdEvaluacion = idEvaluacion;
            this.Nota = nota;
        }

        public int Id { get => id; set => id = value; }
        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public int IdEvaluacion { get => idEvaluacion; set => idEvaluacion = value; }
        public double Nota { get => nota; set => nota = value; }
    }
}
