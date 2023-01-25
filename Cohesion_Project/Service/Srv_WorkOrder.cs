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
        public List<Work_Order_MST_DTO> GetAllWorkOrderList()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<Work_Order_MST_DTO> list = db.GetAllWorkOrderList();
            db.Dispose();

            return list;
        }

        public List<Sales_Order_DTO> SelectOrderList()
        {
            WorkOrder_DAO db = new WorkOrder_DAO();
            List<Sales_Order_DTO> list = db.SelectOrderList();
            db.Dispose();

            return list;
        }
    }
}
