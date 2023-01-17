
namespace Cohesion_Project
{
   partial class Frm_Main
   {
      /// <summary>
      /// 필수 디자이너 변수입니다.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// 사용 중인 모든 리소스를 정리합니다.
      /// </summary>
      /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form 디자이너에서 생성한 코드

      /// <summary>
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
      /// </summary>
      private void InitializeComponent()
      {
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.Flp_Side = new System.Windows.Forms.FlowLayoutPanel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel1 = new System.Windows.Forms.Panel();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.Lbl_Position = new System.Windows.Forms.Label();
         this.Lbl_Part = new System.Windows.Forms.Label();
         this.Lbl_Id = new System.Windows.Forms.Label();
         this.Pnl_Top = new System.Windows.Forms.Panel();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.Btn_Close = new System.Windows.Forms.Button();
         this.cc_TabControl1 = new Cohesion_Project.Cc_TabControl();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.panel2.SuspendLayout();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.Pnl_Top.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1511, 24);
         this.menuStrip1.TabIndex = 8;
         this.menuStrip1.Text = "menuStrip1";
         this.menuStrip1.Visible = false;
         // 
         // Flp_Side
         // 
         this.Flp_Side.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.Flp_Side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.Flp_Side.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Flp_Side.Location = new System.Drawing.Point(0, 52);
         this.Flp_Side.Margin = new System.Windows.Forms.Padding(0);
         this.Flp_Side.Name = "Flp_Side";
         this.Flp_Side.Size = new System.Drawing.Size(180, 854);
         this.Flp_Side.TabIndex = 11;
         // 
         // panel2
         // 
         this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.panel2.Controls.Add(this.pictureBox1);
         this.panel2.Controls.Add(this.Flp_Side);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(180, 906);
         this.panel2.TabIndex = 16;
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.Control;
         this.panel1.Controls.Add(this.tableLayoutPanel1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(180, 886);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1331, 20);
         this.panel1.TabIndex = 18;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
         this.tableLayoutPanel1.ColumnCount = 10;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.Controls.Add(this.Lbl_Position, 8, 0);
         this.tableLayoutPanel1.Controls.Add(this.Lbl_Part, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.Lbl_Id, 6, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(428, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 20);
         this.tableLayoutPanel1.TabIndex = 72;
         // 
         // Lbl_Position
         // 
         this.Lbl_Position.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.Lbl_Position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.Lbl_Position.Location = new System.Drawing.Point(803, 0);
         this.Lbl_Position.Name = "Lbl_Position";
         this.Lbl_Position.Size = new System.Drawing.Size(94, 20);
         this.Lbl_Position.TabIndex = 1;
         this.Lbl_Position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Lbl_Part
         // 
         this.Lbl_Part.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.Lbl_Part.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.Lbl_Part.Location = new System.Drawing.Point(703, 0);
         this.Lbl_Part.Name = "Lbl_Part";
         this.Lbl_Part.Size = new System.Drawing.Size(94, 20);
         this.Lbl_Part.TabIndex = 2;
         this.Lbl_Part.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Lbl_Id
         // 
         this.Lbl_Id.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.Lbl_Id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.Lbl_Id.Location = new System.Drawing.Point(603, 0);
         this.Lbl_Id.Name = "Lbl_Id";
         this.Lbl_Id.Size = new System.Drawing.Size(94, 20);
         this.Lbl_Id.TabIndex = 3;
         this.Lbl_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Pnl_Top
         // 
         this.Pnl_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.Pnl_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Pnl_Top.Controls.Add(this.label2);
         this.Pnl_Top.Controls.Add(this.label1);
         this.Pnl_Top.Controls.Add(this.button1);
         this.Pnl_Top.Controls.Add(this.button2);
         this.Pnl_Top.Controls.Add(this.Btn_Close);
         this.Pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
         this.Pnl_Top.Location = new System.Drawing.Point(180, 0);
         this.Pnl_Top.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Pnl_Top.Name = "Pnl_Top";
         this.Pnl_Top.Size = new System.Drawing.Size(1331, 30);
         this.Pnl_Top.TabIndex = 19;
         // 
         // label2
         // 
         this.label2.Dock = System.Windows.Forms.DockStyle.Right;
         this.label2.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.label2.ForeColor = System.Drawing.Color.White;
         this.label2.Location = new System.Drawing.Point(1089, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(80, 28);
         this.label2.TabIndex = 17;
         this.label2.Text = "관리자";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Right;
         this.label1.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.label1.ForeColor = System.Drawing.Color.White;
         this.label1.Location = new System.Drawing.Point(1169, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(10, 28);
         this.label1.TabIndex = 16;
         this.label1.Text = "|";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // Btn_Close
         // 
         this.Btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
         this.Btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.Btn_Close.FlatAppearance.BorderSize = 0;
         this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Btn_Close.ForeColor = System.Drawing.Color.White;
         this.Btn_Close.Image = global::Cohesion_Project.Properties.Resources.cancel;
         this.Btn_Close.Location = new System.Drawing.Point(1279, 0);
         this.Btn_Close.Margin = new System.Windows.Forms.Padding(0);
         this.Btn_Close.Name = "Btn_Close";
         this.Btn_Close.Size = new System.Drawing.Size(50, 28);
         this.Btn_Close.TabIndex = 7;
         this.Btn_Close.UseVisualStyleBackColor = true;
         // 
         // cc_TabControl1
         // 
         this.cc_TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.cc_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
         this.cc_TabControl1.Location = new System.Drawing.Point(180, 30);
         this.cc_TabControl1.Name = "cc_TabControl1";
         this.cc_TabControl1.SelectedIndex = 0;
         this.cc_TabControl1.Size = new System.Drawing.Size(1331, 23);
         this.cc_TabControl1.TabIndex = 20;
         // 
         // button1
         // 
         this.button1.Dock = System.Windows.Forms.DockStyle.Right;
         this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.ForeColor = System.Drawing.Color.White;
         this.button1.Image = global::Cohesion_Project.Properties.Resources.minus;
         this.button1.Location = new System.Drawing.Point(1179, 0);
         this.button1.Margin = new System.Windows.Forms.Padding(0);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(50, 28);
         this.button1.TabIndex = 8;
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Dock = System.Windows.Forms.DockStyle.Right;
         this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
         this.button2.FlatAppearance.BorderSize = 0;
         this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button2.ForeColor = System.Drawing.Color.White;
         this.button2.Image = global::Cohesion_Project.Properties.Resources.max;
         this.button2.Location = new System.Drawing.Point(1229, 0);
         this.button2.Margin = new System.Windows.Forms.Padding(0);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(50, 28);
         this.button2.TabIndex = 7;
         this.button2.UseVisualStyleBackColor = true;
         // 
         // pictureBox1
         // 
         this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox1.Location = new System.Drawing.Point(0, 0);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(181, 53);
         this.pictureBox1.TabIndex = 12;
         this.pictureBox1.TabStop = false;
         // 
         // Frm_Main
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(1511, 906);
         this.Controls.Add(this.cc_TabControl1);
         this.Controls.Add(this.Pnl_Top);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.menuStrip1);
         this.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.IsMdiContainer = true;
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Name = "Frm_Main";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Form1";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.Frm_Main_Load);
         this.panel2.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.Pnl_Top.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.FlowLayoutPanel Flp_Side;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel1;
      protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label Lbl_Position;
      private System.Windows.Forms.Label Lbl_Part;
      private System.Windows.Forms.Label Lbl_Id;
      private System.Windows.Forms.Panel Pnl_Top;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button Btn_Close;
      private Cc_TabControl cc_TabControl1;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}

