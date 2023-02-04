using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Sales_Order : Cohesion_Project.Frm_Base_2
    {
        private Sales_Order_DTO iProperty = new Sales_Order_DTO();
        private Sales_Order_DTO_Search sProperty = new Sales_Order_DTO_Search();
        private List<Sales_Order_DTO> orders = new List<Sales_Order_DTO>();
        Srv_Sales_Order srvSalesOrder = new Srv_Sales_Order();
        Util.ComboUtil comboUtil = new Util.ComboUtil();
        List<Sales_Order_DTO> srcList;

        private List<Sales_Order_DTO> productCode = new List<Sales_Order_DTO>();


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
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문코드",    "SALES_ORDER_ID",   150, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문일자",    "ORDER_DATE",       200, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사코드",  "CUSTOMER_CODE",    150, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사명",    "CUSTOMER_NAME",    120, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품코드",    "PRODUCT_CODE",     120, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품명",      "PRODUCT_NAME",     150, readOnly: true, align: 0, frozen: true); //> btnAdd_Click -> public List<Sales_Order_DTO> SelectSalesList()
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문수량",    "ORDER_QTY",        100, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgv_SalesOrder, "확정여부",    "CONFIRM_FLAG",     90, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "배송여부",    "SHIP_FLAG",        90, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성시간",    "CREATE_TIME",      200, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성 사용자", "CREATE_USER_ID",   130, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경시간",    "UPDATE_TIME",      200, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경 사용자", "UPDATE_USER_ID",   130, readOnly: true, align: 0);

            LoadData();
        }
        private void FormCondition()
        {
            lbl4.Text = "▶ 주문 목록";
            lbl3.Text = "▶ 신규 주문 생성";

            ppg_SalesOrder.PropertySort = PropertySort.Categorized;
            ppg_SalesOrder.SelectedObject = iProperty;

            dgv_SalesOrder.ClearSelection();
        }

        private void LoadData()
        {
            srcList = srvSalesOrder.SelectSalesList();
            dgv_SalesOrder.DataSource = null;
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
            if (dto.CUSTOMER_CODE == null || dto.PRODUCT_CODE == null || dto.ORDER_QTY == null) 
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
            btnRefresh.PerformClick();
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
            LoadData();
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
            bool result = default;

            var dto = ppg_SalesOrder.SelectedObject as Sales_Order_DTO;
            if (dto.CUSTOMER_CODE == null || dto.PRODUCT_CODE == null || dto.ORDER_QTY == null || dto.PRODUCT_NAME == null)
            {
                MboxUtil.MboxWarn("변경할 주문 정보를 선택해주세요.");
                return;
            }

            //>  =============== 주문확정 & 배송 확정 "Y"일 경우 수정 불가 ===============
            //if (dto.CONFIRM_FLAG.Equals("Y") || dto.SHIP_FLAG.Equals("Y"))
            //{
            //    MboxUtil.MboxWarn("주문 또는 배송 확정된 주문은 변경하실 수 없습니다.");
            //    return;
            //}
            //>  ======================================================================
            if (dto.CONFIRM_FLAG == null || dto.CONFIRM_FLAG == "N")
            {
                if(dto.SHIP_FLAG == "Y")
                    MboxUtil.MboxInfo("주문 확정이 되지 않은 주문은 배송여부를 변경할 수 없습니다.");
                
            }

            if (dto.CONFIRM_FLAG == "Y")
            {
                if (dgv_SalesOrder["PRODUCT_CODE", dgv_SalesOrder.CurrentRow.Index].Value == null)
                {
                    if (dgv_SalesOrder[1, dgv_SalesOrder.CurrentRow.Index].Value == null)
                        return;

                    MboxUtil.MboxInfo("수정하실 주문 정보를 선택해주세요.");
                    return;
                }
                if (dto.SHIP_FLAG == "Y")
                {
                    MboxUtil.MboxInfo("배송처리가 완료되었습니다.");

                    result = srvSalesOrder.UpdateSalesOrder(dto);
                    LoadData();
                    return;
                }
                
                Pop_Sales_Order pop = new Pop_Sales_Order();
                pop.ProductCode = dgv_SalesOrder["PRODUCT_CODE", dgv_SalesOrder.CurrentRow.Index].Value.ToString();
                pop.SalesOrderID = dgv_SalesOrder["SALES_ORDER_ID", dgv_SalesOrder.CurrentRow.Index].Value.ToString();
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    MboxUtil.MboxInfo("주문 등록이 완료되었습니다.");

                    //if (pop.StockAvailable)
                    //    MboxUtil.MboxInfo_("주문 확정 처리를 하시겠습니까?");

                    dto.UPDATE_USER_ID = "정민영";
                    dto.UPDATE_TIME = DateTime.Now;
                    result = srvSalesOrder.UpdateSalesOrder(dto);
                    LoadData();
                }
                else if (pop.StockAvailable)
                {
                    MboxUtil.MboxInfo("주문 확정 처리가 되었습니다");
                    result = srvSalesOrder.UpdateSalesOrder(dto);
                    LoadData();
                }
                else
                    MboxUtil.MboxInfo("다시 시도하여 주십시오."); return;
            
            }
            
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Delete_Check_Condition(iProperty)) 
                return;
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
        private bool Delete_Check_Condition(Sales_Order_DTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CONFIRM_FLAG))
            {
                return true;
            }
            if (dto.CONFIRM_FLAG.Equals("Y"))
            {
                MboxUtil.MboxWarn("주문이 확정되어 주문을 삭제하실 수 없습니다.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(dto.SHIP_FLAG))
            {
                return true;
            }
            if (dto.SHIP_FLAG.Equals("Y"))
            {
                MboxUtil.MboxWarn("주문 상품이 출고 처리되어 주문을 삭제하실 수 없습니다.");
                return false;
            }
            
            return true;                    
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (isCondition)
            //{
            //    MboxUtil.MboxError("검색 조건을 입력해주십시오.");
            //    return;
            //}
            orders = srvSalesOrder.SelectOrderWithCondition(sProperty);
            dgv_SalesOrder.DataSource = orders;
            if (ppg_SalesOrder.SelectedObject is Sales_Order_DTO_Search)
            {
                var condition = ppg_SalesOrder.SelectedObject as Sales_Order_DTO_Search;
                var list = srvSalesOrder.SelectOrderWithCondition(condition);
                dgv_SalesOrder.DataSource = list;
            }
            else
            {
                MboxUtil.MboxError("검색 조건을 입력하세요.");
            }
        }
    }
}
