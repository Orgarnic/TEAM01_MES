
namespace Cohesion_Project
{
    partial class Frm_Sales_Order
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
            this.dgv_SalesOrder = new System.Windows.Forms.DataGridView();
            this.ppg_SalesOrder = new System.Windows.Forms.PropertyGrid();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_SalesOrder);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgv_SalesOrder, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            // 
            // splitContainer1
            // 
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ppg_SalesOrder);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.ppg_SalesOrder, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
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
            // dgv_SalesOrder
            // 
            this.dgv_SalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SalesOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SalesOrder.Location = new System.Drawing.Point(0, 30);
            this.dgv_SalesOrder.Name = "dgv_SalesOrder";
            this.dgv_SalesOrder.RowTemplate.Height = 23;
            this.dgv_SalesOrder.Size = new System.Drawing.Size(1151, 842);
            this.dgv_SalesOrder.TabIndex = 5;
            // 
            // ppg_SalesOrder
            // 
            this.ppg_SalesOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppg_SalesOrder.Location = new System.Drawing.Point(0, 30);
            this.ppg_SalesOrder.Name = "ppg_SalesOrder";
            this.ppg_SalesOrder.Size = new System.Drawing.Size(356, 920);
            this.ppg_SalesOrder.TabIndex = 7;
            // 
            // Frm_Sales_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1521, 1041);
            this.Name = "Frm_Sales_Order";
            this.Load += new System.EventHandler(this.Frm_Sales_Order_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SalesOrder;
        private System.Windows.Forms.PropertyGrid ppg_SalesOrder;
    }
}
