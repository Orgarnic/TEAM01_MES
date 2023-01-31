
namespace Cohesion_Project
{
    partial class Frm_Operation_Inspection_Rel
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboValueUnit = new System.Windows.Forms.ComboBox();
            this.dgvAddedInspection = new System.Windows.Forms.DataGridView();
            this.dgvInspectionList = new System.Windows.Forms.DataGridView();
            this.dgvOperationList = new System.Windows.Forms.DataGridView();
            this.ppgSearchCondition = new System.Windows.Forms.PropertyGrid();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedInspection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspectionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl6
            // 
            this.lbl6.Size = new System.Drawing.Size(826, 32);
            this.lbl6.Text = "▶ 할당 검사 항목 목록";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAddedInspection);
            this.panel3.Controls.SetChildIndex(this.lbl6, 0);
            this.panel3.Controls.SetChildIndex(this.dgvAddedInspection, 0);
            // 
            // lbl7
            // 
            this.lbl7.Size = new System.Drawing.Size(604, 32);
            this.lbl7.Text = "▶ 전체 검사 항목 목록";
            // 
            // btnLeft
            // 
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvInspectionList);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.SetChildIndex(this.lbl7, 0);
            this.panel6.Controls.SetChildIndex(this.panel8, 0);
            this.panel6.Controls.SetChildIndex(this.dgvInspectionList, 0);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ppgSearchCondition);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.ppgSearchCondition, 0);
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOperationList);
            this.panel2.Size = new System.Drawing.Size(1153, 334);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgvOperationList, 0);
            // 
            // lbl4
            // 
            this.lbl4.Size = new System.Drawing.Size(1151, 32);
            this.lbl4.Text = "▶ 공정 목록";
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Visible = false;
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.cboValueUnit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 32);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(604, 46);
            this.panel8.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "값 유형";
            // 
            // cboValueUnit
            // 
            this.cboValueUnit.FormattingEnabled = true;
            this.cboValueUnit.Items.AddRange(new object[] {
            "전체",
            "N",
            "C"});
            this.cboValueUnit.Location = new System.Drawing.Point(274, 10);
            this.cboValueUnit.Name = "cboValueUnit";
            this.cboValueUnit.Size = new System.Drawing.Size(181, 23);
            this.cboValueUnit.TabIndex = 0;
            this.cboValueUnit.SelectedIndexChanged += new System.EventHandler(this.cboValueUnit_SelectedIndexChanged);
            // 
            // dgvAddedInspection
            // 
            this.dgvAddedInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddedInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddedInspection.Location = new System.Drawing.Point(0, 32);
            this.dgvAddedInspection.Name = "dgvAddedInspection";
            this.dgvAddedInspection.RowTemplate.Height = 23;
            this.dgvAddedInspection.Size = new System.Drawing.Size(826, 428);
            this.dgvAddedInspection.TabIndex = 5;
            // 
            // dgvInspectionList
            // 
            this.dgvInspectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspectionList.Location = new System.Drawing.Point(0, 78);
            this.dgvInspectionList.Name = "dgvInspectionList";
            this.dgvInspectionList.RowTemplate.Height = 23;
            this.dgvInspectionList.Size = new System.Drawing.Size(604, 382);
            this.dgvInspectionList.TabIndex = 5;
            // 
            // dgvOperationList
            // 
            this.dgvOperationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperationList.Location = new System.Drawing.Point(0, 32);
            this.dgvOperationList.Name = "dgvOperationList";
            this.dgvOperationList.RowTemplate.Height = 23;
            this.dgvOperationList.Size = new System.Drawing.Size(1151, 300);
            this.dgvOperationList.TabIndex = 5;
            this.dgvOperationList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperationList_CellClick);
            // 
            // ppgSearchCondition
            // 
            this.ppgSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSearchCondition.Location = new System.Drawing.Point(0, 30);
            this.ppgSearchCondition.Name = "ppgSearchCondition";
            this.ppgSearchCondition.Size = new System.Drawing.Size(356, 412);
            this.ppgSearchCondition.TabIndex = 7;
            // 
            // Frm_Operation_Inspection_Rel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1521, 1061);
            this.Name = "Frm_Operation_Inspection_Rel";
            this.Load += new System.EventHandler(this.Frm_Operationg_Inspection_Rel_Load);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedInspection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspectionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboValueUnit;
        private System.Windows.Forms.DataGridView dgvAddedInspection;
        private System.Windows.Forms.DataGridView dgvInspectionList;
        private System.Windows.Forms.DataGridView dgvOperationList;
        private System.Windows.Forms.PropertyGrid ppgSearchCondition;
    }
}
