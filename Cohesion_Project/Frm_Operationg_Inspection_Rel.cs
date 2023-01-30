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
    public partial class Frm_Operationg_Inspection_Rel : Cohesion_Project.Frm_Base_4
    {
        Operationg_Inspection_Rel_Search oSearch = new Operationg_Inspection_Rel_Search();
        Srv_Operation svP = new Srv_Operation();

        public Frm_Operationg_Inspection_Rel()
        {
            InitializeComponent();
        }

        private void Frm_Operationg_Inspection_Rel_Load(object sender, EventArgs e)
        {

            InitDgv();

            var list = svP.SelectOperation(new OPERATION_MST_DTO_Condition());

            dgvOperationList.DataSource = list;

        }

        private void InitDgv()
        {
            //데이터 그리드 뷰 초기 설정
            DgvUtil.DgvInit(dgvOperationList);
            DgvUtil.AddTextCol(dgvOperationList, "NO", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "공정 코드", "OPERATION_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "공정명", "OPERATION_NAME", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "불량입력", "CHECK_DEFECT_FLAG", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "검사 데이터 입력", "CHECK_INSPECT_FLAG", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "자재 사용", "CHECK_MATERIAL_FLAG", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "생성 시간", "CREATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "생성자", "CREATE_USER_ID", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "변경 시간", "UPDATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvOperationList, "변경자", "UPDATE_USER_ID", 120, readOnly: true);

            DgvUtil.DgvInit(dgvAddedInspection);
            DgvUtil.AddTextCol(dgvAddedInspection, "순번", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedInspection, "검사 항목 코드", "INSPECT_ITEM_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddedInspection, "검사 항목명", "INSPECT_ITEM_NAME", 100, readOnly: true);

            DgvUtil.DgvInit(dgvInspectionList);
            DgvUtil.AddTextCol(dgvInspectionList, "순번", "CODE_TABLE_NAME", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvInspectionList, "검사 항목 코드", "INSPECT_ITEM_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvInspectionList, "검사 항목명", "INSPECT_ITEM_NAME", 100, readOnly: true);

            ppgSearchCondition.PropertySort = PropertySort.Categorized;
            ppgSearchCondition.SelectedObject = oSearch;
        }
    }
}
