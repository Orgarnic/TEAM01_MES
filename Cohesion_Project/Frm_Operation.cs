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
   public partial class Frm_Operation : Cohesion_Project.Frm_Base_2
   {
      private Srv_Operation srvOperation = new Srv_Operation();
      private OPERATION_MST_DTO_Condition condition = new OPERATION_MST_DTO_Condition();
      private List<OPERATION_MST_DTO> operations = new List<OPERATION_MST_DTO>();
      private OPERATION_MST_DTO operation = new OPERATION_MST_DTO();
      private bool isCondition = true;
      Util.ComboUtil comboUtil = new Util.ComboUtil();

      public Frm_Operation()
      {
         InitializeComponent();
      }
      private void Frm_Operation_Load(object sender, EventArgs e)
      {
         DgvInit();
         PpgInit();
         DgvFill();
      }
      private void DgvInit()
      {
         DgvUtil.DgvInit(dgvOperation);
         DgvUtil.AddTextCol(dgvOperation, "공정 코드", "OPERATION_CODE", width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvOperation, "공정 명칭", "OPERATION_NAME", width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvOperation, "불량 입력", "CHECK_DEFECT_FLAG", width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvOperation, "검사 데이터", "CHECK_INSPECT_FLAG", width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "자재 사용", "CHECK_MATERIAL_FLAG", width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "생성 시간", "CREATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "생성 사용자", "CREATE_USER_ID", width: 150, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "변경 시간", "UPDATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "변경 사용자", "UPDATE_USER_ID", width: 150, readOnly: true);
      }
      private void PpgInit()
      {
         ppgOperation.PropertySort = PropertySort.Categorized;
         ppgOperation.SelectedObject = new OPERATION_MST_DTO();
      }
      public void DgvFill()
      {
         btnSearch.PerformClick();
      }
      private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         int row = e.RowIndex;
         if (row < 0) return;
         operation = DgvUtil.DgvToDto<OPERATION_MST_DTO>(dgvOperation);
         ppgOperation.SelectedObject = operation;

         ppgOperation.Enabled = false;
         btnAdd.Enabled = false;
         btnUpdate.Enabled = true;
         btnInsert.Enabled = true;
         isCondition = true;
      }
      private void btnRefresh_Click(object sender, EventArgs e)
      {
         ppgOperation.Enabled = true;
         btnAdd.Enabled = true;
         btnUpdate.Enabled = false;
         btnInsert.Enabled = false;
         operation = new OPERATION_MST_DTO();
         ppgOperation.SelectedObject = operation;
      }
      private void btnAdd_Click(object sender, EventArgs e)
      {
         OPERATION_MST_DTO dto = ppgOperation.SelectedObject as OPERATION_MST_DTO;
         if (dto == null) return;
         if (!Available(dto)) return;
         dto.CREATE_USER_ID = "TEST";
         dto.CREATE_TIME = DateTime.Now;
         bool result = srvOperation.InsertOperation(dto);
         if (result)
         {
            MboxUtil.MboxInfo("공정이 등록되었습니다.");
            this.DgvFill();
         }
         else
            MboxUtil.MboxError("오류가 발생했습니다.");
      }
      private void btnUpdate_Click(object sender, EventArgs e)
      {
         ppgOperation.Enabled = true;
         btnAdd.Enabled = false;
      }
      private void btnInsert_Click(object sender, EventArgs e)
      {
         if (!ppgOperation.Enabled)
            return;
         if (!Available(operation)) return;
         operation.UPDATE_TIME = DateTime.Now;
         operation.UPDATE_USER_ID = "TEST";
         bool result = srvOperation.UpdateOperation(operation);
         if (result)
         {
            MboxUtil.MboxInfo("공정이 수정되었습니다.");
            this.DgvFill();
         }
         else
         {
            MboxUtil.MboxError("오류가 발생했습니다.");
            return;
         }
         btnAdd.Enabled = true;
         isCondition = true;
         ppgOperation.Enabled = false;
      }
      private void btnSearch_Click(object sender, EventArgs e)
      {
         operations = srvOperation.SelectOperation(condition);
         dgvOperation.DataSource = operations;
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
      private void btnDelete_Click(object sender, EventArgs e)
      {
         if (dgvOperation.SelectedRows.Count < 1) return;
         if (!MboxUtil.MboxInfo_("선택된 공정을 삭제하시겠습니까 ? ")) return;
         OPERATION_MST_DTO dto = DgvUtil.DgvToDto<OPERATION_MST_DTO>(dgvOperation);
         bool result = srvOperation.DeleteOperation(dto);
         if (result)
         {
            MboxUtil.MboxInfo("공정이 삭제되었습니다.");
            this.DgvFill();
         }
         else
            MboxUtil.MboxError("오류가 발생했습니다.");
      }
      private void btnSearchCondition_Click(object sender, EventArgs e)
      {
         if (isCondition)
         {
            lbl3.Text = "▶ 검색 조건";
            ppgOperation.Enabled = true;
            ppgOperation.SelectedObject = condition;
            isCondition = false;
         }
         else
         {
            lbl3.Text = "▶ 속성";
            ppgOperation.SelectedObject = operation;
            condition = new OPERATION_MST_DTO_Condition();
            isCondition = true;
            ppgOperation.Enabled = false;
         }
      }

      private bool Available(OPERATION_MST_DTO dto)
      {
         if (string.IsNullOrWhiteSpace(dto.OPERATION_CODE))
         {
            MboxUtil.MboxWarn("공정 코드는 필수 입력입니다.");
            return false;
         }
         if (string.IsNullOrWhiteSpace(dto.OPERATION_NAME))
         {
            MboxUtil.MboxWarn("공정 명은 필수 입력입니다.");
            return false;
         }
         return true;
      }
   }
}
