using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_UserMgt : Frm_Base_2
    {
        public Frm_UserMgt()
        {
            InitializeComponent();
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            DgvInit();
        }
        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUser);
            DgvUtil.AddTextCol(DgvUser,  "사용자 코드", "USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 이름", "USER_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 그룹", "USER_GROUP_CODE",  120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "암호 ", "USER_PASSWORD", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "부서 ", "USER_DEPARTMENT",  120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "생성 시간 ", "CREATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "사용자", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "수정 시간", "UPDATE_TIME",  120, true, align: 2);
            DgvUtil.AddTextCol(DgvUser, "사용자 ", "UPDATE_USER_ID",  120, true, align: 1);
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Udate data = Ppg_User.SelectedObject as Udate;

            var dto = PropertyToDto<Udate, User_DTO>(data);
            dto.CREATE_TIME = DateTime.Now;
            bool result = srv_U.InsertUser(dto);

            if (result)
            {
                MessageBox.Show("입력 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("입력 실패");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ppg_User.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var data = Ppg_User.SelectedObject as Udate;
            if (data.USER_ID == null)
            {
                MessageBox.Show("변경할 유저ID을 선택해주세요.");
                return;
            }
            var dto = PropertyToDto<Udate, User_DTO>(data);
            dto.UPDATE_TIME = DateTime.Now;
            bool result = srv_U.UpdateUser(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }

            //   Ppg_UserGourp.Enabled = false; 추적창만 펄스해야 됨 안됨
            btnAdd.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Udate blankData = new Udate();
            Ppg_User.SelectedObject = blankData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
