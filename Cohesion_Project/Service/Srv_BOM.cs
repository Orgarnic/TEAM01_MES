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
            List<PRODUCT_MST_DTO> list = dao.SelectProductList();
            dao.Dispose();

            return list;
        }

        //public List<PRODUCT_MST_DTO> SelectProductChildList(string code)
        //{
        //    BOM_DAO dao = new BOM_DAO();
        //    List<PRODUCT_MST_DTO> list = dao.SelectProductChildList(code);
        //    dao.Dispose();

        //    return list;
        //}
    }
}
