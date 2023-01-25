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
            string sql = @"SELECT SALES_ORDER_ID, ORDER_DATE, CUSTOMER_CODE, PRODUCT_CODE, ORDER_QTY, CONFIRM_FLAG, SHIP_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           FROM SALES_ORDER_MST
                           ORDER BY SALES_ORDER_ID DESC;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Sales_Order_DTO> list = Helper.DataReaderMapToList<Sales_Order_DTO>(cmd.ExecuteReader());

            return list;
        }
    }
}
