
namespace Cohesion_Project
{
    partial class Frm_Equipment_Operation_Rel
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
            this.cboEquipmentUnit = new System.Windows.Forms.ComboBox();
            this.ppgSearchCondition = new System.Windows.Forms.PropertyGrid();
            this.dgvOperationList = new System.Windows.Forms.DataGridView();
            this.dgvAddedEquipment = new System.Windows.Forms.DataGridView();
            this.dgvEquipmentList = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1422, 952);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl6
            // 
            this.lbl6.Text = "▶ 할당 설비 목록";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAddedEquipment);
            this.panel3.Size = new System.Drawing.Size(828, 410);
            this.panel3.Controls.SetChildIndex(this.lbl6, 0);
            this.panel3.Controls.SetChildIndex(this.dgvAddedEquipment, 0);
            // 
            // lbl7
            // 
            this.lbl7.Text = "▶ 전체 설비 목록";
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLeft.Location = new System.Drawing.Point(838, 80);
            this.btnLeft.Size = new System.Drawing.Size(69, 136);
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRight.Location = new System.Drawing.Point(838, 222);
            this.btnRight.Size = new System.Drawing.Size(69, 143);
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvEquipmentList);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Size = new System.Drawing.Size(606, 410);
            this.panel6.Controls.SetChildIndex(this.lbl7, 0);
            this.panel6.Controls.SetChildIndex(this.panel8, 0);
            this.panel6.Controls.SetChildIndex(this.dgvEquipmentList, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1521, 416);
            // 
            // lbl3
            // 
            this.lbl3.Size = new System.Drawing.Size(286, 30);
            this.lbl3.Text = "▶ 조회 조건";
            // 
            // lbl5
            // 
            this.lbl5.Text = "공정별 설비 할당";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ppgSearchCondition);
            this.panel7.Size = new System.Drawing.Size(288, 444);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.ppgSearchCondition, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 1226;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOperationList);
            this.panel2.Size = new System.Drawing.Size(1223, 366);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgvOperationList, 0);
            // 
            // lbl4
            // 
            this.lbl4.Size = new System.Drawing.Size(1221, 30);
            this.lbl4.Text = "▶ 공정 목록";
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(1223, 72);
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Location = new System.Drawing.Point(1134, 38);
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(1058, 21);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new System.Drawing.Point(1074, 38);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl2
            // 
            this.lbl2.Size = new System.Drawing.Size(1221, 30);
            // 
            // lbl1
            // 
            this.lbl1.Text = "/ 기준 정보 관리 / 공정 설비 관계 설정";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(3, 952);
            this.btnDelete.Visible = false;
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(1220, 952);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1018, 952);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1119, 952);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(1321, 952);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.cboEquipmentUnit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(604, 43);
            this.panel8.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "값 유형";
            // 
            // cboEquipmentUnit
            // 
            this.cboEquipmentUnit.FormattingEnabled = true;
            this.cboEquipmentUnit.Items.AddRange(new object[] {
            "EQUIP"});
            this.cboEquipmentUnit.Location = new System.Drawing.Point(274, 9);
            this.cboEquipmentUnit.Name = "cboEquipmentUnit";
            this.cboEquipmentUnit.Size = new System.Drawing.Size(181, 22);
            this.cboEquipmentUnit.TabIndex = 0;
            // 
            // ppgSearchCondition
            // 
            this.ppgSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSearchCondition.Location = new System.Drawing.Point(0, 30);
            this.ppgSearchCondition.Name = "ppgSearchCondition";
            this.ppgSearchCondition.Size = new System.Drawing.Size(286, 412);
            this.ppgSearchCondition.TabIndex = 7;
            // 
            // dgvOperationList
            // 
            this.dgvOperationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperationList.Location = new System.Drawing.Point(0, 30);
            this.dgvOperationList.Name = "dgvOperationList";
            this.dgvOperationList.RowTemplate.Height = 23;
            this.dgvOperationList.Size = new System.Drawing.Size(1221, 334);
            this.dgvOperationList.TabIndex = 5;
            this.dgvOperationList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperationList_CellClick);
            // 
            // dgvAddedEquipment
            // 
            this.dgvAddedEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddedEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddedEquipment.Location = new System.Drawing.Point(0, 30);
            this.dgvAddedEquipment.Name = "dgvAddedEquipment";
            this.dgvAddedEquipment.RowTemplate.Height = 23;
            this.dgvAddedEquipment.Size = new System.Drawing.Size(826, 378);
            this.dgvAddedEquipment.TabIndex = 6;
            // 
            // dgvEquipmentList
            // 
            this.dgvEquipmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipmentList.Location = new System.Drawing.Point(0, 73);
            this.dgvEquipmentList.Name = "dgvEquipmentList";
            this.dgvEquipmentList.RowTemplate.Height = 23;
            this.dgvEquipmentList.Size = new System.Drawing.Size(604, 335);
            this.dgvEquipmentList.TabIndex = 9;
            // 
            // Frm_Equipment_Operation_Rel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1521, 990);
            this.Name = "Frm_Equipment_Operation_Rel";
            this.Text = "Frm_Equipment_Operation_Rel";
            this.Load += new System.EventHandler(this.Frm_Equipment_Operation_Rel_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddedEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEquipmentUnit;
        private System.Windows.Forms.DataGridView dgvAddedEquipment;
        private System.Windows.Forms.DataGridView dgvEquipmentList;
        private System.Windows.Forms.PropertyGrid ppgSearchCondition;
        private System.Windows.Forms.DataGridView dgvOperationList;
    }
}
