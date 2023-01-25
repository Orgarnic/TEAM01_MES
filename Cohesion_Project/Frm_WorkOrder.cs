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
    public partial class Frm_WorkOrder : Cohesion_Project.Frm_Base_2
    {
        Work_Order_MST_DTO wOrder = null;
        public Frm_WorkOrder()
        {
            InitializeComponent();
        }

        private void Frm_WorkOrder_Load(object sender, EventArgs e)
        {
            GetWorkOrderList();
        }

        private void GetWorkOrderList()
        {
            DgvUtil.DgvInit(dgvWorkOrderList);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 작업지시 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업 일자", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "고객사 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "계획 수량", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 상태", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);    // 최초 : OPEN, 생산 중 : PROC, 마감 : CLOSE
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 생성 시간", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 생성 사용자", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 변경 시간", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 변경 사용자", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 수량", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "불량 수량", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업 시작 시간", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 마감 시간", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 마감자", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);

            ppgWorkOrderSearch.SelectedObject = new Work_Order_MST_DTO();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ppgWorkOrderSearch.SelectedObject = new 
        }
    }
}
