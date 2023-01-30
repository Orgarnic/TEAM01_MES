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
        List<Sales_Order_Work_DTO> order = null;
        List<BOM_MST_DTO> bom = null;
        Work_Order_MST_DTO initWork = null;
        Srv_WorkOrder work = new Srv_WorkOrder();
        List<PRODUCT_OPERATION_REL_DTO> operations = null;

        string userID, oCode, pCode;
        int totQty = 0;
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
            operations = work.GetOperationRel();
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
            int cnt = 0;
            decimal oQty = 0, lQty = 0;
            if(dgvOrderList.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("작업지시를 등록하실 주문내역을 선택해주세요.");
                return;
            }
            if(orderQty > lotQty)
            {
                totQty = Convert.ToInt32(orderQty - lotQty);
                if (MboxUtil.MboxInfo_("현재 재고가 부족합니다.\n해당 제품에 대한 생산지시를 등록하시겠습니까?") == false) return;
                else
                {
                    List<Work_Order_MST_DTO> inData = new List<Work_Order_MST_DTO>();
                    Work_Order_MST_DTO dto = null;
                    for (int i = 0; i < dgvBOMStock.Rows.Count; i++)
                    {
                        oQty = Convert.ToDecimal(dgvBOMStock[4, i].Value);
                        lQty = Convert.ToDecimal(dgvBOMStock[5, i].Value);
                        int tQty = Convert.ToInt32(oQty - lQty);
                        if (oQty > lQty /*&& operations.Find((p)=>p.PRODUCT_CODE.Equals(dgvBOMStock[0,i].Value.ToString())) != null*/)
                        {
                            dto = new Work_Order_MST_DTO
                            {
                                PRODUCT_CODE = dgvBOMStock[0, i].Value.ToString(),
                                ORDER_QTY = tQty,
                                ORDER_STATUS = "OPEN",
                                CREATE_USER_ID = "유기현",
                                CREATE_TIME = DateTime.Now,
                                CUSTOMER_CODE = DBNull.Value.ToString()
                            };
                            inData.Add(dto);
                            cnt++;
                        }
                    }
                    if (MboxUtil.MboxInfo_($"총 {cnt}건의 자품목 생산등록이 가능합니다.\n등록하시겠습니까?") == false) return;
                    else
                    {
                        for (int j = 0; j < inData.Count; j++)
                        {
                            bool check = work.InsertWorkOrder(inData[j]);
                            if (!check)
                            {
                                MboxUtil.MboxWarn("등록되지 못했습니다.\n다시 시도해주세요.");
                                return;
                            }
                        }
                    }
                    MboxUtil.MboxInfo("생산지시 등록이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
                        MboxUtil.MboxInfo("생산지시 등록이 완료되었습니다.");
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
            dgvBOMStock.ClearSelection();
            if (e.RowIndex < 0) return;
            orderQty = Convert.ToDecimal(dgvOrderList[4, e.RowIndex].Value.ToString());
            lotQty = Convert.ToDecimal(dgvOrderList[5, e.RowIndex].Value.ToString());
            oCode = dgvOrderList[0, e.RowIndex].Value.ToString();
            pCode = dgvOrderList[3, e.RowIndex].Value.ToString();
            bom = work.GetOrderProductBOM(oCode, pCode);
            dgvBOMStock.DataSource = bom;
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
