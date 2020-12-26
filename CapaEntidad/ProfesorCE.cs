using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProfesorCE
    {
        private int id;
        private string nombre;
        private int dni;
        private DateTime fechaNac;
        private int telefono;
        private string correo;



        public ProfesorCE() { }
        public ProfesorCE(int id, string nombre, int dni, DateTime fechaNac, int telefono, string correo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Dni = dni;
            this.FechaNac = fechaNac;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
