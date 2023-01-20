using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DAO;
using Cohesion_DTO;

namespace Cohesion_Project.Service
{
    class Srv_CommonData
    {
        public List<CommonTable_DTO> SelectCommonTable()
        {
            Common_DAO dao = new Common_DAO();
            List<CommonTable_DTO> list = dao.SelectCommonTable();
            dao.Dispose();

            return list;
        }

        public bool InsertCommonTable(CommonTable_DTO dto)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.InsertCommonTable(dto);
            dao.Dispose();

            return result;
        }

        public bool UpdateCommonTable(CommonTable_DTO dto)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.UpdateCommonTable(dto);
            dao.Dispose();

            return result;
        }

        public List<CommonData_DTO> SelectCommonTableData(string CODE_TABLE_NAME)
        {
            Common_DAO dao = new Common_DAO();
            List<CommonData_DTO> list = dao.SelectCommonTableData(CODE_TABLE_NAME);
            dao.Dispose();

            return list;
        }

        public bool InsertCommonTableData(CommonData_DTO dto)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.InsertCommonTableData(dto);
            dao.Dispose();

            return result;
        }

        public bool UpsertCommonTableData(string CODE_TABLE_NAME, List<CommonData_DTO> list)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.UpsertCommonTableData(CODE_TABLE_NAME,list);
            dao.Dispose();

            return result;
        }

        public bool DeleteTable(CommonTable_DTO dto)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.DeleteTable(dto);
            dao.Dispose();

            return result;
        }

        public bool DeleteTableData(string CODE_TABLE_NAME,CommonData_DTO dto)
        {
            Common_DAO dao = new Common_DAO();
            bool result = dao.DeleteTableData(CODE_TABLE_NAME,dto);
            dao.Dispose();

            return result;
        }
        public List<CommonData_DTO> SelectAllCommonTableData()
        {
            Common_DAO dao = new Common_DAO();
            List<CommonData_DTO> list = dao.SelectAllCommonTableData();
            dao.Dispose();

            return list;
        }
    }
}
