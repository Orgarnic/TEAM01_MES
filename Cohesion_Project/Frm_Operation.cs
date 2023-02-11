using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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
      private User_DTO userinfo;

      public Frm_Operation()
      {
         InitializeComponent();
      }
      private void Frm_Operation_Load(object sender, EventArgs e)
      {
         DgvInit();
         PpgInit();
         DgvFill();
         userinfo = (this.ParentForm as Frm_Main).userInfo;
      }
      private void DgvInit()
      {
         DgvUtil.DgvInit(dgvOperation);
         DgvUtil.AddTextCol(dgvOperation, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
         DgvUtil.AddTextCol(dgvOperation, "  공정 코드", "OPERATION_CODE", width: 150, readOnly: true, frozen: true, align:0);
         DgvUtil.AddTextCol(dgvOperation, "  공정 명칭", "OPERATION_NAME", width: 150, readOnly: true, frozen: true, align: 0);
         DgvUtil.AddTextCol(dgvOperation, "  불량 입력", "CHECK_DEFECT_FLAG", width: 120, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvOperation, "   검사 데이터", "CHECK_INSPECT_FLAG", width: 120, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "  자재 사용", "CHECK_MATERIAL_FLAG", width: 120, readOnly: true);
         DgvUtil.AddTextCol(dgvOperation, "  생성 시간", "CREATE_TIME", width: 195, readOnly: true, align: 1);
         DgvUtil.AddTextCol(dgvOperation, "   생성 사용자", "CREATE_USER_ID", width: 150, readOnly: true, align: 0);
         DgvUtil.AddTextCol(dgvOperation, "  변경 시간", "UPDATE_TIME", width: 195, readOnly: true, align: 1);
         DgvUtil.AddTextCol(dgvOperation, "   변경 사용자", "UPDATE_USER_ID", width: 150, readOnly: true, align: 0);
      }
      private void PpgInit()
      {
         ppgOperation.PropertySort = PropertySort.Categorized;
         ppgOperation.SelectedObject = new OPERATION_MST_DTO();
      }
      public void DgvFill()
      {
         //btnSearch.PerformClick();
         operations = srvOperation.SelectOperation(condition);
         int seq = 1;
         dgvOperation.DataSource = operations.Select((o) =>
         new
         {
            IDX = seq++,
            OPERATION_CODE = o.OPERATION_CODE,
            OPERATION_NAME = o.OPERATION_NAME,
            CHECK_DEFECT_FLAG = o.CHECK_DEFECT_FLAG,
            CHECK_INSPECT_FLAG = o.CHECK_INSPECT_FLAG,
            CHECK_MATERIAL_FLAG = o.CHECK_MATERIAL_FLAG,
            CREATE_TIME = o.CREATE_TIME,
            CREATE_USER_ID = o.CREATE_USER_ID,
            UPDATE_TIME = o.UPDATE_TIME,
            UPDATE_USER_ID = o.UPDATE_USER_ID
         }).ToList();
      }
      private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         int row = e.RowIndex;
         if (row < 0) return;
         operation = new OPERATION_MST_DTO
         {
            OPERATION_CODE = (string)dgvOperation["OPERATION_CODE", row].Value,
            OPERATION_NAME = (string)dgvOperation["OPERATION_NAME", row].Value,
            CHECK_DEFECT_FLAG = (char)dgvOperation["CHECK_DEFECT_FLAG", row].Value,
            CHECK_INSPECT_FLAG = (char)dgvOperation["CHECK_INSPECT_FLAG", row].Value,
            CHECK_MATERIAL_FLAG = (char)dgvOperation["CHECK_MATERIAL_FLAG", row].Value,
            CREATE_TIME = Convert.ToDateTime(dgvOperation["CREATE_TIME", row].Value),
            CREATE_USER_ID = (string)dgvOperation["CREATE_USER_ID", row].Value,
            UPDATE_TIME = Convert.ToDateTime(dgvOperation["UPDATE_TIME", row].Value),
            UPDATE_USER_ID = (string)dgvOperation["UPDATE_USER_ID", row].Value
         };
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
         dto.CREATE_USER_ID = userinfo.USER_ID;
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
         operation.UPDATE_USER_ID = userinfo.USER_ID;
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
         if (isCondition)
         {
            MboxUtil.MboxError("검색 조건을 먼저 눌러주세요.");
            return;
         }
         operations = srvOperation.SelectOperation(condition);
         int seq = 1;
         dgvOperation.DataSource = operations.Select((o) =>
         new
         {
            IDX = seq++,
            OPERATION_CODE = o.OPERATION_CODE,
            OPERATION_NAME = o.OPERATION_NAME,
            CHECK_DEFECT_FLAG = o.CHECK_DEFECT_FLAG,
            CHECK_INSPECT_FLAG = o.CHECK_INSPECT_FLAG,
            CHECK_MATERIAL_FLAG = o.CHECK_MATERIAL_FLAG,
            CREATE_TIME = o.CREATE_TIME,
            CREATE_USER_ID = o.CREATE_USER_ID,
            UPDATE_TIME = o.UPDATE_TIME,
            UPDATE_USER_ID = o.UPDATE_USER_ID
         }).ToList();
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
      private void btnDelete_Click(object sender, EventArgs e)
      {
         if (dgvOperation.SelectedRows.Count < 1) return;
         if (!MboxUtil.MboxInfo_("선택된 공정을 삭제하시겠습니까 ? ")) return;
         int row = dgvOperation.CurrentRow.Index;
         OPERATION_MST_DTO dto = new OPERATION_MST_DTO
         {
            OPERATION_CODE = (string)dgvOperation["OPERATION_CODE", row].Value,
            OPERATION_NAME = (string)dgvOperation["OPERATION_NAME", row].Value,
            CHECK_DEFECT_FLAG = (char)dgvOperation["CHECK_DEFECT_FLAG", row].Value,
            CHECK_INSPECT_FLAG = (char)dgvOperation["CHECK_INSPECT_FLAG", row].Value,
            CHECK_MATERIAL_FLAG = (char)dgvOperation["CHECK_MATERIAL_FLAG", row].Value,
            CREATE_TIME = Convert.ToDateTime(dgvOperation["CREATE_TIME", row].Value),
            CREATE_USER_ID = (string)dgvOperation["CREATE_USER_ID", row].Value,
            UPDATE_TIME = Convert.ToDateTime(dgvOperation["UPDATE_TIME", row].Value),
            UPDATE_USER_ID = (string)dgvOperation["UPDATE_USER_ID", row].Value
         };
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
