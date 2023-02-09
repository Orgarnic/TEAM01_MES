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
                MenuIn();
            }
        }

        private void MenuIn()
        {
            string[] str = {"메뉴관리","주문관리","지시관리","사용자관리","권한관리"};
            int[] num = { 1,2,3,4,5 };
            list = new List<Srv_UserGroup>();
            /*foreach (var item in num)
            {
                Button menu = new Button();
                menu.Size = new Size(180, 50);
                menu.BackColor = Color.Transparent;
                menu.Font = new Font("나눔 고딕", 10, FontStyle.Bold);
                menu.ForeColor = Color.White;
                menu.FlatStyle = FlatStyle.Flat;
                menu.FlatAppearance.BorderColor = Color.FromArgb(49, 65, 81);
                menu.Margin = new Padding(0);
                menu.Padding = new Padding(0);
                menu.Text = str[item];
                //menu.Text = item.Name;
                menu.FlatAppearance.BorderSize = 1;
                Flp_Side.Controls.Add(menu);
            }*/

            for (int i = 0; i < num.Length; i++)
            {
                Button menu = new Button();
                menu.Size = new Size(180, 50);
                menu.BackColor = Color.Transparent;
                menu.Font = new Font("나눔 고딕", 10, FontStyle.Bold);
                menu.ForeColor = Color.White;
                menu.FlatStyle = FlatStyle.Flat;
                menu.FlatAppearance.BorderColor = Color.FromArgb(49, 65, 81);
                menu.Margin = new Padding(0);
                menu.Padding = new Padding(left: 30,0,0,0);
                menu.TextAlign = ContentAlignment.MiddleLeft;
                menu.Text = str[i];
                //menu.Text = item.Name;
                menu.FlatAppearance.BorderSize = 1;
                Flp_Side.Controls.Add(menu);
                menu.Click += Menu_Click;
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            btnClick("","");
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

        private void btnClick(string menuName, string tag)
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type tForm = Type.GetType(appName);
            Form fm = Application.OpenForms[$"{tForm.FullName}.{tag}"];
            if(fm.ShowDialog() == DialogResult.OK)
            {
                fm.Activate();
                fm.BringToFront();
            }
            else
            {
                fm.WindowState = FormWindowState.Maximized;
                fm.Show();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Procuct"];
            if( fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Product frm = new Frm_Product();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Procuct";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Order"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Sales_Order frm = new Frm_Sales_Order();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Order";
            }
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_WorkOrder"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_WorkOrder frm = new Frm_WorkOrder();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_WorkOrder";
            }
        }

        private void btnProductBOM_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_ProductBOM"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_BOM frm = new Frm_BOM();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_ProductBOM";
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Store"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Store frm = new Frm_Store();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Store";
            }
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Operation"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Operation frm = new Frm_Operation();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Operation";
            }
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Equipment"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Equipment frm = new Frm_Equipment();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Equipment";
            }
        }

        private void btnEquipmentOperationRel_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Equipment_Operation_Rel"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Equipment_Operation_Rel frm = new Frm_Equipment_Operation_Rel();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Equipment_Operation_Rel";
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Inspection"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Inspection frm = new Frm_Inspection();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Inspection";
            }
        }

        private void btnOperationInspectionRel_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Operation_Inspection_Rel"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Operation_Inspection_Rel frm = new Frm_Operation_Inspection_Rel();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Operation_Inspection_Rel";
            }
        }

        private void btnProductOperationRel_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Product_Operation_Rel"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Product_Operation_Rel frm = new Frm_Product_Operation_Rel();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Product_Operation_Rel";
            }
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Common"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Common frm = new Frm_Common();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Common";
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_UserMgt"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_UserMgt frm = new Frm_UserMgt();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_UserMgt";
            }
        }

        private void btnUserGroup_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_UserGroup"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_UserGroup frm = new Frm_UserGroup();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_UserGroup";
            }
        }

        private void btnFunctionUserGroup_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Function_User_Group_Rel"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Function_User_Group_Rel frm = new Frm_Function_User_Group_Rel();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Function_User_Group_Rel";
            }
        }

        private void btnFuction__Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Frm_Function"];
            if (fm != null)
            {
                fm.Focus();
                return;
            }
            else
            {
                Frm_Function frm = new Frm_Function();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.Name = "Frm_Function";
            }
        }
    }
}
