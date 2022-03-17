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
    public partial class frmLogin : Form
    {

        CLoginUsuarios log;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e) 
        {
            if (log.LogUsuario(txtUsuario.Text, txtPassword.Text)) //log.LogUsuario(txtUsuario.Text, txtPassword.Text)
            {
                this.Hide();
                txtPassword.Clear();
                txtUsuario.Clear();
                frmMENU frmMENU = new frmMENU(log.idProfesor, this);
                frmMENU.Show();
            } else
            {
                MessageBox.Show("La contraseña o el usuario no coinciden.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            log = new CLoginUsuarios();
        }
    }
}
