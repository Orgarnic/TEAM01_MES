using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DAO;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public class Srv_Store
    {
        public List<Store_DTO> SelectStoreList()
        {
            Store_DAO db = new Store_DAO();
            List<Store_DTO> list = db.SelectStoreList();
            db.Dispose();

            return list;
        }

        public bool InsertStore(Store_DTO dto)
        {
            Store_DAO dao = new Store_DAO();
            bool result = dao.InsertStore(dto);
            dao.Dispose();

            return result;
        }

        public bool UpdateStore(Store_DTO dto)
        {
            Store_DAO dao = new Store_DAO();
            bool result = dao.UpdateStore(dto);
            dao.Dispose();

            return result;
        }

        public List<Store_DTO_Search_Data> SelectStore(Store_DTO_Search_Data condtion)
        {
            Store_DAO dao = new Store_DAO();
            List<Store_DTO_Search_Data> list = dao.SelectStore(condtion);
            dao.Dispose();

            return list;
        }

        public bool DeleteStore(Store_DTO dto)
        {
            Store_DAO dao = new Store_DAO();
            bool result = dao.DeleteStore(dto);
            dao.Dispose();

            return result;
        }
    }
}
