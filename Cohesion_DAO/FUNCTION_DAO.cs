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
   public class Function_DAO : IDisposable
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
        // 화면기능 입력
        public bool InsertFunction(FUNCTION_MST_DTO dto)
        {
            try
            {
                conn.Open();
                string sql = @"insert into FUNCTION_MST(FUNCTION_CODE, FUNCTION_NAME,CREATE_TIME ,SHORT_CUT_KEY ,ICON_INDEX,  CREATE_USER_ID)
                                    values((FORMAT(cast(GETDATE() as datetime), 'F_'+'yyMMddHHmmss')),@FUNCTION_NAME,@CREATE_TIME,@SHORT_CUT_KEY,@ICON_INDEX,@CREATE_USER_ID)";
                SqlCommand cmd = Helper.UpsertCmdValue<FUNCTION_MST_DTO>(dto, sql, conn);
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
        // 화면기능 셀렉
        public List<FUNCTION_MST_DTO> SelectFunction()
        {
            List<FUNCTION_MST_DTO> list = null;
            try
            {
                string sql = @"SELECT FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                from FUNCTION_MST";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                list = Helper.DataReaderMapToList<FUNCTION_MST_DTO>(cmd.ExecuteReader());
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

        // 화면기능 업뎃
        public bool UpdateFunction(FUNCTION_MST_DTO dto)
        {
            try
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                int iRowAffect = default;
                string sql = @"UPDATE  FUNCTION_MST
                            SET  FUNCTION_NAME = @FUNCTION_NAME, SHORT_CUT_KEY = @SHORT_CUT_KEY, ICON_INDEX = @ICON_INDEX,
		                          UPDATE_TIME = @UPDATE_TIME, UPDATE_USER_ID = @UPDATE_USER_ID
                            WHERE FUNCTION_CODE = @FUNCTION_CODE";
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
        // 화면 기능 삭제
        public bool DeleteFunction(string FUNCTION_CODE)
        {
            try
            {
                string sql = @"delete FUNCTION_MST where FUNCTION_CODE = @FUNCTION_CODE";
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

        public List<FUNCTION_MST_DTO> SelectFunction2(FUNCTION_MST_DTO_Condition condition)
        {
            List<FUNCTION_MST_DTO> list = new List<FUNCTION_MST_DTO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"SELECT FUNCTION_CODE, FUNCTION_NAME, SHORT_CUT_KEY, ICON_INDEX, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                    from FUNCTION_MST where   1 = 1");
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

                list = Helper.DataReaderMapToList<FUNCTION_MST_DTO>(cmd.ExecuteReader());
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
