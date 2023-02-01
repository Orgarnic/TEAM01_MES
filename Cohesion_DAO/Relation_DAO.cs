using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cohesion_DTO;

namespace Cohesion_DAO
{
    public class Relation_DAO : IDisposable
    {
        SqlConnection conn = null;
        readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public Relation_DAO()
        {
            conn = new SqlConnection(DB);
        }
        public void Dispose()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        
        
        public List<Inspection_DTO> SelectInsWithOper(string operationCode)
        {
            try
            {
                string sql = @"SELECT O.INSPECT_ITEM_CODE, I.INSPECT_ITEM_NAME, O.CREATE_TIME, O.CREATE_USER_ID, O.UPDATE_TIME, O.UPDATE_USER_ID
                               FROM INSPECT_ITEM_OPERATION_REL O
                               INNER JOIN INSPECT_ITEM_MST I ON O.INSPECT_ITEM_CODE = I.INSPECT_ITEM_CODE
                               WHERE OPERATION_CODE = @OPERATION_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                conn.Open();
                var list = Helper.DataReaderMapToList<Inspection_DTO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }

            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool InsertInsWithOper(string operationCode, List<Inspection_REL_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"INSERT INTO INSPECT_ITEM_OPERATION_REL (OPERATION_CODE, INSPECT_ITEM_CODE, CREATE_TIME, CREATE_USER_ID)
                               VALUES (@OPERATION_CODE, @INSPECT_ITEM_CODE, GETDATE(), @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", "서지환");
                cmd.Parameters.Add("@INSPECT_ITEM_CODE", System.Data.SqlDbType.VarChar);
                for (int i = 0; i < list.Count; i++)
                {
                    cmd.Parameters["@INSPECT_ITEM_CODE"].Value = list[i].INSPECT_ITEM_CODE;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool UpdateInsWithOper(string operationCode, List<Inspection_REL_DTO> list)
        {

            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                StringBuilder sb = new StringBuilder();
                list.ForEach((c) => sb.Append(c.INSPECT_ITEM_CODE + "','"));
                string codes = "'" + sb.ToString().TrimEnd(',', '\'') + "'";
                string sql1 = $@"DELETE INSPECT_ITEM_OPERATION_REL WHERE OPERATION_CODE = @OPERATION_CODE AND INSPECT_ITEM_CODE NOT IN (SELECT DISTINCT EQUIPMENT_CODE
                                                                                                                                     FROM INSPECT_ITEM_OPERATION_REL
                                                                                                                                     WHERE INSPECT_ITEM_CODE IN ({codes}))";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                cmd.Transaction = trans;
                int irow = cmd.ExecuteNonQuery();
                trans.Commit();
                conn.Close();

                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = @"DECLARE @INS INT
                                        SET @INS = (SELECT COUNT(*) FROM EQUIPMENT_OPERATION_REL WHERE OPERATION_CODE = @OPERATION_CODE AND INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE)       
                                        IF @INS > 0
                                        BEGIN 
                                            UPDATE INSPECT_ITEM_OPERATION_REL SET UPDATE_TIME = GETDATE(), UPDATE_USER_ID = @UPDATE_USER_ID
                                            WHERE OPERATION_CODE = @OPERATION_CODE AND INSPECT_ITEM_CODE = @INSPECT_ITEM_CODE
                                        END
                                        ELSE
                                        BEGIN
                                         	INSERT INTO  EQUIPMENT_OPERATION_REL (OPERATION_CODE, INSPECT_ITEM_CODE, CREATE_TIME, CREATE_USER_ID)
                                                                    		VALUES (@OPERATION_CODE, @INSPECT_ITEM_CODE, GETDATE(), @CREATE_USER_ID)
                                        END;";
                cmd2.Parameters.Add(new SqlParameter("@OPERATION_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@INSPECT_ITEM_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@UPDATE_USER_ID", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar));

                cmd2.Transaction = trans;
                for (int i = 0; i < list.Count; i++)
                {
                    cmd2.Parameters["@OPERATION_CODE"].Value = operationCode;
                    cmd2.Parameters["@UPDATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@CREATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@INSPECT_ITEM_CODE"].Value = list[i].INSPECT_ITEM_CODE;
                    cmd2.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
        }


        public List<Equipment_DTO> SelectEquipWithOper(string operationCode)
        {
            try
            {
                string sql = @"SELECT O.EQUIPMENT_CODE, E.EQUIPMENT_NAME, O.CREATE_TIME, O.CREATE_USER_ID, O.UPDATE_TIME, O.UPDATE_USER_ID
                               FROM EQUIPMENT_OPERATION_REL O
                               INNER JOIN EQUIPMENT_MST E ON O.EQUIPMENT_CODE = E.EQUIPMENT_CODE
                               WHERE OPERATION_CODE = @OPERATION_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                conn.Open();
                var list = Helper.DataReaderMapToList<Equipment_DTO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }

            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool InsertEquipWithOper(string operationCode, List<Equipment_REL_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"INSERT INTO EQUIPMENT_OPERATION_REL (OPERATION_CODE, EQUIPMENT_CODE, CREATE_TIME, CREATE_USER_ID)
                               VALUES (@OPERATION_CODE, @EQUIPMENT_CODE, GETDATE(), @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", "서지환");
                cmd.Parameters.Add("@EQUIPMENT_CODE", System.Data.SqlDbType.VarChar);
                for (int i = 0; i < list.Count; i++)
                {
                    cmd.Parameters["@EQUIPMENT_CODE"].Value = list[i].EQUIPMENT_CODE;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool UpdateEquipWithOper(string operationCode, List<Equipment_REL_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                StringBuilder sb = new StringBuilder();
                list.ForEach((c) => sb.Append(c.EQUIPMENT_CODE+"','"));
                string codes = "'"+sb.ToString().TrimEnd(',','\'')+"'";
                string sql1 = $@"DELETE EQUIPMENT_OPERATION_REL WHERE OPERATION_CODE = @OPERATION_CODE AND EQUIPMENT_CODE NOT IN (SELECT DISTINCT EQUIPMENT_CODE
                                                                                                                                     FROM EQUIPMENT_OPERATION_REL
                                                                                                                                     WHERE EQUIPMENT_CODE IN ({codes}))";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@OPERATION_CODE", operationCode);
                cmd.Transaction = trans;
                int irow=cmd.ExecuteNonQuery();
                trans.Commit();
                conn.Close();

                conn.Open();
                trans=conn.BeginTransaction();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = @"DECLARE @EQUIP INT
                                        SET @EQUIP = (SELECT COUNT(*) FROM EQUIPMENT_OPERATION_REL WHERE OPERATION_CODE = @OPERATION_CODE AND EQUIPMENT_CODE = @EQUIPMENT_CODE)       
                                        IF @EQUIP > 0
                                        BEGIN 
                                            UPDATE EQUIPMENT_OPERATION_REL SET UPDATE_TIME = GETDATE(), UPDATE_USER_ID = @UPDATE_USER_ID
                                            WHERE OPERATION_CODE = @OPERATION_CODE AND EQUIPMENT_CODE = @EQUIPMENT_CODE
                                        END
                                        ELSE
                                        BEGIN
                                         	INSERT INTO  EQUIPMENT_OPERATION_REL (OPERATION_CODE, EQUIPMENT_CODE, CREATE_TIME, CREATE_USER_ID)
                                                                    		VALUES (@OPERATION_CODE, @EQUIPMENT_CODE, GETDATE(), @CREATE_USER_ID)
                                        END;";
                cmd2.Parameters.Add(new SqlParameter("@OPERATION_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@EQUIPMENT_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@UPDATE_USER_ID", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar));
                
                cmd2.Transaction = trans;
                for (int i = 0; i < list.Count; i++)
                {
                    cmd2.Parameters["@OPERATION_CODE"].Value = operationCode;
                    cmd2.Parameters["@UPDATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@CREATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@EQUIPMENT_CODE"].Value = list[i].EQUIPMENT_CODE;
                    cmd2.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
        }


        public List<OPERATION_REL_DTO> SelectOperWithProduct(string productCode)
        {
            try
            {
                string sql = @"SELECT O.OPERATION_CODE,O.OPERATION_NAME, FLOW_SEQ as DISPLAY_SEQ
                               FROM PRODUCT_OPERATION_REL P
                               INNER JOIN OPERATION_MST O ON O.OPERATION_CODE = P.OPERATION_CODE
                               WHERE PRODUCT_CODE = @PRODUCT_CODE";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                conn.Open();
                var list = Helper.DataReaderMapToList<OPERATION_REL_DTO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }

            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool InsertOperWithProduct(string productCode, List<OPERATION_REL_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"INSERT INTO PRODUCT_OPERATION_REL (PRODUCT_CODE, OPERATION_CODE, FLOW_SEQ, CREATE_TIME, CREATE_USER_ID)
                               VALUES (@PRODUCT_CODE, @OPERATION_CODE,@FLOW_SEQ, GETDATE(), @CREATE_USER_ID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                cmd.Parameters.AddWithValue("@CREATE_USER_ID", "서지환");
                cmd.Parameters.Add("@OPERATION_CODE", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@FLOW_SEQ", System.Data.SqlDbType.Decimal);
                for (int i = 0; i < list.Count; i++)
                {
                    cmd.Parameters["@OPERATION_CODE"].Value = list[i].OPERATION_CODE;
                    cmd.Parameters["@FLOW_SEQ"].Value = list[i].DISPLAY_SEQ;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
        }
        public bool UpdateOperWithProduct(string productCode, List<OPERATION_REL_DTO> list)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                StringBuilder sb = new StringBuilder();
                list.ForEach((c) => sb.Append(c.OPERATION_CODE + "','"));
                string codes = "'" + sb.ToString().TrimEnd(',', '\'') + "'";
                string sql1 = $@"DELETE PRODUCT_OPERATION_REL WHERE PRODUCT_CODE = @PRODUCT_CODE AND OPERATION_CODE NOT IN (SELECT DISTINCT OPERATION_CODE
                                                                                                                                     FROM PRODUCT_OPERATION_REL
                                                                                                                                     WHERE OPERATION_CODE IN ({codes}))";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                cmd.Transaction = trans;
                int irow = cmd.ExecuteNonQuery();
                trans.Commit();
                conn.Close();

                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = @"DECLARE @OPER INT
                                        SET @OPER = (SELECT COUNT(*) FROM PRODUCT_OPERATION_REL WHERE PRODUCT_CODE = @PRODUCT_CODE AND OPERATION_CODE = @OPERATION_CODE)       
                                        IF @OPER > 0
                                        BEGIN 
                                            UPDATE PRODUCT_OPERATION_REL SET UPDATE_TIME = GETDATE(), UPDATE_USER_ID = @UPDATE_USER_ID, FLOW_SEQ=@FLOW_SEQ
                                            WHERE PRODUCT_CODE = @PRODUCT_CODE AND OPERATION_CODE = @OPERATION_CODE
                                        END
                                        ELSE
                                        BEGIN
                                         	INSERT INTO  PRODUCT_OPERATION_REL (PRODUCT_CODE, OPERATION_CODE, FLOW_SEQ,CREATE_TIME, CREATE_USER_ID)
                                                                    		VALUES (@PRODUCT_CODE, @OPERATION_CODE, @FLOW_SEQ, GETDATE(), @CREATE_USER_ID)
                                        END;";
                cmd2.Connection = conn;
                cmd2.Parameters.Add(new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@OPERATION_CODE", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@UPDATE_USER_ID", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@CREATE_USER_ID", SqlDbType.VarChar));
                cmd2.Parameters.Add(new SqlParameter("@FLOW_SEQ", System.Data.SqlDbType.Decimal));


                cmd2.Transaction = trans;
                for (int i = 0; i < list.Count; i++)
                {
                    cmd2.Parameters["@PRODUCT_CODE"].Value = productCode;
                    cmd2.Parameters["@UPDATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@CREATE_USER_ID"].Value = "서지환";
                    cmd2.Parameters["@OPERATION_CODE"].Value = list[i].OPERATION_CODE;
                    cmd2.Parameters["@FLOW_SEQ"].Value = list[i].DISPLAY_SEQ;
                    cmd2.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }

            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }

            finally
            {
                conn.Close();
            }
            
        }

        public List<Operation_Inspection_Rel_DTO> SelectOperationInRel(Operation_Inspection_Rel_DTO condition)
        {
            List<Operation_Inspection_Rel_DTO> list = new List<Operation_Inspection_Rel_DTO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"SELECT OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG,
                                                           CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, 
                                                           CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                                        FROM OPERATION_MST WHERE 1 = 1");
                foreach (var prop in condition.GetType().GetProperties())
                {
                    if (prop.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace((string)prop.GetValue(condition)))
                    {
                        sql.Append($" and {prop.Name} like @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", "%" + prop.GetValue(condition).ToString() + "%");
                    }
                    else if (prop.PropertyType == typeof(char) && (char)prop.GetValue(condition) != '\0')
                    {
                        sql.Append($" and {prop.Name} = @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(condition).ToString());
                    }
                }

                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Operation_Inspection_Rel_DTO dto = new Operation_Inspection_Rel_DTO();
                    dto.OPERATION_CODE = reader["OPERATION_CODE"].ToString();
                    dto.OPERATION_NAME = reader["OPERATION_NAME"].ToString();
                    if (reader["CHECK_DEFECT_FLAG"] != DBNull.Value)
                        dto.CHECK_DEFECT_FLAG = Convert.ToChar(reader["CHECK_DEFECT_FLAG"]);
                    if (reader["CHECK_INSPECT_FLAG"] != DBNull.Value)
                        dto.CHECK_INSPECT_FLAG = Convert.ToChar(reader["CHECK_INSPECT_FLAG"]);
                    if (reader["CHECK_MATERIAL_FLAG"] != DBNull.Value)
                        dto.CHECK_MATERIAL_FLAG = Convert.ToChar(reader["CHECK_MATERIAL_FLAG"]);
                    if (reader["CREATE_TIME"] != DBNull.Value)
                        dto.CREATE_TIME = Convert.ToDateTime(reader["CREATE_TIME"]);
                    dto.CREATE_USER_ID = reader["CREATE_USER_ID"].ToString();
                    if (reader["UPDATE_TIME"] != DBNull.Value)
                        dto.UPDATE_TIME = Convert.ToDateTime(reader["UPDATE_TIME"]);
                    dto.UPDATE_USER_ID = reader["UPDATE_USER_ID"].ToString();
                    list.Add(dto);
                }
                conn.Close();
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
        public List<PRODUCT_OPERATION_REL_DTO> SelectProductInRel(PRODUCT_OPERATION_REL_DTO condition)
        {
            List<PRODUCT_OPERATION_REL_DTO> list = new List<PRODUCT_OPERATION_REL_DTO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(@"SELECT PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, 
                                                               VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                                        FROM PRODUCT_MST
                                                        WHERE 1 = 1");
                foreach (var prop in condition.GetType().GetProperties())
                {
                    if (prop.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace((string)prop.GetValue(condition)))
                    {
                        sql.Append($" and {prop.Name} like @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", "%" + prop.GetValue(condition).ToString() + "%");
                    }
                    else if (prop.PropertyType == typeof(char) && (char)prop.GetValue(condition) != '\0')
                    {
                        sql.Append($" and {prop.Name} = @{prop.Name}");
                        cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(condition).ToString());
                    }
                }

                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PRODUCT_OPERATION_REL_DTO dto = new PRODUCT_OPERATION_REL_DTO();
                    dto.PRODUCT_CODE = reader["PRODUCT_CODE"].ToString();
                    dto.PRODUCT_NAME = reader["PRODUCT_NAME"].ToString();
                    dto.PRODUCT_TYPE = reader["PRODUCT_TYPE"].ToString();
                    dto.CUSTOMER_CODE = reader["CUSTOMER_CODE"].ToString();
                    dto.VENDOR_CODE = reader["VENDOR_CODE"].ToString();
                    if (reader["CREATE_TIME"] != DBNull.Value)
                        dto.CREATE_TIME = Convert.ToDateTime(reader["CREATE_TIME"]);
                    dto.CREATE_USER_ID = reader["CREATE_USER_ID"].ToString();
                    if (reader["UPDATE_TIME"] != DBNull.Value)
                        dto.UPDATE_TIME = Convert.ToDateTime(reader["UPDATE_TIME"]);
                    dto.UPDATE_USER_ID = reader["UPDATE_USER_ID"].ToString();
                    list.Add(dto);
                }
                conn.Close();
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

        public List<PRODUCT_OPERATION_REL_DTO> SelectProductInRel()
        {
            try
            {
                string sql = @"SELECT PRODUCT_CODE, PRODUCT_NAME, PRODUCT_TYPE, CUSTOMER_CODE, 
                                      VENDOR_CODE, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                               FROM PRODUCT_MST";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var list = Helper.DataReaderMapToList<PRODUCT_OPERATION_REL_DTO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Equipment_DTO> SelectEquipment(Equipment_DTO condtion)
        {
            List<Equipment_DTO> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                StringBuilder sql = new StringBuilder(
                    @"SELECT EQUIPMENT_CODE, EQUIPMENT_NAME, EQUIPMENT_TYPE, EQUIPMENT_STATUS, LAST_DOWN_TIME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                      FROM EQUIPMENT_MST
                      WHERE 1 = 1");
                if (!string.IsNullOrWhiteSpace(condtion.EQUIPMENT_CODE))
                {
                    sql.Append(" and EQUIPMENT_CODE = @EQUIPMENT_CODE ");
                    cmd.Parameters.AddWithValue("@EQUIPMENT_CODE", condtion.EQUIPMENT_CODE);
                }
                if (!string.IsNullOrWhiteSpace(condtion.EQUIPMENT_NAME))
                {
                    sql.Append(" and EQUIPMENT_NAME = @EQUIPMENT_NAME ");
                    cmd.Parameters.AddWithValue("@EQUIPMENT_NAME", condtion.EQUIPMENT_NAME);
                }
                if (!string.IsNullOrWhiteSpace(condtion.EQUIPMENT_TYPE))
                {
                    sql.Append(" and EQUIPMENT_TYPE = @EQUIPMENT_TYPE ");
                    cmd.Parameters.AddWithValue("@EQUIPMENT_TYPE", condtion.EQUIPMENT_TYPE);
                }
                if (!string.IsNullOrWhiteSpace(condtion.EQUIPMENT_STATUS))
                {
                    sql.Append(" and EQUIPMENT_STATUS = @EQUIPMENT_STATUS ");
                    cmd.Parameters.AddWithValue("@EQUIPMENT_STATUS", condtion.EQUIPMENT_STATUS);
                }
                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;
                conn.Open();
                list = Helper.DataReaderMapToList<Equipment_DTO>(cmd.ExecuteReader());
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
    }
}
