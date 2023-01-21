using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;

namespace Cohesion_DAO
{
   public class Operation_DAO : IDisposable
   {
      SqlConnection conn = null;
      readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
      public Operation_DAO()
      {
         conn = new SqlConnection(DB);
      }
      public List<OPERATION_MST_DTO> SelectOperation(OPERATION_MST_DTO_Condition condition)
      {
         List<OPERATION_MST_DTO> list = new List<OPERATION_MST_DTO>();
         try
         {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sql = new StringBuilder(@"select OPERATION_CODE, OPERATION_NAME, CHECK_DEFECT_FLAG,
                                                           CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG, CREATE_TIME, 
                                                           CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                                                    from OPERATION_MST where 1 = 1");
            foreach (var prop in condition.GetType().GetProperties())
            {
               if (prop.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace((string)prop.GetValue(condition)))
               {
                  sql.Append($" and {prop.Name} = @{prop.Name}");
                  cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(condition).ToString());
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
               OPERATION_MST_DTO dto = new OPERATION_MST_DTO();
               dto.OPERATION_CODE = reader["OPERATION_CODE"].ToString();
               dto.OPERATION_NAME = reader["OPERATION_NAME"].ToString();
               if(reader["CHECK_DEFECT_FLAG"] != DBNull.Value)
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
      public void Dispose()
      {
         if (conn != null || conn.State == ConnectionState.Open)
            conn.Close();
      }
   }
}
