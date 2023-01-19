
namespace Cohesion_Project
{
    partial class Frm_User
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
            this.pnlSearch.Size = new System.Drawing.Size(1195, 35);
            // 
            // label6
            // 
            this.label6.Text = "사용자 설정";
            // 
            // Txt_Search
            // 
            this.Txt_Search.Size = new System.Drawing.Size(740, 21);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvUser);
            this.panel2.Size = new System.Drawing.Size(883, 389);
            this.panel2.Controls.SetChildIndex(this.label3, 0);
            this.panel2.Controls.SetChildIndex(this.DgvUser, 0);
            // 
            // label3
            // 
            this.label3.Size = new System.Drawing.Size(881, 30);
            this.label3.Text = "▶ 사용자 목록 조회";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new System.Drawing.Point(756, 38);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(905, 72);
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Location = new System.Drawing.Point(816, 38);
            // 
            // label7
            // 
            this.label7.Size = new System.Drawing.Size(903, 30);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(1195, 487);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(1195, 487);
            this.splitContainer1.SplitterDistance = 908;
            // 
            // panel7
            // 
            this.panel7.Size = new System.Drawing.Size(280, 481);
            // 
            // label8
            // 
            this.label8.Size = new System.Drawing.Size(278, 30);
            // 
            // Btn_Close
            // 
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.Location = new System.Drawing.Point(1096, 532);
            // 
            // DgvUser
            // 
            this.DgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUser.Location = new System.Drawing.Point(134, 74);
            this.DgvUser.Name = "DgvUser";
            this.DgvUser.Size = new System.Drawing.Size(537, 246);
            this.DgvUser.TabIndex = 6;
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 570);
            this.Name = "Frm_User";
            this.Text = "Frm_User";
            this.Load += new System.EventHandler(this.Frm_User_Load);
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