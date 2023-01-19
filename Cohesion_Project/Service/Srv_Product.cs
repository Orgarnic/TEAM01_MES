using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
   class Srv_Product
   {
      public List<PRODUCT_MST_DTO> SelectProduts()
      {
         Product_DAO dao = new Product_DAO();
         List<PRODUCT_MST_DTO> list = dao.SelectProduts();
         dao.Dispose();

         return list;
      }
   }
}
