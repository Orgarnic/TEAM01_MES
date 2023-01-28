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
    public class UserGroup_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public UserGroup_DAO()
        {
            conn = new SqlConnection(DB);
        }
        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        // 사용자 그룹 Insert
        //public bool InsertUserGroup1(UserGroup_DTO dto)
        //{
        //    conn.Open();

        //    string sql = @"insert into USER_GROUP_MST(USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID)
        //                        values(@USER_GROUP_CODE,@USER_GROUP_NAME,@USER_GROUP_TYPE,@CREATE_TIME,@CREATE_USER_ID,@UPDATE_TIME,@UPDATE_USER_ID)";
        //    SqlCommand cmd = Helper.UpsertCmdValue<UserGroup_DTO>(dto, sql, conn);
        //    int result = cmd.ExecuteNonQuery();
        //    return result > 0;

        //}

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


        // 사용자 그룹 Select
        public List<UserGroup_DTO> SelectUserGroup()
        {
            List<UserGroup_DTO> list = null;
            try
            {
                string sql = @"Select USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                from USER_GROUP_MST";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<UserGroup_DTO>(cmd.ExecuteReader());
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

        //public List<UserGroup_DTO> SelectUserGroup()
        //{
        //    UserGroup_DAO dao = new UserGroup_DAO();
        //    List<UserGroup_DTO> list = dao.SelectUserGroup();
        //    dao.Dispose();

        //    return list;
        //}

        // 사용자 그룹 Update
        public bool UpdateUserGroup(UserGroup_DTO dto)
        {
            try
            {

                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                int iRowAffect = default;
                string sql = @"UPDATE USER_GROUP_MST 
                            SET  USER_GROUP_NAME = @USER_GROUP_NAME, USER_GROUP_TYPE = @USER_GROUP_TYPE, 
		                          UPDATE_TIME = @UPDATE_TIME, UPDATE_USER_ID = @UPDATE_USER_ID
                            WHERE USER_GROUP_CODE = @USER_GROUP_CODE";
                SqlCommand CMD = Helper.UpsertCmdValue<UserGroup_DTO>(dto, sql, conn);
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

        // 사용자 그룹 Delete

        public bool DeleteUserGroup(string USER_GROUP_CODE)
        {
            try
            {
                string sql = @"delete USER_GROUP_MST where USER_GROUP_CODE = @USER_GROUP_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@USER_GROUP_CODE", USER_GROUP_CODE);
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
        public List<UserGroup_DTO> SelectUserGroup2(UserGoupCondition_DTO condition)
        {
            List<UserGroup_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"Select USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                    from USER_GROUP_MST where   1 = 1");
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

                list = Helper.DataReaderMapToList<UserGroup_DTO>(cmd.ExecuteReader());
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
