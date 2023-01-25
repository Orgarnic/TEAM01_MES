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

        public List<Sales_Order_DTO> SelectOrderList()
        {
            List<Sales_Order_DTO> list = null;
            try
            {
                string sql = @"select SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE, PRODUCT_CODE, ORDER_QTY
                               from SALES_ORDER_MST";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<Sales_Order_DTO>(cmd.ExecuteReader());

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

        public bool InsertWorkOrder(Work_Order_MST_DTO work)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_InsertWorkOrderCode", conn);
                cmd.Parameters.AddWithValue("@ORDER_DATE", work.ORDER_DATE);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE);
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", work.CUSTOMER_CODE);
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", null);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", null);
                cmd.Parameters.AddWithValue("@WORK_START_TIME", null);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", null);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", null);
                cmd.Parameters.AddWithValue("@CREATE_TIME", work.CREATE_TIME);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", work.CREATE_USER_ID);
                cmd.Parameters.AddWithValue("@UPDATE_TIME", null);
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", null);

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
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", work.PRODUCT_CODE);
                cmd.Parameters.AddWithValue("@ORDER_QTY", work.ORDER_QTY);
                cmd.Parameters.AddWithValue("@ORDER_STATUS", work.ORDER_STATUS);
                cmd.Parameters.AddWithValue("@PRODUCT_QTY", work.PRODUCT_QTY);
                cmd.Parameters.AddWithValue("@DEFECT_QTY", work.DEFECT_QTY);
                cmd.Parameters.AddWithValue("@WORK_START_TIME", work.WORK_START_TIME);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_TIME", work.WORK_CLOSE_TIME);
                cmd.Parameters.AddWithValue("@WORK_CLOSE_USER_ID", work.WORK_CLOSE_USER_ID);
                cmd.Parameters.AddWithValue("@UPDATE_TIME", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                cmd.Parameters.AddWithValue("@UPDATE_USER_ID", work.UPDATE_USER_ID);
                // type이 datetime인 property들을 string으로 변경 필요.

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
    }
}
