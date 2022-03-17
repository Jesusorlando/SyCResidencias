using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyCResidencias.Clases
{
    class CLoginUsuarios
    {
        MySQL cnx;
        OdbcDataReader dr;
        public long idProfesor { set; get; }
        public CLoginUsuarios ()
        {
            cnx = new MySQL();
        }


        public Boolean LogUsuario(String usuario, String pw)
        {
            dr = cnx.objetoDataReader("Select * from profesores where Usuario = '"+usuario+"' and Contrasenia ='"+pw+"';");
            if (dr.HasRows)
            {
                dr.Read();
                idProfesor = dr.GetInt32(0);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
