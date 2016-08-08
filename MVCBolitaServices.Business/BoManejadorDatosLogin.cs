using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBolitaServices.DataAccess.Login;

namespace MVCBolitaServices.Business
{
    public class BoManejadorDatosLogin
    {
        public string ProbarConexion()
        {
            DoManejadorDatosLogin dm =new DoManejadorDatosLogin();
            return dm.ProbarConexion();
        }
    }
}
