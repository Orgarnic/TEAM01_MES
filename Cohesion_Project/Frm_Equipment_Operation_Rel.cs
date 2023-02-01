using Cohesion_DTO;
using Cohesion_Project.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_Equipment_Operation_Rel : Cohesion_Project.Frm_Base_4
    {
        Operationg_Inspection_Rel_Search oSearch = new Operationg_Inspection_Rel_Search();
        Srv_Relation svR = new Srv_Relation();
        List<Equipment_DTO> iList = new List<Equipment_DTO>();
        bool searchState = false;
        public Frm_Equipment_Operation_Rel()
        {
            InitializeComponent();
        }

        private void Frm_Equipment_Operation_Rel_Load(object sender, EventArgs e)
        {
            InitDgv();

            var list = svR.SelectOperationInRel(new Operation_Inspection_Rel_DTO());
            int seq = 1;
            dgvOperationList.DataSource = list.Select((i) => new
            {
                OPERATION_CODE = i.OPERATION_CODE,
                OPERATION_NAME = i.OPERATION_NAME,
                CHECK_DEFECT_FLAG = i.CHECK_DEFECT_FLAG,
                CHECK_INSPECT_FLAG = i.CHECK_INSPECT_FLAG,
                CHECK_MATERIAL_FLAG = i.CHECK_MATERIAL_FLAG,
                CREATE_TIME = i.CREATE_TIME,
                CREATE_USER_ID = i.CREATE_USER_ID,
                UPDATE_TIME = i.UPDATE_TIME,
                UPDATE_USER_ID = i.UPDATE_USER_ID,
                DISPLAY_SEQ = seq++
            }).ToList();
        }
        private void InitDgv()
        {
            //데이터 그리드 뷰 초기 설정
            DgvUtil.DgvInit(dgvOperationList);
            DgvUtil.AddTextCol(dgvOperationList, "    NO", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "  공정 코드", "OPERATION_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "  공정명", "OPERATION_NAME", 150, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    불량 입력", "CHECK_DEFECT_FLAG", 150, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    검사 데이터 입력", "CHECK_INSPECT_FLAG", 150, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    자재 사용", "CHECK_MATERIAL_FLAG", 150, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    생성 시간", "CREATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    생성자", "CREATE_USER_ID", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    변경 시간", "UPDATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "    변경자", "UPDATE_USER_ID", 120, readOnly: true);

            DgvUtil.DgvInit(dgvAddedEquipment);
            DgvUtil.AddTextCol(dgvAddedEquipment, "    NO", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedEquipment, "    설비 코드", "EQUIPMENT_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedEquipment, "    설비명", "EQUIPMENT_NAME", 150, readOnly: true);

            DgvUtil.DgvInit(dgvEquipmentList);
            DgvUtil.AddTextCol(dgvEquipmentList, "    NO", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvEquipmentList, "    설비 코드", "EQUIPMENT_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvEquipmentList, "    설비명", "EQUIPMENT_NAME", 150, readOnly: true);


            btnLeft.Enabled = false;
            btnRight.Enabled = false;

            iList = svR.SelectEquipment(new Equipment_DTO());
            int seq = 1;
            dgvEquipmentList.DataSource = iList.Select((i) => new Equipment_REL_DTO
            {
                EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();

            List<string> cboList = new List<string> { "전체", "EQUIP" };
            cboEquipmentUnit.DataSource = cboList;
            cboEquipmentUnit.SelectedIndex = 0;
            ppgSearchCondition.PropertySort = PropertySort.Categorized;
            ppgSearchCondition.SelectedObject = oSearch;
            ppgSearchCondition.Enabled = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!searchState)
            {
                searchState = true;
                ppgSearchCondition.Enabled = true;
            }
            else
            {
                searchState = false;
                ppgSearchCondition.SelectedObject = new Operationg_Inspection_Rel_Search();
                ppgSearchCondition.Enabled = false;
            }
        }

        private void dgvOperationList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string operationCode = dgvOperationList[1, e.RowIndex].Value.ToString();
            var list = svR.SelectEquipWithOper(operationCode);
            int seq = 1;
            int seqI = 1;
            dgvAddedEquipment.DataSource = list.Select((i) => new
            Equipment_REL_DTO
            {
                EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();

            dgvEquipmentList.DataSource = iList.Where((i) => !list.Any((o) => i.EQUIPMENT_CODE == o.EQUIPMENT_CODE)).Select((i) => new Equipment_REL_DTO
            {
                EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                DISPLAY_SEQ = seqI++
            }).ToList();

            if (dgvAddedEquipment.Rows.Count != 0)
            {
                btnAdd.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.PerformClick();
                btnUpdate.Enabled = false;
                btnInsert.Enabled = false;
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (dgvEquipmentList.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = dgvEquipmentList.CurrentRow.Index;
            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }


            Equipment_REL_DTO dto = new Equipment_REL_DTO
            {
                EQUIPMENT_CODE = dgvEquipmentList.Rows[idx].Cells[1].Value.ToString()
               ,
                EQUIPMENT_NAME = dgvEquipmentList.Rows[idx].Cells[2].Value.ToString()
            };

            if (dgvAddedEquipment.Rows.Count == 0)
            {
                List<Equipment_REL_DTO> addList = new List<Equipment_REL_DTO>();
                addList.Add(dto);
                dgvAddedEquipment.DataSource = null;
                dgvAddedEquipment.DataSource = addList.OrderBy((i) => i.EQUIPMENT_CODE).Select((i) => new Equipment_REL_DTO { EQUIPMENT_CODE = i.EQUIPMENT_CODE, EQUIPMENT_NAME = i.EQUIPMENT_NAME, DISPLAY_SEQ = seq++ }).ToList();
                var l1 = dgvAddedEquipment.DataSource;

                List<Equipment_REL_DTO> list = dgvEquipmentList.DataSource as List<Equipment_REL_DTO>;
                list.RemoveAt(list.FindIndex((i) => i.EQUIPMENT_CODE.Equals(dto.EQUIPMENT_CODE, StringComparison.OrdinalIgnoreCase)));

                dgvEquipmentList.DataSource = list.Select((i) => new Equipment_REL_DTO
                {
                    EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                    EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
            else
            {
                var addList = dgvAddedEquipment.DataSource as List<Equipment_REL_DTO>;
                addList.Add(dto);
                dgvAddedEquipment.DataSource = null;
                dgvAddedEquipment.DataSource = addList.OrderBy((i) => i.EQUIPMENT_CODE).Select((i) => new Equipment_REL_DTO { EQUIPMENT_CODE = i.EQUIPMENT_CODE, EQUIPMENT_NAME = i.EQUIPMENT_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<Equipment_REL_DTO> list = dgvEquipmentList.DataSource as List<Equipment_REL_DTO>;
                list.Remove(list.Find((i) => i.EQUIPMENT_CODE.Equals(dto.EQUIPMENT_CODE, StringComparison.OrdinalIgnoreCase)));

                dgvEquipmentList.DataSource = list.Select((i) => new Equipment_REL_DTO
                {
                    EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                    EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (dgvAddedEquipment.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = dgvAddedEquipment.CurrentRow.Index;

            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }
            if (dgvAddedEquipment.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사 항목이 존재하지 않습니다.");
                return;
            }
            else
            {
                var dto = dgvAddedEquipment.Rows[idx].DataBoundItem as Equipment_REL_DTO;
                var addList = dgvAddedEquipment.DataSource as List<Equipment_REL_DTO>;
                addList.Remove(dto);
                dgvAddedEquipment.DataSource = null;
                dgvAddedEquipment.DataSource = addList.OrderBy((i) => i.EQUIPMENT_CODE).Select((i) => new Equipment_REL_DTO { EQUIPMENT_CODE = i.EQUIPMENT_CODE, EQUIPMENT_NAME = i.EQUIPMENT_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<Equipment_REL_DTO> list = dgvEquipmentList.DataSource as List<Equipment_REL_DTO>;
                if (list.Exists((i) => i.EQUIPMENT_CODE.Equals(dto.EQUIPMENT_CODE)))
                {
                    return;
                }
                else
                {
                    list.Add(dto);

                    dgvEquipmentList.DataSource = list.Select((i) => new Equipment_REL_DTO
                    {
                        EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                        EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                        DISPLAY_SEQ = seqI++
                    }).ToList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string operationCode = dgvOperationList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<Equipment_REL_DTO> list = dgvAddedEquipment.DataSource as List<Equipment_REL_DTO>;

            if (dgvAddedEquipment.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사항목을 등록해주세요");
                return;
            }

            bool result = svR.InsertEquipWithOper(operationCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("설비 정보를 입력했습니다.");
                dgvAddedEquipment.DataSource = null;
                int seq = 1;
                dgvEquipmentList.DataSource = iList.Select((i) => new Equipment_REL_DTO
                {
                    EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                    EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("설비 정보 입력중 오류가 발생했습니다.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string operationCode = dgvOperationList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<Equipment_REL_DTO> list = dgvAddedEquipment.DataSource as List<Equipment_REL_DTO>;
            var result = svR.UpdateEquipWithOper(operationCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("설비 정보를 수정했습니다.");
                dgvAddedEquipment.DataSource = null;
                int seq = 1;
                dgvEquipmentList.DataSource = iList.Select((i) => new Equipment_REL_DTO
                {
                    EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                    EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("설비 정보 수정중 오류가 발생했습니다.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ppgSearchCondition.Enabled)
            {
                MboxUtil.MboxError("검색조건을 활성화 시켜주세요.");
                return;
            }
            else
            {
                var t = ppgSearchCondition.SelectedObject as Operationg_Inspection_Rel_Search;
                Operation_Inspection_Rel_DTO dto = new Operation_Inspection_Rel_DTO { OPERATION_CODE = t.OPERATION_CODE, OPERATION_NAME = t.OPERATION_NAME, CHECK_DEFECT_FLAG = t.CHECK_DEFECT_FLAG, CHECK_INSPECT_FLAG = t.CHECK_INSPECT_FLAG, CHECK_MATERIAL_FLAG = t.CHECK_MATERIAL_FLAG };
                var list = svR.SelectOperationInRel(dto);
                int seq = 1;
                dgvOperationList.DataSource = list.Select((i) => new
                {
                    OPERATION_CODE = i.OPERATION_CODE,
                    OPERATION_NAME = i.OPERATION_NAME,
                    CHECK_DEFECT_FLAG = i.CHECK_DEFECT_FLAG,
                    CHECK_INSPECT_FLAG = i.CHECK_INSPECT_FLAG,
                    CHECK_MATERIAL_FLAG = i.CHECK_MATERIAL_FLAG,
                    CREATE_TIME = i.CREATE_TIME,
                    CREATE_USER_ID = i.CREATE_USER_ID,
                    UPDATE_TIME = i.UPDATE_TIME,
                    UPDATE_USER_ID = i.UPDATE_USER_ID,
                    DISPLAY_SEQ = seq++
                }).ToList();
            }
        }
    }
}
