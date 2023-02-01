using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;

namespace Cohesion_DAO
{
   public class Function_User_Group_Rel_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public Function_User_Group_Rel_DAO()
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
        public bool InsertFUG(String USER_GROUP_CODE , String[] FUNCTION_CODE)
        {

            try
            {
                conn.Open();
                string sql = @"insert into FUNCTION_USER_GROUP_REL(USER_GROUP_CODE, FUNCTION_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID)
                              values(@USER_GROUP_CODE,@FUNCTION_CODE,@CREATE_TIME,@CREATE_USER_ID,@UPDATE_TIME,@UPDATE_USER_ID)";
              
                SqlCommand cmd = new SqlCommand();
                
          
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

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG()
        {
            List<FUNCTION_USER_GROUP_REL_DTO> list = null;
            try
            {
                string sql = @"select U.USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, F.CREATE_TIME, F.CREATE_USER_ID, F.UPDATE_TIME, U.UPDATE_USER_ID
                                from FUNCTION_USER_GROUP_REL F RIGHT join USER_GROUP_MST U ON F.CREATE_TIME  = U.CREATE_TIME";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG1()
        {
            List<FUNCTION_USER_GROUP_REL_DTO> list = null;
            try
            {
                string sql = @"select F.FUNCTION_CODE,FUNCTION_NAME
                                from FUNCTION_USER_GROUP_REL FU RIGHT join FUNCTION_MST F ON FU.FUNCTION_CODE  = F.FUNCTION_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG2()
        {
            List<FUNCTION_USER_GROUP_REL_DTO> list = null;
            try
            {
                string sql = @"SELECT USER_GROUP_CODE,FUNCTION_CODE
                                FROM FUNCTION_USER_GROUP_REL";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public bool UpdateFUG(FUNCTION_USER_GROUP_REL_DTO dto)
        {
            try
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                int iRowAffect = default;
                string sql = @"UPDATE  FUNCTION_USER_GROUP_REL
                            SET FUNCTION_CODE = @FUNCTION_CODE, CREATE_TIME = @CREATE_TIME, CREATE_USER_ID =@CREATE_USER_ID
                            WHERE  USER_GROUP_CODE = @USER_GROUP_CODE";
                SqlCommand CMD = Helper.UpsertCmdValue<FUNCTION_MST_DTO>(dto, sql, conn);
                iRowAffect = CMD.ExecuteNonQuery();
                //CMD.Transaction = trans;
                // trans.Commit();

                return iRowAffect > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        public bool DeleteFUG(string FUNCTION_CODE)
        {
            try
            {
                string sql = @"NCTION_USER_GROUP_REL where USER_GROUP_CODE = @USER_GROUP_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FUNCTION_CODE", FUNCTION_CODE);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG2(FUNCTION_USER_GROUP_REL_Condition_DTO condition)
        {
            List<FUNCTION_USER_GROUP_REL_DTO> list = new List<FUNCTION_USER_GROUP_REL_DTO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"SELECT USER_GROUP_CODE, FUNCTION_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                    from FUNCTION_USER_GROUP_REL where   1 = 1");
                foreach (var prop in condition.GetType().GetProperties())
                {
                    if (!string.IsNullOrWhiteSpace((string)prop.GetValue(condition)))
                    {
                        sql.Append($" and {prop.Name} = @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(condition).ToString());
                    }
                }
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();

                list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());
                conn.Close();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);

            }
            finally
            {
                conn.Close();
            }
            return list;

        }



    }
}
