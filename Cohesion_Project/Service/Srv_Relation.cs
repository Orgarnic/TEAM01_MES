using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DTO;
using Cohesion_DAO;

namespace Cohesion_Project.Service
{
    public class Srv_Relation
    {
        public List<Inspection_DTO> SelectInsWithOper(string operationCode)
        {
            Relation_DAO dao = new Relation_DAO();
            var list = dao.SelectInsWithOper(operationCode);
            dao.Dispose();

            return list;
        }
        public bool InsertInsWithOper(string operationCode, List<Inspection_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.InsertInsWithOper(operationCode, list);
            dao.Dispose();

            return result;
        }
        public bool UpdateInsWithOper(string operationCode, List<Inspection_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.UpdateInsWithOper(operationCode, list);
            dao.Dispose();
            return result;

        }

        public List<Equipment_DTO> SelectEquipWithOper(string operationCode)
        {
            Relation_DAO dao = new Relation_DAO();
            var list = dao.SelectEquipWithOper(operationCode);
            dao.Dispose();

            return list;
        }
        public bool InsertEquipWithOper(string operationCode, List<Equipment_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.InsertEquipWithOper(operationCode, list);
            dao.Dispose();

            return result;
        }
        public bool UpdateEquipWithOper(string operationCode, List<Equipment_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.UpdateEquipWithOper(operationCode, list);
            dao.Dispose();
            return result;

        }

        public List<OPERATION_REL_DTO> SelectOperWithProduct(string productCode)
        {
            Relation_DAO dao = new Relation_DAO();
            var list = dao.SelectOperWithProduct(productCode);
            dao.Dispose();

            return list;
        }
        public bool InsertOperWithProduct(string productCode, List<OPERATION_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.InsertOperWithProduct(productCode, list);
            dao.Dispose();

            return result;
        }
        public bool UpdateOperWithProduct(string productCode, List<OPERATION_REL_DTO> list)
        {
            Relation_DAO dao = new Relation_DAO();
            var result = dao.UpdateOperWithProduct(productCode, list);
            dao.Dispose();
            return result;

        }

        
        public List<Operation_Inspection_Rel_DTO> SelectOperationInRel(Operation_Inspection_Rel_DTO condition)
        {
            Relation_DAO dao = new Relation_DAO();
            List<Operation_Inspection_Rel_DTO> list = dao.SelectOperationInRel(condition);
            dao.Dispose();
            return list;
        }

        public List<PRODUCT_OPERATION_REL_DTO> SelectProductInRel(PRODUCT_OPERATION_REL_DTO condition)
        {
            Relation_DAO dao = new Relation_DAO();
            List<PRODUCT_OPERATION_REL_DTO> list = dao.SelectProductInRel(condition);
            dao.Dispose();
            return list;
        }

        public List<PRODUCT_OPERATION_REL_DTO> SelectProductInRel()
        {
            Relation_DAO dao = new Relation_DAO();
            List<PRODUCT_OPERATION_REL_DTO> list = dao.SelectProductInRel();
            dao.Dispose();

            return list;
        }

        public List<Equipment_DTO> SelectEquipment(Equipment_DTO condtion)
        {
            Relation_DAO dao = new Relation_DAO();
            List<Equipment_DTO> list = dao.SelectEquipment(condtion);
            dao.Dispose();

            return list;
        }
    }
}
