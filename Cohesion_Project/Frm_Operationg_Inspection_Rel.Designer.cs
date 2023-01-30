
namespace Cohesion_Project
{
    partial class Frm_Operationg_Inspection_Rel
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
            this.dgvOperationList = new System.Windows.Forms.DataGridView();
            this.dgvAddedInspection = new System.Windows.Forms.DataGridView();
            this.dgvInspectionList = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedInspection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspectionList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // lbl6
            // 
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
            this.lbl7.Text = "▶ 전체 검사 항목 목록";
            // 
            // btnLeft
            // 
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            // 
            // btnRight
            // 
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvInspectionList);
            this.panel6.Controls.SetChildIndex(this.lbl7, 0);
            this.panel6.Controls.SetChildIndex(this.dgvInspectionList, 0);
            // 
            // lbl3
            // 
            this.lbl3.Text = "▶ 조회 조건";
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
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgvOperationList, 0);
            // 
            // lbl4
            // 
            this.lbl4.Text = "▶ 공정 목록";
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            // 
            // dgvOperationList
            // 
            this.dgvOperationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperationList.Location = new System.Drawing.Point(0, 30);
            this.dgvOperationList.Name = "dgvOperationList";
            this.dgvOperationList.RowTemplate.Height = 23;
            this.dgvOperationList.Size = new System.Drawing.Size(1151, 334);
            this.dgvOperationList.TabIndex = 5;
            // 
            // dgvAddedInspection
            // 
            this.dgvAddedInspection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddedInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddedInspection.Location = new System.Drawing.Point(0, 30);
            this.dgvAddedInspection.Name = "dgvAddedInspection";
            this.dgvAddedInspection.RowTemplate.Height = 23;
            this.dgvAddedInspection.Size = new System.Drawing.Size(826, 430);
            this.dgvAddedInspection.TabIndex = 5;
            // 
            // dgvInspectionList
            // 
            this.dgvInspectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInspectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInspectionList.Location = new System.Drawing.Point(0, 30);
            this.dgvInspectionList.Name = "dgvInspectionList";
            this.dgvInspectionList.RowTemplate.Height = 23;
            this.dgvInspectionList.Size = new System.Drawing.Size(604, 430);
            this.dgvInspectionList.TabIndex = 5;
            // 
            // ppgSearchCondition
            // 
            this.ppgSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSearchCondition.Location = new System.Drawing.Point(0, 30);
            this.ppgSearchCondition.Name = "ppgSearchCondition";
            this.ppgSearchCondition.Size = new System.Drawing.Size(356, 412);
            this.ppgSearchCondition.TabIndex = 7;
            // 
            // Frm_Operationg_Inspection_Rel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1521, 1041);
            this.Name = "Frm_Operationg_Inspection_Rel";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedInspection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInspectionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOperationList;
        private System.Windows.Forms.DataGridView dgvAddedInspection;
        private System.Windows.Forms.DataGridView dgvInspectionList;
        private System.Windows.Forms.PropertyGrid ppgSearchCondition;
    }
}
