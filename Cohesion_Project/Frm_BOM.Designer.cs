
namespace Cohesion_Project
{
    partial class Frm_BOM
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvBOMParent = new System.Windows.Forms.DataGridView();
            this.ppgSearch = new System.Windows.Forms.PropertyGrid();
            this.ppgBOMAttribute = new System.Windows.Forms.PropertyGrid();
            this.dgvBOMChild = new System.Windows.Forms.DataGridView();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMChild)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(1422, 1003);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl7
            // 
            this.lbl7.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl7.Size = new System.Drawing.Size(286, 30);
            this.lbl7.Text = "▶ BOM 속성";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ppgBOMAttribute);
            this.panel9.Size = new System.Drawing.Size(288, 461);
            this.panel9.Controls.SetChildIndex(this.lbl7, 0);
            this.panel9.Controls.SetChildIndex(this.ppgBOMAttribute, 0);
            // 
            // lbl6
            // 
            this.lbl6.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl6.Size = new System.Drawing.Size(1221, 30);
            this.lbl6.Text = "▶ 제품 BOM 구성";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvBOMChild);
            this.panel6.Size = new System.Drawing.Size(1223, 462);
            this.panel6.Controls.SetChildIndex(this.lbl6, 0);
            this.panel6.Controls.SetChildIndex(this.dgvBOMChild, 0);
            // 
            // splitContainer2
            // 
            this.splitContainer2.SplitterDistance = 1226;
            // 
            // lbl3
            // 
            this.lbl3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Size = new System.Drawing.Size(286, 30);
            this.lbl3.Text = "▶ 검색 상세 조건";
            // 
            // lbl5
            // 
            this.lbl5.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Text = "제품 BOM View";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ppgSearch);
            this.panel7.Size = new System.Drawing.Size(288, 444);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.ppgSearch, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 1226;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvBOMParent);
            this.panel2.Size = new System.Drawing.Size(1223, 366);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgvBOMParent, 0);
            // 
            // lbl4
            // 
            this.lbl4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl4.Size = new System.Drawing.Size(1221, 30);
            this.lbl4.Text = "▶ 제품 목록";
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
            this.lbl2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Size = new System.Drawing.Size(1221, 30);
            this.lbl2.Text = "▶ 제품 목록 검색";
            // 
            // lbl1
            // 
            this.lbl1.Text = "/ 제품 품목 관리 / BOM 관리";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(3, 1003);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(1220, 1003);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1018, 1003);
            this.btnAdd.Text = "      추  가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1119, 1003);
            this.btnUpdate.Text = "      등  록";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(1321, 1003);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1513, 430);
            this.dataGridView1.TabIndex = 6;
            // 
            // dgvBOMParent
            // 
            this.dgvBOMParent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBOMParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOMParent.Location = new System.Drawing.Point(0, 30);
            this.dgvBOMParent.Name = "dgvBOMParent";
            this.dgvBOMParent.RowTemplate.Height = 23;
            this.dgvBOMParent.Size = new System.Drawing.Size(1221, 334);
            this.dgvBOMParent.TabIndex = 6;
            this.dgvBOMParent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOMParent_CellClick);
            // 
            // ppgSearch
            // 
            this.ppgSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgSearch.Enabled = false;
            this.ppgSearch.Location = new System.Drawing.Point(0, 30);
            this.ppgSearch.Name = "ppgSearch";
            this.ppgSearch.Size = new System.Drawing.Size(286, 412);
            this.ppgSearch.TabIndex = 8;
            this.ppgSearch.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgSearch_PropertyValueChanged);
            // 
            // ppgBOMAttribute
            // 
            this.ppgBOMAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgBOMAttribute.Enabled = false;
            this.ppgBOMAttribute.Location = new System.Drawing.Point(0, 30);
            this.ppgBOMAttribute.Name = "ppgBOMAttribute";
            this.ppgBOMAttribute.Size = new System.Drawing.Size(286, 429);
            this.ppgBOMAttribute.TabIndex = 9;
            this.ppgBOMAttribute.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgBOMAttribute_PropertyValueChanged);
            // 
            // dgvBOMChild
            // 
            this.dgvBOMChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMChild.Location = new System.Drawing.Point(539, 173);
            this.dgvBOMChild.Name = "dgvBOMChild";
            this.dgvBOMChild.RowTemplate.Height = 23;
            this.dgvBOMChild.Size = new System.Drawing.Size(240, 150);
            this.dgvBOMChild.TabIndex = 5;
            this.dgvBOMChild.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOMChild_CellClick);
            // 
            // Frm_BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1521, 1041);
            this.Name = "Frm_BOM";
            this.Text = "BOM 관리";
            this.Load += new System.EventHandler(this.Frm_BOM_Load);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMChild)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvBOMParent;
        private System.Windows.Forms.PropertyGrid ppgBOMAttribute;
        private System.Windows.Forms.PropertyGrid ppgSearch;
        private System.Windows.Forms.DataGridView dgvBOMChild;
    }
}
