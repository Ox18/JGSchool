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
         // singleton
        private static RegistrosCP instancia = null;
        public static RegistrosCP Instancia
        {
            get
            {
                if ((instancia == null) || (instancia.IsDisposed))
                {
                    instancia = new RegistrosCP();
                }
                return instancia;
            }
        }
        public RegistrosCP()
        {
            InitializeComponent();
            ListarEvaluaciones();
            formatGrid();
        }

        private void RegistrosCP_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarProfesor_Click_1(object sender, EventArgs e)
        {
            BuscarProfesor();
        }

        private void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            BuscarCurso();
        }

        private void btnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            BuscarEstudiante();
        }
        
        private void ListarEvaluaciones()
        {
            EvaluacionCN evaluacionCN = new EvaluacionCN();
            List<EvaluacionCE> evaluacionCEs = evaluacionCN.Leer();
            lstEvaluacion.DataSource = evaluacionCEs;
            lstEvaluacion.DisplayMember = "Descripcion";
            lstEvaluacion.ValueMember = "Id";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

            if (txtIdCurso.Text.Length > 0 && txtIdProfesor.Text.Length > 0 && txtIdEstudiante.Text.Length > 0
               && txtCurso.Text.Length > 0 && txtProfesor.Text.Length > 0 && txtEstudiante.Text.Length > 0
               && txtNota.Text.Length > 0)
            {
                int idEstudiante = Convert.ToInt32(txtIdEstudiante.Text);
                string nombreEstudiante = txtEstudiante.Text;
                int idEvaluacion = (int)lstEvaluacion.SelectedValue;
                string descripcionEvaluacion = lstEvaluacion.Text;
                double nota = Convert.ToDouble(txtNota.Text);

                dgvDatos.Rows.Add(idEstudiante, nombreEstudiante, idEvaluacion, descripcionEvaluacion, nota);

                CalcularPromedio();
                txtNota.Text = "0";

            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados. Puede que los datos esténs vacíos.");
            }
        }

        private void txtIdProfesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool verificar = char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar);
            if (verificar)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void txtIdCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool verificar = char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar);
            if (verificar)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtIdEstudiante_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool verificar = char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar);
            if (verificar)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool verificar = char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar);
            if (verificar)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            if (txtNota.Text.Length > 0)
            {
                int nota = Convert.ToInt32(txtNota.Text);
                if (nota > 20)
                {
                    txtNota.Text = "20";
                }
            }
            
        }

        private void txtIdProfesor_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void BuscarProfesor()
        {
            if (txtIdProfesor.Text.Length > 0)
            {
                ProfesorCN profesorCN = new ProfesorCN();

                int idBuscado = Convert.ToInt32(txtIdProfesor.Text);

                ProfesorCE profesorCE = profesorCN.BuscarID(idBuscado);

                txtProfesor.Text = profesorCE.Nombre;
            }
        }
        private void BuscarEstudiante()
        {
            if (txtIdEstudiante.Text.Length > 0)
            {
                EstudianteCN estudianteCN = new EstudianteCN();
                int idBuscado = Convert.ToInt32(txtIdEstudiante.Text);
                EstudianteCE estudianteCE = estudianteCN.BusquedaId(idBuscado);
                txtEstudiante.Text = estudianteCE.Nombre;
            }
        }
        private void BuscarCurso()
        {
            if (txtIdCurso.Text.Length > 0)
            {
                CursoCN cursoCN = new CursoCN();
                int idBuscado = Convert.ToInt32(txtIdCurso.Text);
                CursoCE cursoCE = cursoCN.LeerId(idBuscado);
                txtCurso.Text = cursoCE.Nombre;
            }
        }
        private void txtIdProfesor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                BuscarProfesor();
            }
        }

        private void txtIdCurso_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                BuscarCurso();
            }
        }

        private void txtIdEstudiante_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                BuscarEstudiante();
            }
        }
        private void formatGrid()
        {
            //Agregar columnas
            dgvDatos.Columns.Add("idEstudiante", "ID ESTUDIANTE");
            dgvDatos.Columns.Add("nombreEstudiante", "NOMBRE ESTUDIANTE");
            dgvDatos.Columns.Add("idEvaluacion", "ID EVALUACION");
            dgvDatos.Columns.Add("desEvaluacion", "DESCRIPCIÓN EVALUACIÓN");
            dgvDatos.Columns.Add("nota", "NOTA");
            //Quitar la fila en blanco
            dgvDatos.AllowUserToAddRows = false;
            //Ancho de columnas
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void CalcularPromedio()
        {
            double total = 0;
            int divisor = dgvDatos.Rows.Count;
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                total = total + Convert.ToDouble(fila.Cells["nota"].Value);
            }
            double promedio = total / divisor;
            double promedioProcess = double.IsNaN(promedio) ? 0 : promedio;
            txtPromedio.Text = promedioProcess.ToString();
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                if (txtIdProfesor.Text.Length > 0 && txtProfesor.Text.Length > 0
                   && txtIdCurso.Text.Length > 0 &&  txtCurso.Text.Length > 0
                   && txtIdEstudiante.Text.Length > 0 && txtEstudiante.Text.Length > 0)
                {
                    DialogResult rpta = MessageBox.Show("Está a punto de GUARDAR los REGISTROS y sus detalles. ¿Está seguro?",
                "Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (rpta == DialogResult.Yes)
                    {
                        int idProfesor = Convert.ToInt32(txtIdProfesor.Text);
                        int idCurso = Convert.ToInt32(txtIdCurso.Text);
                        DateTime fechaInicio = dtpFInicio.Value;
                        DateTime fechaTermino = dtpFTermino.Value;
                        RegistroCE registroCE = new RegistroCE(0, idProfesor, idCurso, fechaInicio, fechaTermino);
                        RegistroCN registroCN = new RegistroCN();

                        int idRegistro = registroCN.Crear(registroCE);

                        foreach (DataGridViewRow fila in dgvDatos.Rows)
                        {
                            int idEstudiante = Convert.ToInt32(fila.Cells["idEstudiante"].Value);
                            int idEvaluacion = Convert.ToInt32(fila.Cells["idEvaluacion"].Value);
                            double nota = Convert.ToDouble(fila.Cells["nota"].Value);

                            NotasCE notasCE = new NotasCE(0, idEstudiante, idEvaluacion, idRegistro, nota);
                            NotasCN notasCN = new NotasCN();

                            int idNotas = notasCN.Crear(notasCE);

                            Console.WriteLine("Registro guardado => " + idRegistro + " / " + idNotas);
                        }
                        LimpiarTodo();
                        CalcularPromedio();
                    }
                }
                else
                {
                    MessageBox.Show("Al parecer hay ciertos datos incompletos. Por favor, completelo para guardar los registros.");
                }
                
            }
            else
            {
                MessageBox.Show("No hay registros introducidos.");
            }
        }
        private void LimpiarGrid()
        {
            dgvDatos.DataSource = "";
        }
        private void LimpiarInformacion()
        {
            txtIdEstudiante.Text = "";
            txtEstudiante.Text = "";
            txtCurso.Text = "";
            txtIdCurso.Text = "";
        }
        private void LimpiarTodo()
        {
            LimpiarGrid();
            LimpiarInformacion();
        }

        private void lstEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarEstudiante_Click_1(object sender, EventArgs e)
        {
            BuscarEstudiante();
        }

        private void btnBuscarCurso_Click_1(object sender, EventArgs e)
        {
            BuscarCurso();
        }

        private void txtIdProfesor_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                BuscarProfesor();
            }
        }

        private void txtIdCurso_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                BuscarCurso();
            }
        }

        private void txtIdEstudiante_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                BuscarEstudiante();
            }
        }
    }
}
