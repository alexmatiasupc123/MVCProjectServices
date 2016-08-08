using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MVCBolitaServices.DataAccess.Login
{
    public class DoManejadorDatosLogin
    {
        public string ProbarConexion()
        {
            string cadenaConexionBOLITABOOK=System.Configuration.ConfigurationManager.ConnectionStrings["connBOLITABOOK"].ConnectionString;
            string estado = String.Empty;

            try
            {
                Conexion.Init(cadenaConexionBOLITABOOK);
                Conexion objOperacion = new Conexion();
                objOperacion.ConectarBOLITABOOK();
                estado="ConnectionState: "+objOperacion.connBOLITABOOK.State.ToString()+" Database: "+objOperacion.connBOLITABOOK.Database+" DataSource: "+objOperacion.connBOLITABOOK.DataSource;
            }
            catch (Exception)
            {
                
                throw;
            }

            return estado;
        }
    }
}
