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
    public partial class frmAsesorExterno : Form
    {
        CEmpresas empresas;
        CAsesores_Externos ae;
        public frmAsesorExterno()
        {
            InitializeComponent();
        }

        private void frmAsesorExterno_Load(object sender, EventArgs e)
        {
            fillDGV();
            fillCBEmpresas();
        }

        private void fillDGV()
        {
            ae = new CAsesores_Externos();
            ae.poblarDataGridAsesoresExternos(DGVAsesores);
            ae = null;
        }

        private void fillCBEmpresas()
        {
            empresas = new CEmpresas();
            cmbEmpresa.DataSource = empresas.consultaTodosEmpresas();
            cmbEmpresa.DisplayMember = "Nombre";
            cmbEmpresa.ValueMember = "IDEmpresa";
            empresas = null;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //public CAsesores_Externos(long IDAsesorExterno, long IDEmpresa, string Nombre, string Cargo, string Departamento, string Correo, string Telefono)
            
            ae = new CAsesores_Externos(0, long.Parse(cmbEmpresa.SelectedValue.ToString()),  txtAsesor.Text, txtCargo.Text, txtDepto.Text, txtCorreo.Text, txtCelular.Text);
            ae.insertaAsesorExterno();
            ae = null;
            fillDGV();
            limpiarTexto();
        }

        private void limpiarTexto()
        {
            txtAsesor.Clear();
            txtCargo.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
            txtDepto.Clear();
            cmbEmpresa.SelectedIndex = 0;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVAsesores_CellContentClick(object sender, DataGridViewCellEventArgs e)//CellClick
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGVAsesores.Rows.Count-1 && DGVAsesores.Rows.Count > 0)
            {
                ae = new CAsesores_Externos();
                ae.getSetIDAsesorExterno = long.Parse(DGVAsesores.Rows[e.RowIndex].Cells[0].Value.ToString());
                ae.eliminaAsesorExterno();
                ae = null;
                fillDGV();
            }
        }
    }
}
