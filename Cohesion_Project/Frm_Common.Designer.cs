
namespace Cohesion_Project
{
    partial class Frm_Common
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
            this.Dgv_CommonTable = new System.Windows.Forms.DataGridView();
            this.Ppg_CommonTable = new System.Windows.Forms.PropertyGrid();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_CommonTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dgv_CommonTable);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.Dgv_CommonTable, 0);
            // 
            // lbl4
            // 
            this.lbl4.Text = "▶ 공통코드 테이블 정보";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // splitContainer1
            // 
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.Ppg_CommonTable);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.Ppg_CommonTable, 0);
            // 
            // lbl3
            // 
            this.lbl3.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(4, 1003);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1018, 1003);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1119, 1003);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Dgv_CommonTable
            // 
            this.Dgv_CommonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_CommonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_CommonTable.Location = new System.Drawing.Point(0, 30);
            this.Dgv_CommonTable.Name = "Dgv_CommonTable";
            this.Dgv_CommonTable.Size = new System.Drawing.Size(1151, 842);
            this.Dgv_CommonTable.TabIndex = 5;
            // 
            // Ppg_CommonTable
            // 
            this.Ppg_CommonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_CommonTable.Location = new System.Drawing.Point(0, 30);
            this.Ppg_CommonTable.Name = "Ppg_CommonTable";
            this.Ppg_CommonTable.Size = new System.Drawing.Size(356, 920);
            this.Ppg_CommonTable.TabIndex = 7;
            // 
            // Frm_Common
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1521, 1041);
            this.Name = "Frm_Common";
            this.Load += new System.EventHandler(this.Frm_Common_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_CommonTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_CommonTable;
        private System.Windows.Forms.PropertyGrid Ppg_CommonTable;
    }
}
