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
        Srv_Sales_Order srvSalesOrder = new Srv_Sales_Order();
        List<Sales_Order_DTO> srcList;
        public Frm_Sales_Order()
        {
            InitializeComponent();
        }

        private void Frm_Sales_Order_Load(object sender, EventArgs e)
        {
            DataGridViewBinding();

        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_SalesOrder);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문코드", "SALES_ORDER_ID", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문일자", "ORDER_DATE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사코드", "CUSTOMER_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "고객사명", "", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품코드", "PRODUCT_CODE", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "제품명", "", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "주문수량", "ORDER_QTY", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "확정여부", "CONFIRM_FLAG", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "배송여부", "SHIP_FLAG", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성시간", "CREATE_TIME", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "생성 사용자", "CREATE_USER_ID", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경시간", "UPDATE_TIME", 150, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_SalesOrder, "변경 사용자", "UPDATE_USER_ID", 150, readOnly: true, align: 1);

            LoadData();
        }
        private void FormCondition()
        {
            lbl4.Text = "▶ 주문 목록";
            lbl3.Text = "▶ 주문 속성";

            ppg_SalesOrder.PropertySort = PropertySort.Categorized;
            ppg_SalesOrder.SelectedObject = iProperty;
        }

        private void LoadData()
        {
            srcList = srvSalesOrder.SelectSalesList();
            dgv_SalesOrder.DataSource = srcList;
        }
    }
}
