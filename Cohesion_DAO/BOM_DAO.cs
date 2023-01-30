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

        public List<PRODUCT_MST_DTO> SelectGetProduct(BOM_PRODUCT_SEARCH search)
        {
            List<PRODUCT_MST_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                                        from PRODUCT_MST
                                                        where 1 = 1");

                foreach (var property in search.GetType().GetProperties())
                {
                    if (!string.IsNullOrWhiteSpace((string)property.GetValue(search)))
                    {
                        sql.Append($" and {property.Name} = @{property.Name}");
                        cmd.Parameters.AddWithValue($"@{property.Name}", property.GetValue(search).ToString());
                    }
                }
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();

                list = Helper.DataReaderMapToList<PRODUCT_MST_DTO>(cmd.ExecuteReader());

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public List<PRODUCT_MST_DTO> SelectGetAllProductList()
        {
            List<PRODUCT_MST_DTO> list = null;

            try
            {
                string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                               from PRODUCT_MST
                               where PRODUCT_TYPE = 'FERT'";

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

        public List<BOM_MST_DTO> SelectBOMList(string code)
        {
            List<BOM_MST_DTO> list = null;

            try
            {
                string sql = $@"select CHILD_PRODUCT_CODE, p2.PRODUCT_NAME, REQUIRE_QTY, ALTER_PRODUCT_CODE, b.CREATE_TIME, b.CREATE_USER_ID, b.UPDATE_TIME, b.UPDATE_USER_ID
                                from BOM_MST b inner join PRODUCT_MST p on b.PRODUCT_CODE = p.PRODUCT_CODE
			                                   inner join PRODUCT_MST p2 on b.CHILD_PRODUCT_CODE = p2.PRODUCT_CODE
                                where p.PRODUCT_CODE = '" + $"{code}" + "' ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                list = Helper.DataReaderMapToList<BOM_MST_DTO>(cmd.ExecuteReader());

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

        public bool DeleteProduct(string parentCode, string childCode)
        {
            try
            {
                string sql = @"delete BOM_MST
                               where PRODUCT_CODE = @PRODUCT_CODE 
                               and CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", parentCode);
                cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", childCode);
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
    }
}
