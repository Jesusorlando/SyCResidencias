using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyCResidencias.Clases;
namespace SyCResidencias.Formularios
{
    public partial class frmResidentes : Form
    {
        CResidencias cr;

        public frmResidentes()
        {
            InitializeComponent();
        }

        private void frmResidentes_Load(object sender, EventArgs e)
        {
            fillDGV();
        }

        private void fillDGV()
        {
            cr = new CResidencias();
            cr.PoblarDGVResidencias(dgvResidentes);
            cr = null;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResidencia frmRes = new frmResidencia();
            frmRes.MdiParent = this.MdiParent;
            this.Close();
            frmRes.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
