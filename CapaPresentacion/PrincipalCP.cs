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
            txtFecha.Text = DateTime.Now.Day.ToString() + " " + DateTime.Now.ToString("MMMM");
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
    }
}
