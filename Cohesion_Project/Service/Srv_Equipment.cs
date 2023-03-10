using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cohesion_DAO;
using Cohesion_DTO;

namespace Cohesion_Project.Service
{
    public class Srv_Equipment
    {
        public List<Equipment_DTO> SelectEquipmentList()
        {
            Equipment_DAO db = new Equipment_DAO();
            List<Equipment_DTO> list = db.SelectEquipmentList();
            db.Dispose();

            return list;
        }
        public List<Equipment_DTO_Search_Data> SelectEquipmentSearchList(Equipment_DTO_Search_Data condtion)
        {
            Equipment_DAO db = new Equipment_DAO();
            List<Equipment_DTO_Search_Data> list = db.SelectEquipmentSearchList(condtion);
            db.Dispose();

            return list;
        }
        public bool InsertEquipment(Equipment_DTO dto)
        {
            Equipment_DAO dao = new Equipment_DAO();
            bool result = dao.InsertEquipment(dto);
            dao.Dispose();

            return result;
        }

        
        public bool UpdateEquipment(Equipment_DTO dto)
        {
            Equipment_DAO dao = new Equipment_DAO();
            bool result = dao.UpdateEquipment(dto);
            dao.Dispose();

            return result;
        }

        public bool DeleteEquipment(Equipment_DTO dto)
        {
            Equipment_DAO dao = new Equipment_DAO();
            bool result = dao.DeleteEquipment(dto);
            dao.Dispose();

            return result;
        }
    }
}
