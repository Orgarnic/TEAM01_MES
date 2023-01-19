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
      public List<PRODUCT_MST_DTO> SelectProduts(PRODUCT_MST_DTO condtion)
      {
         Product_DAO dao = new Product_DAO();
         List<PRODUCT_MST_DTO> list = dao.SelectProduts(condtion);
         dao.Dispose();

         return list;
      }
      public bool InsertProduct(PRODUCT_MST_DTO dto)
      {
         Product_DAO dao = new Product_DAO();
         bool result = dao.InsertProduct(dto);
         dao.Dispose();

         return result;
      }
      public bool UpdateProduct(PRODUCT_MST_DTO dto)
      {
         Product_DAO dao = new Product_DAO();
         bool result = dao.UpdateProduct(dto);
         dao.Dispose();

         return result;
      }
      public bool DeleteProduct(PRODUCT_MST_DTO dto)
      {
         Product_DAO dao = new Product_DAO();
         bool result = dao.DeleteProduct(dto);
         dao.Dispose();

         return result;
      }
   }
}
