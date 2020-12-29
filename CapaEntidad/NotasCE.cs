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
        private int idRegistro;
        private double nota;

        public NotasCE() { }

        public NotasCE(int id, int idEstudiante, int idEvaluacion, int idRegistro, double nota)
        {
            this.id = id;
            this.idEstudiante = idEstudiante;
            this.idEvaluacion = idEvaluacion;
            this.idRegistro = idRegistro;
            this.nota = nota;
        }

        public int Id { get => id; set => id = value; }
        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public int IdEvaluacion { get => idEvaluacion; set => idEvaluacion = value; }
        public double Nota { get => nota; set => nota = value; }
        public int IdRegistro { get => idRegistro; set => idRegistro = value; }
    }
}
