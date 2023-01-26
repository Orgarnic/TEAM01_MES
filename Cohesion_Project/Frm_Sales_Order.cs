using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cohesion_DAO;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Sales_Order : Cohesion_Project.Frm_Base_2
    {
        private Sales_Order_DTO iProperty = new Sales_Order_DTO();
        private Sales_Order_DTO_Search sProperty = new Sales_Order_DTO_Search();
        Srv_Sales_Order srvSalesOrder = new Srv_Sales_Order();
        Util.ComboUtil comboUtil = new Util.ComboUtil();
        List<Sales_Order_DTO> srcList;

        bool stateSearchCondition = false;
        public Frm_Sales_Order()
        {
            InitializeComponent();
        }

        private void Frm_Sales_Order_Load(object sender, EventArgs e)
        {
            DataGridViewBinding();
            FormCondition();
        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_SalesOrder);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문코드",    "SALES_ORDER_ID",   150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문일자",    "ORDER_DATE",       150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사코드",  "CUSTOMER_CODE",    150, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사명",    "CUSTOMER_NAME",    150, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품코드",    "PRODUCT_CODE",     150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품명",      "PRODUCT_NAME",     150, readOnly: true, align: 1, frozen: true); //> btnAdd_Click -> public List<Sales_Order_DTO> SelectSalesList()
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문수량",    "ORDER_QTY",        150, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgv_SalesOrder, "확정여부",    "CONFIRM_FLAG",     100, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "배송여부",    "SHIP_FLAG",        100, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성시간",    "CREATE_TIME",      150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성 사용자", "CREATE_USER_ID",   150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경시간",    "UPDATE_TIME",      150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경 사용자", "UPDATE_USER_ID",   150, readOnly: true, align: 1);

            LoadData();
        }
        private void FormCondition()
        {
            lbl4.Text = "▶ 주문 목록";
            lbl3.Text = "▶ 신규 주문 생성";

            ppg_SalesOrder.PropertySort = PropertySort.Categorized;
            ppg_SalesOrder.SelectedObject = iProperty;
        }

        private void LoadData()
        {
            srcList = srvSalesOrder.SelectSalesList();
            dgv_SalesOrder.DataSource = srcList;
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                ppg_SalesOrder.SelectedObject = sProperty;
                stateSearchCondition = true;
                btnAdd.Enabled = true;
            }
            else
            {
                lbl3.Text = "▶ 신규 주문 생성";
                ppg_SalesOrder.Enabled = true;
                ppg_SalesOrder.SelectedObject = iProperty;
                stateSearchCondition = false;
                btnAdd.Enabled = true;
            }
        }

        private void dgv_SalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            iProperty = dgv_SalesOrder.Rows[e.RowIndex].DataBoundItem as Sales_Order_DTO;
            ppg_SalesOrder.SelectedObject = iProperty;
            ppg_SalesOrder.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sales_Order_DTO dto = ppg_SalesOrder.SelectedObject as Sales_Order_DTO;
            if (dto.CUSTOMER_CODE == null || dto.PRODUCT_CODE == null || dto.ORDER_QTY == null || dto.PRODUCT_NAME == null) 
            {
                MboxUtil.MboxInfo("등록하실 주문 정보를 입력해주세요.");
                return;
            }

            var list = dgv_SalesOrder.DataSource as List<Sales_Order_DTO>;
            bool codeExist = list.Exists((i) => i.SALES_ORDER_ID.Equals(dto.SALES_ORDER_ID, StringComparison.OrdinalIgnoreCase));
            if (codeExist)
            {
                MboxUtil.MboxInfo("동일한 주문번호가 존재합니다.");
                return;
            }
            dto.CREATE_USER_ID = "정민영";
            dto.CREATE_TIME = DateTime.Now;

            bool result = srvSalesOrder.InsertSalesOrder(dto);
            if (result)
            {
                MboxUtil.MboxInfo("주문 등록이 완료되었습니다.");
                LoadData();
            }
            else
                MboxUtil.MboxError("주문 등록 중 오류가 발생했습니다.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                ppg_SalesOrder.SelectedObject = new Sales_Order_DTO();
                ppg_SalesOrder.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                ppg_SalesOrder.SelectedObject = new Sales_Order_DTO_Search();
                ppg_SalesOrder.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ppg_SalesOrder.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var dto = ppg_SalesOrder.SelectedObject as Sales_Order_DTO;
            if (dto.CUSTOMER_CODE == null || dto.PRODUCT_CODE == null || dto.ORDER_QTY == null || dto.PRODUCT_NAME == null)
            {
                MboxUtil.MboxWarn("변경할 주문 정보를 선택해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_("선택하신 주문 정보를 수정하시겠습니까?"))
            {
                return;
            }
            dto.UPDATE_USER_ID = "정민영";

            bool result = srvSalesOrder.UpdateSalesOrder(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 주문 정보 수정이 완료되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("선택하신 주문 정보 수정 중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택하신 주문 정보를 삭제하시겠습니까?"))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<Sales_Order_DTO>(dgv_SalesOrder);
            bool result = srvSalesOrder.DeleteSalesOrder(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 주문 정보를 삭제가 되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("선택하신 주문 정보를 삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }
    }
}
