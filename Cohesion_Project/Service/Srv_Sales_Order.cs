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
        public bool InsertSalesOrder(Sales_Order_DTO dto)
        {
            Sales_Order_DAO dao = new Sales_Order_DAO();
            bool result = dao.InsertSalesOrder(dto);
            dao.Dispose();

            return result;
        }

        public bool UpdateSalesOrder(Sales_Order_DTO dto)
        {
            Sales_Order_DAO dao = new Sales_Order_DAO();
            bool result = dao.UpdateSalesOrder(dto);
            dao.Dispose();

            return result;
        }

        public bool DeleteSalesOrder(Sales_Order_DTO dto)
        {
            Sales_Order_DAO dao = new Sales_Order_DAO();
            bool result = dao.DeleteSalesOrder(dto);
            dao.Dispose();

            return result;
        }

        public List<Sales_Order_DTO> SelectOrderWithCondition(Sales_Order_DTO_Search condition)
        {
            Sales_Order_DAO dao = new Sales_Order_DAO();
            var result = dao.SelectOrderWithCondition(condition);
            dao.Dispose();

            return result;
        }
    }
}
