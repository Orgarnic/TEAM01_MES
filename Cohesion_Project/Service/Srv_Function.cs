using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;


namespace Cohesion_Project
{ 
    public class Srv_Function
    {
        public List<FUNCTION_MST_DTO> SelectFunction()
        {
            Function_DAO dao = new Function_DAO();
            List<FUNCTION_MST_DTO> list = dao.SelectFunction();
            dao.Dispose();

            return list;
        }
        public bool DeleteFunctio(string functiocode)
        {
            Function_DAO dao = new Function_DAO();
            bool result = dao.DeleteFunction(functiocode);
            dao.Dispose();

            return result;
        }
        public bool InsertFunction(FUNCTION_MST_DTO dto)
        {
            Function_DAO dao = new Function_DAO();
            bool result = dao.InsertFunction(dto);
            dao.Dispose();
            return result;

        }

    }
}
