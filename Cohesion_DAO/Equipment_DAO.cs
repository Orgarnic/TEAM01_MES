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
    public class Equipment_DAO : IDisposable
    {
        SqlConnection conn;
        public Equipment_DAO()
        {
            string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            conn = new SqlConnection(connstr);
        }
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Equipment_DTO> SelectEquipmentList()
        {
            string sql = @"SELECT EQUIPMENT_CODE, EQUIPMENT_NAME, EQUIPMENT_TYPE, EQUIPMENT_STATUS, 
                                  LAST_DOWN_TIME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           FROM EQUIPMENT_MST ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Equipment_DTO> list = Helper.DataReaderMapToList<Equipment_DTO>(cmd.ExecuteReader());

            return list;
        }
        public bool InsertEquipment(Equipment_DTO dto)
        {
            string sql = @"INSERT INTO EQUIPMENT_MST(EQUIPMENT_CODE, EQUIPMENT_NAME, EQUIPMENT_TYPE, EQUIPMENT_STATUS, CREATE_TIME, CREATE_USER_ID)
                           VALUES(@EQUIPMENT_CODE, @EQUIPMENT_NAME, @EQUIPMENT_TYPE, @EQUIPMENT_STATUS, GETDATE(), @CREATE_USER_ID) ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@EQUIPMENT_CODE", string.IsNullOrEmpty(dto.EQUIPMENT_CODE) ? (object)DBNull.Value : dto.EQUIPMENT_CODE);
            cmd.Parameters.AddWithValue("@EQUIPMENT_NAME", string.IsNullOrEmpty(dto.EQUIPMENT_NAME) ? (object)DBNull.Value : dto.EQUIPMENT_NAME);
            cmd.Parameters.AddWithValue("@EQUIPMENT_TYPE", string.IsNullOrEmpty(dto.EQUIPMENT_TYPE) ? (object)DBNull.Value : dto.EQUIPMENT_TYPE);
            cmd.Parameters.AddWithValue("@EQUIPMENT_STATUS", string.IsNullOrEmpty(dto.EQUIPMENT_STATUS) ? (object)DBNull.Value : dto.EQUIPMENT_STATUS);
            cmd.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrEmpty(dto.CREATE_USER_ID) ? (object)DBNull.Value : dto.CREATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        //> 다운시간 코드 X
        //public bool UpdateEquipment(Equipment_DTO dto)
        //{
        //    string sql = @"UPDATE EQUIPMENT_MST 
        //                   SET  EQUIPMENT_NAME = @EQUIPMENT_NAME
        //                   	   ,EQUIPMENT_TYPE = @EQUIPMENT_TYPE
        //  ,EQUIPMENT_STATUS = @EQUIPMENT_STATUS
        //                   	   ,UPDATE_TIME = GETDATE()
        //                   	   ,UPDATE_USER_ID = @UPDATE_USER_ID
        //                   WHERE EQUIPMENT_CODE = @EQUIPMENT_CODE ";

        //    SqlCommand cmd = new SqlCommand(sql, conn);

        //    cmd.Parameters.AddWithValue("@EQUIPMENT_CODE", string.IsNullOrEmpty(dto.EQUIPMENT_CODE) ? (object)DBNull.Value : dto.EQUIPMENT_CODE);
        //    cmd.Parameters.AddWithValue("@EQUIPMENT_NAME", string.IsNullOrEmpty(dto.EQUIPMENT_NAME) ? (object)DBNull.Value : dto.EQUIPMENT_NAME);
        //    cmd.Parameters.AddWithValue("@EQUIPMENT_TYPE", string.IsNullOrEmpty(dto.EQUIPMENT_TYPE) ? (object)DBNull.Value : dto.EQUIPMENT_TYPE);
        //    cmd.Parameters.AddWithValue("@EQUIPMENT_STATUS", string.IsNullOrEmpty(dto.EQUIPMENT_STATUS) ? (object)DBNull.Value : dto.EQUIPMENT_STATUS);
        //    cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    return true;
        //}

        //> 다운시간 코드 O
        public bool UpdateEquipment(Equipment_DTO dto)
        {
            string sql = @"UPDATE EQUIPMENT_MST 
            SET  EQUIPMENT_NAME = @EQUIPMENT_NAME
            	,EQUIPMENT_TYPE = @EQUIPMENT_TYPE
                ,EQUIPMENT_STATUS = @EQUIPMENT_STATUS
                ,LAST_DOWN_TIME = CASE 
            		WHEN @EQUIPMENT_STATUS = 'WAIT' THEN GETDATE()
            		WHEN @EQUIPMENT_STATUS = 'DOWN' THEN GETDATE()
            		WHEN @EQUIPMENT_STATUS = 'PROC' THEN NULL END
            	,UPDATE_TIME = GETDATE()
            	,UPDATE_USER_ID = @UPDATE_USER_ID
            WHERE EQUIPMENT_CODE = @EQUIPMENT_CODE ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@EQUIPMENT_CODE", string.IsNullOrEmpty(dto.EQUIPMENT_CODE) ? (object)DBNull.Value : dto.EQUIPMENT_CODE);
            cmd.Parameters.AddWithValue("@EQUIPMENT_NAME", string.IsNullOrEmpty(dto.EQUIPMENT_NAME) ? (object)DBNull.Value : dto.EQUIPMENT_NAME);
            cmd.Parameters.AddWithValue("@EQUIPMENT_TYPE", string.IsNullOrEmpty(dto.EQUIPMENT_TYPE) ? (object)DBNull.Value : dto.EQUIPMENT_TYPE);
            cmd.Parameters.AddWithValue("@EQUIPMENT_STATUS", string.IsNullOrEmpty(dto.EQUIPMENT_STATUS) ? (object)DBNull.Value : dto.EQUIPMENT_STATUS);
            cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        

        public bool DeleteEquipment(Equipment_DTO dto)
        {
            try
            {
                string sql = @"DELETE FROM EQUIPMENT_MST WHERE EQUIPMENT_CODE = @EQUIPMENT_CODE ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EQUIPMENT_CODE", dto.EQUIPMENT_CODE);
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
