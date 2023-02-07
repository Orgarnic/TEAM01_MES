
namespace Cohesion_Project
{
    partial class Frm_Product_Operation_Rel
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
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.dgvAddOperationList = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddOperationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1422, 948);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl6
            // 
            this.lbl6.Text = "▶ 할당 공정 목록";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAddOperationList);
            this.panel3.Size = new System.Drawing.Size(828, 403);
            this.panel3.Controls.SetChildIndex(this.lbl6, 0);
            this.panel3.Controls.SetChildIndex(this.dgvAddOperationList, 0);
            // 
            // lbl7
            // 
            this.lbl7.Text = "▶ 전체 공정 목록";
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLeft.Location = new System.Drawing.Point(838, 80);
            this.btnLeft.Size = new System.Drawing.Size(69, 137);
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
            this.btnRight.Size = new System.Drawing.Size(69, 136);
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvOperationList);
            this.panel6.Size = new System.Drawing.Size(606, 403);
            this.panel6.Controls.SetChildIndex(this.lbl7, 0);
            this.panel6.Controls.SetChildIndex(this.dgvOperationList, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1521, 409);
            // 
            // lbl3
            // 
            this.lbl3.Size = new System.Drawing.Size(286, 30);
            this.lbl3.Text = "▶ 조회 조건";
            // 
            // lbl5
            // 
            this.lbl5.Text = "품번별 공정 할당";
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
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.dgvProductList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 75);
            this.panel2.Size = new System.Drawing.Size(1223, 373);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgvProductList, 0);
            // 
            // lbl4
            // 
            this.lbl4.Size = new System.Drawing.Size(1221, 30);
            this.lbl4.Text = "▶ 품번 목록";
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
            this.lbl1.Size = new System.Drawing.Size(399, 23);
            this.lbl1.Text = "/ 기준 정보 관리 / 품번별 공정 설정";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(3, 948);
            this.btnDelete.Visible = false;
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(1220, 948);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1018, 948);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1119, 948);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(1321, 948);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvProductList
            // 
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 30);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 23;
            this.dgvProductList.Size = new System.Drawing.Size(1221, 341);
            this.dgvProductList.TabIndex = 5;
            this.dgvProductList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellClick);
            // 
            // dgvAddOperationList
            // 
            this.dgvAddOperationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddOperationList.Location = new System.Drawing.Point(0, 30);
            this.dgvAddOperationList.Name = "dgvAddOperationList";
            this.dgvAddOperationList.RowTemplate.Height = 23;
            this.dgvAddOperationList.Size = new System.Drawing.Size(826, 371);
            this.dgvAddOperationList.TabIndex = 6;
            // 
            // dgvOperationList
            // 
            this.dgvOperationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperationList.Location = new System.Drawing.Point(0, 30);
            this.dgvOperationList.Name = "dgvOperationList";
            this.dgvOperationList.RowTemplate.Height = 23;
            this.dgvOperationList.Size = new System.Drawing.Size(604, 371);
            this.dgvOperationList.TabIndex = 7;
            // 
            // ppgSearchCondition
            // 
            this.ppgSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSearchCondition.Location = new System.Drawing.Point(0, 30);
            this.ppgSearchCondition.Name = "ppgSearchCondition";
            this.ppgSearchCondition.Size = new System.Drawing.Size(286, 412);
            this.ppgSearchCondition.TabIndex = 7;
            // 
            // Frm_Product_Operation_Rel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1521, 990);
            this.Name = "Frm_Product_Operation_Rel";
            this.Text = "Frm_Product_Operation_Rel";
            this.Load += new System.EventHandler(this.Frm_Product_Operation_Rel_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddOperationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.DataGridView dgvAddOperationList;
        private System.Windows.Forms.DataGridView dgvOperationList;
        private System.Windows.Forms.PropertyGrid ppgSearchCondition;
    }
}
