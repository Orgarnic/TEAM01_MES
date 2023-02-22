using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Pop_WorkOrder : Form
    {
        List<Sales_Order_Work_DTO> order = null;
        List<BOM_MST_WORKORDER_DTO> bom = null;
        Work_Order_MST_DTO initWork = null;
        Srv_WorkOrder work = new Srv_WorkOrder();
        List<PRODUCT_OPERATION_REL_DTO> operations = null;
        List<PRODUCT_MST_DTO> product = new List<PRODUCT_MST_DTO>();
        User_DTO user = new User_DTO();

        string oCode, pCode;
        int totQty = 0, row = 0;
        decimal orderQty, lotQty;
        public Pop_WorkOrder()
        {
            InitializeComponent();
        }
        public Pop_WorkOrder(User_DTO userinfo)
        {
            user = userinfo;
            InitializeComponent();
        }

        private void Pop_WorkOrder_Load(object sender, EventArgs e)
        {
            GetAllOrderData();
            InitoOrderList();
            operations = work.GetOperationRel();
            product = work.GetAllProduct();
        }

        private void GetAllOrderData()
        {
            DgvUtil.DgvInit(dgvOrderList);
            DgvUtil.AddTextCol(dgvOrderList, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
            DgvUtil.AddTextCol(dgvOrderList, "주문 코드", "SALES_ORDER_ID", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주문 일자", "ORDER_DATE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "고객 코드", "CUSTOMER_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주문 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "재고 수량", "LOT_QTY", width: 140, readOnly: true, frozen: true);

            DgvUtil.DgvInit(dgvBOMStock);
            DgvUtil.AddTextCol(dgvBOMStock, "제품 코드", "CHILD_PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제품명",    "PRODUCT_NAME", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제품 유형", "PRODUCT_TYPE", width: 100, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "매입처",    "VENDOR_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "단위 수량", "REQUIRE_QTY", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제작 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "재고 수량", "LOT_QTY", width: 140, readOnly: true, frozen: true);
        }

        private void InitoOrderList()
        {
            order = work.SelectOrderList();
         int seq = 1;
            dgvOrderList.DataSource = order.Select((o) => 
            new
            {
               IDX = seq ++,
               SALES_ORDER_ID = o.SALES_ORDER_ID,
               ORDER_DATE = o.ORDER_DATE,
               CUSTOMER_CODE = o.CUSTOMER_CODE,
               PRODUCT_CODE = o.PRODUCT_CODE,
               ORDER_QTY = o.ORDER_QTY,
               LOT_QTY = o.LOT_QTY
            }).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            decimal oQty = 0, lQty = 0, tot = 0;
            if(dgvOrderList.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("작업지시를 등록하실 주문내역을 선택해주세요.");
                return;
            }

            if(orderQty > lotQty)
            {
                totQty = Convert.ToInt32(orderQty - lotQty);
                List<Work_Order_MST_DTO> inData = new List<Work_Order_MST_DTO>();
                Work_Order_MST_DTO dto = null;
                if (MboxUtil.MboxInfo_("현재 재고가 부족합니다.\n해당 제품의 자재에 대한 생산지시를 등록하시겠습니까?") == false) return;
                else
                {
                    for (int i = 0; i < dgvBOMStock.Rows.Count; i++)
                    {
                        oQty = Convert.ToDecimal(dgvBOMStock["ORDER_QTY", i].Value);
                        lQty = Convert.ToDecimal(dgvBOMStock["LOT_QTY", i].Value);
                        if (oQty - lQty < 1) tot = oQty;
                        else tot = oQty - lQty;

                        if (dgvBOMStock["VENDOR_CODE", i].Value == null)    // 매입처가 있는 제품들만 가져오기.
                        {

                            dto = new Work_Order_MST_DTO
                            {
                                PRODUCT_CODE = dgvBOMStock["CHILD_PRODUCT_CODE", i].Value.ToString(),
                                ORDER_QTY = tot,
                                ORDER_STATUS = "OPEN",
                                ORDER_DATE = initWork.ORDER_DATE,
                                CREATE_USER_ID = user.USER_NAME,
                                CREATE_TIME = DateTime.Now,
                                CUSTOMER_CODE = (string)dgvOrderList["CUSTOMER_CODE", row].Value
                            };
                            inData.Add(dto);
                            cnt++;
                        }
                    }
                    if (oQty > lQty)
                    {
                        if (MboxUtil.MboxInfo_($"총 {cnt}건의 품목 생산지시 등록이 가능합니다.\n등록하시겠습니까?") == false) return;
                        else
                        {
                            StringBuilder sv = new StringBuilder();
                            for (int j = 0; j < inData.Count; j++)
                            {
                                bool check = work.InsertWorkOrder(inData[j]);
                                if (!check)
                                {
                                    sv.AppendLine($"{inData[j]}제품이 등록되지 못했습니다.");
                                }
                            }
                            if (sv.Length > 0)
                            {
                                MboxUtil.MboxWarn(sv.ToString());
                                return;
                            }
                        }
                    }
                    else
                    {
                        bool result = work.InsertWorkOrder(initWork);//, result2 = work.UpdateOrderShip(oCode);
                        if (!result)
                        {
                            MboxUtil.MboxError("등록되지 못했습니다.\n다시 시도해주세요.");
                            return;
                        }
                        else
                        {
                            MboxUtil.MboxInfo("생산지시 등록이 완료되었습니다.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (MboxUtil.MboxInfo_("해당 주문내역으로 작업지시를 등록하시겠습니까?") == false) return;
                else
                {
                    bool result = work.InsertWorkOrder(initWork);//, result2 = work.UpdateOrderShip(oCode);
                    if(!result)
                    {
                        MboxUtil.MboxError("등록되지 못했습니다.\n다시 시도해주세요.");
                        return;
                    }
                    else
                    {
                        MboxUtil.MboxInfo("생산지시 등록이 완료되었습니다.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                InitoOrderList();
                return;
            }
            var list = order.FindAll((p) => p.PRODUCT_CODE.Contains(txtSearch.Text.ToUpper()));
            dgvOrderList.DataSource = list;
        }

        private void dgvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBOMStock.ClearSelection();
            if (e.RowIndex < 0) return;
            lotQty = Convert.ToDecimal(dgvOrderList["LOT_QTY", e.RowIndex].Value.ToString());
            orderQty = Convert.ToDecimal(dgvOrderList["ORDER_QTY", e.RowIndex].Value.ToString());
            row = dgvOrderList.CurrentRow.Index;
            oCode = dgvOrderList["SALES_ORDER_ID", e.RowIndex].Value.ToString();
            pCode = dgvOrderList["PRODUCT_CODE", e.RowIndex].Value.ToString();
            bom = work.GetOrderProductBOM(oCode, pCode);
            dgvBOMStock.DataSource = bom;
            initWork = new Work_Order_MST_DTO
            {
                CUSTOMER_CODE = dgvOrderList["CUSTOMER_CODE", e.RowIndex].Value.ToString().Trim(),
                PRODUCT_CODE = dgvOrderList["PRODUCT_CODE", e.RowIndex].Value.ToString().Trim(),
                ORDER_DATE = Convert.ToDateTime(dgvOrderList["ORDER_DATE", e.RowIndex].Value.ToString()),
                ORDER_QTY = orderQty,
                ORDER_STATUS = "OPEN",
                CREATE_USER_ID = user.USER_NAME
            };

            
        }
    }
}
