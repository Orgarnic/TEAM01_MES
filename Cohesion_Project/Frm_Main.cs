using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public partial class Frm_Main : Form
    {
        User_DTO userInfo = new User_DTO();
        List<Srv_UserGroup> list = null;
        private Util.ComboUtil comboUtil;
        int cnt = 0;
        public Frm_Main()
        {
            InitializeComponent();
        }
        public Frm_Main(User_DTO user)
        {
            InitializeComponent();
            userInfo = user;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Frm_Login login = new Frm_Login();
            DialogResult result = login.ShowDialog(this);

            if(result == DialogResult.OK)
            {
                this.Visible = true;
                userInfo = login.user;
                comboUtil = new Util.ComboUtil();
                list = new List<Srv_UserGroup>();
                lblUserName.Text = userInfo.USER_NAME + "님";
                //MenuIn();
            }
        }
        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.FromArgb(224, 224, 224);
            btn.BackColor = Color.FromArgb(26, 29, 33);
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.FromArgb(26, 29, 33);
            btn.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void OpenCreateForm<T>(Button btn) where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    form.Activate();
                    form.BringToFront();

                    return;
                }
            }
            cnt++;
            T frm = new T();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = btn.Text + "   ";
            cc_TabControl1.TabPages.Add(frm.Text);
            frm.Show();
        }

        private void CheckedForm(Form form, string check)
        {
            form = Application.OpenForms[check];
            if(form == null)
            {

            }
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                cc_TabControl1.Visible = false;
            }
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null) //신규로 탭을 생성하는 경우
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
                    cc_TabControl1.TabPages.Add(tp);

                    tp.Tag = this.ActiveMdiChild;
                    this.ActiveMdiChild.Tag = tp;

                    cc_TabControl1.SelectedTab = tp;

                    //자식폼이 닫힐때 탭페이지도 같이 삭제
                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
                }
                else //기존에 탭이 있는 경우
                {
                    cc_TabControl1.SelectedTab = (TabPage)this.ActiveMdiChild.Tag;
                }

                if (!cc_TabControl1.Visible)
                {
                    cc_TabControl1.Visible = true;
                }
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            ((TabPage)frm.Tag).Dispose();
        }

        private void cc_TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cc_TabControl1.SelectedTab != null)
            {
                Form frm = (Form)cc_TabControl1.SelectedTab.Tag;
                frm.Select();
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Product>(btn);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Sales_Order>(btn);
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_WorkOrder>(btn);
        }

        private void btnProductBOM_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_BOM>(btn);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Store>(btn);
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Operation>(btn);
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Equipment>(btn);
        }

        private void btnEquipmentOperationRel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Equipment_Operation_Rel>(btn);
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Inspection>(btn);
        }

        private void btnOperationInspectionRel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Operation_Inspection_Rel>(btn);
        }

        private void btnProductOperationRel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Product_Operation_Rel>(btn);
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Common>(btn);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_UserMgt>(btn);
        }

        private void btnUserGroup_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_UserGroup>(btn);
        }

        private void btnFunctionUserGroup_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Function_User_Group_Rel>(btn);
        }

        private void btnFuction__Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OpenCreateForm<Frm_Function>(btn);
        }

        private void cc_TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < cc_TabControl1.TabPages.Count; i++)
            {
                var r = cc_TabControl1.GetTabRect(i);
                var closeImage = Properties.Resources.close_grey;
                var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (closeRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    break;
                }
            }
        }
    }
}
