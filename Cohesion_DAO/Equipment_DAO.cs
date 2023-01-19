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
    public class Equipment_DAO : IDisposable
    {
        SqlConnection conn;
        public Equipment_DAO()
        {
            string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            conn = new SqlConnection(connstr);
        }
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Equipment_DTO> SelectEquipmentList()
        {
            string sql = @"SELECT EQUIPMENT_CODE, EQUIPMENT_NAME, EQUIPMENT_TYPE, EQUIPMENT_STATUS, 
                                  LAST_DOWN_TIME, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           FROM EQUIPMENT_MST";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Equipment_DTO> list = Helper.DataReaderMapToList<Equipment_DTO>(cmd.ExecuteReader());

            return list;
        }
    }
}
