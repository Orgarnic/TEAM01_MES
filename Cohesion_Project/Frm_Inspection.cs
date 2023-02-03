using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public partial class Frm_Inspection : Cohesion_Project.Frm_Base_2
    {
        private Inspection_DTO iProperty = new Inspection_DTO();
        private Inspection_DTO_Search sProperty = new Inspection_DTO_Search();
        Service.Srv_Inspection srvInspection = new Service.Srv_Inspection();
        bool stateSearchCondition = false;

        List<Inspection_DTO> srcList;


        public Frm_Inspection()
        {
            InitializeComponent();
        }

        private void Frm_Inspection_Load(object sender, EventArgs e)
        {
            DgvUtil.DgvInit(dgvInspection);
            DgvUtil.AddTextCol(dgvInspection, "    검사 항목", "INSPECT_ITEM_CODE", 180, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgvInspection, "    검사 항목명", "INSPECT_ITEM_NAME", 200, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgvInspection, "    값 유형", "VALUE_TYPE", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    규격 하한", "SPEC_LSL", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    평균 규격", "SPEC_TARGET", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    규격 상한", "SPEC_USL", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    생성 시간", "CREATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    생성자", "CREATE_USER_ID", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    변경 시간", "UPDATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvInspection, "    변경자", "UPDATE_USER_ID", 120, readOnly: true);

            ppgInspection.PropertySort = PropertySort.Categorized;
            ppgInspection.SelectedObject = iProperty;


            LoadData();

            dgvInspection.CellClick += DgvInspection_CellClick;
        }

        private void DgvInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            lbl3.Text = "▶ 검사 항목 등록 속성";
            iProperty = dgvInspection.Rows[e.RowIndex].DataBoundItem as Inspection_DTO;
            ppgInspection.SelectedObject = iProperty;
            ppgInspection.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Inspection_DTO dto = ppgInspection.SelectedObject as Inspection_DTO;
            if (dto.INSPECT_ITEM_CODE == null)
            {
                MboxUtil.MboxInfo("검사 항목 정보를 입력해주세요.");
                return;
            }

            var list = dgvInspection.DataSource as List<Inspection_DTO>;
            bool codeExist = list.Exists((i) => i.INSPECT_ITEM_CODE.Equals(dto.INSPECT_ITEM_CODE, StringComparison.OrdinalIgnoreCase));
            if (codeExist)
            {
                MboxUtil.MboxInfo("동일한 코드의 검사항목이 존재합니다.");
                return;
            }
            dto.CREATE_USER_ID = "서지환";
            dto.CREATE_TIME = DateTime.Now;

            if (dto.VALUE_TYPE == 'N')
            {
                if (dto.SPEC_TARGET == null)
                {
                    dto.SPEC_TARGET = ((Convert.ToDouble(dto.SPEC_LSL) + Convert.ToDouble(dto.SPEC_USL)) / 2).ToString();
                }
            }
            else if(dto.VALUE_TYPE == 'C')
            {
                if (dto.SPEC_TARGET == null)
                {
                    dto.SPEC_TARGET = "OK";
                }
            }

            bool result = srvInspection.InsertInspection(dto);
            if (result)
            {
                MboxUtil.MboxInfo("검사 항목이 등록되었습니다.");
                LoadData();
            }
            else
                MboxUtil.MboxError("검사 항목 등록 중 오류가 발생했습니다.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ppgInspection.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var dto = ppgInspection.SelectedObject as Inspection_DTO;
            if (dto.INSPECT_ITEM_CODE == null)
            {
                MessageBox.Show("변경할 검사 항목을 선택해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_("선택된 검사 항목 정보를 수정하시겠습니까 ? "))
            {
                return;
            }
            dto.UPDATE_USER_ID = "서지환";

            //N타입에서 C타입으로 바꿀경우, 상한값과 하한값을 없애고, 타겟값만 넣어준다.
            if (dto.VALUE_TYPE == 'C')
            {
                if (dto.SPEC_TARGET == null)
                {
                    dto.SPEC_TARGET = "OK";
                }
                else
                {
                    dto.SPEC_TARGET = dto.SPEC_TARGET.ToUpper();
                }
            }

            bool result = srvInspection.UpdateInspection(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                LoadData();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                ppgInspection.SelectedObject = new Inspection_DTO();
                ppgInspection.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                ppgInspection.SelectedObject = new Inspection_DTO_Search();
                ppgInspection.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택된 테이블 정보를 삭제하시겠습니까 ? "))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<Inspection_DTO>(dgvInspection);
            bool result = srvInspection.DeleteInspection(dto);
            if (result)
            {
                MboxUtil.MboxInfo("테이블 삭제 성공.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("테이블 삭제 실패.");
            }
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                ppgInspection.SelectedObject = sProperty;
                stateSearchCondition = true;
                btnAdd.Enabled = true;

            }
            else
            {
                lbl3.Text = "▶ 검사 항목 등록 속성";
                ppgInspection.Enabled = true;
                ppgInspection.SelectedObject = iProperty;
                stateSearchCondition = false;
                btnAdd.Enabled = true;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ppgInspection.SelectedObject is Inspection_DTO_Search)
            {
                Inspection_DTO_Search condition = ppgInspection.SelectedObject as Inspection_DTO_Search;
                string inspectCode = condition.INSPECT_ITEM_CODE;
                char valueType = condition.VALUE_TYPE;
                string searchText = txtSearch.Text.ToUpper();

                //데이터 베이스 안가고 조회조건

                if (!string.IsNullOrEmpty(inspectCode) && valueType.ToString() != "\0")
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE == inspectCode && c.VALUE_TYPE == valueType && c.INSPECT_ITEM_CODE.Contains(searchText));
                    }
                    else
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE == inspectCode && c.VALUE_TYPE == valueType);
                    }
                }

                else if (!string.IsNullOrEmpty(inspectCode) && valueType.ToString() == "\0")
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE == inspectCode && c.INSPECT_ITEM_CODE.Contains(searchText));
                    }
                    else
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE == inspectCode);
                    }
                }

                else if (string.IsNullOrEmpty(inspectCode) && valueType.ToString() != "\0")
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE.Contains(searchText) && c.VALUE_TYPE == valueType);
                    }
                    else
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.VALUE_TYPE == valueType);
                    }
                }

                else if (string.IsNullOrEmpty(inspectCode) && valueType.ToString() == "\0")
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvInspection.DataSource = srcList.FindAll((c) => c.INSPECT_ITEM_CODE.Contains(searchText));
                    }
                    else
                    {
                        dgvInspection.DataSource = srcList;
                    }
                }
            }
            else
            {
                MboxUtil.MboxError("검색 조건을 먼저 눌러주세요.");
            }

        }

        private void LoadData()
        {
            srcList = srvInspection.SelectInspection();
            dgvInspection.DataSource = srcList;
        }

        private void ppgInspection_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (ppgInspection.SelectedObject is Inspection_DTO)
            {
                Inspection_DTO dto = ppgInspection.SelectedObject as Inspection_DTO;
                if (dto.VALUE_TYPE == 'C')
                {
                    int result = default;
                    if (dto.SPEC_LSL != null && int.TryParse(dto.SPEC_TARGET, out result))
                    {
                        dto.SPEC_TARGET = null;
                        dto.SPEC_LSL = null;
                        dto.SPEC_USL = null;
                    }
                }
                else
                {
                    dto.SPEC_TARGET = null;
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
