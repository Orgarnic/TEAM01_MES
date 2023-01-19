using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
   public partial class Frm_Product : Cohesion_Project.Frm_Base_2
   {
      Srv_Product srvProduct = new Srv_Product();
      List<PRODUCT_MST_DTO> products = new List<PRODUCT_MST_DTO>();

      public Frm_Product()
      {
         InitializeComponent();
      }
      private void Frm_Product_Load(object sender, EventArgs e)
      {
         this.DgvInit();
         this.PpgInit();
         this.DgvFill();
      }
      private void DgvInit()
      {
         DgvUtil.DgvInit(dgvProduct);
         DgvUtil.AddTextCol(dgvProduct, "제품 코드", "PRODUCT_CODE", width: 140, readOnly: true, frozen:true);
         DgvUtil.AddTextCol(dgvProduct, "제품 명칭", "PRODUCT_NAME", width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvProduct, "품버 유형", "PRODUCT_TYPE", width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvProduct, "고객 코드", "CUSTOMER_CODE", width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "납품 업체 코드", "VENDOR_CODE", width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "생성 시간", "CREATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "생성 사용자", "CREATE_USER_ID", width: 150, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "변경 시간", "UPDATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "변경 사용자", "UPDATE_USER_ID", width: 150, readOnly: true);
      }
      public void DgvFill()
      {
         products = srvProduct.SelectProduts();
         dgvProduct.DataSource = products;
      }
      private void PpgInit()
      {
         ppgProduct.PropertySort = PropertySort.NoSort;
      }
      private void btnRefresh_Click(object sender, EventArgs e)
      {
         ppgProduct.SelectedObject = new PRODUCT_MST_DTO();
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {

      }
   }
}
