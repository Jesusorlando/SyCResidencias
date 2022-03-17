using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyCResidencias.Clases;
using System.Windows.Forms;
using System.Data.Odbc;

namespace SyCResidencias.Clases
{
    class CResidencias
    {
        MySQL cnx;

        public long NumControl { get; set; }
        public long IDAsesorEx { get; set; }
        public String proyecto { get; set; }
        public long IDEstatus { get; set; }
        public long IDProfesor { get; set; }
        public String fechaInicio { get; set; }
        public String fechaTermino { get; set; }
        public String ConstanciaInicio { get; set; }
        public String CandidatoTitulacion { get; set; }

        public CResidencias()
        {

        }

        public CResidencias(long NumControl, long IDAsesorEx, String proyecto, long IDEstatus, long IDProfesor, String fechaInicio, String fechaTermino)
        {
            this.NumControl = NumControl;
            this.IDAsesorEx = IDAsesorEx;
            this.proyecto = proyecto;
            this.IDEstatus = IDEstatus;
            this.IDProfesor = IDProfesor;
            this.fechaInicio = fechaInicio;
            this.fechaTermino = fechaTermino;
        }

        //Metodos operativos

            //UPDATE asesor interno

            public void asignaAsesorInterno()
        {
            try
            {
                cnx = new MySQL();
                cnx.objetoCommand("UPDATE residencias SET IDProfesor = "+ IDProfesor + " WHERE NumControl = " + NumControl + ";");
            } catch (Exception e)
            {
                MessageBox.Show("CResidencias.asingaAsesorInterno " + e.Message);
            }
        }


        //INSERT

        public void InsertaResidencia ()
        {
            try
            {
                cnx = new MySQL();
                cnx.objetoCommand("INSERT INTO residencias (NumControl, IDAsesorEx, Proyecto, IDEstatus, IDProfesor, FechaInicio, FechaTermino) VALUES (" + NumControl + ", " + IDAsesorEx + ", '" + proyecto + "', " + IDEstatus + ", " + IDProfesor + ", '" + fechaInicio + "', '" + fechaTermino + "');");
            } catch (Exception e)
            {
                if (e.HResult == -2146233088)
                    MessageBox.Show("El alumno ya tiene un proyecto de residencia registrado." + e.Message);
                else
                    MessageBox.Show("Error en CResidencias.InsertaResidencia: "+e.Message);

            } finally
            {
                cnx = null;
            }
        }

        //DELETE

        public void BorraResidencia()
        {
            try
            {
                cnx = new MySQL();
                cnx.objetoCommand("DELETE FROM residencias WHERE NumControl = " + NumControl + ";");

            } catch (Exception e)
            {
                MessageBox.Show("Error en CResidencias.BorraResidencia: " + e.Message);
            } finally
            {
                cnx = null;
            }
        }

        //MostrarResidencia por ID

        public void MuestraPorID()
        {
            try
            {
                cnx = new MySQL();
                OdbcDataReader dr = cnx.objetoDataReader("SELECT * FROM residencias WHERE NumControl = " + NumControl + ";");

                if (dr.HasRows)
                {
                    dr.Read();
                    IDAsesorEx = dr.GetInt64(1);
                    proyecto = dr.GetString(2);
                    IDEstatus = dr.GetInt64(3);
                    IDProfesor = dr.GetInt64(4);
                    fechaInicio = dr.GetString(5);
                    fechaTermino = dr.GetString(6);
                }
            } catch (Exception e)
            {
                MessageBox.Show("Error en CResidencias.MuestraPorID: " + e.Message);
            }
            finally
            {
                cnx = null;
                
            }
        }

        public void PoblarDGVResidencias(DataGridView DGV)
        {
            try
            {
                cnx = new MySQL();
                String qry = "SELECT r.NumControl as NumControl, al.Nombre as Alumno, ae.Nombre as AsesorExterno, r.Proyecto as Proyecto, es.Descripcion as Estatus, p.nombre as Profesor, r.FechaInicio as Inicio, r.FechaTermino as Termino " +
"FROM residencias r, asesores_externos ae, estatus_residencias es, profesores p, alumnos al " +
"WHERE r.IDAsesorEx = ae.IDAsesorEx AND " +
"r.IDEstatus = es.IDEstatus AND " +
"r.NumControl = al.NumControl AND " +
"r.IDProfesor = p.IDProfesor " +
"UNION " +
"SELECT r.NumControl as NumControl, al.Nombre as Alumno, ae.Nombre as AsesorExterno, r.Proyecto as Proyecto, es.Descripcion as Estatus, 'Sin asesor aignado' as Profesor, r.FechaInicio as Inicio, r.FechaTermino as Termino " +
"FROM residencias r, asesores_externos ae, estatus_residencias es, profesores p, alumnos al " +
"WHERE r.IDAsesorEx = ae.IDAsesorEx AND " +
"r.IDEstatus = es.IDEstatus AND " +
"r.NumControl = al.NumControl AND " +
"r.IDProfesor = 0; ";
                DGV.DataSource = cnx.objetoDataAdapter(qry);
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
            } catch (Exception e)
            {
                MessageBox.Show("Error en CResidencias." + e.Message);
            }
        }

        public Boolean alumnoTieneResidencia()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            OdbcDataReader dr;
            try
            {
                strSQL = "SELECT * " +
                 "FROM residencias " +
                 "WHERE numControl=" + NumControl;

                dr = xCnx.objetoDataReader(strSQL);

                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("CResidencias.alumnoTieneResidencia: " + e.Message);
                return false;
            }
        }
    }



}
