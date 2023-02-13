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
    public partial class Frm_Login : Form
    {
        public User_DTO user = null;
        Srv_User srv = null;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            srv = new Srv_User();
            user = new User_DTO();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUserID.Text)||string.IsNullOrWhiteSpace(txtUserPwd.Text))
            {
                MboxUtil.MboxWarn("회원 아이디/비밀번호를 제대로 입력해주세요.");
                return;
            }
            user = srv.GetAdmin(txtUserID.Text, txtUserPwd.Text);
            if(user == null || user.USER_ID == null)
            {
                MboxUtil.MboxWarn("다시 시도해주세요.");
                return;
            }
            if (!txtUserID.Text.Equals(user.USER_ID) && !txtUserPwd.Text.Equals(user.USER_PASSWORD))
            {
                MboxUtil.MboxWarn("다시 시도해주세요.");
                return;
            }
            else
            {
                MboxUtil.MboxInfo($"{user.USER_NAME}님 반갑습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }
    }
}
