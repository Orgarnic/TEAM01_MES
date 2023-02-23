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
        bool TagMove;
        int MX, MY;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void txtUserPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MX = e.X;
            MY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MX, MousePosition.Y - MY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }
    }
}
