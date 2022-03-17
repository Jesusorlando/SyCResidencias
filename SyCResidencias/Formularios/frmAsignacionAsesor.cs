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
    public partial class frmAsignacionAsesor : Form
    {
        CResidencias cResidencia;
        CEstatus cEstatus;
        CProfesor cProfesor;
        CAlumno cAlumno;
        string CURP = "", profesor = "", alumno = "", estatus = "";
        long idProfesor = 0, idAlumno = 0;


        public frmAsignacionAsesor()
        {
            InitializeComponent();
        }

        private void frmAsignacionAsesor_Load(object sender, EventArgs e)
        {
            fillCBEstatus();
            fillDGVProfesores();
            fillDGVResidencias();
        }

        private void fillDGVResidencias()
        {
            cResidencia = new CResidencias();
            cResidencia.PoblarDGVResidencias(DGVResidencias);
        }

        private void fillDGVProfesores()
        {
            cProfesor = new CProfesor();
            DGVProfesores.DataSource = cProfesor.consultaTodosProfesores();
            DGVProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            txtAlumno.Text = alumno;
            txtControl.Text = idAlumno.ToString();
            cmbEstatus.SelectedIndex = cmbEstatus.FindString(estatus);
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cResidencia = new CResidencias();
            cResidencia.NumControl = idAlumno;
            cResidencia.IDProfesor = idProfesor;
            cResidencia.asignaAsesorInterno();
            fillDGVResidencias();
            limpiaTodo();

        }

        private void limpiaTodo()
        {
            txtAlumno.Clear();
            txtControl.Clear();
            txtCurp.Clear();
            txtNumResidentes.Clear();
            txtProfesor.Clear();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e) //Profesor
        {
            txtProfesor.Text = profesor;
            txtCurp.Text = CURP;
            txtNumResidentes.Text = "0";
        }

        private void fillCBEstatus()
        {
            cEstatus = new CEstatus();
            cmbEstatus.DataSource = cEstatus.CBEstatus();
            cmbEstatus.DisplayMember = "Descripcion";
            cmbEstatus.ValueMember = "IDEstatus";
            //cmbEstatus.SelectedValue = -1;
            //cmbEstatus.Enabled = false;
            
        }

        private void DGVResidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVResidencias.RowCount)
            {
                idAlumno = long.Parse(DGVResidencias.Rows[e.RowIndex].Cells[0].Value.ToString());
                alumno = DGVResidencias.Rows[e.RowIndex].Cells[1].Value.ToString();
                estatus = DGVResidencias.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void DGVProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && e.RowIndex < DGVProfesores.RowCount)
            {
                idProfesor = long.Parse(DGVProfesores.Rows[e.RowIndex].Cells[0].Value.ToString());
                CURP = DGVProfesores.Rows[e.RowIndex].Cells[1].Value.ToString();
                profesor = DGVProfesores.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
