using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyCResidencias.Clases
{
    class CEstatus
    {
        private string descripcion;
        private long idEstatus;

        public CEstatus()
        {
            descripcion = null;
            idEstatus = 0;
        }

        public CEstatus(string descripcion, long idEstatus)
        {
            this.descripcion = descripcion;
            this.idEstatus = idEstatus;
        }

        //MÉTODOS PROPERTY
        public long getSetidEstatus
        {
            get { return idEstatus; }
            set { idEstatus = value; }
        }

        public string getSetDescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        //Métodos operativos ps

        public void agregarEstatus()
        {

        }

        public Object CBEstatus()
        {
            MySQL cnx = new MySQL();
            try
            {
                return cnx.objetoDataAdapter("SELECT * FROM estatus_residencias; ");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en CEstatus.CBEstatus: " + e.Message);
                cnx = null;
                return null;
            }

        }
    }
}
