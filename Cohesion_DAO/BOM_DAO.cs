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
                               where PRODUCT_TYPE <> 'ROH'";

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
                string sql = $@"select b.PRODUCT_CODE, CHILD_PRODUCT_CODE, p2.PRODUCT_NAME, REQUIRE_QTY, ALTER_PRODUCT_CODE, b.OPERATION_CODE, b.CREATE_TIME, b.CREATE_USER_ID, b.UPDATE_TIME, b.UPDATE_USER_ID, p2.PRODUCT_TYPE
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

        public bool InsertBOM(List<BOM_MST_DTO> bom)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"insert into BOM_MST(PRODUCT_CODE, CHILD_PRODUCT_CODE, REQUIRE_QTY, CREATE_TIME, CREATE_USER_ID)
                               values (@PRODUCT_CODE, @CHILD_PRODUCT_CODE, @REQUIRE_QTY, @CREATE_TIME, @CREATE_USER_ID)";

                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Transaction = trans;

                foreach (var item in bom)
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_CODE", item.PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", item.CHILD_PRODUCT_CODE);
                    cmd.Parameters.AddWithValue("@REQUIRE_QTY", item.REQUIRE_QTY);
                    cmd.Parameters.AddWithValue("@CREATE_TIME", item.CREATE_TIME);
                    cmd.Parameters.AddWithValue("@CREATE_USER_ID", item.CREATE_USER_ID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                trans.Commit();
                return true;
            }
            catch(Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);
                
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateBOM(List<BOM_MST_DTO> bom, string prodID)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            StringBuilder sb = new StringBuilder();
            bom.ForEach((s) => sb.Append("'" +s.CHILD_PRODUCT_CODE + "',"));
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                cmd.Connection = conn;
                string sql = $@"delete from BOM_MST where PRODUCT_CODE = @PRODUCT_CODE";
                if(bom.Count > 0)
                {
                    sql += $" and CHILD_PRODUCT_CODE not in ({sb.ToString().TrimEnd(',')}) ";
                }
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", prodID);
                cmd.CommandText = sql;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                
                string sql2 = @"declare @num int
                                set @num = (select count(*) from BOM_MST where PRODUCT_CODE = @PRODUCT_CODE and CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE)
                                if (@num <> 0)
                                begin
                                update BOM_MST set REQUIRE_QTY = @REQUIRE_QTY, ALTER_PRODUCT_CODE = @ALTER_PRODUCT_CODE, UPDATE_TIME = @UPDATE_TIME, UPDATE_USER_ID = @UPDATE_USER_ID
                                where PRODUCT_CODE = @PRODUCT_CODE and CHILD_PRODUCT_CODE = @CHILD_PRODUCT_CODE
                                end
                                else
                                begin
                                insert into BOM_MST (PRODUCT_CODE, CHILD_PRODUCT_CODE, REQUIRE_QTY, ALTER_PRODUCT_CODE, CREATE_TIME, CREATE_USER_ID)
                                values(@PRODUCT_CODE, @CHILD_PRODUCT_CODE, @REQUIRE_QTY, @ALTER_PRODUCT_CODE, @CREATE_TIME, @CREATE_USER_ID)
                                end";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Transaction = trans;
                foreach (var item in bom)
                {
                      
                    cmd2.Parameters.AddWithValue("@PRODUCT_CODE", item.PRODUCT_CODE);
                    cmd2.Parameters.AddWithValue("@CHILD_PRODUCT_CODE", item.CHILD_PRODUCT_CODE);
                    cmd2.Parameters.AddWithValue("@REQUIRE_QTY", item.REQUIRE_QTY);
                    cmd2.Parameters.AddWithValue("@CREATE_TIME", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@ALTER_PRODUCT_CODE", string.IsNullOrWhiteSpace(item.ALTER_PRODUCT_CODE) ? (object)DBNull.Value : item.ALTER_PRODUCT_CODE);
                    cmd2.Parameters.AddWithValue("@CREATE_USER_ID", string.IsNullOrWhiteSpace(item.CREATE_USER_ID) ? (object)DBNull.Value : item.CREATE_USER_ID);
                    cmd2.Parameters.AddWithValue("@UPDATE_TIME", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@UPDATE_USER_ID", string.IsNullOrWhiteSpace(item.UPDATE_USER_ID) ? (object)DBNull.Value : item.UPDATE_USER_ID);

                    cmd2.ExecuteNonQuery();
                    cmd2.Parameters.Clear();
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                Debug.WriteLine(err.StackTrace);

                return false;
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
                string sql = $@"delete BOM_MST
                               where PRODUCT_CODE = @PRODUCT_CODE 
                               and CHILD_PRODUCT_CODE in ({childCode})";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", parentCode);
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
