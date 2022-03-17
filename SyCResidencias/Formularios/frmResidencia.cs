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
    public partial class frmResidencia : Form
    {
        CResidencias cresi;
        CAsesores_Externos cAsesor;
        CEmpresas cempresa;
        CEstatus cEstat;
        CAlumno cAlumno;
        CCiclos ciclo;
        long idProfesor;
        public frmResidencia(long idProfesor)
        {
            InitializeComponent();
            this.idProfesor = idProfesor;
        }

        public frmResidencia()
        {
            InitializeComponent();
        }

        private void btnNuevoAsesorExt_Click(object sender, EventArgs e)
        {
            frmAsesorExterno frmAsesorExterno = new Formularios.frmAsesorExterno();
            frmAsesorExterno.MdiParent = this.MdiParent;
            frmAsesorExterno.Show();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResidentes frmRes = new frmResidentes();
            frmRes.MdiParent = this.MdiParent;
            frmRes.Show();
            this.Close();

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertaResidencia();
        }

        private void InsertaResidencia()
        {
//public CResidencias(long NumControl, long IDAsesorEx, String proyecto, long IDEstatus, long IDProfesor, String fechaInicio, String fechaTermino)
            //PENDIENTE PREGUNTAR COMO RECOGER EL IDPROFESOR DESDE EL LOGIN
            cresi = new CResidencias(long.Parse(txtNumControl.Text), long.Parse(cmbAsesorExterno.SelectedValue.ToString()), txtProyecto.Text, long.Parse(cmbEstatus.SelectedValue.ToString()), 0, dtpInicio.Value.ToString("yyyy-MM-dd"), dtpTermino.Value.ToString("yyyy-MM-dd"));
            cresi.InsertaResidencia();
            cresi = null;
            limpiaTodo();
        }

        private void limpiaTodo()
        {
            txtAlumno.Clear();
            txtCargo.Clear();
            txtCarrera.Clear();
            txtCiclo.Clear();
            txtCorreo.Clear();
            txtDepto.Clear();
            txtNumControl.Clear();
            txtProyecto.Clear();
            txtTelFijo.Clear();
            dtpInicio.Value = DateTime.Today;
            dtpTermino.Value = DateTime.Today;
            cmbEmpresa.SelectedIndex = -1;
            cmbAsesorExterno.SelectedIndex = -1;
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            frmCapturaEmpresa frmEmpresa = new frmCapturaEmpresa();
            frmEmpresa.MdiParent = this.MdiParent;
            frmEmpresa.Show();
        }

        private void frmResidencia_Load(object sender, EventArgs e)
        {
            fillCBEmpresa();
            fillCBEstatus();
            cmbAsesorExterno.SelectedIndex = -1;
            cmbAsesorExterno.Text = "";
        }

        private void fillCBEmpresa()
        {
            cempresa = new CEmpresas();
            cmbEmpresa.DataSource = cempresa.consultaTodosEmpresas();
            cmbEmpresa.ValueMember = "IDEmpresa";
            cmbEmpresa.DisplayMember = "Nombre";
            cempresa = null;
            cmbEmpresa.SelectedIndex = -1;
        }

        private void fillCBAsesoresExternos()
        {
            
            cAsesor = new CAsesores_Externos();
            DataRowView drv = (DataRowView)cmbEmpresa.SelectedItem;
            int idEmpresa = (int)drv.Row.ItemArray[0];
            cAsesor.getSetIDEmpresa = idEmpresa;
            cmbAsesorExterno.DataSource  = cAsesor.CBAsesoresPorEmpresa();
            cmbAsesorExterno.DisplayMember = "Nombre";
            cmbAsesorExterno.ValueMember = "IDAsesorEx";
            cmbAsesorExterno.AutoCompleteCustomSource = cAsesor.LoadAutoComplete();
            cmbAsesorExterno.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbAsesorExterno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cAsesor = null;
            if (cmbAsesorExterno.Items.Count == 0 || cmbEmpresa.SelectedIndex == -1)
            {
                cmbAsesorExterno.DataSource = null;
                cmbAsesorExterno.AutoCompleteMode = AutoCompleteMode.None;
                cmbAsesorExterno.Items.Clear();
                cmbAsesorExterno.Text = "";
                cmbAsesorExterno.SelectedIndex = -1;
                txtCargo.Clear();
                txtCorreo.Clear();
                txtDepto.Clear();
                txtTelFijo.Clear();
            }
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex != -1)
            fillCBAsesoresExternos();
        }

        private void fillCBEstatus ()
        {
            cEstat = new CEstatus();
            cmbEstatus.DataSource = cEstat.CBEstatus();
            cmbEstatus.DisplayMember = "Descripcion";
            cmbEstatus.ValueMember = "IDEstatus";
            cEstat = null;
        }

        private void cmbAsesorExterno_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDatosDeAsesor();
        }

        private void llenarDatosDeAsesor()
        {
            if (cmbAsesorExterno.Items.Count != 0 && cmbAsesorExterno.SelectedIndex != -1)
            {
                DataRowView drv = (DataRowView)cmbAsesorExterno.SelectedItem;
                int idAsesorExterno = (int)drv.Row.ItemArray[0];
                if (idAsesorExterno != 0)
                {
                    cAsesor = new CAsesores_Externos();
                    cAsesor.getSetIDAsesorExterno = idAsesorExterno;
                    cAsesor.consultaAsesorExtID();
                    txtCargo.Text = cAsesor.getSetCargo;
                    txtCorreo.Text = cAsesor.getSetCorreo;
                    txtDepto.Text = cAsesor.getSetDepartamento;
                    txtTelFijo.Text = cAsesor.getSetTelefono;
                }
                else
                {
                    limpiaAsesor();
                }
            } else
            {
                limpiaAsesor();
            }
        }

        private void limpiaAsesor ()
        {
            txtCargo.Clear();
            txtCorreo.Clear();
            txtDepto.Clear();
            txtTelFijo.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNumControl.Text != String.Empty)
                llenarDatosAlumno();
            else
                MessageBox.Show("Ingrese el número de control.");
        }

        private void llenarDatosAlumno()
        {
            cresi = new CResidencias();
            cAlumno = new CAlumno();
            cAlumno.getSetNumControl = long.Parse(txtNumControl.Text);
            cAlumno.consultaAlumnoNumControl();
            txtAlumno.Text = cAlumno.getSetNombre;
            String carrera="";
            switch (cAlumno.getSetidCarrera)
            {
                case "0":
                    carrera = "ISC";
                    break;
                case "1":
                    carrera = "IGE";
                    break;
                case "2":
                    carrera = "IME";
                    break;
                case "3":
                    carrera = "IM";
                    break;
                case "4":
                    carrera = "IEE";
                    break;
                case "5":
                    carrera = "IE";
                    break;
                case "6":
                    carrera = "II";
                    break;
            }
            txtCarrera.Text = carrera;
            ciclo = new CCiclos();
            ciclo.getSetidCiclo = cAlumno.getSetIdCiclo;
            ciclo.buscaCicloPorID();
            txtCiclo.Text = ciclo.getSetDescripcion;
            ciclo = null;
            cresi.NumControl = long.Parse(txtNumControl.Text);
            if (cresi.alumnoTieneResidencia()) //Ya está registrado y haciendo una residencia
            {
                cresi.MuestraPorID();
                //Muestra datos del asesor y su empresa
                cAsesor = new CAsesores_Externos();
                cAsesor.getSetIDAsesorExterno = cresi.IDAsesorEx;
                cAsesor.consultaAsesorExtID();
                int idAsesorEx = (int)cAsesor.getSetIDAsesorExterno;
                cmbEmpresa.SelectedValue = (int)cAsesor.getSetIDEmpresa;
                fillCBAsesoresExternos();
                cmbAsesorExterno.SelectedValue = idAsesorEx;
                //Datos del proyecto y residencia
                dtpInicio.Value = DateTime.Parse(cresi.fechaInicio);
                dtpTermino.Value = DateTime.Parse(cresi.fechaTermino);
                txtProyecto.Text = cresi.proyecto;
                cmbEstatus.SelectedValue = (int)cresi.IDEstatus;
            } else
            {
                limpiaTodoMAlumno();
            }
        }
        private void limpiaTodoMAlumno()
        {
            txtCargo.Clear();
            txtCorreo.Clear();
            txtDepto.Clear();
            txtProyecto.Clear();
            txtTelFijo.Clear();
            dtpInicio.Value = DateTime.Today;
            dtpTermino.Value = DateTime.Today;
        }
    }   
}
