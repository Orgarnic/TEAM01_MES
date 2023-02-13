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
        string wCode, Status;
        User_DTO user = new User_DTO();
        bool change = true;

        public Frm_WorkOrder()
        {
            InitializeComponent();
        }

        private void Frm_WorkOrder_Load(object sender, EventArgs e)
        {
            user = (this.ParentForm as Frm_Main).userInfo;
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
            DgvUtil.AddTextCol(dgvWorkOrderList, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    생산 작업지시 코드", "WORK_ORDER_ID", align: 0, width: 200, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    작업 일자", "ORDER_DATE", width: 200, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    생산 제품명", "PRODUCT_CODE", align: 0, width: 140, readOnly: true, frozen: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    고객사명", "CUSTOMER_CODE", align: 0, width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    계획 수량", "ORDER_QTY", align: 2, width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    지시 상태", "ORDER_STATUS", width: 140, readOnly: true);    // 최초 : OPEN, 생산 중 : PROC, 마감 : CLOSE
            DgvUtil.AddTextCol(dgvWorkOrderList, "    생성 시간", "CREATE_TIME", width: 200, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    생성 사용자", "CREATE_USER_ID", align: 0, width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    변경 시간", "UPDATE_TIME", width: 200, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    변경 사용자", "UPDATE_USER_ID", align: 0, width: 180, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    생산 수량", "PRODUCT_QTY", align: 2, width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    불량 수량", "DEFECT_QTY", align: 2, width: 140, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    작업 시작 시간", "WORK_START_TIME", width: 200, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    지시 마감 시간", "WORK_CLOSE_TIME", width: 200, readOnly: true);
            DgvUtil.AddTextCol(dgvWorkOrderList, "    지시 마감자", "WORK_CLOSE_USER_ID", align: 0, width: 140, readOnly: true);
        }

        private void DataGridClean()
        {
            dgvWorkOrderList.DataSource = null;
            var list = srv.GetAllWorkOrderList();
            int seq = 1;
            dgvWorkOrderList.DataSource = list.Select((l) =>
            new
            {
                IDX = seq++,
                WORK_ORDER_ID = l.WORK_ORDER_ID,
                ORDER_DATE = l.ORDER_DATE,
                PRODUCT_CODE = l.PRODUCT_CODE,
                CUSTOMER_CODE = l.CUSTOMER_CODE,
                ORDER_QTY = l.ORDER_QTY,
                ORDER_STATUS = l.ORDER_STATUS,
                CREATE_TIME = l.CREATE_TIME,
                CREATE_USER_ID = l.CREATE_USER_ID,
                UPDATE_TIME = l.UPDATE_TIME,
                UPDATE_USER_ID = l.UPDATE_USER_ID,
                PRODUCT_QTY = l.PRODUCT_QTY,
                DEFECT_QTY = l.DEFECT_QTY,
                WORK_START_TIME = l.WORK_START_TIME,
                WORK_CLOSE_TIME = l.WORK_CLOSE_TIME,
                WORK_CLOSE_USER_ID = l.WORK_CLOSE_USER_ID
            }).ToList();
            ppgWorkOrderSearch.PropertySort = PropertySort.Categorized;
            ppgWorkOrderSearch.SelectedObject = new Work_Order_MST_DTO();
            dgvWorkOrderList.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pop_WorkOrder frm = new Pop_WorkOrder(user);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
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
                var temp = srv.SelectWorkOrders(list);
                int seq = 1;
                dgvWorkOrderList.DataSource = temp.Select((l) =>
                new
                {
                    IDX = seq++,
                    WORK_ORDER_ID = l.WORK_ORDER_ID,
                    ORDER_DATE = l.ORDER_DATE,
                    PRODUCT_CODE = l.PRODUCT_CODE,
                    CUSTOMER_CODE = l.CUSTOMER_CODE,
                    ORDER_QTY = l.ORDER_QTY,
                    ORDER_STATUS = l.ORDER_STATUS,
                    CREATE_TIME = l.CREATE_TIME,
                    CREATE_USER_ID = l.CREATE_USER_ID,
                    UPDATE_TIME = l.UPDATE_TIME,
                    UPDATE_USER_ID = l.UPDATE_USER_ID,
                    PRODUCT_QTY = l.PRODUCT_QTY,
                    DEFECT_QTY = l.DEFECT_QTY,
                    WORK_START_TIME = l.WORK_START_TIME,
                    WORK_CLOSE_TIME = l.WORK_CLOSE_TIME,
                    WORK_CLOSE_USER_ID = l.WORK_CLOSE_USER_ID
                }).ToList();
            }
        }

        private void dgvWorkOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int row = e.RowIndex;
            ppgWorkOrderSearch.PropertySort = PropertySort.Categorized;
            ppgWorkOrderSearch.SelectedObject = new Work_Order_MST_DTO
            {
                WORK_ORDER_ID = (string)dgvWorkOrderList["WORK_ORDER_ID", row].Value,
                ORDER_DATE = Convert.ToDateTime(dgvWorkOrderList["ORDER_DATE", row].Value),
                PRODUCT_CODE = (string)dgvWorkOrderList["PRODUCT_CODE", row].Value,
                CUSTOMER_CODE = (string)dgvWorkOrderList["CUSTOMER_CODE", row].Value,
                ORDER_QTY = Convert.ToDecimal(dgvWorkOrderList["ORDER_QTY", row].Value),
                ORDER_STATUS = (string)dgvWorkOrderList["ORDER_STATUS", row].Value,
                CREATE_TIME = Convert.ToDateTime(dgvWorkOrderList["CREATE_TIME", row].Value),
                CREATE_USER_ID = (string)dgvWorkOrderList["CREATE_USER_ID", row].Value,
                UPDATE_TIME = Convert.ToDateTime(dgvWorkOrderList["UPDATE_TIME", row].Value),
                UPDATE_USER_ID = (string)dgvWorkOrderList["UPDATE_USER_ID", row].Value,
                PRODUCT_QTY = Convert.ToDecimal(dgvWorkOrderList["PRODUCT_QTY", row].Value),
                DEFECT_QTY = Convert.ToDecimal(dgvWorkOrderList["DEFECT_QTY", row].Value),
                WORK_START_TIME = Convert.ToDateTime(dgvWorkOrderList["WORK_START_TIME", row].Value),
                WORK_CLOSE_TIME = Convert.ToDateTime(dgvWorkOrderList["WORK_CLOSE_TIME", row].Value),
                WORK_CLOSE_USER_ID = (string)dgvWorkOrderList["WORK_CLOSE_USER_ID", row].Value,
            };
            Status = dgvWorkOrderList[5, e.RowIndex].Value.ToString();
            wCode = dgvWorkOrderList[0, e.RowIndex].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!change)
            {
                btnUpdate.PerformClick();
            }
            DataGridClean();
            txtSearch.Text = "";
            dgvWorkOrderList.ClearSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var list = this.ppgWorkOrderSearch.SelectedObject as Work_Order_MST_DTO;
            if (change) return;
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
                        srv.UpdateWorkOrder(wOrder, user.USER_NAME);
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
                ppgWorkOrderSearch.SelectedObject = new Work_Order_MST_DTO();
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
            if (change)
            {
                if (dgvWorkOrderList.SelectedRows.Count < 1)
                {
                    MboxUtil.MboxWarn("선택된 내역이 없습니다.\n다시 시도해주세요.");
                    return;
                }
                wOrder = (Work_Order_MST_DTO)ppgWorkOrderSearch.SelectedObject;

                dgvWorkOrderList.Enabled = false;
                ppgWorkOrderSearch.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                change = false;
            }
            else
            {
                dgvWorkOrderList.Enabled = true;
                ppgWorkOrderSearch.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                change = true;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int row = dgvWorkOrderList.CurrentRow.Index;
            if (dgvWorkOrderList["ORDER_STATUS", row].Value.ToString().Equals("CLOSE"))
            {
                MboxUtil.MboxWarn("이미 마감된 작업지시입니다.");
                return;
            }
            if (dgvWorkOrderList["ORDER_STATUS", row].Value.ToString().Equals("OPEN"))
                if (!MboxUtil.MboxWarn_("공정이 시작되지 않은 작업지시입니다 정말 마감하시겠습니까?")) return;

            Work_Order_MST_DTO dto = new Work_Order_MST_DTO
            {
                CREATE_TIME = Convert.ToDateTime(dgvWorkOrderList["ORDER_DATE", row].Value),
                UPDATE_USER_ID = user.USER_NAME,
                WORK_ORDER_ID = dgvWorkOrderList["WORK_ORDER_ID", row].Value.ToString()
            };
            bool result = srv.EndWorkOrder(dto);
            if (result)
            {
                MboxUtil.MboxInfo("작업지시가 마감되었습니다.");
                btnRefresh.PerformClick();
                btnSearchCondition.PerformClick();
            }
            else
                MboxUtil.MboxError("오류가 발생했습니다.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorkOrderList.SelectedRows.Count < 0)
            {
                MboxUtil.MboxWarn("삭제하실 작업지시를 선택해주세요.");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Status)) return;
                if (!Status.Equals("OPEN"))
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
