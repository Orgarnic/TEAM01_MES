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
            if (conn.State == System.Data.ConnectionState.Open || conn!=null)
            {
                conn.Close();
            }
        }
        public bool InsertFUG(String USER_GROUP_CODE , List<FUNCTION_USER_GROUP_REL_DTO> FUNCTION_CODE)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in FUNCTION_CODE)
            {
                sb.Append("'"+ item.FUNCTION_CODE + "',");
            }
            conn.Open();
            SqlTransaction stans = conn.BeginTransaction();
            try
            {
                string sql = $@"delete from FUNCTION_USER_GROUP_REL where USER_GROUP_CODE = @USER_GROUP_CODE";
                if (FUNCTION_CODE.Count > 0)
                {
                    sql += $" and FUNCTION_CODE not in ({sb.ToString().TrimEnd(',')}) ";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@USER_GROUP_CODE", USER_GROUP_CODE); cmd.Transaction = stans;
                cmd.ExecuteNonQuery();

                sql = @"declare @num int
                                set @num = (select count(*) from FUNCTION_USER_GROUP_REL where USER_GROUP_CODE = @USER_GROUP_CODE and FUNCTION_CODE  = @FUNCTION_CODE)
                                if (@num <> 0)
                                begin
                                update FUNCTION_USER_GROUP_REL 
								set 
								UPDATE_TIME=@UPDATE_TIME , UPDATE_USER_ID=@UPDATE_USER_ID
                                where  USER_GROUP_CODE = @USER_GROUP_CODE and FUNCTION_CODE  = @FUNCTION_CODE
                                end
                                else
                                begin
                                insert into  FUNCTION_USER_GROUP_REL(USER_GROUP_CODE, FUNCTION_CODE, CREATE_TIME, CREATE_USER_ID)
                                values(@USER_GROUP_CODE, @FUNCTION_CODE, @CREATE_TIME, @CREATE_USER_ID)
                                end";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                cmd2.Transaction = stans;
                cmd2.Parameters.AddWithValue("@USER_GROUP_CODE", USER_GROUP_CODE);
                cmd2.Parameters.AddWithValue("@CREATE_TIME", DateTime.Now) ; 
                cmd2.Parameters.AddWithValue("@CREATE_USER_ID", "test");
                cmd2.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
                cmd2.Parameters.AddWithValue("@UPDATE_USER_ID", "test");
                cmd2.Parameters.Add("@FUNCTION_CODE", System.Data.SqlDbType.VarChar);
                foreach (var item in FUNCTION_CODE)
                {
                    cmd2.Parameters["@FUNCTION_CODE"].Value = item.FUNCTION_CODE;
                    cmd2.ExecuteNonQuery();
                }
                stans.Commit();
                return true;
            }
            catch (Exception err)
            {
                stans.Rollback();
                Debug.WriteLine(err);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<UserGroup_DTO> SelectF(UserGoupCondition_DTO condition)
        {
            List<UserGroup_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"select USER_GROUP_CODE, USER_GROUP_NAME, USER_GROUP_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
from USER_GROUP_MST where 1=1");
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


        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUGR(string USER_GROUP_CODE)
        {
            try
            {
                string sql = @"select f.FUNCTION_CODE,f.FUNCTION_NAME
  from  FUNCTION_MST f  inner join FUNCTION_USER_GROUP_REL U  ON U.FUNCTION_CODE  = F.FUNCTION_CODE	
								where U.USER_GROUP_CODE = @USER_GROUP_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@USER_GROUP_CODE", USER_GROUP_CODE);
                conn.Open();
                var list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());  //스칼라 변수 "@g"을(를) 선언해야 합니다.
                conn.Close();
                return list;
            }

            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

            finally
            {
                conn.Close();
            }
        }




        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG() //근본 셀렉
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

        //        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG1()
        //        {
        //            List<FUNCTION_USER_GROUP_REL_DTO> list = null;
        //            try
        //            {
        //                string sql = @"select FUNCTION_NAME,FUNCTION_CODE, Rank() OVER(order by FUNCTION_CODE ASC) DISPLAY_SEQ
        //from FUNCTION_MST where 1=1
        //";
        //                SqlCommand cmd = new SqlCommand(sql, conn);
        //                conn.Open();
        //                list = Helper.DataReaderMapToList<FUNCTION_USER_GROUP_REL_DTO>(cmd.ExecuteReader());
        //            }
        //            catch (Exception err)
        //            {
        //                Debug.WriteLine(err.StackTrace);
        //                Debug.WriteLine(err.Message);
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //            return list;
        //        }



        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG1(FUNCTION_USER_GROUP_REL_DTO dto)
        {
            //select FUNCTION_NAME,FUNCTION_CODE, Rank() OVER(order by FUNCTION_CODE ASC) DISPLAY_SEQ       from FUNCTION_MST where 1 = 1

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

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG2()
        {
            List<FUNCTION_USER_GROUP_REL_DTO> list = null;
            try
            {
                string sql = @"select f.FUNCTION_CODE, f.FUNCTION_NAME
  from  FUNCTION_MST f  ";
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
