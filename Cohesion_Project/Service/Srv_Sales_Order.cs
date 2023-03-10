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

        public List<Sales_Order_VO> SelectSalesOrderState(string productCode, string orderID)
        {
            Sales_Order_DAO db = new Sales_Order_DAO();
            List<Sales_Order_VO> list = db.SelectSalesOrderState(productCode, orderID);
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

        public List<Sales_Order_VO> SelectOrderWithCondition(Sales_Order_VO condition)
        {
            Sales_Order_DAO db = new Sales_Order_DAO();
            List<Sales_Order_VO> list = db.SelectOrderWithCondition(condition);
            db.Dispose();

            return list;
        }

        public bool InsertPurchase(List<Sales_Order_VO> list)
        {
            Sales_Order_DAO dao = new Sales_Order_DAO();
            bool result = dao.InsertPurchase(list);
            dao.Dispose();

            return result;
        }
        

        //public List<Sales_Order_DTO> SelectSalesOrderState(string productCode)
        //{
        //    Sales_Order_DAO dao = new Sales_Order_DAO();
        //    var list = dao.SelectSalesOrderState(productCode);
        //    dao.Dispose();
        //    return list;
        //}

    }
}
