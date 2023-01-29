﻿using System;
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
        List<Sales_Order_DTO> order = null;
        Work_Order_MST_DTO initWork = null;
        Srv_WorkOrder work = new Srv_WorkOrder();
        string userID, oCode, pCode;
        decimal orderQty = 0, lotQty = 0;
        public Pop_WorkOrder()
        {
            InitializeComponent();
        }
        public Pop_WorkOrder(string userid)
        {
            userID = userid;
            InitializeComponent();
        }

        private void Pop_WorkOrder_Load(object sender, EventArgs e)
        {
            GetAllOrderData();
            InitoOrderList();
        }

        private void GetAllOrderData()
        {
            DgvUtil.DgvInit(dgvOrderList);
            DgvUtil.AddTextCol(dgvOrderList, "주문 코드", "SALES_ORDER_ID", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주문 일자", "ORDER_DATE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "고객 코드", "CUSTOMER_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주문 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true); 
            DgvUtil.AddTextCol(dgvOrderList, "재고 수량", "LOT_QTY", width: 140, readOnly: true, frozen: true);


            DgvUtil.DgvInit(dgvBOMStock);
            DgvUtil.AddTextCol(dgvBOMStock, "제품 코드", "CHILD_PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제품명", "PRODUCT_NAME", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제품 유형", "PRODUCT_TYPE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "단위 수량", "REQUIRE_QTY", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "제작 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMStock, "재고 수량", "LOT_QTY", width: 140, readOnly: true, frozen: true);
        }

        private void InitoOrderList()
        {
            order = work.SelectOrderList();
            dgvOrderList.DataSource = order;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            decimal oQty = 0, lQty = 0;
            if(dgvOrderList.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("작업지시를 등록하실 주문내역을 선택해주세요.");
                return;
            }
            if(orderQty > lotQty)
            {
                if (MboxUtil.MboxInfo_("현재 재고가 부족합니다.\n해당 제품에 대한 생산지시를 등록하시겠습니까?") == false) return;
                else
                {
                    for (int i = 0; i < dgvBOMStock.Rows.Count; i++)
                    {
                        oQty = Convert.ToDecimal(dgvBOMStock[4, i].Value);
                        lQty = Convert.ToDecimal(dgvBOMStock[5, i].Value);
                        if (oQty > lQty)
                        {
                            if (MboxUtil.MboxWarn_("자품목의 자재가 부족합니다.\n해당 자재의 주문을 등록하시겠습니까?") == false) return;
                            else
                            {
                                // 주문 등록 폼으로 이동 + 해당 내역의 정보르 가지고 가야함.
                                Frm_Sales_Order order = new Frm_Sales_Order();
                                order.Show();
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                if (MboxUtil.MboxInfo_("해당 주문내역으로 작업지시를 등록하시겠습니까?") == false) return;
                else
                {
                    bool result = work.InsertWorkOrder(initWork);
                    if(!result)
                    {
                        MboxUtil.MboxError("등록되지 못했습니다.\n다시 시도해주세요.");
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = order.FindAll((p) => p.PRODUCT_CODE.Contains(txtSearch.Text.ToUpper()));
            dgvOrderList.DataSource = list;
        }

        private void dgvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            orderQty = Convert.ToDecimal(dgvOrderList[4, e.RowIndex].Value.ToString());
            lotQty = Convert.ToDecimal(dgvOrderList[5, e.RowIndex].Value.ToString());
            oCode = dgvOrderList[0, e.RowIndex].Value.ToString();
            pCode = dgvOrderList[3, e.RowIndex].Value.ToString();
            dgvBOMStock.DataSource = work.GetOrderProductBOM(oCode, pCode);
            initWork = new Work_Order_MST_DTO
            {
                CUSTOMER_CODE = dgvOrderList[2, e.RowIndex].Value.ToString().Trim(),
                PRODUCT_CODE = dgvOrderList[3, e.RowIndex].Value.ToString().Trim(),
                ORDER_QTY = orderQty,
                ORDER_STATUS = "OPEN",
                
                CREATE_USER_ID = "김재형" // 임시 관리자 지정 => 추후에 관리자별 지정으로 변경 예정(로그인한 관리자에 따라)
                //CREATE_USER_ID = userID
            };

            
        }
    }
}
