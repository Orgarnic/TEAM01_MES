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
    class FUNCTION_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public FUNCTION_DAO()
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

        public bool InsertUserGroup(UserGroup_DTO dto)
        {
            try
            {

                conn.Open();

                string sql = @"insert into USER_GROUP_MST(USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_USER_ID,CREATE_TIME )
                                    values( @USER_GROUP_CODE, @USER_GROUP_NAME, @USER_GROUP_TYPE, @CREATE_USER_ID, @CREATE_TIME)";
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
