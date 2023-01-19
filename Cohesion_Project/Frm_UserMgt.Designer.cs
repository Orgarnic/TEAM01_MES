
namespace Cohesion_Project
{
    partial class Frm_UserMgt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgvUser = new System.Windows.Forms.DataGridView();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Size = new System.Drawing.Size(800, 35);
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(440, 21);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvUser);
            this.panel2.Size = new System.Drawing.Size(603, 286);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.DgvUser, 0);
            // 
            // lbl4
            // 
            this.lbl4.Size = new System.Drawing.Size(601, 30);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new System.Drawing.Point(456, 38);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(605, 72);
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Location = new System.Drawing.Point(516, 38);
            // 
            // lbl2
            // 
            this.lbl2.Size = new System.Drawing.Size(603, 30);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(800, 367);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(800, 367);
            this.splitContainer1.SplitterDistance = 608;
            // 
            // panel7
            // 
            this.panel7.Size = new System.Drawing.Size(185, 361);
            // 
            // lbl3
            // 
            this.lbl3.Size = new System.Drawing.Size(183, 30);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(701, 412);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(-718, 412);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(499, 412);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(297, 412);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(398, 412);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(600, 412);
            // 
            // DgvUser
            // 
            this.DgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUser.Location = new System.Drawing.Point(166, 56);
            this.DgvUser.Name = "DgvUser";
            this.DgvUser.Size = new System.Drawing.Size(240, 150);
            this.DgvUser.TabIndex = 5;
            // 
            // Frm_UserMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Frm_UserMgt";
            this.Text = "Frm_UserMgt";
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvUser;
    }
}