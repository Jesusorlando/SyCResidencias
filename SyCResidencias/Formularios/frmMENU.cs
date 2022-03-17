using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyCResidencias.Formularios
{
    public partial class frmMENU : Form
    {
        long idProfesor;

        

        frmCapturaCandidato frmCapturaCandidato;
        frmCapturaEmpresa frmCapturaEmpresa;
        frmAsesorExterno frmAe;
        frmResidencia frmResidencia;
        frmAsignacionAsesor frmAsigna;
        frmLogin log;
        public frmMENU(long idProfesor, frmLogin log)
        {
            InitializeComponent();
            this.idProfesor = idProfesor;
            this.log = log;
        }

        private void frmMENU_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void candidatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapturaCandidato = new frmCapturaCandidato();
            frmCapturaCandidato.MdiParent = this;
            frmCapturaCandidato.Show();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapturaEmpresa = new frmCapturaEmpresa();
            frmCapturaEmpresa.MdiParent = this;
            frmCapturaEmpresa.Show();
        }

        private void asesoresExternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAe = new frmAsesorExterno();
            frmAe.MdiParent = this;
            frmAe.Show();
        }

        private void residentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResidencia = new frmResidencia(idProfesor);
            frmResidencia.MdiParent = this;
            frmResidencia.Show();
        }

        private void asignarAsesorInternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsigna = new frmAsignacionAsesor();
            frmAsigna.MdiParent = this;
            frmAsigna.Show();
        }
        string hora;
        string fecha;
        private void timer1_Tick(object sender, EventArgs e)
        {
            hora = "Hora del Sistema: " + DateTime.Now.ToString("hh:mm:ss");
            fecha = "Fecha del Sistema: " + DateTime.Now.ToString("dd-MM-yyyy");
            statusStrip1.Items[1].Text = hora;
            statusStrip1.Items[2].Text = fecha;
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            log.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alumno Jesús Orlando Alvarado Perez");
        }
    }
}
