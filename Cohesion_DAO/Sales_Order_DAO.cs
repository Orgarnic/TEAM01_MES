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
    public class Sales_Order_DAO : IDisposable
    {
        SqlConnection conn;
        public Sales_Order_DAO()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        
        public List<Sales_Order_DTO> SelectSalesList()
        {
            string sql = @"SELECT SOM.SALES_ORDER_ID, SOM.ORDER_DATE, SOM.CUSTOMER_CODE, DATA_1 AS CUSTOMER_NAME, SOM.PRODUCT_CODE, PRODUCT_NAME, SOM.ORDER_QTY, 
                                  SOM.CONFIRM_FLAG, SOM.SHIP_FLAG, SOM.CREATE_TIME, SOM.CREATE_USER_ID, SOM.UPDATE_TIME, SOM.UPDATE_USER_ID
                           FROM SALES_ORDER_MST SOM INNER JOIN CODE_DATA_MST CDM ON SOM.CUSTOMER_CODE = CDM.KEY_1
                                                    INNER JOIN PRODUCT_MST PM ON SOM.PRODUCT_CODE = PM.PRODUCT_CODE
                           ORDER BY SALES_ORDER_ID DESC";

            //string sql = @"SELECT SOM.SALES_ORDER_ID, SOM.ORDER_DATE, SOM.CUSTOMER_CODE, DATA_1 AS CUSTOMER_NAME, SOM.PRODUCT_CODE,  SOM.ORDER_QTY, --PM.PRODUCT_NAME,
            //                      SOM.CONFIRM_FLAG, SOM.SHIP_FLAG, SOM.CREATE_TIME, SOM.CREATE_USER_ID, SOM.UPDATE_TIME, SOM.UPDATE_USER_ID
            //               FROM SALES_ORDER_MST SOM INNER JOIN CODE_DATA_MST CDM ON SOM.CUSTOMER_CODE = CDM.KEY_1
            //               	   --,SALES_ORDER_MST SOM2 INNER JOIN PRODUCT_MST PM ON SOM2.PRODUCT_CODE = PM.PRODUCT_CODE
            //               ORDER BY SALES_ORDER_ID DESC ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Sales_Order_DTO> list = Helper.DataReaderMapToList<Sales_Order_DTO>(cmd.ExecuteReader());

            return list;
        }

        public bool InsertSalesOrder(Sales_Order_DTO dto)
        {
            string sql = @"INSERT INTO SALES_ORDER_MST(SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE
                                                , PRODUCT_CODE, ORDER_QTY, CONFIRM_FLAG, SHIP_FLAG, CREATE_TIME, CREATE_USER_ID)
                           VALUES((FORMAT(cast(GETDATE() as datetime), 'SALES_'+'yyMMddHHmmss')), GETDATE(), @CUSTOMER_CODE
                                                , @PRODUCT_CODE, @ORDER_QTY, @CONFIRM_FLAG, @SHIP_FLAG, GETDATE(), @CREATE_USER_ID)  ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CUSTOMER_CODE", string.IsNullOrEmpty(dto.CUSTOMER_CODE) ? (object)DBNull.Value : dto.CUSTOMER_CODE);
            cmd.Parameters.AddWithValue("@PRODUCT_CODE", string.IsNullOrEmpty(dto.PRODUCT_CODE) ? (object)DBNull.Value : dto.PRODUCT_CODE);
            cmd.Parameters.AddWithValue("@ORDER_QTY", string.IsNullOrEmpty(dto.ORDER_QTY) ? (object)DBNull.Value : dto.ORDER_QTY);
            cmd.Parameters.AddWithValue("@CONFIRM_FLAG", string.IsNullOrEmpty(dto.CONFIRM_FLAG) ? (object)DBNull.Value : dto.CONFIRM_FLAG);
            cmd.Parameters.AddWithValue("@SHIP_FLAG", string.IsNullOrEmpty(dto.SHIP_FLAG) ? (object)DBNull.Value : dto.SHIP_FLAG);
            cmd.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrEmpty(dto.CREATE_USER_ID) ? (object)DBNull.Value : dto.CREATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool UpdateSalesOrder(Sales_Order_DTO dto)
        {
            string sql = @"UPDATE SALES_ORDER_MST 
                           SET     PRODUCT_CODE = @PRODUCT_CODE
                           	      ,ORDER_QTY = @ORDER_QTY
                           	      ,CONFIRM_FLAG = @CONFIRM_FLAG
                           	      ,SHIP_FLAG = @SHIP_FLAG
                           	      ,UPDATE_TIME = GETDATE()
                           	      ,UPDATE_USER_ID = @UPDATE_USER_ID
                           WHERE SALES_ORDER_ID = @SALES_ORDER_ID  ";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@SALES_ORDER_ID", string.IsNullOrEmpty(dto.SALES_ORDER_ID) ? (object)DBNull.Value : dto.SALES_ORDER_ID);
            cmd.Parameters.AddWithValue("@PRODUCT_CODE", string.IsNullOrEmpty(dto.PRODUCT_CODE) ? (object)DBNull.Value : dto.PRODUCT_CODE);
            cmd.Parameters.AddWithValue("@ORDER_QTY", string.IsNullOrEmpty(dto.ORDER_QTY) ? (object)DBNull.Value : dto.ORDER_QTY);
            cmd.Parameters.AddWithValue("@CONFIRM_FLAG", string.IsNullOrEmpty(dto.CONFIRM_FLAG) ? (object)DBNull.Value : dto.CONFIRM_FLAG);
            cmd.Parameters.AddWithValue("@SHIP_FLAG", string.IsNullOrEmpty(dto.SHIP_FLAG) ? (object)DBNull.Value : dto.SHIP_FLAG);
            cmd.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrEmpty(dto.UPDATE_USER_ID) ? (object)DBNull.Value : dto.UPDATE_USER_ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteSalesOrder(Sales_Order_DTO dto)
        {
            try
            {
                string sql = @"DELETE FROM SALES_ORDER_MST WHERE SALES_ORDER_ID = @SALES_ORDER_ID ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SALES_ORDER_ID", dto.SALES_ORDER_ID);
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
