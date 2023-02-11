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
      public User_DTO userInfo { get; set; }
      private List<FUNCTION_MST_DTO> menus;
      private Srv_User srvUser = new Srv_User();
      private Util.ComboUtil comboUtil;
      int cnt = 0;
      public Frm_Main()
      {
         InitializeComponent();
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

         if (result == DialogResult.OK)
         {
            this.Visible = true;
            userInfo = login.user;
            comboUtil = new Util.ComboUtil();
            lblUserName.Text = userInfo.USER_NAME + "님";
            menus = srvUser.GetFunc(userInfo.USER_ID);
            MenuInit();
         }
      }
      private void MenuInit()
      {
         var sales = menus.FindAll((m) => m.ICON_INDEX.Equals(1)).ToList();
         if (sales.Count > 0)
         {
            flpSide.Controls.Add(pnlSales);
            foreach (var menu in sales)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
         var production = menus.FindAll((m) => m.ICON_INDEX.Equals(2)).ToList();
         if (production.Count > 0)
         {
            flpSide.Controls.Add(pnlProduction);
            foreach (var menu in production)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
         var equip = menus.FindAll((m) => m.ICON_INDEX.Equals(3)).ToList();
         if (equip.Count > 0)
         {
            flpSide.Controls.Add(pnlEquip);
            foreach (var menu in equip)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
         var quality = menus.FindAll((m) => m.ICON_INDEX.Equals(4)).ToList();
         if (quality.Count > 0)
         {
            flpSide.Controls.Add(pnlQuality);
            foreach (var menu in quality)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
         var security = menus.FindAll((m) => m.ICON_INDEX.Equals(5)).ToList();
         if (security.Count > 0)
         {
            flpSide.Controls.Add(pnlSecurity);
            foreach (var menu in security)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
         var common = menus.FindAll((m) => m.ICON_INDEX.Equals(6)).ToList();
         if (common.Count > 0)
         {
            flpSide.Controls.Add(pnlCommon);
            foreach (var menu in common)
               flpSide.Controls.Add(CreateBtn(menu.FUNCTION_NAME, menu.FUNCTION_CODE));
         }
      }
      private Button CreateBtn(string text, string program)
      {
         Button btn = new Button();
         btn.Padding = new Padding(0);
         btn.Margin = new Padding(0);
         btn.Size = new Size(177, 45);
         btn.Text = text;
         btn.BackColor = Color.Transparent;
         btn.ForeColor = Color.FromArgb(224, 224, 224);
         btn.FlatAppearance.BorderSize = 0;
         btn.FlatStyle = FlatStyle.Flat;
         btn.MouseMove += btn_MouseMove;
         btn.MouseLeave += btn_MouseLeave;
         btn.Click += (obj, e) =>
         {
            Form_Changed(program, text);
         };
         return btn;
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
      private void Form_Changed(string prg, string menu) // (유기현)
      {
         string appName = Assembly.GetEntryAssembly().GetName().Name; // Application의 Name (AssamblyName)
         Type frmType = Type.GetType($"{appName}.{prg}");
         foreach (Form form in Application.OpenForms)
         {
            if (form.GetType().Equals(frmType))
            {
               form.Activate();
               form.BringToFront();
               return;
            }
         }
         if (frmType == null)
            return;
         Form frm = Activator.CreateInstance(frmType) as Form;
         if (frm != null)
         {
            frm.MdiParent = this;
            frm.Text = menu;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
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
      private void Frm_Main_MdiChildActivate(object sender, EventArgs e)
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
      private void btnSmall_Click(object sender, EventArgs e)
      {
         this.WindowState = FormWindowState.Minimized;
      }
      private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         flpSide.Controls.Clear();
         srvUser = null;
         Frm_Login frm = new Frm_Login();
         this.Hide();
         if(srvUser == null)
            srvUser = new Srv_User();
         if (frm.ShowDialog(this) == DialogResult.OK)
         {
            this.Visible = true;
            userInfo = frm.user;
            comboUtil = new Util.ComboUtil();
            lblUserName.Text = userInfo.USER_NAME + "님";
            menus = srvUser.GetFunc(userInfo.USER_ID);
            MenuInit();
         }
      }
   }
}
