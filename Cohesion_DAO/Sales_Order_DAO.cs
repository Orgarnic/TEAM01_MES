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
        public List<Sales_Order_DTO> SelectOrderWithCondition(Sales_Order_DTO_Search condition)
        {
            List<Sales_Order_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"SELECT SOM.SALES_ORDER_ID, CONVERT(VARCHAR(30), SOM.ORDER_DATE, 121) ORDER_DATE, SOM.CUSTOMER_CODE, DATA_1 AS CUSTOMER_NAME, SOM.PRODUCT_CODE, PRODUCT_NAME, SOM.ORDER_QTY, 
                                                               SOM.CONFIRM_FLAG, SOM.SHIP_FLAG, SOM.CREATE_TIME, SOM.CREATE_USER_ID, SOM.UPDATE_TIME, SOM.UPDATE_USER_ID
                                                        FROM SALES_ORDER_MST SOM INNER JOIN CODE_DATA_MST CDM ON SOM.CUSTOMER_CODE = CDM.KEY_1
                                                                                 INNER JOIN PRODUCT_MST PM ON SOM.PRODUCT_CODE = PM.PRODUCT_CODE
                                                        WHERE 1 = 1 ");

                foreach (var prop in condition.GetType().GetProperties())
                {
                    if (prop.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace((string)prop.GetValue(condition)))
                    {
                        sql.Append($" and {prop.Name} = @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(condition).ToString());
                    }
                }
                sql.Append(" ORDER BY SALES_ORDER_ID DESC ");
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                list = Helper.DataReaderMapToList<Sales_Order_DTO>(cmd.ExecuteReader());
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
        
        public List<Sales_Order_VO> SelectSalesOrderState(string productCode, string orderID)
        {
            List<Sales_Order_VO> list = default;
            try
            {
                //string sql = @"SELECT SOM.SALES_ORDER_ID, SOM.CUSTOMER_CODE, SOM.PRODUCT_CODE, PM.PRODUCT_NAME, SOM.ORDER_QTY,
                //               		  BM.CHILD_PRODUCT_CODE, PMS.PRODUCT_NAME AS CHILD_PRODUCT_NAME, REQUIRE_QTY, 
                //               		  CAST(ORDER_QTY * REQUIRE_QTY AS DECIMAL) NEED_QTY, PMS1.VENDOR_CODE, 
                //                      CAST(LS.LOT_QTY AS DECIMAL) LOT_QTY,
                //               		  CAST(LS.LOT_QTY - (ORDER_QTY * REQUIRE_QTY)AS DECIMAL)LEFT_QTY
                //               FROM SALES_ORDER_MST SOM INNER JOIN CODE_DATA_MST CDM ON SOM.CUSTOMER_CODE = CDM.KEY_1
                //                                        INNER JOIN PRODUCT_MST PM ON SOM.PRODUCT_CODE = PM.PRODUCT_CODE
                //               						    INNER JOIN BOM_MST BM ON SOM.PRODUCT_CODE = BM.PRODUCT_CODE
                //               						    INNER JOIN PRODUCT_MST PMS ON BM.CHILD_PRODUCT_CODE = PMS.PRODUCT_CODE
                //               						    INNER JOIN PRODUCT_MST PMS1 ON BM.CHILD_PRODUCT_CODE = PMS1.PRODUCT_CODE AND PMS1.VENDOR_CODE IS NOT NULL
                //               						    INNER JOIN LOT_STS LS ON PMS.PRODUCT_CODE = LS.PRODUCT_CODE
                //               WHERE SOM.PRODUCT_CODE = @PRODUCT_CODE AND SOM.SALES_ORDER_ID = @SALES_ORDER_ID
                //               					   -- AND PMS1.VENDOR_CODE IS NOT NULL
                //               ORDER BY SALES_ORDER_ID DESC";

                //> 참고 쿼리
                /*
                 SELECT PURCHASE_ORDER_ID, PURCHASE_SEQ, SALES_ORDER_ID, ORDER_DATE, VENDOR_CODE,
		MATERIAL_CODE, ORDER_QTY, STOCK_IN_FLAG, STOCK_IN_STORE_CODE, STOCK_IN_LOT_ID
FROM PURCHASE_ORDER_MST
WHERE STOCK_IN_FLAG = 'N'
                 */
                /*
                 * SELECT MATERIAL_CODE, ORDER_QTY, STOCK_IN_FLAG, SUM(ORDER_QTY) OVER() NOT_STOCKED_QTY
FROM PURCHASE_ORDER_MST
WHERE MATERIAL_CODE = 'HB_CLP_JVP' AND STOCK_IN_FLAG = 'N'
                 */

                //> QUERY 수정 필요! : 미입고 수량 
                string sql = @"SELECT SOM.SALES_ORDER_ID, SOM.CUSTOMER_CODE, SOM.PRODUCT_CODE, PM.PRODUCT_NAME, SOM.ORDER_QTY,
                               		  BM.CHILD_PRODUCT_CODE, PMS.PRODUCT_NAME AS CHILD_PRODUCT_NAME, REQUIRE_QTY, 
                               		  CAST(SOM.ORDER_QTY * REQUIRE_QTY AS DECIMAL) NEED_QTY, PMS1.VENDOR_CODE, 
                                      CAST(LS.LOT_QTY AS DECIMAL) LOT_QTY,
                               		  CAST(LS.LOT_QTY - (SOM.ORDER_QTY * REQUIRE_QTY)AS DECIMAL)LEFT_QTY,
									  POM.MATERIAL_CODE, POM.ORDER_QTY, STOCK_IN_FLAG, CAST(SUM(POM.ORDER_QTY) OVER() AS DECIMAL) NOT_STOCKED_QTY
                               FROM SALES_ORDER_MST SOM INNER JOIN CODE_DATA_MST CDM ON SOM.CUSTOMER_CODE = CDM.KEY_1
                                                        INNER JOIN PRODUCT_MST PM ON SOM.PRODUCT_CODE = PM.PRODUCT_CODE
                               						    INNER JOIN BOM_MST BM ON SOM.PRODUCT_CODE = BM.PRODUCT_CODE
                               						    INNER JOIN PRODUCT_MST PMS ON BM.CHILD_PRODUCT_CODE = PMS.PRODUCT_CODE
                               						    INNER JOIN PRODUCT_MST PMS1 ON BM.CHILD_PRODUCT_CODE = PMS1.PRODUCT_CODE AND PMS1.VENDOR_CODE IS NOT NULL
                               						    INNER JOIN LOT_STS LS ON PMS.PRODUCT_CODE = LS.PRODUCT_CODE
														INNER JOIN PURCHASE_ORDER_MST POM ON SOM.SALES_ORDER_ID = POM.SALES_ORDER_ID
                               WHERE SOM.PRODUCT_CODE = @PRODUCT_CODE AND SOM.SALES_ORDER_ID = @SALES_ORDER_ID
                               					   -- AND PMS1.VENDOR_CODE IS NOT NULL
                               ORDER BY SALES_ORDER_ID DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                cmd.Parameters.AddWithValue("@SALES_ORDER_ID", orderID);
                conn.Open();

                list = Helper.DataReaderMapToList<Sales_Order_VO>(cmd.ExecuteReader());

                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool InsertPurchase(List<Sales_Order_VO> list)
        {
            string sql = @"INSERT INTO PURCHASE_ORDER_MST (PURCHASE_ORDER_ID, PURCHASE_SEQ, SALES_ORDER_ID, ORDER_DATE, 
                                                           VENDOR_CODE, MATERIAL_CODE, ORDER_QTY, STOCK_IN_FLAG)
                           VALUES(@PURCHASE_ORDER_ID, @PURCHASE_SEQ,@SALES_ORDER_ID, 
                                   GETDATE(), @VENDOR_CODE, @MATERIAL_CODE, CAST(@ORDER_QTY AS DECIMAL), 'N') ";

            //string sql = @"INSERT INTO PURCHASE_ORDER_MST (PURCHASE_ORDER_ID, PURCHASE_SEQ, SALES_ORDER_ID, ORDER_DATE, 
            //                                               VENDOR_CODE, MATERIAL_CODE, ORDER_QTY, STOCK_IN_FLAG)
            //               VALUES(@PURCHASE_ORDER_ID, RANK() OVER(PARTITION BY SALES_ORDER_ID ORDER BY ORDER_DATE),@SALES_ORDER_ID, 
            //                       GETDATE(), @VENDOR_CODE, @MATERIAL_CODE, CAST(@ORDER_QTY AS DECIMAL), 'N') ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            string pCode = "PURC_" + DateTime.Now.ToString("yyMMddHHmmss");
            cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID", pCode);
            cmd.Parameters.Add("@PURCHASE_SEQ", SqlDbType.Int);
            cmd.Parameters.Add("@SALES_ORDER_ID", SqlDbType.VarChar);
            cmd.Parameters.Add("@VENDOR_CODE", SqlDbType.VarChar);
            cmd.Parameters.Add("@MATERIAL_CODE", SqlDbType.VarChar);
            cmd.Parameters.Add("@ORDER_QTY", SqlDbType.Decimal);

            conn.Open();
            for (int i = 0; i < list.Count; i++)
            {
                cmd.Parameters["@PURCHASE_SEQ"].Value = i+1;
                cmd.Parameters["@SALES_ORDER_ID"].Value = list[i].SALES_ORDER_ID;
                cmd.Parameters["@VENDOR_CODE"].Value = list[i].VENDOR_CODE;
                cmd.Parameters["@MATERIAL_CODE"].Value = list[i].MATERIAL_CODE;
                cmd.Parameters["@ORDER_QTY"].Value = Convert.ToDecimal(list[i].ORDER_QTY);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

    }
}
