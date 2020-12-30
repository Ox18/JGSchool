using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class RegistrosCP : Form
    {
        public RegistrosCP()
        {
            InitializeComponent();
            ListarEvaluaciones();
        }

        private void RegistrosCP_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarProfesor_Click(object sender, EventArgs e)
        {
            ProfesorCN profesorCN = new ProfesorCN();

            int idBuscado = Convert.ToInt32(txtIdProfesor.Text);

            ProfesorCE profesorCE = profesorCN.BuscarID(idBuscado);

            txtProfesor.Text = profesorCE.Nombre;

        }

        private void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            CursoCN cursoCN = new CursoCN();

            int idBuscado = Convert.ToInt32(txtIdCurso.Text);
            CursoCE cursoCE = cursoCN.LeerId(idBuscado);
            txtCurso.Text = cursoCE.Nombre;
        }

        private void btnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            EstudianteCN estudianteCN = new EstudianteCN();
            int idBuscado = Convert.ToInt32(txtIdEstudiante.Text);
            EstudianteCE estudianteCE = estudianteCN.BusquedaId(idBuscado);
            txtEstudiante.Text = estudianteCE.Nombre;
        }
        
        private void ListarEvaluaciones()
        {
            EvaluacionCN evaluacionCN = new EvaluacionCN();
            List<EvaluacionCE> evaluacionCEs = evaluacionCN.Leer();
            lstEvaluacion.DataSource = evaluacionCEs;
            lstEvaluacion.DisplayMember = "descripcion";
            lstEvaluacion.ValueMember = "id";
        }
    }
}
