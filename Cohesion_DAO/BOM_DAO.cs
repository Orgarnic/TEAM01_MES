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
    public class BOM_DAO : IDisposable
    {
        SqlConnection conn = null;
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public BOM_DAO()
        {
            conn = new SqlConnection(connstr);
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<PRODUCT_MST_DTO> SelectProductList()
        {
            string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           from PRODUCT_MST
                           where PRODUCT_TYPE = 'FERT'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<PRODUCT_MST_DTO> list = Helper.DataReaderMapToList<PRODUCT_MST_DTO>(cmd.ExecuteReader());
            conn.Close();

            return list;
        }
    }
}
