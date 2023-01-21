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

      private void btnSearch_Click(object sender, EventArgs e)
      {
         operations = srvOperation.SelectOperation(condition);
         dgvOperation.DataSource = operations;
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
   }
}
