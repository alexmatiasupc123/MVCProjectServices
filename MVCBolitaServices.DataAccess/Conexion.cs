using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace MVCBolitaServices.DataAccess
{
    public class Conexion
    {
        private static string conncadenaConexionBOLITABOOK;

        public MySqlConnection connBOLITABOOK = new MySqlConnection();

        public static void Init(string cadenaConexionBOLITABOOK)
        {
            conncadenaConexionBOLITABOOK = cadenaConexionBOLITABOOK;
        }

        # region "ConectarBOLITABOOK"
        public MySqlConnection ConectarBOLITABOOK()
        {
            connBOLITABOOK = new MySqlConnection(conncadenaConexionBOLITABOOK);
            try
            {
                connBOLITABOOK.Open();
                return connBOLITABOOK;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        public bool desconectarBOLITABOOK()
        {
            try
            {
                connBOLITABOOK.Close();
                connBOLITABOOK.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "Ejecutar Procedimiento BOLITABOOK"
        public DataTable EjecutarProcedimientoBRITMOBILE(string sentencia, List<MySqlParameter> parametros)
        {
            try
            {
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = ConectarBOLITABOOK();
                comando.CommandText = sentencia;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador.SelectCommand = comando;

                foreach (MySqlParameter item in parametros)
                {
                    comando.Parameters.Add(item);
                }

                comando.ExecuteNonQuery();
                comando.Dispose();

                DataSet resultado = new DataSet();
                adaptador.Fill(resultado, "Data");

                desconectarBOLITABOOK();

                return resultado.Tables[0];
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region "Ejecutar Insercion Procedure BOLITABOOK"
        public int EjecutarInsercionProcedureBRITMOBILE(string sentencia, List<MySqlParameter> parametros)
        {
            try
            {
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = ConectarBOLITABOOK();
                comando.CommandText = sentencia;

                Int32 rowsAffected;

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador.SelectCommand = comando;

                foreach (MySqlParameter item in parametros)
                {
                    comando.Parameters.Add(item);
                }

                rowsAffected = comando.ExecuteNonQuery();


                desconectarBOLITABOOK();
                return rowsAffected;
            }
            catch (Exception e) { throw e; }
        }
        #endregion

    }
}
