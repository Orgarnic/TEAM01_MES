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
    public partial class Pop_CommonTableData : Form
    {
        Srv_CommonData srvC = new Srv_CommonData();
        CommonTable_DTO target = new CommonTable_DTO();
        bool tagMove;
        int x, y = default;
        public Pop_CommonTableData()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pop_CommonTableData_Load(object sender, EventArgs e)
        {
            DgvUtil.DgvInit(Dgv_DataTable);
            Dgv_DataTable.DataSource = null;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "수정 여부";
            Dgv_DataTable.Columns.Add(chk);
            DgvUtil.AddTextCol(Dgv_DataTable, "순서", "DISPLAY_SEQ", 100, readOnly: true, align:1 );

            MakeColumn();
            LoadData();

            Lbl_Title.MouseDown += Lbl_Title_MouseDown;
            Lbl_Title.MouseMove += Lbl_Title_MouseMove;
            Lbl_Title.MouseUp += Lbl_Title_MouseUp;

            Dgv_DataTable.CellValueChanged += Dgv_DataTable_CellValueChanged;
         
        }

        //=============================================================라벨 이벤트===========================================================

        private void Lbl_Title_MouseUp(object sender, MouseEventArgs e)
        {
            tagMove = false;
        }

        private void Lbl_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (tagMove)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void Lbl_Title_MouseDown(object sender, MouseEventArgs e)
        {
            tagMove = true;
            x = e.X;
            y = e.Y;

        }
        private void LoadData()
        {
            var list = srvC.SelectCommonTableData(target.CODE_TABLE_NAME);
            
            //데이터 입력을 받기위한, 행추가
            list.Add(new CommonData_DTO { DISPLAY_SEQ = null });
            
            Dgv_DataTable.DataSource = list;
        }


        //============================================================그리드 이벤트===========================================================

        private void Dgv_DataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Dgv_DataTable[0, e.RowIndex].Value = true;
        }
        
        //=============================================================버튼 이벤트===========================================================

        private void Btn_Delete_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.FromArgb(13, 76, 115);
        }

        private void Btn_Delete_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            //체크 되어있는 것만 데이터에 삽입한다.
            List<CommonData_DTO> list = new List<CommonData_DTO>();

            foreach (DataGridViewRow row in Dgv_DataTable.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    list.Add((CommonData_DTO)row.DataBoundItem);
                }
            }
            bool result = srvC.UpsertCommonTableData(target.CODE_TABLE_NAME, list);
            if (result)
            {
                MboxUtil.MboxInfo("데이터 저장을 완료했습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("데이터 저장에 실패했습니다. 다시 시도해주세요.");
            }

            //체크 되어 있는 것을 저장
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택된 테이블 정보를 삭제하시겠습니까 ? "))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<CommonData_DTO>(Dgv_DataTable);
            bool result = srvC.DeleteTableData(target.CODE_TABLE_NAME,dto);
            if (result)
            {
                MboxUtil.MboxInfo("데이터 삭제 성공.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("데이터 삭제 실패.");
            }
        }

        //=============================================================컬럼 동적 생성========================================================

        private void MakeColumn()
        {
            Frm_Common f1 = (Frm_Common)this.Owner;
            target = f1.Table;

            for (int i = 2; i < target.GetType().GetProperties().Length; i++)
            {
                var value = target.GetType().GetProperties()[i].GetValue(target);
                if (value == null || target.GetType().GetProperties()[i].Name.Contains("USER_ID") || target.GetType().GetProperties()[i].Name.Contains("TIME"))
                {
                    DgvUtil.AddTextCol(Dgv_DataTable, $"{value}", $"{target.GetType().GetProperties()[i].Name.Replace("_NAME", "")}", 100, visible: false, align: 1);
                    continue;
                }
                DgvUtil.AddTextCol(Dgv_DataTable, $"{value}", $"{target.GetType().GetProperties()[i].Name.Replace("_NAME", "")}", 100, readOnly: false, align: 1);
            }
        }
    }
}
