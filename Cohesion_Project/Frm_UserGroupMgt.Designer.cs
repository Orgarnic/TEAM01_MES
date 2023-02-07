
namespace Cohesion_Project
{
    partial class Frm_UserGroup
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
            this.DgvUserGroup = new System.Windows.Forms.DataGridView();
            this.Ppg_UserGourp = new System.Windows.Forms.PropertyGrid();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Size = new System.Drawing.Size(1516, 33);
            // 
            // lbl1
            // 
            this.lbl1.Size = new System.Drawing.Size(399, 23);
            this.lbl1.Text = "/ 기준정보관리 / 사용자 그룹 마스터";
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(1058, 21);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.DgvUserGroup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 70);
            this.panel2.Size = new System.Drawing.Size(1223, 668);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.DgvUserGroup, 0);
            // 
            // lbl4
            // 
            this.lbl4.Size = new System.Drawing.Size(1221, 28);
            this.lbl4.Text = "▶ 그룹 조회";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new System.Drawing.Point(1074, 35);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(1223, 67);
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Location = new System.Drawing.Point(1134, 35);
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // lbl2
            // 
            this.lbl2.Size = new System.Drawing.Size(1221, 28);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(1516, 741);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(1516, 741);
            this.splitContainer1.SplitterDistance = 1226;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.Ppg_UserGourp);
            this.panel7.Size = new System.Drawing.Size(283, 736);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.Ppg_UserGourp, 0);
            // 
            // lbl3
            // 
            this.lbl3.Size = new System.Drawing.Size(281, 28);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1417, 783);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(7, 782);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(1215, 783);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1013, 783);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1114, 783);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(1316, 783);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DgvUserGroup
            // 
            this.DgvUserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUserGroup.Location = new System.Drawing.Point(404, 166);
            this.DgvUserGroup.Name = "DgvUserGroup";
            this.DgvUserGroup.Size = new System.Drawing.Size(240, 140);
            this.DgvUserGroup.TabIndex = 6;
            this.DgvUserGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUserGroup_CellClick);
            // 
            // Ppg_UserGourp
            // 
            this.Ppg_UserGourp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_UserGourp.Location = new System.Drawing.Point(0, 28);
            this.Ppg_UserGourp.Name = "Ppg_UserGourp";
            this.Ppg_UserGourp.Size = new System.Drawing.Size(281, 706);
            this.Ppg_UserGourp.TabIndex = 7;
            // 
            // Frm_UserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 819);
            this.Name = "Frm_UserGroup";
            this.Text = "Frm_UserGroupMgt";
            this.Load += new System.EventHandler(this.Frm_UserGroup_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvUserGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvUserGroup;
        private System.Windows.Forms.PropertyGrid Ppg_UserGourp;
    }
}