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
    public class CAlumno
    {
        private long _numControl; //Nú. de control
        private string _idCarrera; //ID de carrera que cursa
        private string _nombre; //Nombre completo
        private string _direccion; //Direccion
        private string _correo; //Correo electronico
        private string _celular; //Tel celular
        private string _telefono; //Tel fijo
        private string _genero; //Genero F, M
        private int _idCiclo; //Nú. de control

        public CAlumno()
        {
            _numControl = 0;
            _idCarrera = null;
            _nombre = null;
            _direccion = null;
            _correo = null;
            _celular = null;
            _telefono = null;
            _genero = null;
            _idCiclo = 0;
        }

        public CAlumno(long numCtrl, string nombre, string direccion, string genero, string correo, string celular, string tel, string idcarrera, int idciclo)
        {
            _numControl = numCtrl;
            _idCarrera = idcarrera;
            _nombre = nombre;
            _direccion = direccion;
            _correo = correo;
            _celular = celular;
            _telefono = tel;
            _genero = genero;
            _idCiclo = idciclo;
        }

        //MÉTODOS PROPERTY
        public long getSetNumControl
        {
            get { return _numControl; }
            set { _numControl = value; }
        }

        public string getSetidCarrera
        {
            get { return _idCarrera; }
            set { _idCarrera = value; }
        }
        public string getSetNombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string getSetDireccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        public string getSetGenero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        public string getSetCorreo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public string getSetTelefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string getSetCelular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public int getSetIdCiclo
        {
            get { return _idCiclo; }
            set { _idCiclo = value; }
        }


        //MÉTODOS OPERATIVOS
        public void insertaAlumno()
        {
            string strSql = null;
            MySQL xCnx = new MySQL();
            try
            {
                if (_numControl != 0)
                {
                    //Realiza inserción de datos
                    strSql = "INSERT INTO alumnos (numControl, nombre, direccion, correo, celular, telFijo, genero, IDCarrera, idCiclo) " +
                             "VALUES ('" + _numControl + "','" + _nombre + "','" + _direccion + "','" + _correo + "','" + _celular + "','" + _telefono + "','" + _genero + "','" +
                             _idCarrera + "', " + _idCiclo + ")";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!", "ATENCIÓN");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:insertaAlumno " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void actualizaAlumno()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_numControl != 0)
                {
                    strSql = "UPDATE alumnos SET " +
                        "numControl=" + _numControl + ", " +
                        "idCarrera='" + _idCarrera + "'," +
                        "nombre='" + _nombre + "'," +
                        "direccion='" + _direccion + "'," +
                        "celular='" + _celular + "'," +
                        "correo='" + _correo + "', " +
                        "telFijo='" + _telefono + "', " +
                        "genero='" + _genero + "', " +
                        "idCiclo=" + _idCiclo + " " +
                        "WHERE numControl=" + _numControl;
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:actualizaAlumno " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void eliminaAlumno()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_numControl != 0)
                {
                    strSql = "DELETE FROM alumnos WHERE numControl=" + _numControl;
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:eliminaAlumno " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        


        public Boolean consultaAlumnoNumControl()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT numControl, nombre, direccion, correo, celular, telFijo, genero, idcarrera, idCiclo " +
                 "FROM alumnos " +
                 "WHERE numControl=" + _numControl;

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {
                    if (xDT.Rows[0]["numControl"] == null)
                        _numControl = 0;
                    else
                        _numControl = Convert.ToInt64(xDT.Rows[0]["numControl"]);

                    if (xDT.Rows[0]["idCarrera"] == null)
                        _idCarrera = null;
                    else
                        _idCarrera = xDT.Rows[0]["idCarrera"].ToString();

                    if (xDT.Rows[0]["nombre"] == null)
                        _nombre = null;
                    else
                        _nombre = xDT.Rows[0]["nombre"].ToString();

                    if (xDT.Rows[0]["direccion"] == null)
                        _direccion = null;
                    else
                        _direccion = xDT.Rows[0]["direccion"].ToString();

                    if (xDT.Rows[0]["correo"] == null)
                        _correo = null;
                    else
                        _correo = xDT.Rows[0]["correo"].ToString();

                    if (xDT.Rows[0]["telFijo"] == null)
                        _telefono = null;
                    else
                        _telefono = xDT.Rows[0]["telFijo"].ToString();

                    if (xDT.Rows[0]["celular"] == null)
                        _celular = null;
                    else
                        _celular = xDT.Rows[0]["celular"].ToString();

                    if (xDT.Rows[0]["genero"] == null)
                        _genero = null;
                    else
                        _genero = xDT.Rows[0]["genero"].ToString();

                    if (xDT.Rows[0]["idCiclo"] == null)
                        _idCiclo = 0;
                    else
                        _idCiclo = Convert.ToInt32(xDT.Rows[0]["idCiclo"].ToString());

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:consultaAlumnoNumControl " + ex.ToString());
                return false;
            }
            finally
            {
                xDT = null;
                xCnx = null;
            }
        }

        public Boolean consultaAlumnoNombre()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT numControl, nombre, direccion, correo, celular, telFijo, genero, idcarrera, idCiclo " +
                 "FROM alumnos " +
                 "WHERE nombre='" + _nombre + "'";

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {
                    if (xDT.Rows[0]["numControl"] == null)
                        _numControl = 0;
                    else
                        _numControl = Convert.ToInt64(xDT.Rows[0]["numControl"]);

                    if (xDT.Rows[0]["idCarrera"] == null)
                        _idCarrera = null;
                    else
                        _idCarrera = xDT.Rows[0]["idCarrera"].ToString();

                    if (xDT.Rows[0]["nombre"] == null)
                        _nombre = null;
                    else
                        _nombre = xDT.Rows[0]["nombre"].ToString();

                    if (xDT.Rows[0]["direccion"] == null)
                        _direccion = null;
                    else
                        _direccion = xDT.Rows[0]["direccion"].ToString();

                    if (xDT.Rows[0]["correo"] == null)
                        _correo = null;
                    else
                        _correo = xDT.Rows[0]["correo"].ToString();

                    if (xDT.Rows[0]["telFijo"] == null)
                        _telefono = null;
                    else
                        _telefono = xDT.Rows[0]["telFijo"].ToString();

                    if (xDT.Rows[0]["celular"] == null)
                        _celular = null;
                    else
                        _celular = xDT.Rows[0]["celular"].ToString();

                    if (xDT.Rows[0]["genero"] == null)
                        _genero = null;
                    else
                        _genero = xDT.Rows[0]["genero"].ToString();

                    if (xDT.Rows[0]["idCiclo"] == null)
                        _idCiclo = 0;
                    else
                        _idCiclo = Convert.ToInt32(xDT.Rows[0]["idCiclo"].ToString());

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:consultaAlumnoNombre " + ex.ToString());
                return false;
            }
            finally
            {
                xDT = null;
                xCnx = null;
            }
        }


        //Consulta datos de todos los alumnos
        public Object consultaTodosAlumnos()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            try
            {
                //Consulta alumnos candidatos con estado 'C'
                strSQL = "SELECT a.NumControl, ce.Descripcion, a.Nombre, a.Correo, a.Celular, a.Genero, "+
"CASE " +
"WHEN a.IDCarrera = 0 THEN 'ISC' " +
"WHEN a.IDCarrera = 1 THEN 'IGE' " +
"WHEN a.IDCarrera = 2 THEN 'IME' " +
"WHEN a.IDCarrera = 3 THEN 'IM' " +
"WHEN a.IDCarrera = 4 THEN 'IEE' " +
"WHEN a.IDCarrera = 5 THEN 'IE' " +
"WHEN a.IDCarrera = 6 THEN 'II'  END AS Carrera, " +
"a.Direccion, a.TelFijo " +
"from alumnos as a, ciclos_escolares as ce " +
"WHERE ce.IDCiclo = a.IDCiclo; ";

                return xCnx.objetoDataAdapter(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:consultaTodoAlumnos " + ex.ToString());
                return null;
            }
            finally
            {
                xCnx = null;
            }
        }

        public void poblarDataGridCandidatos(DataGridView DGV)
        {
            //Método que lee todas las materias del origen de datos
            DGV.DataSource = consultaTodosAlumnos();
            DGV.Refresh();
            //Establecer ancho de cada columna del DataGridView
            DGV.Columns[0].Width = 90;
            DGV.Columns["NumControl"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //            DGV.Columns["NumControl"].DefaultCellStyle.Format = "###,###,###";
            DGV.Columns["Carrera"].Width = 90;
            DGV.Columns["Carrera"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Nombre"].Width = 180;
            DGV.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Direccion"].Width = 180;
            DGV.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Correo"].Width = 180;
            DGV.Columns["Correo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Celular"].Width = 90;
            DGV.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Telefono"].Width = 90;
            DGV.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Genero"].Width = 90;
            DGV.Columns["Genero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns["Ciclo"].Width = 90;
            DGV.Columns["Ciclo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        public Object consultaCandidatosEmpresas()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            try
            {
                strSQL = "SELECT R.NumControl, A.Nombre, A.idCarrera, R.proyecto, E.nombre " +
                    "FROM Residencias R, Alumnos A, Asesores_externos AE, Empresas E " +
                    "WHERE R.numControl=A.numControl AND R.idAsesorE=AE.idAsesorE AND AE.idEmpresa=E.idEmpresa " +
                    "ORDER BY A.nombre";

                return xCnx.objetoDataAdapter(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:consultaCandidatosEmpresas " + ex.ToString());
                return null;
            }
            finally
            {
                xCnx = null;
            }
        }

        //Consultar alumnos candidatos del departamento y de las n carreras que tenga el departamento
        public void cargarDataGridCandidatos(DataGridView dgv)
        {
            OdbcConnection con = new OdbcConnection("DRIVER={MySQL ODBC 5.1 Driver}; SERVER=127.0.0.1; DATABASE=SAUA; UID=root; PWD=mejiko");
            OdbcCommand comando = new OdbcCommand();
            OdbcDataReader dr;
           
            try
            {
                //con.ConnectionString = Funciones.MisFunciones.conexionMySQL(); ;
                comando.Connection = con;
                comando.CommandText = "SELECT NumControl, Nombre, direccion, idCarrera AS Carrera, Genero, Correo, celular, telFijo, C.descripcion " +
                    "FROM alumnos A, ciclos_escolares c WHERE A.idCiclo=C.idCiclo ORDER BY numControl";
                comando.CommandType = CommandType.Text;
                con.Open();
                dgv.Rows.Clear();
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dgv.Rows.Add();

                    dgv.Rows[renglon].Cells["NumControl"].Value = dr.GetInt64(dr.GetOrdinal("numControl")).ToString();
                    //dgv.Columns["NumControl"].Width = 30;

                    if (dr.IsDBNull(dr.GetOrdinal("Nombre")))
                        dgv.Rows[renglon].Cells["Nombre"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Nombre"].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                    //dgv.Columns["Nombre"].Width = 200;

                    if (dr.IsDBNull(dr.GetOrdinal("direccion")))
                        dgv.Rows[renglon].Cells["direccion"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["direccion"].Value = dr.GetString(dr.GetOrdinal("direccion"));
                    //dgv.Columns["Nombre"].Width = 200;

                    if (dr.IsDBNull(dr.GetOrdinal("Carrera")))
                        dgv.Rows[renglon].Cells["Carrera"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Carrera"].Value = dr.GetString(dr.GetOrdinal("Carrera"));
                    //dgv.Columns["Carrera"].Width = 80;

                    if (dr.IsDBNull(dr.GetOrdinal("Genero")))
                        dgv.Rows[renglon].Cells["Genero"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Genero"].Value = dr.GetString(dr.GetOrdinal("Genero"));
                    //dgv.Columns["Genero"].Width = 70;

                    if (dr.IsDBNull(dr.GetOrdinal("Correo")))
                        dgv.Rows[renglon].Cells["Correo"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Correo"].Value = dr.GetString(dr.GetOrdinal("Correo"));
                    //dgv.Columns["Correo"].Width = 200;

                    if (dr.IsDBNull(dr.GetOrdinal("TelFijo")))
                        dgv.Rows[renglon].Cells["TelFijo"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["TelFijo"].Value = dr.GetString(dr.GetOrdinal("TelFijo"));
                    //dgv.Columns["TelFijo"].Width = 200;

                    if (dr.IsDBNull(dr.GetOrdinal("celular")))
                        dgv.Rows[renglon].Cells["Celular"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Celular"].Value = dr.GetString(dr.GetOrdinal("celular"));
                    //dgv.Columns["TelFijo"].Width = 200;

                    if (dr.IsDBNull(dr.GetOrdinal("descripcion")))
                        dgv.Rows[renglon].Cells["PeriodoEscolar"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["PeriodoEscolar"].Value = dr.GetString(dr.GetOrdinal("descripcion"));
                    //dgv.Columns["TelFijo"].Width = 200;


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:cargarDataGridCandidatos " + ex.ToString());
            }
            finally
            {
                con = null;
                comando = null;
                dr = null;
            }
        }

        //Consulta alumnos del departamento con estado C)andidatos y proyecto/empresa registrados pero SIN asesor interno
        public void cargarDataGridCandidatosEmpresas(DataGridView dgv)
        {
            OdbcConnection con = new OdbcConnection("DRIVER={MySQL ODBC 5.1 Driver}; SERVER=127.0.0.1; DATABASE=SAUA; UID=root; PWD=mejiko");
            OdbcCommand comando = new OdbcCommand();
            OdbcDataReader dr;
           
            try
            {
                comando.Connection = con;
                //Alumnos residentes sin asesor interno y con proyecto registrado
                comando.CommandText = "SELECT R.NumControl, A.Nombre AS Alumno, A.idCarrera, CE.descripcion, A.correo, proyecto, E.nombre AS Empresa " +
                      "FROM Residencias R, Alumnos A, Estatus_Residencia ER, ciclos_escolares CE, Asesores_externos AE, Empresas E " +
                      "WHERE R.numControl=A.numControl AND R.idEstatus=ER.idEstatus AND A.idCiclo=CE.idCiclo AND " +
                      "R.idAsesorE=AE.idAsesorE AND AE.idEmpresa=E.idEmpresa AND " +
                      "ER.descripcion='ANTEPROYECTO' " +
                      "ORDER BY A.nombre";
                comando.CommandType = CommandType.Text;
                con.Open();
                dgv.Rows.Clear();
                dr = comando.ExecuteReader();
                //el ciclo while se ejecutará mientras lea registros en la tabla
                while (dr.Read())
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dgv.Rows.Add();

                    dgv.Rows[renglon].Cells["NumControl"].Value = dr.GetInt64(dr.GetOrdinal("numControl")).ToString();

                    if (dr.IsDBNull(dr.GetOrdinal("Alumno")))
                        dgv.Rows[renglon].Cells["Alumno"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Alumno"].Value = dr.GetString(dr.GetOrdinal("Alumno"));

                    if (dr.IsDBNull(dr.GetOrdinal("idCarrera")))
                        dgv.Rows[renglon].Cells["Carrera"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Carrera"].Value = dr.GetString(dr.GetOrdinal("idCarrera"));

                    if (dr.IsDBNull(dr.GetOrdinal("descripcion")))
                        dgv.Rows[renglon].Cells["descripcion"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["descripcion"].Value = dr.GetString(dr.GetOrdinal("descripcion"));

                    if (dr.IsDBNull(dr.GetOrdinal("correo")))
                        dgv.Rows[renglon].Cells["mail"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["mail"].Value = dr.GetString(dr.GetOrdinal("correo"));

                    if (dr.IsDBNull(dr.GetOrdinal("Proyecto")))
                        dgv.Rows[renglon].Cells["Proyecto"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Proyecto"].Value = dr.GetString(dr.GetOrdinal("Proyecto"));

                    if (dr.IsDBNull(dr.GetOrdinal("Empresa")))
                        dgv.Rows[renglon].Cells["Empresa"].Value = "";
                    else
                        dgv.Rows[renglon].Cells["Empresa"].Value = dr.GetString(dr.GetOrdinal("Empresa"));
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CAlumno:cargarDataGridCandidatosEmpresas " + ex.ToString());
            }
            finally
            {
                con = null;
                comando = null;
                dr = null;
            }
        }
    }

}
