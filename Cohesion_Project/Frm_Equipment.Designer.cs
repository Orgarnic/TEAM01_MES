﻿
namespace Cohesion_Project
{
    partial class Frm_Equipment
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
            this.ppg_Equipment = new System.Windows.Forms.PropertyGrid();
            this.dgv_Equipment = new System.Windows.Forms.DataGridView();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Equipment);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.dgv_Equipment, 0);
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
            this.panel7.Controls.Add(this.ppg_Equipment);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.ppg_Equipment, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // ppg_Equipment
            // 
            this.ppg_Equipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppg_Equipment.Location = new System.Drawing.Point(0, 30);
            this.ppg_Equipment.Name = "ppg_Equipment";
            this.ppg_Equipment.Size = new System.Drawing.Size(356, 920);
            this.ppg_Equipment.TabIndex = 7;
            // 
            // dgv_Equipment
            // 
            this.dgv_Equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Equipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Equipment.Location = new System.Drawing.Point(0, 30);
            this.dgv_Equipment.Name = "dgv_Equipment";
            this.dgv_Equipment.RowTemplate.Height = 23;
            this.dgv_Equipment.Size = new System.Drawing.Size(1151, 842);
            this.dgv_Equipment.TabIndex = 6;
            this.dgv_Equipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Equipment_CellClick);
            // 
            // Frm_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1521, 1041);
            this.Name = "Frm_Equipment";
            this.Load += new System.EventHandler(this.Frm_Equipment_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid ppg_Equipment;
        private System.Windows.Forms.DataGridView dgv_Equipment;
    }
}