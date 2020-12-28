using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EvaluacionCE
    {
        private int id;
        private string descripcion;

        public EvaluacionCE() { }

        public EvaluacionCE(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
