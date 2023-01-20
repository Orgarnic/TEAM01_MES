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
    public class Common_DAO
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public Common_DAO()
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

        public List<CommonTable_DTO> SelectCommonTable()
        {
            try
            {
                string sql = @"SELECT   CODE_TABLE_NAME, CODE_TABLE_DESC
                                      , KEY_1_NAME, KEY_2_NAME, KEY_3_NAME
                                      , DATA_1_NAME, DATA_2_NAME, DATA_3_NAME, DATA_4_NAME, DATA_5_NAME
                                      , CREATE_TIME
                                      , CREATE_USER_ID
                                      , UPDATE_TIME
                                      , UPDATE_USER_ID
                               FROM CODE_TABLE_MST";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var list = Helper.DataReaderMapToList<CommonTable_DTO>(cmd.ExecuteReader());
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

        

        public bool InsertCommonTable(CommonTable_DTO dto)
        {
            try
            {
                string sql = @"INSERT INTO CODE_TABLE_MST (CODE_TABLE_NAME, CODE_TABLE_DESC, KEY_1_NAME, KEY_2_NAME, KEY_3_NAME, DATA_1_NAME, DATA_2_NAME, DATA_3_NAME, DATA_4_NAME, DATA_5_NAME, CREATE_USER_ID)
	                                                VALUES (@CODE_TABLE_NAME, @CODE_TABLE_DESC, @KEY_1_NAME, @KEY_2_NAME, @KEY_3_NAME, @DATA_1_NAME, @DATA_2_NAME, @DATA_3_NAME, @DATA_4_NAME, @DATA_5_NAME, @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", string.IsNullOrEmpty(dto.CODE_TABLE_NAME) ? (object)DBNull.Value : dto.CODE_TABLE_NAME);
                cmd.Parameters.AddWithValue("@CODE_TABLE_DESC", string.IsNullOrEmpty(dto.CODE_TABLE_DESC) ? (object)DBNull.Value : dto.CODE_TABLE_DESC);
                cmd.Parameters.AddWithValue("@KEY_1_NAME", string.IsNullOrEmpty(dto.KEY_1_NAME) ? (object)DBNull.Value : dto.KEY_1_NAME);
                cmd.Parameters.AddWithValue("@KEY_2_NAME", string.IsNullOrEmpty(dto.KEY_2_NAME) ? (object)DBNull.Value : dto.KEY_2_NAME);
                cmd.Parameters.AddWithValue("@KEY_3_NAME", string.IsNullOrEmpty(dto.KEY_3_NAME) ? (object)DBNull.Value : dto.KEY_3_NAME);
                cmd.Parameters.AddWithValue("@DATA_1_NAME", string.IsNullOrEmpty(dto.DATA_1_NAME) ? (object)DBNull.Value : dto.DATA_1_NAME);
                cmd.Parameters.AddWithValue("@DATA_2_NAME", string.IsNullOrEmpty(dto.DATA_2_NAME) ? (object)DBNull.Value : dto.DATA_2_NAME);
                cmd.Parameters.AddWithValue("@DATA_3_NAME", string.IsNullOrEmpty(dto.DATA_3_NAME) ? (object)DBNull.Value : dto.DATA_3_NAME);
                cmd.Parameters.AddWithValue("@DATA_4_NAME", string.IsNullOrEmpty(dto.DATA_4_NAME) ? (object)DBNull.Value : dto.DATA_4_NAME);
                cmd.Parameters.AddWithValue("@DATA_5_NAME", string.IsNullOrEmpty(dto.DATA_5_NAME) ? (object)DBNull.Value : dto.DATA_5_NAME);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrEmpty(dto.CREATE_USER_ID) ? (object)DBNull.Value : dto.CREATE_USER_ID);

                conn.Open();
                int irowAffect=cmd.ExecuteNonQuery();
                return irowAffect>0;
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

        public bool UpdateCommonTable(CommonTable_DTO dto)
        {
            try
            {
                string sql = @" UPDATE CODE_TABLE_MST SET 
						                                  CODE_TABLE_DESC = @CODE_TABLE_DESC
						                                , KEY_1_NAME = @KEY_1_NAME
						                                , KEY_2_NAME = @KEY_2_NAME
						                                , KEY_3_NAME = @KEY_3_NAME
						                                , DATA_1_NAME = @DATA_1_NAME
						                                , DATA_2_NAME = @DATA_2_NAME
						                                , DATA_3_NAME = @DATA_3_NAME
						                                , DATA_4_NAME = @DATA_4_NAME
						                                , DATA_5_NAME = @DATA_5_NAME
						                                , UPDATE_TIME = @UPDATE_TIME
						                                , UPDATE_USER_ID = @UPDATE_USER_ID
                                WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CODE_TABLE_DESC", string.IsNullOrEmpty(dto.CODE_TABLE_DESC) ? (object)DBNull.Value : dto.CODE_TABLE_DESC);
                cmd.Parameters.AddWithValue("@KEY_1_NAME", string.IsNullOrEmpty(dto.KEY_1_NAME) ? (object)DBNull.Value : dto.KEY_1_NAME);
                cmd.Parameters.AddWithValue("@KEY_2_NAME", string.IsNullOrEmpty(dto.KEY_2_NAME) ? (object)DBNull.Value : dto.KEY_2_NAME);
                cmd.Parameters.AddWithValue("@KEY_3_NAME", string.IsNullOrEmpty(dto.KEY_3_NAME) ? (object)DBNull.Value : dto.KEY_3_NAME);
                cmd.Parameters.AddWithValue("@DATA_1_NAME", string.IsNullOrEmpty(dto.DATA_1_NAME) ? (object)DBNull.Value : dto.DATA_1_NAME);
                cmd.Parameters.AddWithValue("@DATA_2_NAME", string.IsNullOrEmpty(dto.DATA_2_NAME) ? (object)DBNull.Value : dto.DATA_2_NAME);
                cmd.Parameters.AddWithValue("@DATA_3_NAME", string.IsNullOrEmpty(dto.DATA_3_NAME) ? (object)DBNull.Value : dto.DATA_3_NAME);
                cmd.Parameters.AddWithValue("@DATA_4_NAME", string.IsNullOrEmpty(dto.DATA_4_NAME) ? (object)DBNull.Value : dto.DATA_4_NAME);
                cmd.Parameters.AddWithValue("@DATA_5_NAME", string.IsNullOrEmpty(dto.DATA_5_NAME) ? (object)DBNull.Value : dto.DATA_5_NAME);
                cmd.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);
                cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", string.IsNullOrEmpty(dto.CODE_TABLE_NAME) ? (object)DBNull.Value : dto.CODE_TABLE_NAME);

                conn.Open();
                int iRowAffect=cmd.ExecuteNonQuery();
                return iRowAffect>0;
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

        public List<CommonData_DTO> SelectCommonTableData(string CODE_TABLE_NAME)
        {
            string sql = @"SELECT   
                                    DISPLAY_SEQ
                                  , KEY_1 , KEY_2 , KEY_3 
                                  , DATA_1 , DATA_2 , DATA_3 , DATA_4 , DATA_5 
                           FROM CODE_DATA_MST
                           WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME
                           ORDER BY DISPLAY_SEQ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", CODE_TABLE_NAME);
            conn.Open();
            var list = Helper.DataReaderMapToList<CommonData_DTO>(cmd.ExecuteReader());
            conn.Close();
            return list;
        }

        public List<CommonData_DTO> SelectAllCommonTableData()
        {
            string sql = @"SELECT   CODE_TABLE_NAME
                                  , DISPLAY_SEQ
                                  , KEY_1 , KEY_2 , KEY_3 
                                  , DATA_1 , DATA_2 , DATA_3 , DATA_4 , DATA_5 
                           FROM CODE_DATA_MST";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            var list = Helper.DataReaderMapToList<CommonData_DTO>(cmd.ExecuteReader());
            conn.Close();
            return list;
        }

        public bool InsertCommonTableData(CommonData_DTO dto)
        {
            try
            {
                string sql = @"INSERT INTO CODE_DATA_MST (CODE_TABLE_NAME, CODE_TABLE_DESC, KEY_1_NAME, KEY_2_NAME, KEY_3_NAME, DATA_1_NAME, DATA_2_NAME, DATA_3_NAME, DATA_4_NAME, DATA_5_NAME, CREATE_USER_ID)
	                                                VALUES (@CODE_TABLE_NAME, @CODE_TABLE_DESC, @KEY_1_NAME, @KEY_2_NAME, @KEY_3_NAME, @DATA_1_NAME, @DATA_2_NAME, @DATA_3_NAME, @DATA_4_NAME, @DATA_5_NAME, @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@KEY_1_NAME", string.IsNullOrEmpty(dto.KEY_1) ? (object)DBNull.Value : dto.KEY_1);
                cmd.Parameters.AddWithValue("@KEY_2_NAME", string.IsNullOrEmpty(dto.KEY_2) ? (object)DBNull.Value : dto.KEY_2);
                cmd.Parameters.AddWithValue("@KEY_3_NAME", string.IsNullOrEmpty(dto.KEY_3) ? (object)DBNull.Value : dto.KEY_3);
                cmd.Parameters.AddWithValue("@DATA_1_NAME", string.IsNullOrEmpty(dto.DATA_1) ? (object)DBNull.Value : dto.DATA_1);
                cmd.Parameters.AddWithValue("@DATA_2_NAME", string.IsNullOrEmpty(dto.DATA_2) ? (object)DBNull.Value : dto.DATA_2);
                cmd.Parameters.AddWithValue("@DATA_3_NAME", string.IsNullOrEmpty(dto.DATA_3) ? (object)DBNull.Value : dto.DATA_3);
                cmd.Parameters.AddWithValue("@DATA_4_NAME", string.IsNullOrEmpty(dto.DATA_4) ? (object)DBNull.Value : dto.DATA_4);
                cmd.Parameters.AddWithValue("@DATA_5_NAME", string.IsNullOrEmpty(dto.DATA_5) ? (object)DBNull.Value : dto.DATA_5);

                conn.Open();
                int iRowAffect = cmd.ExecuteNonQuery();
                return iRowAffect>0;
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

        public bool UpsertCommonTableData(string CODE_TABLE_NAME, List<CommonData_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"DECLARE @COUNT INT,@SEQ INT
                               SET @COUNT = (SELECT COUNT(*) FROM CODE_DATA_MST WHERE KEY_1 = @KEY_1 AND CODE_TABLE_NAME = @CODE_TABLE_NAME)
                               SET @SEQ   = ISNULL((SELECT TOP(1) DISPLAY_SEQ FROM CODE_DATA_MST WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME ORDER BY DISPLAY_SEQ DESC),0) + 1
                               
                               IF @COUNT > 0
                               BEGIN
                               UPDATE CODE_DATA_MST SET KEY_1 = @KEY_1
                               						,KEY_2 = @KEY_2
                               						,KEY_3 = @KEY_3
                               						,DATA_1 = @DATA_1
                               						,DATA_2 = @DATA_2
                               						,DATA_3 = @DATA_3
                               						,DATA_4 = @DATA_4
                               						,DATA_5 = @DATA_5
                               						,DISPLAY_SEQ = @DISPLAY_SEQ
                               						,UPDATE_TIME = GETDATE()
                                                    WHERE KEY_1 = @KEY_1 AND CODE_TABLE_NAME = @CODE_TABLE_NAME
                               END
                               
                               ELSE
                               BEGIN
                               INSERT INTO CODE_DATA_MST (CODE_TABLE_NAME, KEY_1, KEY_2, KEY_3, DATA_1, DATA_2, DATA_3, DATA_4, DATA_5, DISPLAY_SEQ, CREATE_TIME)
                                                  VALUES (@CODE_TABLE_NAME, @KEY_1, @KEY_2, @KEY_3, @DATA_1, @DATA_2, @DATA_3, @DATA_4, @DATA_5, @SEQ, GETDATE())
                               END";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", CODE_TABLE_NAME);
                cmd.Parameters.Add(new SqlParameter("@KEY_1", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@KEY_2", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@KEY_3", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DATA_1", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DATA_2", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DATA_3", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DATA_4", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DATA_5", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@DISPLAY_SEQ", SqlDbType.Int));
                cmd.Transaction = trans;


                foreach (CommonData_DTO item in list)
                {
                    cmd.Parameters["@KEY_1"].Value = (item.KEY_1 == null)? (object)DBNull.Value:item.KEY_1;
                    cmd.Parameters["@KEY_2"].Value = (item.KEY_2 == null) ? (object)DBNull.Value : item.KEY_2;
                    cmd.Parameters["@KEY_3"].Value = (item.KEY_3 == null) ? (object)DBNull.Value : item.KEY_3;
                    cmd.Parameters["@DATA_1"].Value = (item.DATA_1 == null) ? (object)DBNull.Value : item.DATA_1;
                    cmd.Parameters["@DATA_2"].Value = (item.DATA_2 == null) ? (object)DBNull.Value : item.DATA_2;
                    cmd.Parameters["@DATA_3"].Value = (item.DATA_3 == null) ? (object)DBNull.Value : item.DATA_3;
                    cmd.Parameters["@DATA_4"].Value = (item.DATA_4 == null) ? (object)DBNull.Value : item.DATA_4;
                    cmd.Parameters["@DATA_5"].Value = (item.DATA_5 == null) ? (object)DBNull.Value : item.DATA_5;
                    cmd.Parameters["@DISPLAY_SEQ"].Value = (item.DISPLAY_SEQ == null) ? (object)DBNull.Value : item.DISPLAY_SEQ;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                trans.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteTable(CommonTable_DTO dto)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            try
            {
                // data table 먼저 삭제하고, 그다음에 table 삭제
                string sql = "DELETE FROM CODE_DATA_MST WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", dto.CODE_TABLE_NAME);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM CODE_TABLE_MST WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME";
                cmd.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteTableData(string CODE_TABLE_NAME,CommonData_DTO dto)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            try
            {
                // data table 먼저 삭제하고, 그다음에 table 삭제
                string sql = "DELETE FROM CODE_DATA_MST WHERE CODE_TABLE_NAME = @CODE_TABLE_NAME";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@CODE_TABLE_NAME", CODE_TABLE_NAME);
                cmd.Parameters.AddWithValue("@KEY_1_NAME", string.IsNullOrEmpty(dto.KEY_1) ? (object)DBNull.Value : dto.KEY_1);
                cmd.Parameters.AddWithValue("@KEY_2_NAME", string.IsNullOrEmpty(dto.KEY_2) ? (object)DBNull.Value : dto.KEY_2);
                cmd.Parameters.AddWithValue("@KEY_3_NAME", string.IsNullOrEmpty(dto.KEY_3) ? (object)DBNull.Value : dto.KEY_3);
                cmd.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
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
