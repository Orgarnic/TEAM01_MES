
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
         this.Prg = new System.Windows.Forms.PropertyGrid();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.btnCreate = new System.Windows.Forms.Button();
         this.button5 = new System.Windows.Forms.Button();
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
         // 
         // splitContainer1
         // 
         // 
         // panel7
         // 
         this.panel7.Controls.Add(this.Prg);
         this.panel7.Controls.SetChildIndex(this.lbl3, 0);
         this.panel7.Controls.SetChildIndex(this.Prg, 0);
         // 
         // lbl3
         // 
         this.lbl3.Text = "▶ 속성";
         // 
         // btnClose
         // 
         this.btnClose.FlatAppearance.BorderSize = 0;
         // 
         // dgvProduct
         // 
         this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvProduct.Location = new System.Drawing.Point(751, 280);
         this.dgvProduct.Name = "dgvProduct";
         this.dgvProduct.RowTemplate.Height = 23;
         this.dgvProduct.Size = new System.Drawing.Size(240, 150);
         this.dgvProduct.TabIndex = 5;
         // 
         // Prg
         // 
         this.Prg.Dock = System.Windows.Forms.DockStyle.Fill;
         this.Prg.Location = new System.Drawing.Point(0, 30);
         this.Prg.Name = "Prg";
         this.Prg.Size = new System.Drawing.Size(356, 920);
         this.Prg.TabIndex = 7;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.button1.ForeColor = System.Drawing.Color.White;
         this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button1.Location = new System.Drawing.Point(1321, 1003);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(95, 35);
         this.button1.TabIndex = 31;
         this.button1.Text = "닫 기";
         this.button1.UseVisualStyleBackColor = false;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.button2.FlatAppearance.BorderSize = 0;
         this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.button2.ForeColor = System.Drawing.Color.White;
         this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button2.Location = new System.Drawing.Point(1220, 1003);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(95, 35);
         this.button2.TabIndex = 32;
         this.button2.Text = "닫 기";
         this.button2.UseVisualStyleBackColor = false;
         // 
         // button3
         // 
         this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.button3.FlatAppearance.BorderSize = 0;
         this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.button3.ForeColor = System.Drawing.Color.White;
         this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button3.Location = new System.Drawing.Point(1119, 1003);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(95, 35);
         this.button3.TabIndex = 33;
         this.button3.Text = "닫 기";
         this.button3.UseVisualStyleBackColor = false;
         // 
         // btnCreate
         // 
         this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.btnCreate.FlatAppearance.BorderSize = 0;
         this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnCreate.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.btnCreate.ForeColor = System.Drawing.Color.White;
         this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnCreate.Location = new System.Drawing.Point(1018, 1003);
         this.btnCreate.Name = "btnCreate";
         this.btnCreate.Size = new System.Drawing.Size(95, 35);
         this.btnCreate.TabIndex = 34;
         this.btnCreate.Text = "생 성";
         this.btnCreate.UseVisualStyleBackColor = false;
         this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
         // 
         // button5
         // 
         this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
         this.button5.FlatAppearance.BorderSize = 0;
         this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button5.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.button5.ForeColor = System.Drawing.Color.White;
         this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button5.Location = new System.Drawing.Point(917, 1003);
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size(95, 35);
         this.button5.TabIndex = 35;
         this.button5.Text = "닫 기";
         this.button5.UseVisualStyleBackColor = false;
         // 
         // Frm_Product
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.ClientSize = new System.Drawing.Size(1521, 1041);
         this.Controls.Add(this.button5);
         this.Controls.Add(this.btnCreate);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Name = "Frm_Product";
         this.Load += new System.EventHandler(this.Frm_Product_Load);
         this.Controls.SetChildIndex(this.btnClose, 0);
         this.Controls.SetChildIndex(this.pnlSearch, 0);
         this.Controls.SetChildIndex(this.panel5, 0);
         this.Controls.SetChildIndex(this.button1, 0);
         this.Controls.SetChildIndex(this.button2, 0);
         this.Controls.SetChildIndex(this.button3, 0);
         this.Controls.SetChildIndex(this.btnCreate, 0);
         this.Controls.SetChildIndex(this.button5, 0);
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
      private System.Windows.Forms.PropertyGrid Prg;
      protected System.Windows.Forms.Button button1;
      protected System.Windows.Forms.Button button2;
      protected System.Windows.Forms.Button button3;
      protected System.Windows.Forms.Button btnCreate;
      protected System.Windows.Forms.Button button5;
   }
}
