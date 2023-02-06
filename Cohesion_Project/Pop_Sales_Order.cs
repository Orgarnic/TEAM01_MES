using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cohesion_DAO;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Pop_Sales_Order : Cohesion_Project.Base.Frm_BaseNone
    {
        //List<Sales_Order_DTO> sales = null;
        Srv_Sales_Order srvSales = new Srv_Sales_Order();
        private List<Sales_Order_VO> productCode = new List<Sales_Order_VO>();

        Srv_Sales_Order svr = new Srv_Sales_Order();
        List<Sales_Order_VO> productList;

        bool stockAvailable = false;

        public string ProductCode { get; set; }
        public string SalesOrderID { get; set; }
        public bool StockAvailable { get { return stockAvailable; } set { stockAvailable = value; } }
        public Pop_Sales_Order()
        {
            InitializeComponent();
        }

        private void Pop_Sales_Order_Load(object sender, EventArgs e)
        {
            DataGridViewBinding();
            FormCondition();
            if (dgvList.Rows.Count == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                stockAvailable = true;
                btnClose.PerformClick();
            }
        }
        
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgvList);
            DgvUtil.AddTextCol(dgvList, "주문코드", "SALES_ORDER_ID", 150, readOnly: true, align: 0, visible:false);
            DgvUtil.AddTextCol(dgvList, "제품코드", "PRODUCT_CODE", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgvList, "제품명", "PRODUCT_NAME", 120, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgvList, "주문수량", "ORDER_QTY", 120, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgvList, "자재품번", "CHILD_PRODUCT_CODE", 120, readOnly: true, align: 0);
            //DgvUtil.AddTextCol(dgvList, "자재품명", "CHILD_PRODUCT_NAME", 120, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgvList, "소요수량", "REQUIRE_QTY", 120, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgvList, "총 소요수량", "NEED_QTY", 120, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgvList, "거래처", "VENDOR_CODE", 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgvList, "현재 로트 수량", "LOT_QTY", 120, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgvList, "주문 필요 수량", "PURCHASE_QTY", 130, readOnly: true, align: 2);
            DgvUtil.AddTextCol(dgvList, "주문 요청 수량", "ORDERING_QTY", 120, readOnly: false, align: 2);
        }
        private void FormCondition()
        {
            productList = svr.SelectSalesOrderState(ProductCode, SalesOrderID);
            dgvList.DataSource = productList.Where((C) => C.PURCHASE_QTY != "0" ).ToList();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (MboxUtil.MboxInfo_("주문을 등록하시겠습니까?"))
            //    return;

            List<Sales_Order_VO> list = new List<Sales_Order_VO>();
            int cnt = 0;

            Sales_Order_VO purchase = new Sales_Order_VO();
            if (dgvList.Rows.Count==0)
            {
                stockAvailable = true;
                return;
            }
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                purchase = new Sales_Order_VO
                {
                    CHILD_PRODUCT_CODE = row.Cells["CHILD_PRODUCT_CODE"].Value.ToString(),
                    SALES_ORDER_ID = row.Cells["SALES_ORDER_ID"].Value.ToString(),
                    VENDOR_CODE = row.Cells["VENDOR_CODE"].Value.ToString(),
                    MATERIAL_CODE = row.Cells["CHILD_PRODUCT_CODE"].Value.ToString(),
                    ORDERING_QTY = Convert.ToInt32(row.Cells["ORDERING_QTY"].Value)
                };
                cnt++;
                list.Add(purchase);
                
            }
            var result = svr.InsertPurchase(list);

            if (result)
            {
                var mboxResult = MessageBox.Show("주문을 등록하시겠습니까?", "알림", MessageBoxButtons.YesNo);
                //MboxUtil.MboxInfo_("주문을 등록하시겠습니까?");
                if (mboxResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else    
                MboxUtil.MboxWarn("주문 등록 중중 오류가 발생했습니다. 다시 시도해주세요.");

            this.Close();
        }
    }
}
