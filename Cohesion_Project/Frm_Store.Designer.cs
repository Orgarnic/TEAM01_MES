
namespace Cohesion_Project
{
    partial class Frm_Store
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
         this.ppg_Store = new System.Windows.Forms.PropertyGrid();
         this.dgv_Store = new System.Windows.Forms.DataGridView();
         this.pnlSearch.SuspendLayout();
         this.panel2.SuspendLayout();
         this.panel4.SuspendLayout();
         this.panel5.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panel7.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgv_Store)).BeginInit();
         this.SuspendLayout();
         // 
         // lbl1
         // 
         this.lbl1.Text = "/ 기준 정보 관리 / 창고 등록";
         // 
         // txtSearch
         // 
         this.txtSearch.Size = new System.Drawing.Size(1058, 21);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.dgv_Store);
         this.panel2.ForeColor = System.Drawing.Color.Black;
         this.panel2.Size = new System.Drawing.Size(1223, 874);
         this.panel2.Controls.SetChildIndex(this.lbl4, 0);
         this.panel2.Controls.SetChildIndex(this.dgv_Store, 0);
         // 
         // lbl4
         // 
         this.lbl4.Size = new System.Drawing.Size(1221, 30);
         // 
         // btnSearch
         // 
         this.btnSearch.FlatAppearance.BorderSize = 0;
         this.btnSearch.Location = new System.Drawing.Point(1074, 38);
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
         // lbl2
         // 
         this.lbl2.Size = new System.Drawing.Size(1221, 30);
         // 
         // splitContainer1
         // 
         this.splitContainer1.SplitterDistance = 1226;
         // 
         // panel7
         // 
         this.panel7.Controls.Add(this.ppg_Store);
         this.panel7.Size = new System.Drawing.Size(288, 952);
         this.panel7.Controls.SetChildIndex(this.lbl3, 0);
         this.panel7.Controls.SetChildIndex(this.ppg_Store, 0);
         // 
         // lbl3
         // 
         this.lbl3.Size = new System.Drawing.Size(286, 30);
         // 
         // btnClose
         // 
         this.btnClose.FlatAppearance.BorderSize = 0;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnDelete
         // 
         this.btnDelete.FlatAppearance.BorderSize = 0;
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // ppg_Store
         // 
         this.ppg_Store.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ppg_Store.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold);
         this.ppg_Store.Location = new System.Drawing.Point(0, 30);
         this.ppg_Store.Name = "ppg_Store";
         this.ppg_Store.Size = new System.Drawing.Size(286, 920);
         this.ppg_Store.TabIndex = 7;
         this.ppg_Store.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppg_Store_PropertyValueChanged);
         // 
         // dgv_Store
         // 
         this.dgv_Store.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgv_Store.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dgv_Store.Location = new System.Drawing.Point(0, 30);
         this.dgv_Store.Name = "dgv_Store";
         this.dgv_Store.Size = new System.Drawing.Size(1221, 842);
         this.dgv_Store.TabIndex = 6;
         this.dgv_Store.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Store_CellClick);
         // 
         // Frm_Store
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.ClientSize = new System.Drawing.Size(1521, 1041);
         this.Name = "Frm_Store";
         this.Load += new System.EventHandler(this.Frm_Store_Load);
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
         ((System.ComponentModel.ISupportInitialize)(this.dgv_Store)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid ppg_Store;
        private System.Windows.Forms.DataGridView dgv_Store;
    }
}
