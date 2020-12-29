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
    public partial class EvaluacionCP : Form
    {
        public EvaluacionCP()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                Buscar(txtBuscar.Text);
            }
            else
            {
                Leer();
            }
        }
        private void Leer()
        {
            EvaluacionCN evaluacionCN = new EvaluacionCN();
            dgvDatos.DataSource = evaluacionCN.Leer();
        }
        private void Buscar(string name)
        {
            EvaluacionCN evaluacionCN = new EvaluacionCN();
            dgvDatos.DataSource = evaluacionCN.BuscarDescripcion(name);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        }
        private bool VerificarFormulario()
        {
            bool verificar = txtDescripcion.Text.Length > 0;
            return verificar;
        }
        private void Limpiar()
        {
            txtId.Text = "0";
            txtDescripcion.Text = "";
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text == "0")
                {
                    // nuevo
                    string descripcion = txtDescripcion.Text;
                    EvaluacionCE evaluacionCE = new EvaluacionCE(0, descripcion);
                    EvaluacionCN evaluacionCN = new EvaluacionCN();

                    int id = evaluacionCN.Crear(evaluacionCE);

                    txtId.Text = id.ToString();
                }
                else
                {
                    // id diferente
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique que el formulario haya sido rellenado.");
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvDatos.SelectedRows[0];
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text != "0")
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string descripcion = txtDescripcion.Text;

                    EvaluacionCE evaluacionCE = new EvaluacionCE(id, descripcion);

                    EvaluacionCN evaluacionCN = new EvaluacionCN();

                    int numFil = evaluacionCN.Actualizar(evaluacionCE);

                    MessageBox.Show(numFil + " Filas afectadas");
                }
                else
                {
                    MessageBox.Show("No se puede editar con datos vacios.");
                }
                
            }
            else
            {
                MessageBox.Show("Si vas a editar, no deje vacios los valores.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                int id = Convert.ToInt32(txtId.Text);
                EvaluacionCE evaluacionCE = new EvaluacionCE();
                evaluacionCE.Id = id;
                EvaluacionCN evaluacionCN = new EvaluacionCN();
                int numFil = evaluacionCN.Eliminar(evaluacionCE);
                MessageBox.Show(numFil + " Filas afectadas");
            }
            else
            {
                MessageBox.Show("No se puede eliminar mientras los datos esten vacios o incompletos.");
            }
            
            
        }
    }
}
