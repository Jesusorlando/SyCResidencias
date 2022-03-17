using SyCResidencias.Clases;
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
    public partial class frmCapturaCandidato : Form
    {
        CAlumno alumno;
        CCiclos ciclos;
        string genero;
        public frmCapturaCandidato()
        {
            InitializeComponent();
        }

        private void frmCapturaCandidato_Load(object sender, EventArgs e)
        {
            alumno = new CAlumno();
            llenarPeriodo();
        }

        private void llenarPeriodo()
        {
            ciclos = new CCiclos();
            cbPeriodo.DataSource = ciclos.consultaTodosCiclos();
            cbPeriodo.DisplayMember = "Descripcion";
            cbPeriodo.ValueMember = "IDCiclo";
        }


        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMuestraCandidatos frmMuestraCandidatos = new frmMuestraCandidatos();
            frmMuestraCandidatos.MdiParent = this.MdiParent;
            frmMuestraCandidatos.Show();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.MdiParent.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNumControl.Text != "")
            {
                alumno = new CAlumno();
                alumno.getSetNumControl = long.Parse(txtNumControl.Text);
                alumno.consultaAlumnoNumControl();
                if (alumno.getSetNombre != null)
                {
                    txtCelular.Text = alumno.getSetCelular;
                    txtCorreo.Text = alumno.getSetCelular;
                    txtDireccion.Text = alumno.getSetDireccion;
                    txtFijo.Text = alumno.getSetTelefono;
                    txtNombre.Text = alumno.getSetNombre;
                    cbCarrera.SelectedValue = int.Parse(alumno.getSetidCarrera);
                    cbPeriodo.SelectedValue = alumno.getSetIdCiclo;
                    if (alumno.getSetGenero == "F") //Es femenino
                    {
                        rbFem.Checked = true;
                    }
                    else
                    {
                        rbMas.Checked = true;
                    }
                } else
                {
                    limpiaCampos();
                }
            } else
            {
                MessageBox.Show("Falta el número de control.");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rbFem.Checked == true)
            {
                genero = "F";
            } else
            {
                genero = "M";
            }
            String nombre = txtNombre.Text, direccion = txtDireccion.Text, correo = txtCorreo.Text, celular = txtCelular.Text, fijo = txtFijo.Text, idCarrera = cbCarrera.SelectedIndex.ToString();
            int idCiclo = (int) cbPeriodo.SelectedValue;
            int numcontrol = Convert.ToInt32(txtNumControl.Text);
            alumno = new CAlumno(numcontrol , nombre, direccion, genero, correo, celular, fijo, idCarrera, idCiclo);
            alumno.insertaAlumno();
            limpiaCampos();
        }

        private void limpiaCampos()
        {
            txtCelular.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtFijo.Clear();
            txtNombre.Clear();
            txtNumControl.Clear();
            if (rbFem.Checked == true) {
                rbFem.Checked = false;
            } else
            {
                rbMas.Checked = false;
            }
            
        }
    }
}
