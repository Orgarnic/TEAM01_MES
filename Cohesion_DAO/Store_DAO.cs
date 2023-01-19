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
                           	   ,UPDATE_TIME = GETDATE()
                           	   ,UPDATE_USER_ID = @UPDATE_USER_ID
                           WHERE STORE_CODE = @STORE_CODE ";
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@STORE_CODE", string.IsNullOrEmpty(dto.STORE_CODE) ? (object)DBNull.Value : dto.STORE_CODE);
            cmd.Parameters.AddWithValue("@STORE_NAME", string.IsNullOrEmpty(dto.STORE_NAME) ? (object)DBNull.Value : dto.STORE_NAME);
            cmd.Parameters.AddWithValue("@STORE_TYPE", string.IsNullOrEmpty(dto.STORE_TYPE) ? (object)DBNull.Value : dto.STORE_TYPE);
            cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
