using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project.Service
{
    public class Srv_WorkOrder
    {
        public List<Work_Order_MST_DTO> SelectWorkOrders(Work_Order_SEARCH_DTO search)
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<Work_Order_MST_DTO> list = db.SelectWorkOrders(search);
            db.Dispose();

            return list;
        }
        public List<Work_Order_MST_DTO> GetAllWorkOrderList()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<Work_Order_MST_DTO> list = db.GetAllWorkOrderList();
            db.Dispose();

            return list;
        }

        public List<Sales_Order_Work_DTO> SelectOrderList()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<Sales_Order_Work_DTO> list = db.SelectOrderList();
            db.Dispose();

            return list;
        }

        public List<BOM_MST_WORKORDER_DTO> GetOrderProductBOM(string ocode, string pcode)
        {
            // LOT 완성되면 쿼리 수정이 필요함.
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<BOM_MST_WORKORDER_DTO> list = db.GetOrderProductBOM(ocode, pcode);
            db.Dispose();

            return list;
        }

        public bool InsertWorkOrder(Work_Order_MST_DTO work)
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            bool result = db.InsertWorkOrder(work);
            db.Dispose();

            return result;
        }

        public bool UpdateWorkOrder(Work_Order_MST_DTO work, string uid)
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            bool result = db.UpdateWorkOrder(work, uid);
            db.Dispose();

            return result;
        }

        public bool DeleteWorkOrder(string wCode)
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            bool result = db.DeleteWorkOrder(wCode);
            db.Dispose();

            return result;
        }

        public List<PRODUCT_OPERATION_REL_DTO> GetOperationRel()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<PRODUCT_OPERATION_REL_DTO> list = db.GetOperationRel();
            db.Dispose();

            return list;
        }

        public List<PRODUCT_MST_DTO> GetAllProduct()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<PRODUCT_MST_DTO> list = db.GetAllProduct();
            db.Dispose();

            return list;
        }
    }
}
