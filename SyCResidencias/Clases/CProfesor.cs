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
    public class CProfesor
    {
        private long _idProfesor; 
        private string _CURP; 
        private string _RFC; 
        private string _nombre; 
        private string _correo; 
        private string _celular; 
        private string _usuario; 
        private string _contraseña;

        public CProfesor()
        {
            _idProfesor = 0;
            _CURP = null;
            _RFC = null;
            _nombre = null;
            _correo = null;
            _celular = null;
            _usuario = null;
            _contraseña = null;
        }

        public CProfesor(long idProfesor, string CURP, string RFC, string nombre, string correo, string celular, string usuario, string contraseña)
        {
            _idProfesor = idProfesor;
            _CURP = CURP;
            _RFC = RFC;
            _nombre = nombre;
            _correo = correo;
            _celular = celular;
            _usuario = usuario;
            _contraseña = contraseña;
        }

        //MÉTODOS PROPERTY
        public long getSetNumControl
        {
            get { return _idProfesor; }
            set { _idProfesor = value; }
        }

        public string getSetUsuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string getSetCURP
        {
            get { return _CURP; }
            set { _CURP = value; }
        }
        public string getSetNombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string getSetCorreo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        
        
        public string getSetCelular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public string getSetContraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public string getSetRFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }



        //MÉTODOS OPERATIVOS
        public void insertaProfesor()
        {
            string strSql = null;
            MySQL xCnx = new MySQL();
            try
            {
                if (_idProfesor != 0)
                {
                    //Realiza inserción de datos
                    strSql = "INSERT INTO profesores VALUES (DEFAULT, '" + _CURP + "', '" + _RFC + "', '" + _nombre + "', " +
                        "'" + _correo + "', '" + _celular + "', '" + _usuario + "', '" + _contraseña + "');";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!", "ATENCIÓN");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.insertProfesor: " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void actualizaProfesor()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_idProfesor != 0)
                {
                    strSql = "UPDATE profesores SET CURP = '"+ _CURP +"', RFC = '"+ _RFC +"', Nombre = '"+ _nombre + "', Correo = '" + _correo + "', " +
                        "Celular = '" + _celular + "', Usuario = ' " + _usuario + " ', Contrasenia = '" + _contraseña +  "' WHERE IDProfesor = '1';";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor:actualizaProfesor " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void eliminaProfesor()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_idProfesor != 0)
                {
                    strSql = "DELETE FROM profesores WHERE IDProfesor=" + _idProfesor;
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan número de control!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.eliminaProfesor: " + ex.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public Boolean consultaProfesorID()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT * FROM profesores where idProfesor = " + _idProfesor +";";

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {
                    if (xDT.Rows[0]["IDProfesor"] == null)
                        _idProfesor = 0;
                    else
                        _idProfesor = Convert.ToInt64(xDT.Rows[0]["IDProfesor"]);

                    if (xDT.Rows[0]["CURP"] == null)
                        _CURP = null;
                    else
                        _CURP = xDT.Rows[0]["CURP"].ToString();

                    if (xDT.Rows[0]["RFC"] == null)
                        _RFC = null;
                    else
                        _RFC = xDT.Rows[0]["RFC"].ToString();

                    if (xDT.Rows[0]["Nombre"] == null)
                        _nombre = null;
                    else
                        _nombre = xDT.Rows[0]["Nombre"].ToString();

                    if (xDT.Rows[0]["Correo"] == null)
                        _correo = null;
                    else
                        _correo = xDT.Rows[0]["Correo"].ToString();

                    if (xDT.Rows[0]["Celular"] == null)
                        _celular = null;
                    else
                        _celular = xDT.Rows[0]["Celular"].ToString();

                    if (xDT.Rows[0]["Usuario"] == null)
                        _usuario = null;
                    else
                        _usuario = xDT.Rows[0]["Usuario"].ToString();

                    if (xDT.Rows[0]["Contrasenia"] == null)
                        _contraseña = null;
                    else
                        _contraseña = xDT.Rows[0]["Contrasenia"].ToString();
 
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.ConsultaProfesorId " + ex.ToString());
                return false;
            }
            finally
            {
                xDT = null;
                xCnx = null;
            }
        }

        //Consulta datos de todos los profesores
        public Object consultaTodosProfesores()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            try
            {
                //Consulta alumnos candidatos con estado 'C'
                strSQL = "SELECT * FROM profesores order by idProfesor;";

                return xCnx.objetoDataAdapter(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CProfesor.ConsultaTodosProfesores " + ex.ToString());
                return null;
            }
            finally
            {
                xCnx = null;
            }
        }

        public void poblarDataGridProfesores(DataGridView DGV)
        {
            //Método que lee todas las materias del origen de datos
            DGV.DataSource = consultaTodosProfesores();
            DGV.Refresh();
            //Establecer ancho de cada columna del DataGridView
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

    }
}

