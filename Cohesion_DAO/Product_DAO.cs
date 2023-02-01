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
   public class Product_DAO : IDisposable
   {
      SqlConnection conn = null;
      readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
      public Product_DAO()
      {
         conn = new SqlConnection(DB);
      }
      public List<PRODUCT_MST_DTO> SelectProduts(PRODUCT_MST_DTO_Condition condition)
      {
         List<PRODUCT_MST_DTO> list = null;
         try
         {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sql = new StringBuilder(@"SELECT PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, 
                                                   VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID FROM PRODUCT_MST where 1 = 1");
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
            list = Helper.DataReaderMapToList<PRODUCT_MST_DTO>(cmd.ExecuteReader());
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
      public bool InsertProduct(PRODUCT_MST_DTO dto)
      {
         try
         {
            string sql = @"INSERT INTO PRODUCT_MST(PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_USER_ID)
                           VALUES(@PRODUCT_CODE, @PRODUCT_NAME, @PRODUCT_TYPE, @CUSTOMER_CODE, @VENDOR_CODE, @CREATE_USER_ID)";
            SqlCommand cmd = Helper.UpsertCmdValue<PRODUCT_MST_DTO>(dto, sql, conn);
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
      public bool UpdateProduct(PRODUCT_MST_DTO dto)
      {
         try
         {
            string sql = @"UPDATE PRODUCT_MST SET PRODUCT_NAME = @PRODUCT_NAME, PRODUCT_TYPE = @PRODUCT_TYPE,
                           CUSTOMER_CODE = @CUSTOMER_CODE, VENDOR_CODE = @VENDOR_CODE, UPDATE_TIME = @UPDATE_TIME, UPDATE_USER_ID = @UPDATE_USER_ID
                           WHERE PRODUCT_CODE = @PRODUCT_CODE ";
            SqlCommand cmd = Helper.UpsertCmdValue<PRODUCT_MST_DTO>(dto, sql, conn);
            cmd.Parameters["@CUSTOMER_CODE"].Value = string.IsNullOrWhiteSpace(dto.CUSTOMER_CODE) ? (object)DBNull.Value : dto.CUSTOMER_CODE;
            cmd.Parameters["@VENDOR_CODE"].Value = string.IsNullOrWhiteSpace(dto.VENDOR_CODE) ? (object)DBNull.Value : dto.VENDOR_CODE;
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
      public bool DeleteProduct(PRODUCT_MST_DTO dto)
      {
         try
         {
            string sql = @"DELETE FROM PRODUCT_MST WHERE PRODUCT_CODE = @PRODUCT_CODE ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PRODUCT_CODE", dto.PRODUCT_CODE);
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
      public void Dispose()
      {
         if (conn != null || conn.State == ConnectionState.Open)
            conn.Close();
      }
        public List<PRODUCT_OPERATION_REL_DTO> SelectProductInRel()
        {
            try
            {
                string sql = @"SELECT PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, 
                                      VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                               FROM PRODUCT_MST";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var list = Helper.DataReaderMapToList<PRODUCT_OPERATION_REL_DTO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
