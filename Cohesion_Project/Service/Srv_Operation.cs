using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
   public class Srv_Operation
   {
      public List<OPERATION_MST_DTO> SelectOperation(OPERATION_MST_DTO_Condition condition)
      {
         Operation_DAO dao = new Operation_DAO();
         List<OPERATION_MST_DTO> list = dao.SelectOperation(condition);
         dao.Dispose();

         return list;
      }
      public bool InsertOperation(OPERATION_MST_DTO dto)
      {
         Operation_DAO dao = new Operation_DAO();
         bool result = dao.InsertOperation(dto);
         dao.Dispose();

         return result;
      }

      public bool UpdateOperation(OPERATION_MST_DTO dto)
      {
         Operation_DAO dao = new Operation_DAO();
         bool result = dao.UpdateOperation(dto);
         dao.Dispose();

         return result;
      }
      public bool DeleteOperation(OPERATION_MST_DTO dto)
      {
         Operation_DAO dao = new Operation_DAO();
         bool result = dao.DeleteOperation(dto);
         dao.Dispose();

         return result;
      }
        public List<Operation_Inspection_Rel_DTO> SelectOperationInRel(Operation_Inspection_Rel_DTO condition)
        {
            Operation_DAO dao = new Operation_DAO();
            List<Operation_Inspection_Rel_DTO> list = dao.SelectOperationInRel(condition);
            dao.Dispose();

            return list;
        }
    }
}
