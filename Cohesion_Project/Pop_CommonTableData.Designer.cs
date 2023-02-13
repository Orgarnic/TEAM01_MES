
namespace Cohesion_Project
{
    partial class Pop_CommonTableData
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
         this.Lbl_Title = new System.Windows.Forms.Label();
         this.Tlp_Button = new System.Windows.Forms.TableLayoutPanel();
         this.Btn_Save = new System.Windows.Forms.Button();
         this.Btn_Search = new System.Windows.Forms.Button();
         this.Btn_Close = new System.Windows.Forms.Button();
         this.txtSearch = new System.Windows.Forms.TextBox();
         this.Btn_Delete = new System.Windows.Forms.Button();
         this.Dgv_DataTable = new System.Windows.Forms.DataGridView();
         this.panel1 = new System.Windows.Forms.Panel();
         this.Tlp_Button.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.Dgv_DataTable)).BeginInit();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // Lbl_Title
         // 
         this.Lbl_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(115)))));
         this.Lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
         this.Lbl_Title.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.Lbl_Title.ForeColor = System.Drawing.Color.White;
         this.Lbl_Title.Location = new System.Drawing.Point(0, 0);
         this.Lbl_Title.Name = "Lbl_Title";
         this.Lbl_Title.Size = new System.Drawing.Size(825, 30);
         this.Lbl_Title.TabIndex = 1;
         this.Lbl_Title.Text = "코드 데이터";
         this.Lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Tlp_Button
         // 
         this.Tlp_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.Tlp_Button.ColumnCount = 10;
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.033295F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.13662F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.846154F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.11722F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.67033F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.85372F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.008827F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.85372F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.134931F));
         this.Tlp_Button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.97982F));
         this.Tlp_Button.Controls.Add(this.Btn_Save, 7, 0);
         this.Tlp_Button.Controls.Add(this.Btn_Search, 5, 0);
         this.Tlp_Button.Controls.Add(this.Btn_Close, 9, 0);
         this.Tlp_Button.Controls.Add(this.txtSearch, 3, 0);
         this.Tlp_Button.Controls.Add(this.Btn_Delete, 1, 0);
         this.Tlp_Button.Location = new System.Drawing.Point(7, 8);
         this.Tlp_Button.Name = "Tlp_Button";
         this.Tlp_Button.RowCount = 1;
         this.Tlp_Button.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.Tlp_Button.Size = new System.Drawing.Size(816, 35);
         this.Tlp_Button.TabIndex = 0;
         // 
         // Btn_Save
         // 
         this.Btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(115)))));
         this.Btn_Save.FlatAppearance.BorderSize = 0;
         this.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Btn_Save.Font = new System.Drawing.Font("맑은 고딕", 9F);
         this.Btn_Save.ForeColor = System.Drawing.Color.White;
         this.Btn_Save.Image = global::Cohesion_Project.Properties.Resources.check;
         this.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.Btn_Save.Location = new System.Drawing.Point(612, 3);
         this.Btn_Save.Name = "Btn_Save";
         this.Btn_Save.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.Btn_Save.Size = new System.Drawing.Size(88, 29);
         this.Btn_Save.TabIndex = 0;
         this.Btn_Save.Text = "     저  장";
         this.Btn_Save.UseVisualStyleBackColor = false;
         this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
         this.Btn_Save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseDown);
         this.Btn_Save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseUp);
         // 
         // Btn_Search
         // 
         this.Btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(115)))));
         this.Btn_Search.FlatAppearance.BorderSize = 0;
         this.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Btn_Search.Font = new System.Drawing.Font("맑은 고딕", 9F);
         this.Btn_Search.ForeColor = System.Drawing.Color.White;
         this.Btn_Search.Image = global::Cohesion_Project.Properties.Resources.search;
         this.Btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.Btn_Search.Location = new System.Drawing.Point(507, 3);
         this.Btn_Search.Name = "Btn_Search";
         this.Btn_Search.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.Btn_Search.Size = new System.Drawing.Size(88, 29);
         this.Btn_Search.TabIndex = 0;
         this.Btn_Search.Text = "     조  회";
         this.Btn_Search.UseVisualStyleBackColor = false;
         this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
         this.Btn_Search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseDown);
         this.Btn_Search.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseUp);
         // 
         // Btn_Close
         // 
         this.Btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(115)))));
         this.Btn_Close.FlatAppearance.BorderSize = 0;
         this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Btn_Close.Font = new System.Drawing.Font("맑은 고딕", 9F);
         this.Btn_Close.ForeColor = System.Drawing.Color.White;
         this.Btn_Close.Image = global::Cohesion_Project.Properties.Resources.cancel;
         this.Btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.Btn_Close.Location = new System.Drawing.Point(718, 3);
         this.Btn_Close.Name = "Btn_Close";
         this.Btn_Close.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.Btn_Close.Size = new System.Drawing.Size(91, 29);
         this.Btn_Close.TabIndex = 0;
         this.Btn_Close.Text = "     닫  기";
         this.Btn_Close.UseVisualStyleBackColor = false;
         this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
         this.Btn_Close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseDown);
         this.Btn_Close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseUp);
         // 
         // txtSearch
         // 
         this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtSearch.Location = new System.Drawing.Point(133, 7);
         this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(330, 21);
         this.txtSearch.TabIndex = 1;
         // 
         // Btn_Delete
         // 
         this.Btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(76)))), ((int)(((byte)(115)))));
         this.Btn_Delete.FlatAppearance.BorderSize = 0;
         this.Btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Btn_Delete.Font = new System.Drawing.Font("맑은 고딕", 9F);
         this.Btn_Delete.ForeColor = System.Drawing.Color.White;
         this.Btn_Delete.Image = global::Cohesion_Project.Properties.Resources.trash;
         this.Btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.Btn_Delete.Location = new System.Drawing.Point(11, 3);
         this.Btn_Delete.Name = "Btn_Delete";
         this.Btn_Delete.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.Btn_Delete.Size = new System.Drawing.Size(83, 29);
         this.Btn_Delete.TabIndex = 0;
         this.Btn_Delete.Text = "     삭  제";
         this.Btn_Delete.UseVisualStyleBackColor = false;
         this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
         this.Btn_Delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseDown);
         this.Btn_Delete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Delete_MouseUp);
         // 
         // Dgv_DataTable
         // 
         this.Dgv_DataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.Dgv_DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.Dgv_DataTable.Location = new System.Drawing.Point(0, 30);
         this.Dgv_DataTable.Name = "Dgv_DataTable";
         this.Dgv_DataTable.RowTemplate.Height = 23;
         this.Dgv_DataTable.Size = new System.Drawing.Size(825, 379);
         this.Dgv_DataTable.TabIndex = 2;
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.Tlp_Button);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 408);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(825, 52);
         this.panel1.TabIndex = 3;
         // 
         // Pop_CommonTableData
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(825, 460);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.Dgv_DataTable);
         this.Controls.Add(this.Lbl_Title);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Location = new System.Drawing.Point(548, 572);
         this.Name = "Pop_CommonTableData";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "Pop_TableData";
         this.Load += new System.EventHandler(this.Pop_CommonTableData_Load);
         this.Tlp_Button.ResumeLayout(false);
         this.Tlp_Button.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.Dgv_DataTable)).EndInit();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.TableLayoutPanel Tlp_Button;
        private System.Windows.Forms.DataGridView Dgv_DataTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}