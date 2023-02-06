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
        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG( )
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG();
            dao.Dispose();

            return list;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG1(FUNCTION_USER_GROUP_REL_DTO dto)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG1(dto);
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



        public bool InsertFUG(string functiocode, List<FUNCTION_USER_GROUP_REL_DTO> list)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            bool result = dao.InsertFUG(functiocode, list);
            dao.Dispose();
            return result;
        }

        public bool UpdateFUG(FUNCTION_USER_GROUP_REL_DTO dto)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            bool result = dao.UpdateFUG(dto);
            dao.Dispose();
            return result;
        }

        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUG2( )
        {

            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUG2();
            dao.Dispose();

            return list;
        }
        public List<FUNCTION_USER_GROUP_REL_DTO> SelectFUGR(string user_GROUP_CODE)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<FUNCTION_USER_GROUP_REL_DTO> list = dao.SelectFUGR(user_GROUP_CODE);
            dao.Dispose();
            return list;
        }
        public List<UserGroup_DTO> SelectF(UserGoupCondition_DTO condition)
        {
            Function_User_Group_Rel_DAO dao = new Function_User_Group_Rel_DAO();
            List<UserGroup_DTO> list = dao.SelectF(condition);
            dao.Dispose();
            return list;
        }
    }
}
