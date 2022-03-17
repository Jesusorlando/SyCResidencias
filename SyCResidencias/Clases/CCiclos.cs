using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SyCResidencias.Clases
{
    class CCiclos
    {
        private string descripcion;
        private long idCiclo;

        public CCiclos()
        {
            descripcion = null;
            idCiclo = 0;
        }

        public CCiclos(string descripcion, long idCiclo)
        {
            this.descripcion = descripcion;
            this.idCiclo = idCiclo;
        }

        //MÉTODOS PROPERTY
        public long getSetidCiclo
        {
            get { return idCiclo; }
            set { idCiclo = value; }
        }

        public string getSetDescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        //Métodos operativos ps
        public void buscaCicloPorID()
        {
            MySQL cnx = new MySQL();
            OdbcDataReader ciclos;
            try
            {
                   ciclos = cnx.objetoDataReader("SELECT * FROM ciclos_escolares WHERE IDCiclo = "+ idCiclo +";");
                if (ciclos.HasRows)
                {
                    ciclos.Read();
                    descripcion = ciclos.GetString(1);
                } else
                {
                    descripcion = "Error";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("CCiclos.consultaCicloPorID " + e.Message);
            }
            finally
            {
                cnx = null;
                ciclos = null;
            }
        }


        public void agregarCiclo()
        {
            MySQL cnx = new MySQL();

            try
            {
                cnx.objetoCommand("INSERT INTO ciclos_escolares VALUES (Default, '" + descripcion + "')");
                cnx = null;
            }
            catch (Exception e)
            {
               MessageBox.Show("CCiclos.agregarCiclo " + e.Message);
            }
            finally
            {
                cnx = null;
            }
        }

        public object consultaTodosCiclos ()
        {
            MySQL cnx = new MySQL();
            try
            {
               return cnx.objetoDataAdapter("SELECT * FROM ciclos_escolares;");

            }catch (Exception e)
            {
                MessageBox.Show("CCiclos.consultaTodosCiclos "+ e.Message);
                return null;
            }
            finally
            {
                cnx = null;

            }

        }

        public Boolean insertaCiclo()
        {
            MySQL cnx = new MySQL();
            try
            {
                cnx.objetoCommand("INSERT INTO ciclos_escolares VALUES (default, '"+ descripcion +"')");
                return true;
            } catch (Exception e)
            {
                MessageBox.Show("CCiclos.insertaCiclo "+ e.Message);
                return false;
            }
            finally
            {
                cnx = null;
            }
        }
    }
}
