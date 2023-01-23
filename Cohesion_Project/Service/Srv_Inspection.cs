using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DAO;
using Cohesion_DTO;

namespace Cohesion_Project.Service
{
    public class Srv_Inspection
    {
        public List<Inspection_DTO> SelectInspection()
        {
            Inspection_DAO dao = new Inspection_DAO();
            List<Inspection_DTO> list = dao.SelectInspection();
            dao.Dispose();

            return list;
        }

        public bool InsertInspection(Inspection_DTO dto)
        {
            Inspection_DAO dao = new Inspection_DAO();
            bool result = dao.InsertInspection(dto);
            dao.Dispose();

            return result;
        }

        public bool UpdateInspection(Inspection_DTO dto)
        {
            Inspection_DAO dao = new Inspection_DAO();
            bool result = dao.UpdateInspection(dto);
            dao.Dispose();

            return result;
        }

        public bool DeleteInspection(Inspection_DTO dto)
        {
            Inspection_DAO dao = new Inspection_DAO();
            bool result = dao.DeleteInspection(dto);
            dao.Dispose();

            return result;
        }
    }
}
