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
        Work_Order_MST_DTO initWork = null;
        Srv_WorkOrder work = new Srv_WorkOrder();
        string userID;
        int row;
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
            DgvUtil.AddTextCol(dgvOrderList, "주무 수량", "ORDER_QTY", width: 140, readOnly: true, frozen: true);
        }

        private void InitoOrderList()
        {
            dgvOrderList.DataSource = work.SelectOrderList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(dgvOrderList.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("작업지시를 등록하실 주문내역을 선택해주세요.");
                return;
            }
            else
            {
                if (MboxUtil.MboxInfo_("해당 주문내역으로 작업지시를 등록하시겠습니까?") == false) return;
                else
                {
                    work.InsertWorkOrder(initWork);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }
        }

        private void dgvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            initWork = new Work_Order_MST_DTO
            {
                ORDER_DATE = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                CUSTOMER_CODE = dgvOrderList[2, e.RowIndex].Value.ToString().Trim(),
                PRODUCT_CODE = dgvOrderList[3, e.RowIndex].Value.ToString().Trim(),
                ORDER_QTY = Convert.ToInt32(dgvOrderList[4, e.RowIndex].Value.ToString().Trim()),
                ORDER_STATUS = "OPEN",
                CREATE_TIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                CREATE_USER_ID = userID
            };
        }
    }
}
