using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Cohesion_DAO
{
    class BOM_DAO : IDisposable
    {
        SqlConnection conn = null;

        public void Dispose()
        {
            //conn = ConfigurationManager["MyDB"]
        }

        //public BOM_MST_DTO SelectProductList()
        //{
        //   // string sql = ""
        //}
    }
}
