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
    class CAsesores_Externos
    {
        private long _IDAsesorExterno;
        private long _IDEmpresa;
        private string _Nombre;
        private string _Cargo;
        private string _Departamento;
        private string _Correo;
        private string _Telefono;

        public CAsesores_Externos()
        {
            _IDAsesorExterno = 0;
            _IDEmpresa = 0;
            _Nombre = null;
            _Cargo = null;
            _Departamento = null;
            _Correo = null;
            _Telefono = null;
        }

        public CAsesores_Externos(long IDAsesorExterno, long IDEmpresa, string Nombre, string Cargo, string Departamento, string Correo, string Telefono)
        {
            _IDAsesorExterno = IDAsesorExterno;
            _IDEmpresa = IDEmpresa;
            _Nombre = Nombre;
            _Cargo = Cargo;
            _Departamento = Departamento;
            _Correo = Correo;
            _Telefono = Telefono;
        }

        //MÉTODOS PROPERTY
        public long getSetIDAsesorExterno
        {
            get { return _IDAsesorExterno; }
            set { _IDAsesorExterno = value; }
        }

        public long getSetIDEmpresa
        {
            get { return _IDEmpresa; }
            set { _IDEmpresa = value; }
        }

        public string getSetNombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string getSetCargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public string getSetCorreo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }


        public string getSetDepartamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }

        public string getSetTelefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }



        //MÉTODOS OPERATIVOS
        public void insertaAsesorExterno()
        {
            
            string strSql = null;
            MySQL xCnx = new MySQL();
            try
            {
                
                //Realiza inserción de datos
                strSql = "INSERT INTO ASESORES_EXTERNOS (IDEmpresa, Nombre, Cargo, Departamento, correo, telefono) VALUES ( " + _IDEmpresa +", '"+ _Nombre +"', '"+ _Cargo +"', '"+ _Departamento +"', '"+ _Correo +"', '"+ _Telefono +"');";
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

        public void actualizaAsesorExterno()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_IDAsesorExterno != 0)
                {
                    strSql = "UPDATE ASESORES_EXTERNOS SET IDEmpresa = '"+ _IDEmpresa +"', Nombre = '"+ _Nombre + "', Cargo = '"+_Cargo+ "', Departamento = '"+_Departamento+ "', Correo = '"+_Correo+ "', Telefono = '"+_Telefono+"' WHERE IDAsesorEx = '"+ _IDAsesorExterno +"';";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor:actualizaAsesorExterno" + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void eliminaAsesorExterno()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_IDAsesorExterno != 0)
                {
                    strSql = "DELETE FROM ASESORES_EXTERNOS WHERE IDAsesorEx=" + _IDAsesorExterno;
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.eliminaAsesorExterno: " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public Boolean consultaAsesorExtID()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT * FROM asesores_externos where IDAsesorEx = " + _IDAsesorExterno+";";

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {
                    if (xDT.Rows[0]["IDAsesorEx"] == null)
                        _IDAsesorExterno = 0;
                    else
                        _IDAsesorExterno = Convert.ToInt64(xDT.Rows[0]["IDAsesorEx"]);

                    if (xDT.Rows[0]["Nombre"] == null)
                        _Nombre = null;
                    else
                        _Nombre = xDT.Rows[0]["Nombre"].ToString();

                    if (xDT.Rows[0]["IDEmpresa"] == null)
                        _IDEmpresa = 0;
                    else
                        _IDEmpresa = Convert.ToInt64(xDT.Rows[0]["IDEmpresa"]);

                    if (xDT.Rows[0]["Cargo"] == null)
                        _Cargo = null;
                    else
                        _Cargo = xDT.Rows[0]["Cargo"].ToString();

                    if (xDT.Rows[0]["Correo"] == null)
                        _Correo = null;
                    else
                        _Correo = xDT.Rows[0]["Correo"].ToString();

                    if (xDT.Rows[0]["Telefono"] == null)
                        _Telefono = null;
                    else
                        _Telefono = xDT.Rows[0]["Telefono"].ToString();

                    if (xDT.Rows[0]["Departamento"] == null)
                        _Departamento = null;
                    else
                        _Departamento = xDT.Rows[0]["Departamento"].ToString();

                 

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
        public Object consultaTodosAsesoresEx()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            try
            {
                //Consulta alumnos candidatos con estado 'C'
                strSQL = "SELECT ae.IDAsesorEx, ae.Nombre as Nombre_Empresa, ae.Nombre as Nombre_Asesor, ae.Cargo as Cargo, ae.Departamento as Departamento, ae.Correo as Correo, ae.Telefono as Telefono FROM Empresas e, asesores_externos ae WHERE e.IDEmpresa = ae.IDEmpresa;";

                return xCnx.objetoDataAdapter(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAsesores_Externos.ConsultaTodosAsesoresEx " + ex.ToString());
                return null;
            }
            finally
            {
                xCnx = null;
            }
        }

        public void poblarDataGridAsesoresExternos(DataGridView DGV)
        {
            //Método que lee todas las materias del origen de datos
            DGV.DataSource = consultaTodosAsesoresEx();
            DGV.Refresh();
            //Establecer ancho de cada columna del DataGridView
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.Columns[0].Visible = false;
        }


        public DataTable CBAsesoresPorEmpresa()
        {
            MySQL cnx = new MySQL();
            try
            {
                return cnx.objetoDataAdapter("SELECT IDAsesorEx, Nombre FROM asesores_externos WHERE idEmpresa = " + _IDEmpresa + ";");
            } catch (Exception e) { 
                MessageBox.Show("Error en CAsesores_Externos.CBAsesoresPorEmpresas: " + e.Message);
            return null;
            } finally
            {
                cnx = null;
            }

        }

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = CBAsesoresPorEmpresa();

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["Nombre"]));
            }

            return stringCol;
        }
    }
}
