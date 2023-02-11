﻿
namespace Cohesion_Project
{
    partial class Frm_WorkOrder
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_WorkOrder));
         this.dgvWorkOrderList = new System.Windows.Forms.DataGridView();
         this.ppgWorkOrderSearch = new System.Windows.Forms.PropertyGrid();
         this.btnFinish = new System.Windows.Forms.Button();
         this.pnlSearch.SuspendLayout();
         this.panel2.SuspendLayout();
         this.panel4.SuspendLayout();
         this.panel5.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panel7.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderList)).BeginInit();
         this.SuspendLayout();
         // 
         // lbl1
         // 
         this.lbl1.Text = "/ 기준 정보 관리 / 작업지시관리";
         // 
         // txtSearch
         // 
         this.txtSearch.Size = new System.Drawing.Size(1058, 21);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.dgvWorkOrderList);
         this.panel2.Size = new System.Drawing.Size(1220, 874);
         this.panel2.Controls.SetChildIndex(this.lbl4, 0);
         this.panel2.Controls.SetChildIndex(this.dgvWorkOrderList, 0);
         // 
         // lbl4
         // 
         this.lbl4.Size = new System.Drawing.Size(1218, 30);
         this.lbl4.Text = "▶ 작업지시 목록";
         // 
         // btnSearch
         // 
         this.btnSearch.Enabled = false;
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
         this.lbl2.Text = "▶ 작업지시 조회";
         // 
         // splitContainer1
         // 
         this.splitContainer1.SplitterDistance = 1226;
         // 
         // panel7
         // 
         this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
         this.panel7.Controls.Add(this.ppgWorkOrderSearch);
         this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel7.Size = new System.Drawing.Size(288, 952);
         this.panel7.Controls.SetChildIndex(this.lbl3, 0);
         this.panel7.Controls.SetChildIndex(this.ppgWorkOrderSearch, 0);
         // 
         // lbl3
         // 
         this.lbl3.Size = new System.Drawing.Size(286, 30);
         this.lbl3.Text = "▶ 속성";
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
         // dgvWorkOrderList
         // 
         this.dgvWorkOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvWorkOrderList.Location = new System.Drawing.Point(385, 293);
         this.dgvWorkOrderList.Name = "dgvWorkOrderList";
         this.dgvWorkOrderList.RowTemplate.Height = 23;
         this.dgvWorkOrderList.Size = new System.Drawing.Size(513, 150);
         this.dgvWorkOrderList.TabIndex = 5;
         this.dgvWorkOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkOrderList_CellClick);
         // 
         // ppgWorkOrderSearch
         // 
         this.ppgWorkOrderSearch.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ppgWorkOrderSearch.Enabled = false;
         this.ppgWorkOrderSearch.Location = new System.Drawing.Point(0, 30);
         this.ppgWorkOrderSearch.Name = "ppgWorkOrderSearch";
         this.ppgWorkOrderSearch.Size = new System.Drawing.Size(286, 920);
         this.ppgWorkOrderSearch.TabIndex = 7;
         this.ppgWorkOrderSearch.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgWorkOrderSearch_PropertyValueChanged);
         // 
         // btnFinish
         // 
         this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.btnFinish.FlatAppearance.BorderSize = 0;
         this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnFinish.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.btnFinish.ForeColor = System.Drawing.Color.White;
         this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
         this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnFinish.Location = new System.Drawing.Point(917, 1003);
         this.btnFinish.Name = "btnFinish";
         this.btnFinish.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.btnFinish.Size = new System.Drawing.Size(95, 35);
         this.btnFinish.TabIndex = 43;
         this.btnFinish.Text = "      마  감";
         this.btnFinish.UseVisualStyleBackColor = false;
         this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
         // 
         // Frm_WorkOrder
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.ClientSize = new System.Drawing.Size(1521, 1041);
         this.Controls.Add(this.btnFinish);
         this.Name = "Frm_WorkOrder";
         this.Text = "작업 지시 관리";
         this.Load += new System.EventHandler(this.Frm_WorkOrder_Load);
         this.Controls.SetChildIndex(this.btnClose, 0);
         this.Controls.SetChildIndex(this.pnlSearch, 0);
         this.Controls.SetChildIndex(this.panel5, 0);
         this.Controls.SetChildIndex(this.btnRefresh, 0);
         this.Controls.SetChildIndex(this.btnUpdate, 0);
         this.Controls.SetChildIndex(this.btnAdd, 0);
         this.Controls.SetChildIndex(this.btnInsert, 0);
         this.Controls.SetChildIndex(this.btnDelete, 0);
         this.Controls.SetChildIndex(this.btnFinish, 0);
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
         ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderList)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkOrderList;
        private System.Windows.Forms.PropertyGrid ppgWorkOrderSearch;
      protected System.Windows.Forms.Button btnFinish;
   }
}
