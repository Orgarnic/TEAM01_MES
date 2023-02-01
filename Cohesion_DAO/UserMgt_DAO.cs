using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Cohesion_DTO;



namespace Cohesion_DAO
{
    public class UserMgt_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public UserMgt_DAO()
        {
            conn = new SqlConnection(DB);
        }
        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<User_DTO> SelectUser()
        {
            List<User_DTO> list = null;
            try
            {
                string sql = @"Select USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD, USER_DEPARTMENT, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                from USER_MST";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<User_DTO>(cmd.ExecuteReader());
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

        public bool InsertUser(User_DTO dto)
        {
            try
            {
                conn.Open();

                string sql = @"insert into USER_MST(USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD, USER_DEPARTMENT, CREATE_TIME, CREATE_USER_ID)
                                values(concat('User_', FORMAT(GETDATE(),'yyMMddHHmmss')),@USER_NAME,@USER_GROUP_CODE,@USER_PASSWORD,@USER_DEPARTMENT,@CREATE_TIME,@CREATE_USER_ID)";
                SqlCommand cmd = Helper.UpsertCmdValue<User_DTO>(dto, sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateUser(User_DTO dto)
        {
            try
            {

                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                int iRowAffect = default;
                string sql = @" UPDATE USER_MST
                            SET USER_NAME=@USER_NAME, USER_GROUP_CODE = @USER_GROUP_CODE, USER_PASSWORD = @USER_PASSWORD, UPDATE_TIME =@UPDATE_TIME, 
		                          USER_DEPARTMENT = @USER_DEPARTMENT, CREATE_USER_ID = @CREATE_USER_ID 
                            WHERE USER_ID = @USER_ID";
                SqlCommand CMD = Helper.UpsertCmdValue<User_DTO>(dto, sql, conn);
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

        public bool DeleteUser(int USER_ID)
        {
            try
            {
                string sql = @"delete USER_MST where USER_ID = @USER_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
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

        public List<User_DTO> SelectUser2(User_Condition_DTO condition)
        {
            List<User_DTO> list = new List<User_DTO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"Select USER_ID, USER_NAME, USER_GROUP_CODE, USER_PASSWORD, USER_DEPARTMENT, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                    from USER_MST where   1 = 1");
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

                list = Helper.DataReaderMapToList<User_DTO>(cmd.ExecuteReader());
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
