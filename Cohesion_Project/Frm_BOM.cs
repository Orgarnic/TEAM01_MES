using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cohesion_Project
{
    public partial class Frm_BOM : Cohesion_Project.Frm_Base_3
    {
        Srv_BOM srv = new Srv_BOM();
        public Frm_BOM()
        {
            InitializeComponent();
        }

        private void Frm_BOM_Load(object sender, EventArgs e)
        {
            DataGirdViewParent();
        }

        public void DataGirdViewParent()
        {
            DgvUtil.DgvInit(dgvBOMParent);
            DgvUtil.AddTextCol(dgvBOMParent, "제품 코드", "PRODUCT_CODE", 150, true, 1, frozen:true);
            DgvUtil.AddTextCol(dgvBOMParent, "제품명", "PRODUCT_NAME", 150, true, 1, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "제품 유형", "PRODUCT_TYPE", 150, true, 1, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);

            dgvBOMParent.DataSource = srv.SelectProductList();
            /*  public string PRODUCT_CODE { get; set; }	 //제품 코드, 품번
		        public string PRODUCT_NAME { get; set; }	 //제품명, 품명
		        public string PRODUCT_TYPE { get; set; }	 //품번 유형, 완제품 : FERT, 반제품 : HALB, 원자재 : ROH
		        public string CUSTOMER_CODE { get; set; }	 //완제품인 경우 고객코드
		        public string VENDOR_CODE { get; set; }		 //원자재인 경우 납품업체 코드
		        public DateTime CREATE_TIME { get; set; }	 //생성 시간
		        public string CREATE_USER_ID { get; set; }	 //생성 사용자
		        public DateTime UPDATE_TIME { get; set; }	 //변경 시간
		        public string UPDATE_USER_ID { get; set; }	 //변경 사용자*/
        }

        public void DataGirdViewChild()
        {
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품 코드", "PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품명", "CHILD_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "단위 수량", "REQUIRE_QTY", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);
        }

        private void dgvBOMParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀클릭시, 클릭된 완제품의 BOM을 Child에 뿌려줌.
            //if(e.ColumnIndex)
        }
    }
}
