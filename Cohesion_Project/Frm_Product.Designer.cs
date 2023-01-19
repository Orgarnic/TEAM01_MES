
namespace Cohesion_Project
{
   partial class Frm_Product
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
         this.dgvProduct = new System.Windows.Forms.DataGridView();
         this.ppgProduct = new System.Windows.Forms.PropertyGrid();
         this.btnLookup = new System.Windows.Forms.Button();
         this.pnlSearch.SuspendLayout();
         this.panel2.SuspendLayout();
         this.panel4.SuspendLayout();
         this.panel5.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panel7.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
         this.SuspendLayout();
         // 
         // lbl1
         // 
         this.lbl1.Text = "/ 기준 정보 관리 / 품번 등록";
         // 
         // panel2
         // 
         this.panel2.AutoScroll = true;
         this.panel2.Controls.Add(this.dgvProduct);
         this.panel2.Controls.SetChildIndex(this.lbl4, 0);
         this.panel2.Controls.SetChildIndex(this.dgvProduct, 0);
         // 
         // lbl4
         // 
         this.lbl4.Text = "▶ 품번 목록";
         // 
         // btnSearch
         // 
         this.btnSearch.FlatAppearance.BorderSize = 0;
         // 
         // btnSearchCondition
         // 
         this.btnSearchCondition.FlatAppearance.BorderSize = 0;
         this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
         // 
         // splitContainer1
         // 
         // 
         // panel7
         // 
         this.panel7.Controls.Add(this.ppgProduct);
         this.panel7.Controls.SetChildIndex(this.lbl3, 0);
         this.panel7.Controls.SetChildIndex(this.ppgProduct, 0);
         // 
         // lbl3
         // 
         this.lbl3.Text = "▶ 속성";
         // 
         // btnClose
         // 
         this.btnClose.FlatAppearance.BorderSize = 0;
         // 
         // btnDelete
         // 
         this.btnDelete.FlatAppearance.BorderSize = 0;
         this.btnDelete.Location = new System.Drawing.Point(1220, 1003);
         // 
         // btnInsert
         // 
         this.btnInsert.FlatAppearance.BorderSize = 0;
         this.btnInsert.Location = new System.Drawing.Point(1119, 1003);
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
         // dgvProduct
         // 
         this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvProduct.Location = new System.Drawing.Point(460, 339);
         this.dgvProduct.Name = "dgvProduct";
         this.dgvProduct.RowTemplate.Height = 23;
         this.dgvProduct.Size = new System.Drawing.Size(240, 150);
         this.dgvProduct.TabIndex = 5;
         this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
         // 
         // ppgProduct
         // 
         this.ppgProduct.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ppgProduct.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.ppgProduct.Location = new System.Drawing.Point(0, 30);
         this.ppgProduct.Name = "ppgProduct";
         this.ppgProduct.Size = new System.Drawing.Size(356, 920);
         this.ppgProduct.TabIndex = 7;
         // 
         // btnLookup
         // 
         this.btnLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.btnLookup.FlatAppearance.BorderSize = 0;
         this.btnLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnLookup.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.btnLookup.ForeColor = System.Drawing.Color.White;
         this.btnLookup.Image = global::Cohesion_Project.Properties.Resources.search;
         this.btnLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnLookup.Location = new System.Drawing.Point(816, 1003);
         this.btnLookup.Name = "btnLookup";
         this.btnLookup.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
         this.btnLookup.Size = new System.Drawing.Size(95, 35);
         this.btnLookup.TabIndex = 36;
         this.btnLookup.Text = "      조  회";
         this.btnLookup.UseVisualStyleBackColor = false;
         // 
         // Frm_Product
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.ClientSize = new System.Drawing.Size(1521, 1041);
         this.Controls.Add(this.btnLookup);
         this.Name = "Frm_Product";
         this.Load += new System.EventHandler(this.Frm_Product_Load);
         this.Controls.SetChildIndex(this.btnClose, 0);
         this.Controls.SetChildIndex(this.pnlSearch, 0);
         this.Controls.SetChildIndex(this.panel5, 0);
         this.Controls.SetChildIndex(this.btnRefresh, 0);
         this.Controls.SetChildIndex(this.btnUpdate, 0);
         this.Controls.SetChildIndex(this.btnAdd, 0);
         this.Controls.SetChildIndex(this.btnInsert, 0);
         this.Controls.SetChildIndex(this.btnDelete, 0);
         this.Controls.SetChildIndex(this.btnLookup, 0);
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
         ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView dgvProduct;
      private System.Windows.Forms.PropertyGrid ppgProduct;
      protected System.Windows.Forms.Button btnLookup;
   }
}
