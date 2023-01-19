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
    public partial class Frm_UserGroup : Frm_Base_2
    {
        Srv_UserGroup Srv_UserGroup;
        List<UserGroup_DTO> UGroupList;
        public Frm_UserGroup()
        {
            InitializeComponent();
        }

        private void Frm_UserGroup_Load(object sender, EventArgs e)
        {
            Srv_UserGroup = new Srv_UserGroup();
            DgvInit();
            DataGridViewFill();

 

        }

        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUserGroup);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 코드", "USER_GROUP_CODE", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 명", "USER_GROUP_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 유형", "USER_GROUP_TYPE", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "생선 시간 ", "CREATE_TIME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "생성 사용자 ", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 시간 ", "UPDATE_TIME", 120, true, align: 2);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 사용자", "UPDATE_USER_ID", 120, true, align: 1);

        }


        private void DataGridViewFill()
        {
            UGroupList = Srv_UserGroup.SelectUserGroup();
            DgvUserGroup.DataSource = UGroupList;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvUserGroup.SelectedRows.Count < 1)
                return;
            if(MessageBox.Show($"{DgvUserGroup[1, DgvUserGroup.CurrentRow.Index].Value.ToString()} 사용자구릅을 삭제하시겠습니까 ?", "알림",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)return;
            int userGroupCode = Convert.ToInt32(DgvUserGroup[0, DgvUserGroup.CurrentRow.Index].Value);
            bool result = Srv_UserGroup.DeleteUserGroup(userGroupCode);
            if (!result)
            {
                MessageBox.Show("권한 저장정보가 삭제되었습니다.", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewFill();
                DgvUserGroup.ClearSelection();
            }
        }
    }


}

