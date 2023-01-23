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
    public class Inspection_DAO
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public Inspection_DAO()
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


        public bool InsertInspection(Inspection_DTO dto)
        {
            try
            {
                string sql = @"INSERT INTO INSPECT_ITEM_MST(INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_USER_ID)
                                                    VALUES(@INSPECT_ITEM_CODE, @INSPECT_ITEM_NAME, @VALUE_TYPE, @SPEC_LSL, @SPEC_TARGET, @SPEC_USL, @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", string.IsNullOrEmpty(dto.INSPECT_ITEM_CODE) ? (object)DBNull.Value : dto.INSPECT_ITEM_CODE);
                cmd.Parameters.AddWithValue("@INSPECT_ITEM_NAME", string.IsNullOrEmpty(dto.INSPECT_ITEM_NAME) ? (object)DBNull.Value : dto.INSPECT_ITEM_NAME);
                cmd.Parameters.AddWithValue("@VALUE_TYPE", dto.VALUE_TYPE);
                cmd.Parameters.AddWithValue("@SPEC_LSL", string.IsNullOrEmpty(dto.SPEC_LSL) ? (object)DBNull.Value : dto.SPEC_LSL);
                cmd.Parameters.AddWithValue("@SPEC_TARGET", string.IsNullOrEmpty(dto.SPEC_TARGET) ? (object)DBNull.Value : dto.SPEC_TARGET);
                cmd.Parameters.AddWithValue("@SPEC_USL", string.IsNullOrEmpty(dto.SPEC_USL) ? (object)DBNull.Value : dto.SPEC_USL);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrEmpty(dto.CREATE_USER_ID) ? (object)DBNull.Value : dto.CREATE_USER_ID);

                conn.Open();
                int irowAffect = cmd.ExecuteNonQuery();
                return irowAffect > 0;
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

        public bool UpdateInspection(Inspection_DTO dto)
        {
            try
            {
                string sql = @" UPDATE INSPECT_ITEM_MST SET 
						                                   INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE
                                                         , INSPECT_ITEM_NAME = @INSPECT_ITEM_NAME
                                                         , VALUE_TYPE = @VALUE_TYPE
                                                         , SPEC_LSL = @SPEC_LSL
                                                         , SPEC_TARGET = @SPEC_TARGET
                                                         , SPEC_USL = @SPEC_USL
                                                         , UPDATE_TIME = @UPDATE_TIME
                                                         , UPDATE_USER_ID = @UPDATE_USER_ID
                                WHERE INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@INSPECT_ITEM_CODE", string.IsNullOrEmpty(dto.INSPECT_ITEM_CODE) ? (object)DBNull.Value : dto.INSPECT_ITEM_CODE);
                cmd.Parameters.AddWithValue("@INSPECT_ITEM_NAME", string.IsNullOrEmpty(dto.INSPECT_ITEM_NAME) ? (object)DBNull.Value : dto.INSPECT_ITEM_NAME);
                cmd.Parameters.AddWithValue("@VALUE_TYPE", dto.VALUE_TYPE);
                cmd.Parameters.AddWithValue("@SPEC_LSL", string.IsNullOrEmpty(dto.SPEC_LSL) ? (object)DBNull.Value : dto.SPEC_LSL);
                cmd.Parameters.AddWithValue("@SPEC_TARGET", string.IsNullOrEmpty(dto.SPEC_TARGET) ? (object)DBNull.Value : dto.SPEC_TARGET);
                cmd.Parameters.AddWithValue("@SPEC_USL", string.IsNullOrEmpty(dto.SPEC_USL) ? (object)DBNull.Value : dto.SPEC_USL);
                cmd.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

                conn.Open();
                int iRowAffect = cmd.ExecuteNonQuery();
                return iRowAffect > 0;
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

        public List<Inspection_DTO> SelectInspection()
        {
            try
            {
                string sql = @"SELECT INSPECT_ITEM_CODE, INSPECT_ITEM_NAME, VALUE_TYPE, SPEC_LSL, SPEC_TARGET, SPEC_USL, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                               FROM INSPECT_ITEM_MST;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                List<Inspection_DTO> list = new List<Inspection_DTO>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Inspection_DTO dto = new Inspection_DTO();

                    dto.INSPECT_ITEM_CODE = reader["INSPECT_ITEM_CODE"].ToString();
                    dto.INSPECT_ITEM_NAME = reader["INSPECT_ITEM_NAME"].ToString();
                    dto.SPEC_LSL = ((reader["SPEC_LSL"] != null) ? reader["SPEC_LSL"].ToString() : null);
                    dto.SPEC_TARGET = ((reader["SPEC_TARGET"] != null) ? reader["SPEC_TARGET"].ToString() : null);
                    dto.SPEC_USL = ((reader["SPEC_USL"] != null) ? reader["SPEC_USL"].ToString() : null);
                    dto.VALUE_TYPE = Convert.ToChar(reader["VALUE_TYPE"]);
                    dto.CREATE_TIME = Convert.ToDateTime(reader["CREATE_TIME"]);
                    dto.CREATE_USER_ID = reader["CREATE_USER_ID"].ToString();
                    dto.UPDATE_USER_ID = ((reader["UPDATE_USER_ID"] != null) ? reader["UPDATE_USER_ID"].ToString() : null);
                    //Inspection_DTO dto = new Inspection_DTO
                    //{
                    //      INSPECT_ITEM_CODE =  reader["INSPECT_ITEM_CODE"].ToString()
                    //    , INSPECT_ITEM_NAME = reader["INSPECT_ITEM_NAME"].ToString()
                    //    , SPEC_LSL = ((reader["SPEC_LSL"] != null) ? reader["SPEC_LSL"].ToString() : null)
                    //    , SPEC_TARGET = ((reader["SPEC_TARGET"] != null) ? reader["SPEC_TARGET"].ToString() : null)
                    //    , SPEC_USL = ((reader["SPEC_USL"] != null) ? reader["SPEC_USL"].ToString() : null)
                    //    , VALUE_TYPE = Convert.ToChar(reader["VALUE_TYPE"])
                    //    , CREATE_TIME = Convert.ToDateTime(reader["CREATE_TIME"])
                    //    , CREATE_USER_ID = reader["CREATE_USER_ID"].ToString()
                    //    , UPDATE_USER_ID = ((reader["UPDATE_USER_ID"] != null) ? reader["UPDATE_USER_ID"].ToString() : null)
                    //};
                    if (reader["UPDATE_TIME"] != DBNull.Value)
                    {
                        dto.UPDATE_TIME = Convert.ToDateTime(reader["UPDATE_TIME"]);
                    }
                    else
                    {
                        dto.UPDATE_TIME = null;
                    }
                    
                    list.Add(dto);
                }
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

        public bool DeleteInspection(Inspection_DTO dto)
        {
            try
            {
                string sql = @"DELETE FROM INSPECT_ITEM_MST WHERE INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var list = Helper.DataReaderMapToList<Inspection_DTO>(cmd.ExecuteReader());
                conn.Close();
                return true;
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
    }
}
