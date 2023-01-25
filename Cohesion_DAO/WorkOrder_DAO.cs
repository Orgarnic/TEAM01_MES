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

        public List<Work_Order_MST_DTO> SelectOrderList()
        {
            List<Work_Order_MST_DTO> list = null;
            try
            {
                string sql = @"select SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE, PRODUCT_CODE, ORDER_QTY
                               from SALES_ORDER_MST";

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
    }
}
