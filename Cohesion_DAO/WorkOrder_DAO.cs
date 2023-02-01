﻿using System;
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

        public List<Work_Order_MST_DTO> GetAllWorkOrderList()
        {
            List<Work_Order_MST_DTO> list = null;
            try
            {
                string sql = @"select WORK_ORDER_ID, ORDER_DATE, PRODUCT_CODE, CUSTOMER_CODE, ORDER_QTY, ORDER_STATUS, PRODUCT_QTY, DEFECT_QTY, WORK_START_TIME, WORK_CLOSE_TIME, WORK_CLOSE_USER_ID, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID, convert(nvarchar(16),ORDER_DATE,120) WORK_CODE
                               from WORK_ORDER_MST";

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
                string sql = @"select SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY
                               from SALES_ORDER_MST so inner join PRODUCT_MST p on so.PRODUCT_CODE = p.PRODUCT_CODE
							   where so.CONFIRM_FLAG = 'Y' and so.SHIP_FLAG is null
							   group by so.SALES_ORDER_ID, so.ORDER_DATE, so.CUSTOMER_CODE, so.PRODUCT_CODE, so.ORDER_QTY";

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

        public List<BOM_MST_DTO> GetOrderProductBOM(string ocode, string pcode)
        {
            // LOT 완성되면 쿼리 수정이 필요함.
            // 안전 재고수량, 현 재고수량, order 수량에 필요한 갯수 등등
            List<BOM_MST_DTO> list = null;
            string sql = @"with BOM as(select b.CHILD_PRODUCT_CODE, pd2.PRODUCT_NAME, REQUIRE_QTY, pd2.PRODUCT_TYPE, so.ORDER_QTY
                                       from SALES_ORDER_MST so inner join PRODUCT_MST pd on so.PRODUCT_CODE = pd.PRODUCT_CODE
						                                       inner join BOM_MST b on so.PRODUCT_CODE = b.PRODUCT_CODE
						                                       inner join PRODUCT_MST pd2 on b.CHILD_PRODUCT_CODE = pd2.PRODUCT_CODE
                                       where 1 = 1 and SALES_ORDER_ID = @SALES_ORDER_ID and so.PRODUCT_CODE = @PRODUCT_CODE
						               group by b.CHILD_PRODUCT_CODE, pd2.PRODUCT_NAME, REQUIRE_QTY, pd2.PRODUCT_TYPE, so.ORDER_QTY)
						               select CHILD_PRODUCT_CODE, PRODUCT_NAME, REQUIRE_QTY, PRODUCT_TYPE, ORDER_QTY, ls.LOT_QTY
						               from BOM m inner join LOT_STS ls on m.CHILD_PRODUCT_CODE = ls.PRODUCT_CODE";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SALES_ORDER_ID", ocode);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", pcode);
                conn.Open();

                list = Helper.DataReaderMapToList<BOM_MST_DTO>(cmd.ExecuteReader());

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

        public bool InsertWorkOrder(Work_Order_MST_DTO work)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_InsertWorkOrderCode", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE);
                cmd.Parameters.AddWithValue("@ORDER_DATE", work.ORDER_DATE);
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", work.CUSTOMER_CODE);
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", work.PRODUCT_QTY > 0 ? work.PRODUCT_QTY : 0);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", work.PRODUCT_QTY > 0 ? work.PRODUCT_QTY : 0);
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

        public bool UpdateWorkOrder(Work_Order_MST_DTO work, string uid)
        {
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
                                 , UPDATE_TIME = @UPDATE_TIME
                                 , UPDATE_USER_ID = @UPDATE_USER_ID
                               where WORK_ORDER_ID = @WORK_ORDER_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE != null ? work.PRODUCT_CODE : DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY > 0 ? work.ORDER_QTY : 0);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", work.PRODUCT_QTY > 0 ? work.PRODUCT_QTY : 0);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", work.DEFECT_QTY > 0 ? work.DEFECT_QTY : 0);
                cmd.Parameters.AddWithValue("@WORK_START_TIME", work.WORK_START_TIME);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", work.WORK_CLOSE_TIME);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", work.WORK_CLOSE_USER_ID != null ? work.WORK_CLOSE_USER_ID : DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
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
    }
}
