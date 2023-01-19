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
      public List<PRODUCT_MST_DTO> SelectProduts()
      {
         List<PRODUCT_MST_DTO> list = null;
         try
         {
            string sql = @"SELECT PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID FROM PRODUCT_MST";
            SqlCommand cmd = new SqlCommand(sql, conn);
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

      public void Dispose()
      {
         if (conn != null || conn.State == ConnectionState.Open)
            conn.Close();
      }
   }
}
