using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
    class Srv_BOM
    {
        public List<PRODUCT_MST_DTO> SelectProductList()
        {
            BOM_DAO dao = new BOM_DAO();
            List<PRODUCT_MST_DTO> list = dao.SelectGetAllProductList();
            dao.Dispose();

            return list;
        }

        public List<BOM_MST_DTO> SelectBOMList(string code)
        {
            BOM_DAO dao = new BOM_DAO();
            List<BOM_MST_DTO> list = dao.SelectBOMList(code);
            dao.Dispose();

            return list;
        }

        public bool DeleteProduct(string parentCode, string childCode)
        {
            BOM_DAO dao = new BOM_DAO();
            bool result = dao.DeleteProduct(parentCode, childCode);
            dao.Dispose();

            return result;
        }
    }
}
