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
    public partial class CursoCP : Form
    {
        // singleton
        private static CursoCP instancia = null;
        public static CursoCP Instancia
        {
            get
            {
                if ((instancia == null) || (instancia.IsDisposed))
                {
                    instancia = new CursoCP();
                }
                return instancia;
            }
        }
        public CursoCP()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
            CursoCN cursoCN = new CursoCN();
            dgvDatos.DataSource = cursoCN.Leer();
        }
        private void Buscar(string name)
        {
            CursoCN cursoCN = new CursoCN();
            dgvDatos.DataSource = cursoCN.LeerNombre(name);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text == "0")
                {
                    // nuevo
                    string nombre = txtNombre.Text;
                    CursoCE cursoCE = new CursoCE(0, nombre);
                    CursoCN cursoCN = new CursoCN();

                    int id = cursoCN.Crear(cursoCE);

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
        private bool VerificarFormulario()
        {
            bool verificar = txtNombre.Text.Length > 0;
            return verificar;
        }
        private void Limpiar()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvDatos.SelectedRows[0];
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text != "0")
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string nombre = txtNombre.Text;

                    CursoCE cursoCE = new CursoCE(id, nombre);

                    CursoCN cursoCN = new CursoCN();

                    int numFil = cursoCN.Actualizar(cursoCE);

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
                CursoCE cursoCE = new CursoCE();
                cursoCE.Id = id;
                CursoCN cursoCN = new CursoCN();
                int numFil = cursoCN.Eliminar(cursoCE);
                MessageBox.Show(numFil + " Filas afectadas");
                if (numFil > 0)
                {
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar mientras los datos esten vacios o incompletos.");
            }
        }

        private void CursoCP_Load(object sender, EventArgs e)
        {

        }
    }
}
