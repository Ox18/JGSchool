using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class PrincipalCP : Form
    {
        public PrincipalCP()
        {
            InitializeComponent();
        }

        private void PrincipalCP_Load(object sender, EventArgs e)
        {
            menuStripBar.ForeColor = Color.FromArgb(64, 72, 204);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getFetch()
        {
            txtFecha.Text = DateTime.Now.Day.ToString() + " " + DateTime.Now.ToString("MMMM, yyyy");
            txtTime.Text = DateTime.Now.ToString("hh:mm tt"); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getFetch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrosCP.Instancia.MdiParent = this;
            RegistrosCP.Instancia.WindowState = FormWindowState.Maximized;
            RegistrosCP.Instancia.FormBorderStyle = FormBorderStyle.None;
            RegistrosCP.Instancia.Show();
            
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfesorCP.Instancia.MdiParent = this;
            ProfesorCP.Instancia.WindowState = FormWindowState.Maximized;
            ProfesorCP.Instancia.Show();
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstudianteCP.Instancia.MdiParent = this;
            EstudianteCP.Instancia.WindowState = FormWindowState.Maximized;
            EstudianteCP.Instancia.Show();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursoCP.Instancia.MdiParent = this;
            CursoCP.Instancia.WindowState = FormWindowState.Maximized;
            CursoCP.Instancia.Show();
        }

        private void evaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvaluacionCP.Instancia.MdiParent = this;
            EvaluacionCP.Instancia.WindowState = FormWindowState.Maximized;
            EvaluacionCP.Instancia.Show();
        }
    }
}
