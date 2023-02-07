
namespace Cohesion_Project
{
    partial class Frm_Function_User_Group_Rel
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
            this.PpgFUG = new System.Windows.Forms.PropertyGrid();
            this.DgvF1 = new System.Windows.Forms.DataGridView();
            this.DgvF2 = new System.Windows.Forms.DataGridView();
            this.DgvFUG = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFUG)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1422, 1016);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DgvF1);
            this.panel3.Size = new System.Drawing.Size(828, 432);
            this.panel3.Controls.SetChildIndex(this.lbl6, 0);
            this.panel3.Controls.SetChildIndex(this.DgvF1, 0);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLeft.Location = new System.Drawing.Point(838, 86);
            this.btnLeft.Size = new System.Drawing.Size(69, 146);
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRight.Location = new System.Drawing.Point(838, 238);
            this.btnRight.Size = new System.Drawing.Size(69, 146);
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DgvF2);
            this.panel6.Size = new System.Drawing.Size(606, 432);
            this.panel6.Controls.SetChildIndex(this.lbl7, 0);
            this.panel6.Controls.SetChildIndex(this.DgvF2, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1521, 438);
            // 
            // lbl3
            // 
            this.lbl3.Size = new System.Drawing.Size(357, 32);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.Controls.Add(this.PpgFUG);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 4);
            this.panel7.Size = new System.Drawing.Size(359, 443);
            this.panel7.Controls.SetChildIndex(this.lbl3, 0);
            this.panel7.Controls.SetChildIndex(this.PpgFUG, 0);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 4, 0, 4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 4, 3, 4);
            this.splitContainer1.SplitterDistance = 1155;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvFUG);
            this.panel2.Size = new System.Drawing.Size(1153, 367);
            this.panel2.Controls.SetChildIndex(this.lbl4, 0);
            this.panel2.Controls.SetChildIndex(this.DgvFUG, 0);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 4);
            this.panel4.Size = new System.Drawing.Size(1152, 77);
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.FlatAppearance.BorderSize = 0;
            this.btnSearchCondition.Location = new System.Drawing.Point(1064, 40);
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 41);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Size = new System.Drawing.Size(987, 21);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new System.Drawing.Point(1004, 40);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl2
            // 
            this.lbl2.Size = new System.Drawing.Size(1150, 32);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(3, 1016);
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Location = new System.Drawing.Point(1220, 1016);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(1018, 1016);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new System.Drawing.Point(1119, 1016);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(1321, 1016);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PpgFUG
            // 
            this.PpgFUG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PpgFUG.Location = new System.Drawing.Point(0, 32);
            this.PpgFUG.Name = "PpgFUG";
            this.PpgFUG.Size = new System.Drawing.Size(357, 409);
            this.PpgFUG.TabIndex = 7;
            // 
            // DgvF1
            // 
            this.DgvF1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvF1.Location = new System.Drawing.Point(0, 30);
            this.DgvF1.Name = "DgvF1";
            this.DgvF1.RowTemplate.Height = 23;
            this.DgvF1.Size = new System.Drawing.Size(826, 400);
            this.DgvF1.TabIndex = 6;
            // 
            // DgvF2
            // 
            this.DgvF2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvF2.Location = new System.Drawing.Point(0, 30);
            this.DgvF2.Name = "DgvF2";
            this.DgvF2.RowTemplate.Height = 23;
            this.DgvF2.Size = new System.Drawing.Size(604, 400);
            this.DgvF2.TabIndex = 7;
            // 
            // DgvFUG
            // 
            this.DgvFUG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFUG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFUG.Location = new System.Drawing.Point(0, 30);
            this.DgvFUG.Name = "DgvFUG";
            this.DgvFUG.RowTemplate.Height = 23;
            this.DgvFUG.Size = new System.Drawing.Size(1151, 335);
            this.DgvFUG.TabIndex = 6;
            this.DgvFUG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFUG_CellClick);
            // 
            // Frm_Function_User_Group_Rel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 1061);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm_Function_User_Group_Rel";
            this.Text = "Frm_Function_User_Group_Rel";
            this.Load += new System.EventHandler(this.Frm_Function_User_Group_Rel_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFUG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PpgFUG;
        private System.Windows.Forms.DataGridView DgvF1;
        private System.Windows.Forms.DataGridView DgvF2;
        private System.Windows.Forms.DataGridView DgvFUG;
    }
}