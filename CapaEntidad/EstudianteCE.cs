using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EstudianteCE
    {
        private int id;
        private string nombre;
        private int dni;
        private DateTime fechaNac;
        private int telefono;
        private string correo;
        private string nivel;
        private int grado;

        public EstudianteCE() { }

        public EstudianteCE(int id, string nombre, int dni, DateTime fechaNac, int telefono, string correo, string nivel, int grado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Dni = dni;
            this.FechaNac = fechaNac;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Nivel = nivel;
            this.Grado = grado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Nivel { get => nivel; set => nivel = value; }
        public int Grado { get => grado; set => grado = value; }
    }
}
