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
    public partial class frmCapturaEmpresa : Form
    {
        CEmpresas empresas;
        private long idEmpresa;
        private string razon;
        private string direccion;
        private string telefono;
        private string contacto;
        private string nombre;

        public frmCapturaEmpresa()
        {
            InitializeComponent();
            
        }

        private void frmCapturaEmpresa_Load(object sender, EventArgs e)
        {
            cargaDGV();
        }

        private void cargaDGV()
        {
            empresas = new CEmpresas();
            empresas.poblarDataGrideEmpresas(dgvEmpresas);
            empresas = null;
        }

        private void limpiaDatos()
        {
            txtContacto.Clear();
            txtDireccion.Clear();
            txtEmpresa.Clear();
            txtRazon.Clear();
            txtTel.Clear();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idEmpresa = -1;
            razon = txtRazon.Text;
            direccion = txtDireccion.Text;
            telefono = txtTel.Text;
            contacto = txtContacto.Text;
            nombre = txtEmpresa.Text;
            empresas = new CEmpresas(idEmpresa, razon, direccion, telefono, contacto, nombre);
            empresas.insertaEmpresas();
            empresas = null;
            cargaDGV();
            limpiaDatos();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpresas.Rows.Count>0 && e.RowIndex>=0 && e.RowIndex < dgvEmpresas.Rows.Count)
            {
                empresas = new CEmpresas();
                empresas.IdEmpresa = long.Parse(dgvEmpresas.Rows[e.RowIndex].Cells[0].Value.ToString());
                empresas.eliminaEmpresa();
                empresas = null;
                cargaDGV();
            }
        }
    }
}
