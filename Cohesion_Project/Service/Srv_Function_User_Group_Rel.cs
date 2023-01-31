using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
    public class Srv_Function_User_Group_Rel
    {
        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG()
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG();
            dao.Dispose();

            return list;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG1()
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG1();
            dao.Dispose();

            return list;
        }

        public bool DeleteFUG(string functiocode)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            bool result = dao.DeleteFUG(functiocode);
            dao.Dispose();

            return result;
        }
        //public bool InsertFUG(FUNCTION_USER_GROUP_REL_DTO dto)
        //{
        //    Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
        //    bool result = dao.InsertFUG(dto);
        //    dao.Dispose();
        //    return result;
        //}

        public bool UpdateFUG(FUNCTION_USER_GROUP_REL_DTO dto)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            bool result = dao.UpdateFUG(dto);
            dao.Dispose();
            return result;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG2(FUNCTION_USER_GROUP_REL_Condition_DTO condtion)
        {

            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG2(condtion);
            dao.Dispose();

            return list;
        }

    }
}
