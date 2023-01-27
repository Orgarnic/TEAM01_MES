using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
   public class Srv_UserGroup
    {
        public bool InsertUserGroup(UserGroup_DTO dto)
        {
            UserGroup_DAO dao = new UserGroup_DAO();
            bool result = dao.InsertUserGroup(dto);
            dao.Dispose();
            return result;

            
        }
        public List<UserGroup_DTO> SelectUserGroup()
        {
            UserGroup_DAO dao = new UserGroup_DAO();
            List<UserGroup_DTO> list = dao.SelectUserGroup();
            dao.Dispose();

            return list;
        }

        public bool DeleteUserGroup(string usergroupcode)
        {
            UserGroup_DAO dao = new UserGroup_DAO();
            bool result = dao.DeleteUserGroup(usergroupcode);
            dao.Dispose();

            return result;
        }
        public bool UpdateUserGroup(UserGroup_DTO dto)
        {
            UserGroup_DAO dao = new UserGroup_DAO();
            bool result = dao.UpdateUserGroup(dto);
            dao.Dispose();
            return result;
        }

        public List<UserGroup_DTO> SelectUserGroup2(UserGoupCondition_DTO condtion)
        {
            
            UserGroup_DAO dao = new UserGroup_DAO();
            List<UserGroup_DTO> list = dao.SelectUserGroup2(condtion);
            dao.Dispose();

            return list;
        }
    }
}
