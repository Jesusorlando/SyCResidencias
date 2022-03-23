using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyCResidencias.Clases
{
    class CEmpresas
    {
        private long idEmpresa;
        private string razon;
        private string direccion;
        private string telefono;
        private string contacto;
        private string nombre;

        public CEmpresas()
        {
            idEmpresa = idEmpresa++;
            razon = null;
            direccion = null;
            telefono = null;
            contacto = null;
            nombre = null;
        }

        public CEmpresas(long idEmpresa, string razon, string direccion, string telefono, string contacto, string nombre)
        {
            this.idEmpresa = idEmpresa;
            this.razon = razon;
            this.direccion = direccion;
            this.telefono = telefono;
            this.contacto = contacto;
            this.nombre = nombre;
        }

        //SET GET PROPIEDADES

        public long IdEmpresa
        {
            set { idEmpresa = value; }
            get { return idEmpresa; }
        }
        public string Razon
        {
            set { razon = value; }
            get { return razon; }
        }
        public string Direccion
        {
            set { direccion = value; }
            get { return direccion; }
        }
        public string Telefono
        {
            set { telefono = value; }
            get { return telefono; }
        }
        public string Contacto
        {
            set { contacto = value; }
            get { return contacto; }
        }
        public string Nombre
        {
            set { Nombre= value; }
            get { return Nombre; }
        }


        //Metodos operativos
        //INSERTAR
        public void insertaEmpresas()
        {
            string strSql = null;
            MySQL xCnx = new MySQL();
            try
            {


                //Realiza inserción de datos
                strSql = "INSERT INTO empresas VALUES ('"+ idEmpresa +"', '"+ razon +"', '" +direccion +"', '" + telefono + "', '" + contacto + "');";

                    xCnx.objetoCommand(strSql);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.insertAsesorExterno: " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void actualizaEmpresa()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (idEmpresa != 0)
                {
                    strSql = "UPDATE empresas SET RazonSocial = '" + razon + "', Direccion = '" + direccion + "', Telefono = '" + telefono + "', Contacto = '"+ contacto +"', Nombre = '"+ nombre + "' WHERE IDEmpresa = " + idEmpresa + ";";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CEmpresa.acualizaEmpresa" + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void eliminaEmpresa()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (idEmpresa != 0)
                {
                    strSql = "DELETE FROM empresas WHERE IDEmpresa=" + idEmpresa;
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CEmpresas.EliminaEmpresa: " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public Boolean consultaEmpresaID()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT * FROM empresas where idEmpresa = " + idEmpresa + ";";

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {
                    if (xDT.Rows[0]["IDEmpresa"] == null)
                        idEmpresa = 0;
                    else
                        idEmpresa = Convert.ToInt64(xDT.Rows[0]["IDEmpresa"]);

                    if (xDT.Rows[0]["Nombre"] == null)
                        Nombre = null;
                    else
                        Nombre = xDT.Rows[0]["Nombre"].ToString();

                    if (xDT.Rows[0]["Direccion"] == null)
                        direccion = null; 
                    else
                        direccion = xDT.Rows[0]["Direccion"].ToString();

                    if (xDT.Rows[0]["Telefono"] == null)
                        telefono = null;
                    else
                        telefono = xDT.Rows[0]["Telefono"].ToString();

                    if (xDT.Rows[0]["Contacto"] == null)
                        contacto = null;
                    else
                        contacto = xDT.Rows[0]["Contacto"].ToString();

                    if (xDT.Rows[0]["Nombre"] == null)
                        nombre = null;
                    else
                        nombre = xDT.Rows[0]["Nombre"].ToString();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAsesoresEx.ConsultaAsesoresEx " + ex.ToString());
                return false;
            }
            finally
            {
                xDT = null;
                xCnx = null;
            }
        }

        //Consulta datos de todos los profesores
        public Object consultaTodosEmpresas()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            try
            {
                //Consulta alumnos candidatos con estado 'C'
                strSQL = "SELECT * FROM empresas order by IDEmpresa;";

                return xCnx.objetoDataAdapter(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CEmpresas.ConsultaTodosEmpresas " + ex.ToString());
                return null;
            }
            finally
            {
                xCnx = null;
            }
        }

        public void poblarDataGrideEmpresas(DataGridView DGV)
        {
            //Método que lee todas las materias del origen de datos
            DGV.DataSource = consultaTodosEmpresas();
            DGV.Refresh();
            //Establecer ancho de cada columna del DataGridView
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].Visible = false;

        }

    }
}
