﻿using System;
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
    }
}