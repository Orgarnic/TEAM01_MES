using Cohesion_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_Project.Service;
using System.Linq;

namespace Cohesion_Project
{
    public partial class Frm_Operation_Inspection_Rel : Cohesion_Project.Frm_Base_4
    {
        Operationg_Inspection_Rel_Search oSearch = new Operationg_Inspection_Rel_Search();
        Srv_Inspection svI = new Srv_Inspection();
        Srv_Relation svR = new Srv_Relation();
        List<Inspection_DTO> iList = new List<Inspection_DTO>();
        bool searchState = false;
        public Frm_Operation_Inspection_Rel()
        {
            InitializeComponent();
        }

        private void Frm_Operationg_Inspection_Rel_Load(object sender, EventArgs e)
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

            DgvUtil.DgvInit(dgvAddedInspection);
            DgvUtil.AddTextCol(dgvAddedInspection, "    NO", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedInspection, "    검사 항목 코드", "INSPECT_ITEM_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedInspection, "    검사 항목명", "INSPECT_ITEM_NAME", 200, readOnly: true);

            DgvUtil.DgvInit(dgvInspectionList);
            DgvUtil.AddTextCol(dgvInspectionList, "     NO", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvInspectionList, "     검사 항목 코드", "INSPECT_ITEM_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvInspectionList, "     검사 항목명", "INSPECT_ITEM_NAME", 200, readOnly: true);


            btnLeft.Enabled = false;
            btnRight.Enabled = false;

            iList = svI.SelectInspection();
            int seq = 1;
            dgvInspectionList.DataSource = iList.Select((i) => new Inspection_REL_DTO
            {
                INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();

            List<string> cboList = new List<string> { "전체", "C", "N" };
            cboValueUnit.DataSource = cboList;
            cboValueUnit.SelectedIndex = 0;
            ppgSearchCondition.PropertySort = PropertySort.Categorized;
            ppgSearchCondition.SelectedObject = oSearch;
            ppgSearchCondition.Enabled = false;

        }

        private void dgvOperationList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string operationCode = dgvOperationList[1, e.RowIndex].Value.ToString();
            var list = svR.SelectInsWithOper(operationCode);
            int seq = 1;
            int seqI = 1;
            dgvAddedInspection.DataSource = list.Select((i) => new
            Inspection_REL_DTO
            {
                INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();


            dgvInspectionList.DataSource = iList.Where((i) => !list.Any((o) => i.INSPECT_ITEM_CODE == o.INSPECT_ITEM_CODE)).Select((i) => new Inspection_REL_DTO
            {
                INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                DISPLAY_SEQ = seqI++
            }).ToList(); 
            

            if (dgvAddedInspection.Rows.Count != 0)
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
            if (dgvInspectionList.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = dgvInspectionList.CurrentRow.Index;
            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }


            Inspection_REL_DTO dto = new Inspection_REL_DTO
            {
                INSPECT_ITEM_CODE = dgvInspectionList.Rows[idx].Cells[1].Value.ToString()
               ,
                INSPECT_ITEM_NAME = dgvInspectionList.Rows[idx].Cells[2].Value.ToString()
            };
            
            if (dgvAddedInspection.Rows.Count == 0)
            {
                List<Inspection_REL_DTO> addList = new List<Inspection_REL_DTO>();
                addList.Add(dto);
                dgvAddedInspection.DataSource = null;
                dgvAddedInspection.DataSource = addList.OrderBy((i) => i.INSPECT_ITEM_CODE).Select((i) => new Inspection_REL_DTO { INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE, INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME, DISPLAY_SEQ = seq++}).ToList();
                var l1 = dgvAddedInspection.DataSource;

                List<Inspection_REL_DTO> list = dgvInspectionList.DataSource as List<Inspection_REL_DTO>;
                list.Remove(list.Find((i) => i.INSPECT_ITEM_CODE.Equals(dto.INSPECT_ITEM_CODE, StringComparison.OrdinalIgnoreCase)));

                dgvInspectionList.DataSource = list.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
            else
            {
                var addList = dgvAddedInspection.DataSource as List<Inspection_REL_DTO>;
                addList.Add(dto);
                dgvAddedInspection.DataSource = null;
                dgvAddedInspection.DataSource = addList.OrderBy((i) => i.INSPECT_ITEM_CODE).Select((i) => new Inspection_REL_DTO { INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE, INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<Inspection_REL_DTO> list = dgvInspectionList.DataSource as List<Inspection_REL_DTO>;
                list.RemoveAt(list.FindIndex((i) => i.INSPECT_ITEM_CODE.Equals(dto.INSPECT_ITEM_CODE, StringComparison.OrdinalIgnoreCase)));

                dgvInspectionList.DataSource = list.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (dgvAddedInspection.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = dgvAddedInspection.CurrentRow.Index;

            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }
            if (dgvAddedInspection.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사 항목이 존재하지 않습니다.");
                return;
            }
            else
            {
                var dto = dgvAddedInspection.Rows[idx].DataBoundItem as Inspection_REL_DTO;
                var addList = dgvAddedInspection.DataSource as List<Inspection_REL_DTO>;
                addList.Remove(dto);
                dgvAddedInspection.DataSource = null;
                dgvAddedInspection.DataSource = addList.OrderBy((i) => i.INSPECT_ITEM_CODE).Select((i) => new Inspection_REL_DTO { INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE, INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME, DISPLAY_SEQ = seq++ }).ToList();
                
                List<Inspection_REL_DTO> list = dgvInspectionList.DataSource as List<Inspection_REL_DTO>;
                if (list.Exists((i) => i.INSPECT_ITEM_CODE.Equals(dto.INSPECT_ITEM_CODE)))
                {
                    return;
                }
                else
                {
                list.Add(dto);
                dgvInspectionList.DataSource = list.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
                }
            }
        }

        private void cboValueUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seq = 1;
            if (cboValueUnit.SelectedIndex ==0)
            {
                dgvInspectionList.DataSource = iList.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
            }
            else
            {
                dgvInspectionList.DataSource=iList.FindAll((t) => t.VALUE_TYPE.Equals(Convert.ToChar(cboValueUnit.SelectedItem))).Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string operationCode = dgvOperationList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<Inspection_REL_DTO> list = dgvAddedInspection.DataSource as List<Inspection_REL_DTO>;

            if (dgvAddedInspection.Rows.Count ==0)
            {
                MboxUtil.MboxError("검사항목을 등록해주세요");
                return;
            }

            bool result = svR.InsertInsWithOper(operationCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("공정 검사 정보를 입력했습니다.");
                dgvAddedInspection.DataSource = null;
                int seq = 1;
                dgvInspectionList.DataSource = iList.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("공정 검사 정보 입력중 오류가 발생했습니다.");
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string operationCode = dgvOperationList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<Inspection_REL_DTO> list = dgvAddedInspection.DataSource as List<Inspection_REL_DTO>;
            var result = svR.UpdateInsWithOper(operationCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("검사 정보를 수정했습니다.");
                dgvAddedInspection.DataSource = null;
                int seq = 1;
                dgvInspectionList.DataSource = iList.Select((i) => new Inspection_REL_DTO
                {
                    INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                    INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("검사 정보 수정중 오류가 발생했습니다.");
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
