using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
    public class Srv_Sales_Order
    {
        public List<Sales_Order_DTO> SelectSalesList()
        {
            Sales_Order_DAO db = new Sales_Order_DAO();
            List<Sales_Order_DTO> list = db.SelectSalesList();
            db.Dispose();

            return list;
        }
    }
}
