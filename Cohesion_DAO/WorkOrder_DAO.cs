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
                string sql = @"select WORK_ORDER_ID, ORDER_DATE, PRODUCT_CODE, CUSTOMER_CODE, ORDER_QTY, ORDER_STATUS, PRODUCT_QTY, DEFECT_QTY, WORK_START_TIME, WORK_CLOSE_TIME, WORK_CLOSE_USER_ID, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
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
    }
}
