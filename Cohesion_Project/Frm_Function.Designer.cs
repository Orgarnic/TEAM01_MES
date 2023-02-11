
namespace Cohesion_Project
{
    partial class Frm_Function
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         this.PpgFunction = new System.Windows.Forms.PropertyGrid();
         this.DgvFunction = new System.Windows.Forms.DataGridView();
         this.pnlSearch.SuspendLayout();
         this.panel2.SuspendLayout();
         this.panel4.SuspendLayout();
         this.panel5.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panel7.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DgvFunction)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlSearch
         // 
         this.pnlSearch.Size = new System.Drawing.Size(1290, 33);
         // 
         // lbl1
         // 
         this.lbl1.Size = new System.Drawing.Size(399, 23);
         this.lbl1.Text = "/ 기준 정보 관리 / 화면 기능 관리";
         // 
         // txtSearch
         // 
         this.txtSearch.Size = new System.Drawing.Size(812, 21);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.DgvFunction);
         this.panel2.Size = new System.Drawing.Size(977, 642);
         this.panel2.Controls.SetChildIndex(this.lbl4, 0);
         this.panel2.Controls.SetChildIndex(this.DgvFunction, 0);
         // 
         // lbl4
         // 
         this.lbl4.Size = new System.Drawing.Size(975, 28);
         this.lbl4.Text = "▶ 화면 기능 목록";
         // 
         // btnSearch
         // 
         this.btnSearch.FlatAppearance.BorderSize = 0;
         this.btnSearch.Location = new System.Drawing.Point(828, 35);
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // panel4
         // 
         this.panel4.Size = new System.Drawing.Size(977, 67);
         // 
         // btnSearchCondition
         // 
         this.btnSearchCondition.FlatAppearance.BorderSize = 0;
         this.btnSearchCondition.Location = new System.Drawing.Point(888, 35);
         this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
         // 
         // lbl2
         // 
         this.lbl2.Size = new System.Drawing.Size(975, 28);
         // 
         // panel5
         // 
         this.panel5.Size = new System.Drawing.Size(1290, 726);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Size = new System.Drawing.Size(1290, 726);
         this.splitContainer1.SplitterDistance = 980;
         // 
         // panel7
         // 
         this.panel7.Controls.Add(this.PpgFunction);
         this.panel7.Size = new System.Drawing.Size(306, 720);
         this.panel7.Controls.SetChildIndex(this.lbl3, 0);
         this.panel7.Controls.SetChildIndex(this.PpgFunction, 0);
         // 
         // lbl3
         // 
         this.lbl3.Size = new System.Drawing.Size(304, 28);
         // 
         // btnClose
         // 
         this.btnClose.FlatAppearance.BorderSize = 0;
         this.btnClose.Location = new System.Drawing.Point(1191, 768);
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnDelete
         // 
         this.btnDelete.FlatAppearance.BorderSize = 0;
         this.btnDelete.Location = new System.Drawing.Point(3, 768);
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
         // btnInsert
         // 
         this.btnInsert.FlatAppearance.BorderSize = 0;
         this.btnInsert.Location = new System.Drawing.Point(989, 768);
         this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
         // 
         // btnAdd
         // 
         this.btnAdd.FlatAppearance.BorderSize = 0;
         this.btnAdd.Location = new System.Drawing.Point(787, 768);
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnUpdate
         // 
         this.btnUpdate.FlatAppearance.BorderSize = 0;
         this.btnUpdate.Location = new System.Drawing.Point(888, 768);
         this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
         // 
         // btnRefresh
         // 
         this.btnRefresh.FlatAppearance.BorderSize = 0;
         this.btnRefresh.Location = new System.Drawing.Point(1090, 768);
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // PpgFunction
         // 
         this.PpgFunction.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PpgFunction.Location = new System.Drawing.Point(0, 28);
         this.PpgFunction.Name = "PpgFunction";
         this.PpgFunction.Size = new System.Drawing.Size(304, 690);
         this.PpgFunction.TabIndex = 7;
         // 
         // DgvFunction
         // 
         this.DgvFunction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DgvFunction.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DgvFunction.Location = new System.Drawing.Point(0, 28);
         this.DgvFunction.Name = "DgvFunction";
         this.DgvFunction.Size = new System.Drawing.Size(975, 612);
         this.DgvFunction.TabIndex = 6;
         this.DgvFunction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFunction_CellClick);
         // 
         // Frm_Function
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1290, 803);
         this.Name = "Frm_Function";
         this.Text = "FUNCTION_MST";
         this.Load += new System.EventHandler(this.Frm_Function_Load);
         this.pnlSearch.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.panel4.ResumeLayout(false);
         this.panel4.PerformLayout();
         this.panel5.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.panel7.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DgvFunction)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid PpgFunction;
        private System.Windows.Forms.DataGridView DgvFunction;
    }
}