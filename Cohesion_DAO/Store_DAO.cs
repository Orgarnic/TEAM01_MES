using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using Cohesion_DTO;
using System.Data;

namespace Cohesion_DAO
{
    public class Store_DAO : IDisposable
    {
        SqlConnection conn;
        public Store_DAO()
        {
            string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            conn = new SqlConnection(connstr);
        }
           
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Store_DTO> SelectStoreList()
        {
            string sql = @"SELECT STORE_CODE, STORE_NAME, STORE_TYPE, FIFO_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                        FROM STORE_MST
                        ORDER BY STORE_CODE";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Store_DTO> list = Helper.DataReaderMapToList<Store_DTO>(cmd.ExecuteReader());

            return list;
        }

        public bool InsertStore(Store_DTO dto)
        {
            string sql = @"INSERT INTO STORE_MST(STORE_CODE, STORE_NAME, STORE_TYPE, CREATE_TIME, CREATE_USER_ID)
                           VALUES(@STORE_CODE, @STORE_NAME, @STORE_TYPE, GETDATE(), @CREATE_USER_ID) ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@STORE_CODE", string.IsNullOrEmpty(dto.STORE_CODE) ? (object)DBNull.Value : dto.STORE_CODE);
            cmd.Parameters.AddWithValue("@STORE_NAME", string.IsNullOrEmpty(dto.STORE_NAME) ? (object)DBNull.Value : dto.STORE_NAME);
            cmd.Parameters.AddWithValue("@STORE_TYPE", string.IsNullOrEmpty(dto.STORE_TYPE) ? (object)DBNull.Value : dto.STORE_TYPE);
            cmd.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrEmpty(dto.CREATE_USER_ID) ? (object)DBNull.Value : dto.CREATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool UpdateStore(Store_DTO dto)
        {
            string sql = @"UPDATE STORE_MST 
                           SET  STORE_NAME = @STORE_NAME
                           	   ,STORE_TYPE = @STORE_TYPE
                           	   ,UPDATE_TIME = @UPDATE_TIME
                           	   ,UPDATE_USER_ID = @UPDATE_USER_ID
                           WHERE STORE_CODE = @STORE_CODE ";
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@STORE_CODE", string.IsNullOrEmpty(dto.STORE_CODE) ? (object)DBNull.Value : dto.STORE_CODE);
            cmd.Parameters.AddWithValue("@STORE_NAME", string.IsNullOrEmpty(dto.STORE_NAME) ? (object)DBNull.Value : dto.STORE_NAME);
            cmd.Parameters.AddWithValue("@STORE_TYPE", string.IsNullOrEmpty(dto.STORE_TYPE) ? (object)DBNull.Value : dto.STORE_TYPE);
            cmd.Parameters.AddWithValue("@UPDATE_TIME", dto.UPDATE_TIME);
            cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public List<Store_DTO_Search_Data> SelectStore(Store_DTO_Search_Data condtion)
        {
            List<Store_DTO_Search_Data> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(
                    @"SELECT STORE_CODE, STORE_NAME, STORE_TYPE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                      FROM STORE_MST
                      where 1 = 1 ");
                if (!string.IsNullOrWhiteSpace(condtion.STORE_CODE))
                {
                    sql.Append(" and STORE_CODE = @STORE_CODE ");
                    cmd.Parameters.AddWithValue("@STORE_CODE", condtion.STORE_CODE);
                }
                if (!string.IsNullOrWhiteSpace(condtion.STORE_NAME))
                {
                    sql.Append(" and STORE_NAME = @STORE_NAME ");
                    cmd.Parameters.AddWithValue("@STORE_NAME", condtion.STORE_NAME);
                }
                if (!string.IsNullOrWhiteSpace(condtion.STORE_TYPE))
                {
                    sql.Append(" and STORE_TYPE = @STORE_TYPE ");
                    cmd.Parameters.AddWithValue("@STORE_TYPE", condtion.STORE_TYPE);
                }
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                list = Helper.DataReaderMapToList<Store_DTO_Search_Data>(cmd.ExecuteReader());
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

        public bool DeleteStore(Store_DTO dto)
        {
            try
            {
                string sql = @"DELETE FROM STORE_MST WHERE STORE_CODE = @STORE_CODE ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@STORE_CODE", dto.STORE_CODE);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
