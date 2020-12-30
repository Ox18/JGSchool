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
    public partial class EstudianteCP : Form
    {
        // singleton
        private static EstudianteCP instancia = null;
        public static EstudianteCP Instancia
        {
            get
            {
                if ((instancia == null) || (instancia.IsDisposed))
                {
                    instancia = new EstudianteCP();
                }
                return instancia;
            }
        }
        public EstudianteCP()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "0")
            {
                if (VerificarFormulario())
                {
                    string nombre = txtNombre.Text;
                    int dni = Convert.ToInt32(txtDNI.Text);
                    DateTime fechaNac = dtpFechaNac.Value;
                    int telefono = Convert.ToInt32(txtTelefono.Text);
                    string correo = txtCorreo.Text;
                    string nivel = lstNivel.SelectedItem.ToString();
                    int grado = lstNivel.SelectedIndex + 1;

                    EstudianteCE estudianteCE = new EstudianteCE(0, nombre, dni, fechaNac, telefono, correo, nivel, grado);
                    EstudianteCN estudianteCN = new EstudianteCN();
                    int idNuevo = estudianteCN.Crear(estudianteCE);
                    txtId.Text = idNuevo.ToString();
                }
                else
                {
                    MessageBox.Show("Los datos del formulario no han sido rellenados correctamente.");
                }
            }
            else
            {
                LimpiarFormulario();
            }
        }
        private bool VerificarFormulario()
        {
            bool verificar = txtNombre.Text.Length > 0 && txtDNI.Text.Length > 0 && txtDNI.Text.Length > 0 && txtCorreo.Text.Length > 0;
            return verificar;
        }
        private void LimpiarFormulario()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            dtpFechaNac.Value = DateTime.Now;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                // extraer nombre a buscar
                string name = txtBuscar.Text;
                // Instanciar objeto 
                EstudianteCN estudianteCN = new EstudianteCN();
                // Insertar retornando los datos del metodo Buscarnombre
                dgvDatos.DataSource = estudianteCN.BusquedaNombre(name);
            }
            else
            {
                // Instanciar
                EstudianteCN estudianteCN = new EstudianteCN();
                // Extraer todos los datos
                dgvDatos.DataSource = estudianteCN.Leer();
            }
        }

        private void lstNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nivel = lstNivel.Items[lstNivel.SelectedIndex].ToString();

            if (nivel == "Primaria")
            {
                lstGrado.Items.Clear();
                for (int i = 1; i <= 6; i++)
                {
                    lstGrado.Items.Add(i);
                }
            }
            if (nivel == "Secundaria")
            {
                lstGrado.Items.Clear();
                for (int i = 1; i <= 5; i++)
                {
                    lstGrado.Items.Add(i);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                int id = Convert.ToInt32(txtId.Text);
                EstudianteCE estudianteCE = new EstudianteCE();
                estudianteCE.Id = id;

                EstudianteCN estudianteCN = new EstudianteCN();

                int numFilas = estudianteCN.Eliminar(estudianteCE);

                MessageBox.Show(numFilas + " filas afectadas");
                if (numFilas > 0)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar mientras los datos esten vacios o incompletos");
            }
        }

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvDatos.SelectedRows[0];
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtDNI.Text = fila.Cells["dni"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["fechaNac"].Value);
                lstNivel.SelectedIndex = fila.Cells["nivel"].Value.ToString() == "Primaria" ? 0 : 1;
                lstGrado.SelectedIndex = Convert.ToInt32(fila.Cells["grado"].Value) - 1;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                if (VerificarFormulario())
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string nombre = txtNombre.Text;
                    int dni = Convert.ToInt32(txtDNI.Text);
                    DateTime fechaNac = dtpFechaNac.Value;
                    int telefono = Convert.ToInt32(txtTelefono.Text);
                    string correo = txtCorreo.Text;
                    string nivel = lstNivel.SelectedItem.ToString();
                    int grado = lstNivel.SelectedIndex + 1;

                    EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechaNac, telefono, correo, nivel, grado);
                    EstudianteCN estudianteCN = new EstudianteCN();
                    int numFile = estudianteCN.Actualizar(estudianteCE);

                    MessageBox.Show(numFile + " Filas Actualizadas");


                }
                else
                {
                    MessageBox.Show("Al parecer no se ha llenado correctamente el formulario.");
                }
            }
            else
            {
                MessageBox.Show("No podemos actualizar con datos nulos o inexistentes.");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra introducida
            char letra = e.KeyChar;
            // Verificar si es:
            // Letra
            // Si es backspace
            // Si es spacebar
            // Si es "."
            bool verificar = char.IsLetter(letra) || char.IsControl(letra) || char.IsWhiteSpace(letra) || letra == '.';


            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
            // Cambia la letra a mayuscula
            e.KeyChar = char.ToUpper(letra);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra
            char letra = e.KeyChar;

            // Verificar si es:
            // Numero
            // Si es backspace
            bool verificar = char.IsNumber(letra) || char.IsControl(letra);

            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra
            char letra = e.KeyChar;

            // Verificar si es:
            // Numero
            // Si es backspace

            bool verificar = char.IsNumber(letra) || char.IsControl(letra);

            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra introducida
            char letra = e.KeyChar;
            // Verificar si es:
            // Letra
            // Si es backspace
            // Si es spacebar
            // Si es "."
            bool verificar = char.IsLetter(letra) || char.IsControl(letra) || char.IsWhiteSpace(letra) || letra == '.';


            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
            // Cambia la letra a mayuscula
            e.KeyChar = char.ToUpper(letra);
        }

        private void EstudianteCP_Load(object sender, EventArgs e)
        {

        }
    }
}
