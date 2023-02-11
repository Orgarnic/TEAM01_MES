using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project
{
   public class Srv_User
    {
        public List<User_DTO> SelectUser()
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            List<User_DTO> list = dao.SelectUser();
            dao.Dispose();

            return list;
        }

        public bool InsertUser(User_DTO dto)
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            bool result = dao.InsertUser(dto);
            dao.Dispose();
            return result;
        }

        public bool UpdateUser(User_DTO dto)
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            bool result = dao.UpdateUser(dto);
            dao.Dispose();
            return result;
        }

        public bool DeleteUser(string usercode)
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            bool result = dao.DeleteUser(usercode);
            dao.Dispose();

            return result;
        }

        public List<User_DTO> SelectUser2(User_Condition_DTO condition)
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            List<User_DTO> list = dao.SelectUser2(condition);
            dao.Dispose();

            return list;
        }

        public User_DTO GetAdmin(string uid, string pwd)
        {
            UserMgt_DAO dao = new UserMgt_DAO();
            User_DTO dto = dao.GetAdmin(uid, pwd);
            dao.Dispose();

            return dto;
        }
      public List<FUNCTION_MST_DTO> GetFunc(string uid)
      {
         UserMgt_DAO dao = new UserMgt_DAO();
         List<FUNCTION_MST_DTO> list = dao.GetFunc(uid);
         dao.Dispose();
         return list;
      }
    }
}
