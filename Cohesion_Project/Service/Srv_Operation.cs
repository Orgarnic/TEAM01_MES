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
   }
}
