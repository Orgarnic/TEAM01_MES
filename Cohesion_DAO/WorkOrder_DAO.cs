using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Cohesion_DAO
{
    public class WorkOrder_DAO : IDisposable
    {
        int oNum, pNum, dNum;
        SqlConnection conn = null;
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public WorkOrder_DAO()
        {
            conn = new SqlConnection(connstr);
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Work_Order_MST_DTO> SelectWorkOrders(Work_Order_SEARCH_DTO search)
        {
            List<Work_Order_MST_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"select WORK_ORDER_ID, ORDER_DATE, PRODUCT_CODE, CUSTOMER_CODE, ORDER_QTY, ORDER_STATUS, PRODUCT_QTY, DEFECT_QTY, WORK_START_TIME, WORK_CLOSE_TIME, WORK_CLOSE_USER_ID, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID, convert(nvarchar(16),ORDER_DATE,120) WORK_CODE
                                                        from WORK_ORDER_MST
                                                        where 1 = 1");
                foreach (var prop in search.GetType().GetProperties())
                {
                    if (!string.IsNullOrWhiteSpace((string)prop.GetValue(search)))
                    {
                        sql.Append($" and {prop.Name} = @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(search).ToString());
                    }
                }
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                list = Helper.DataReaderMapToList<Work_Order_MST_DTO>(cmd.ExecuteReader());
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

        public List<Work_Order_MST_DTO> GetAllWorkOrderList()
        {
            List<Work_Order_MST_DTO> list = null;
            try
            {
                string sql = @"select WORK_ORDER_ID, ORDER_DATE, wo.PRODUCT_CODE, c.DATA_1 CUSTOMER_CODE, ORDER_QTY, ORDER_STATUS, PRODUCT_QTY, DEFECT_QTY, WORK_START_TIME, WORK_CLOSE_TIME, WORK_CLOSE_USER_ID, wo.CREATE_TIME, wo.CREATE_USER_ID, wo.UPDATE_TIME, wo.UPDATE_USER_ID, convert(nvarchar(16),ORDER_DATE,120) WORK_CODE
                               from WORK_ORDER_MST wo inner join PRODUCT_MST p on wo.PRODUCT_CODE = p.PRODUCT_CODE
													  inner join CODE_DATA_MST c on wo.CUSTOMER_CODE = c.KEY_1
                               order by ORDER_DATE DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<Work_Order_MST_DTO>(cmd.ExecuteReader());

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

        public List<Sales_Order_Work_DTO> SelectOrderList()
        {
            List<Sales_Order_Work_DTO> list = null;
            try
            {
                /*string sql = @"select so.SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY
                               from SALES_ORDER_MST so inner join PRODUCT_MST p on so.PRODUCT_CODE = p.PRODUCT_CODE
							   where so.CONFIRM_FLAG = 'Y' and so.SHIP_FLAG is null
							   group by so.SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY";
*/
                // 완제품 LOT 수량을 가져와서 비교 - LOT_SYS에 완제품이 다 들어가 있어야한다.
                string sql = @"select SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY, sum(l.LOT_QTY) LOT_QTY
                               from SALES_ORDER_MST so inner join PRODUCT_MST p on so.PRODUCT_CODE = p.PRODUCT_CODE
													   left join LOT_STS l on so.PRODUCT_CODE = l.PRODUCT_CODE
							   where so.CONFIRM_FLAG = 'Y' and so.SHIP_FLAG is null
							   group by SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY
                               order by so.ORDER_DATE desc";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<Sales_Order_Work_DTO>(cmd.ExecuteReader());

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

        public List<BOM_MST_WORKORDER_DTO> GetOrderProductBOM(string ocode, string pcode)
        {
            // LOT 완성되면 쿼리 수정이 필요함.
            // 안전 재고수량, 현 재고수량, order 수량에 필요한 갯수 등등
            List<BOM_MST_WORKORDER_DTO> list = null;
            string sql = @"with BOM as(select b.CHILD_PRODUCT_CODE, pd2.PRODUCT_NAME, REQUIRE_QTY, pd2.PRODUCT_TYPE, so.ORDER_QTY, pd2.VENDOR_CODE
                                       from SALES_ORDER_MST so inner join PRODUCT_MST pd on so.PRODUCT_CODE = pd.PRODUCT_CODE
						                                       inner join BOM_MST b on so.PRODUCT_CODE = b.PRODUCT_CODE
						                                       inner join PRODUCT_MST pd2 on b.CHILD_PRODUCT_CODE = pd2.PRODUCT_CODE
                                       where 1 = 1 and SALES_ORDER_ID = @SALES_ORDER_ID and so.PRODUCT_CODE = @PRODUCT_CODE
						               group by b.CHILD_PRODUCT_CODE, pd2.PRODUCT_NAME, pd2.VENDOR_CODE, REQUIRE_QTY, pd2.PRODUCT_TYPE, so.ORDER_QTY)
						               select CHILD_PRODUCT_CODE, PRODUCT_NAME, REQUIRE_QTY, PRODUCT_TYPE, ORDER_QTY, isnull(sum(ls.LOT_QTY), 0) LOT_QTY, VENDOR_CODE
						               from BOM m left join LOT_STS ls on m.CHILD_PRODUCT_CODE = ls.PRODUCT_CODE
									   group by CHILD_PRODUCT_CODE, PRODUCT_NAME, REQUIRE_QTY, PRODUCT_TYPE, ORDER_QTY, VENDOR_CODE, LOT_QTY";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SALES_ORDER_ID", ocode);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", pcode);
                conn.Open();

                list = Helper.DataReaderMapToList<BOM_MST_WORKORDER_DTO>(cmd.ExecuteReader());

                return list;

            }
            catch(Exception err)
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
        //--------------------------------------------- 프로시저 상태 현재 데이터 바인딩용으로 설정되어있음 -----------------------------------------
        public bool InsertWorkOrder(Work_Order_MST_DTO work)
        {
            pNum = Convert.ToInt32(work.PRODUCT_QTY);
            dNum = Convert.ToInt32(work.DEFECT_QTY);
            try
            {
                SqlCommand cmd = new SqlCommand("SP_InsertWorkOrderCode", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE);
                cmd.Parameters.AddWithValue("@ORDER_DATE", work.ORDER_DATE);
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", work.CUSTOMER_CODE);
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", pNum > 0 ? pNum : 0);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", dNum > 0 ? dNum : 0);
                cmd.Parameters.AddWithValue("@WORK_START_TIME", DBNull.Value);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", DBNull.Value);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", DBNull.Value);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", work.CREATE_USER_ID);
                cmd.Parameters.AddWithValue("@UPDATE_TIME", DBNull.Value);
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", DBNull.Value);

                conn.Open();
                int iRowAffect = cmd.ExecuteNonQuery();

                return (iRowAffect > 0);
            }
            catch(Exception err)
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

      public bool EndWorkOrder(Work_Order_MST_DTO order)
      {
         try
         {
            string sql = @"update WORK_ORDER_MST
                               set ORDER_STATUS = 'CLOSE'
                                 , WORK_CLOSE_TIME = @WORK_CLOSE_TIME
                                 , WORK_CLOSE_USER_ID = @WORK_CLOSE_USER_ID
                                 , UPDATE_TIME = @UPDATE_TIME
                                 , UPDATE_USER_ID = @UPDATE_USER_ID
                               where WORK_ORDER_ID = @WORK_ORDER_ID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", order.CREATE_TIME);
            cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", order.UPDATE_USER_ID);
            cmd.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
            cmd.Parameters.AddWithValue("@UPDATE_USER_ID", order.UPDATE_USER_ID);
            cmd.Parameters.AddWithValue("@WORK_ORDER_ID", order.WORK_ORDER_ID);

            conn.Open();
            int iRowAffect = cmd.ExecuteNonQuery();

            return (iRowAffect > 0);
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

      public bool UpdateWorkOrder(Work_Order_MST_DTO work, string uid)
        {
            pNum = Convert.ToInt32(work.PRODUCT_QTY);
            dNum = Convert.ToInt32(work.DEFECT_QTY);
            try
            {
                string sql = @"update WORK_ORDER_MST
                               set PRODUCT_CODE = @PRODUCT_CODE
                                 , ORDER_QTY = @ORDER_QTY
                                 , ORDER_STATUS = @ORDER_STATUS
                                 , PRODUCT_QTY = @PRODUCT_QTY
                                 , DEFECT_QTY = @DEFECT_QTY
                                 , WORK_START_TIME = @WORK_START_TIME
                                 , WORK_CLOSE_TIME = @WORK_CLOSE_TIME
                                 , WORK_CLOSE_USER_ID = @WORK_CLOSE_USER_ID
                                 , UPDATE_TIME = getdate()
                                 , UPDATE_USER_ID = @UPDATE_USER_ID
                               where WORK_ORDER_ID = @WORK_ORDER_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", work.WORK_ORDER_ID);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE != null ? work.PRODUCT_CODE : (object)DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", pNum);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", dNum);
                cmd.Parameters.AddWithValue("@WORK_START_TIME", work.WORK_START_TIME != null ? work.WORK_START_TIME : (object)DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", work.WORK_CLOSE_TIME != null ? work.WORK_CLOSE_TIME : (object)DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", work.WORK_CLOSE_USER_ID != null ? work.WORK_CLOSE_USER_ID : (object)DBNull.Value.ToString());
                //cmd.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", uid);

                conn.Open();
                int iRowAffect = cmd.ExecuteNonQuery();

                return (iRowAffect > 0);
            }
            catch(Exception err)
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

        public bool DeleteWorkOrder(string wCode)
        {
            try
            {
                string sql = @"delete WORK_ORDER_MST
                               where  WORK_ORDER_ID = @WORK_ORDER_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@WORK_ORDER_ID", wCode);
                conn.Open();

                int iRowAffect = cmd.ExecuteNonQuery();

                return (iRowAffect > 0);
            }
            catch(Exception err)
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

        public List<PRODUCT_OPERATION_REL_DTO> GetOperationRel()
        {
            // LOT 완성되면 쿼리 수정이 필요함.
            // 안전 재고수량, 현 재고수량, order 수량에 필요한 갯수 등등
            List<PRODUCT_OPERATION_REL_DTO> list = null;
            string sql = @"select PRODUCT_CODE, OPERATION_CODE, FLOW_SEQ, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           from PRODUCT_OPERATION_REL";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<PRODUCT_OPERATION_REL_DTO>(cmd.ExecuteReader());

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

        public List<PRODUCT_MST_DTO> GetAllProduct()
        {
            // LOT 완성되면 쿼리 수정이 필요함.
            // 안전 재고수량, 현 재고수량, order 수량에 필요한 갯수 등등
            List<PRODUCT_MST_DTO> list = null;
            string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           from PRODUCT_MST";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<PRODUCT_MST_DTO>(cmd.ExecuteReader());
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

        public bool UpdateOrderShip(string order)
        {
            try
            {
                string sql = @"update SALES_ORDER_MST
                               set SHIP_FLAG = 'N'
                               where SALES_ORDER_ID = @SALES_ORDER_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SALES_ORDER_ID", order);

                conn.Open();
                int iRowAffect = cmd.ExecuteNonQuery();

                return (iRowAffect > 0);
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

        //주문 코드, 주문 일자, 고객 코드, 제품 코드 -> 검색 조건
        public List<Work_Order_MST_DTO> GetLotInspectHisInfo(string orderid = null, string orderdate = null, string Customer = null, string prod = null)
        {
            string where;
            
            StringBuilder sb = new StringBuilder();
            try
            {
                string sql = @"with WORK as 
                               (
                               select SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY, sum(l.LOT_QTY) LOT_QTY
                                                              from SALES_ORDER_MST so inner join PRODUCT_MST p on so.PRODUCT_CODE = p.PRODUCT_CODE
												                                   left join LOT_STS l on so.PRODUCT_CODE = l.PRODUCT_CODE
							                                  where so.CONFIRM_FLAG = 'Y' and so.SHIP_FLAG is null
							                                  group by SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY
                                                              --order by so.ORDER_DATE desc
                               )
                               select SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE, PRODUCT_CODE, ORDER_QTY, LOT_QTY
                               from WORK
                               where 1 = 1";

                sb.Append(sql);
                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrWhiteSpace(orderid))
                    sb.Append($" and SALES_ORDER_ID = '" + orderid + "'");
                if (!string.IsNullOrWhiteSpace(orderdate))
                    sb.Append($" and ORDER_DATE = '" + orderdate + "'");
                if (!string.IsNullOrWhiteSpace(Customer))
                    sb.Append($" and CUSTOMER_CODE = '" + Customer + "'");
                if (!string.IsNullOrWhiteSpace(prod))
                    sb.Append($" and PRODUCT_CODE = '" + prod + "'");

                sb.Append("order by ORDER_DATE desc");
                cmd.CommandText = sb.ToString();
                cmd.Connection = conn;


                conn.Open();
                List<Work_Order_MST_DTO> list = Helper.DataReaderMapToList<Work_Order_MST_DTO>(cmd.ExecuteReader());

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
    }
}
