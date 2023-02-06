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
    public partial class Frm_WorkOrder : Cohesion_Project.Frm_Base_2
    {
        Srv_WorkOrder srv = new Srv_WorkOrder();
        Work_Order_MST_DTO wOrder = null;
        List<Work_Order_MST_DTO> temp = null;
        string Uid, wCode, Status;
        public Frm_WorkOrder()
        {
            InitializeComponent();
        }
        public Frm_WorkOrder(string uid)
        {
            Uid = uid;
            InitializeComponent();
        }

        private void Frm_WorkOrder_Load(object sender, EventArgs e)
        {
            temp = srv.SelectWorkOrders(new Work_Order_SEARCH_DTO());
            ComboUtil.WorkOrder = (from t in temp
                                   select t.WORK_ORDER_ID).ToList();
            GetWorkOrderList();
            DataGridClean();
        }

        private void GetWorkOrderList()
        {// WORK_ORDER_ID, ORDER_DATE, PRODUCT_CODE, CUSTOMER_CODE, ORDER_QTY, ORDER_STATUS, PRODUCT_QTY, DEFECT_QTY, WORK_START_TIME,
         // WORK_CLOSE_TIME, WORK_CLOSE_USER_ID, CREATE_TIME, CREATE_USER_ID, UPDATE_TIME, UPDATE_USER_ID
            DgvUtil.DgvInit(dgvWorkOrderList);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 작업지시 코드", "WORK_ORDER_ID", width: 200, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업 일자", "ORDER_DATE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "고객사 코드", "CUSTOMER_CODE", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "계획 수량", "ORDER_QTY", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 상태", "ORDER_STATUS", width: 140, readOnly: true);    // 최초 : OPEN, 생산 중 : PROC, 마감 : CLOSE
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 생성 시간", "CREATE_TIME", width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 생성 사용자", "CREATE_USER_ID", width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 변경 시간", "UPDATE_TIME", width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업지시 변경 사용자", "UPDATE_USER_ID", width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "생산 수량", "PRODUCT_QTY", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "불량 수량", "DEFECT_QTY", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "작업 시작 시간", "WORK_START_TIME", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 마감 시간", "WORK_CLOSE_TIME", width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "지시 마감자", "WORK_CLOSE_USER_ID", width: 140, readOnly: true);
        }

        private void DataGridClean()
        {
            dgvWorkOrderList.DataSource = null;
            dgvWorkOrderList.DataSource = srv.GetAllWorkOrderList();
            ppgWorkOrderSearch.PropertySort = PropertySort.Categorized;
            ppgWorkOrderSearch.SelectedObject = new Work_Order_MST_DTO();
            dgvWorkOrderList.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pop_WorkOrder frm = new Pop_WorkOrder(Uid);
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                DataGridClean();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Work_Order_SEARCH_DTO list = (Work_Order_SEARCH_DTO)ppgWorkOrderSearch.SelectedObject;
            if (string.IsNullOrWhiteSpace(txtSearch.Text) &&
                list.WORK_ORDER_ID == null &&
                list.CUSTOMER_CODE == null &&
                list.CREATE_USER_ID == null &&
                list.PRODUCT_CODE == null &&
                list.ORDER_STATUS == null)
            {
                MboxUtil.MboxWarn("검색조건을 입력해주세요.");
                return;
            }
            else
            {
                dgvWorkOrderList.DataSource = srv.SelectWorkOrders(list);
            }
        }

        private void dgvWorkOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ppgWorkOrderSearch.PropertySort = PropertySort.Categorized;
            ppgWorkOrderSearch.SelectedObject = DgvUtil.DgvToDto<Work_Order_MST_DTO>(dgvWorkOrderList);
            Status = dgvWorkOrderList[5, e.RowIndex].Value.ToString();
            wCode = dgvWorkOrderList[0, e.RowIndex].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataGridClean();
            txtSearch.Text = "";
            dgvWorkOrderList.ClearSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var list = this.ppgWorkOrderSearch.SelectedObject as Work_Order_MST_DTO;
            if (btnUpdate.Text == "      변  경") return;
            else
            {
                if (wOrder.Equals(list))
                {
                    MboxUtil.MboxWarn("변경사항이 존재하지 않습니다.\n변경을 취소합니다.");
                    btnUpdate.PerformClick();
                }
                else
                {
                    if (!MboxUtil.MboxInfo_("작업지시 내역을 변경하시겠습니까?")) return;
                    else
                    {
                        srv.UpdateWorkOrder(wOrder, Uid);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (lbl3.Text == "▶ 속성")
            {
                btnSearch.Enabled = true;
                dgvWorkOrderList.ClearSelection();
                ppgWorkOrderSearch.Enabled = true;
                ppgWorkOrderSearch.SelectedObject = new Work_Order_SEARCH_DTO();
                lbl3.Text = "▶ 검색 상세 조건";
            }
            else
            {
                btnSearch.Enabled = false;
                dgvWorkOrderList.ClearSelection();
                ppgWorkOrderSearch.Enabled = false;
                ppgWorkOrderSearch.SelectedObject = DgvUtil.DgvToDto<Work_Order_MST_DTO>(dgvWorkOrderList);
                lbl3.Text = "▶ 속성";
            }
        }

        private void ppgWorkOrderSearch_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Description.Equals("WORK_ORDER_ID"))
            {
                var list = temp.Find((c) => c.WORK_ORDER_ID.Equals(e.ChangedItem.Value.ToString()));
                if (list != null)
                {
                    Work_Order_SEARCH_DTO wwork = (Work_Order_SEARCH_DTO)ppgWorkOrderSearch.SelectedObject;
                    wwork.PRODUCT_CODE = list.PRODUCT_CODE;
                    wwork.CUSTOMER_CODE = list.CUSTOMER_CODE;
                    wwork.ORDER_STATUS = list.ORDER_STATUS;
                    wwork.CREATE_USER_ID = list.CREATE_USER_ID;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "      변  경")
            {
                if(dgvWorkOrderList.SelectedRows.Count < 1)
                {
                    MboxUtil.MboxWarn("선택된 내역이 없습니다.\n다시 시도해주세요.");
                    return;
                }
                wOrder = (Work_Order_MST_DTO)ppgWorkOrderSearch.SelectedObject;

                dgvWorkOrderList.Enabled = false;
                btnUpdate.Text = "      취  소";
                ppgWorkOrderSearch.Enabled = true;
                btnAdd.Enabled = false;
                btnRefresh.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                dgvWorkOrderList.Enabled = true;
                btnUpdate.Text = "      변  경";
                ppgWorkOrderSearch.Enabled = false;
                btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvWorkOrderList.SelectedRows.Count < 0)
            {
                MboxUtil.MboxWarn("삭제하실 작업지시를 선택해주세요.");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Status)) return;
                if(!Status.Equals("OPEN"))
                {
                    MboxUtil.MboxWarn("해당 작업지시는 삭제하실 수 없습니다.");
                    return;
                }
                else
                {
                    if (!MboxUtil.MboxInfo_("정말 삭제하시겠습니까?")) return;
                    else
                    {
                        srv.DeleteWorkOrder(wCode);
                        MboxUtil.MboxInfo("삭제가 완료되었습니다.");
                        dgvWorkOrderList.Refresh();
                    }
                }
            }
        }
    }
}
