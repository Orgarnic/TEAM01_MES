﻿using System;
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
    public class Store_DAO : IDisposable
    {
        SqlConnection conn;
        public Store_DAO()
        {
            string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            conn = new SqlConnection(connstr);
        }
           
        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<Store_DTO> SelectStoreList()
        {
            string sql = @"SELECT STORE_CODE, STORE_NAME, STORE_TYPE, FIFO_FLAG, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
                           FROM STORE_MST
                           ORDER BY STORE_CODE";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            List<Store_DTO> list = Helper.DataReaderMapToList<Store_DTO>(cmd.ExecuteReader());

            return list;
        }
    }
}
