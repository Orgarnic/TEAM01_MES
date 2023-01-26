using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using Cohesion_DTO;

namespace Cohesion_DAO
{
    class Function_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public Function_DAO()
        {
            conn = new SqlConnection(DB);
        }
        public void Dispose()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public bool InsertFunction(Funct dto)
        {
            try
            {

                conn.Open();

                string sql = @"insert into FUNCTION_MST(FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX,  CREATE_USER_ID)
                                    values(@FUNCTION_CODE,@FUNCTION_NAME,@SHORT_CUT_KEY,@ICON_INDEX,@CREATE_USER_ID)";
                SqlCommand cmd = Helper.UpsertCmdValue<UserGroup_DTO>(dto, sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

    }


}
