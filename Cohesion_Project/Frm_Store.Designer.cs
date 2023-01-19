
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
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Search
            // 
            this.Btn_Search.FlatAppearance.BorderSize = 0;
            this.Btn_Search.Location = new System.Drawing.Point(700, 19);
            // 
            // Cbo_Search2
            // 
            this.Cbo_Search2.Size = new System.Drawing.Size(189, 23);
            // 
            // Cbo_Search1
            // 
            this.Cbo_Search1.Size = new System.Drawing.Size(189, 23);
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.FlatAppearance.BorderSize = 0;
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.FlatAppearance.BorderSize = 0;
            // 
            // Btn_Update
            // 
            this.Btn_Update.FlatAppearance.BorderSize = 0;
            // 
            // Btn_Close
            // 
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            // 
            // Btn_Create
            // 
            this.Btn_Create.FlatAppearance.BorderSize = 0;
            // 
            // Frm_Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1521, 831);
            this.Name = "Frm_Store";
            this.Load += new System.EventHandler(this.Frm_Store_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
