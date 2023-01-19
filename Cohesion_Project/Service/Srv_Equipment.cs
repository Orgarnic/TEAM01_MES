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
    }
}
