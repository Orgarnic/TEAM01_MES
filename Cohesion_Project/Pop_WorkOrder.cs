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

namespace Cohesion_Project
{
    public partial class Pop_WorkOrder : Form
    {
        public Pop_WorkOrder()
        {
            InitializeComponent();
        }

        private void Pop_WorkOrder_Load(object sender, EventArgs e)
        {
            GetAllOrderData();
        }

        private void GetAllOrderData()
        {
            DgvUtil.DgvInit(dgvOrderList);
            DgvUtil.AddTextCol(dgvOrderList, "주문 코드", "SALES_ORDER_ID", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주문 일자", "ORDER_DATE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "고객 코드", "CUSTOMER_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvOrderList, "주무 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true);
        }
    }
}
