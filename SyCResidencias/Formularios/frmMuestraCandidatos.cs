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
    public partial class frmMuestraCandidatos : Form
    {
        frmCapturaCandidato frmCapturaCandidato;
        CAlumno alumno;
        public frmMuestraCandidatos()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCapturaCandidato = new frmCapturaCandidato();
            frmCapturaCandidato.MdiParent = this.MdiParent;
            frmCapturaCandidato.Show();
            this.Close();
        }

        private void frmMuestraCandidatos_Load(object sender, EventArgs e)
        {
            alumno = new CAlumno();
            dgvCandidatos.DataSource = alumno.consultaTodosAlumnos();
            
        }
    }
}
