using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
   public partial class Frm_Product : Cohesion_Project.Frm_Base_2
   {
      private Srv_Product srvProduct = new Srv_Product();
      private List<PRODUCT_MST_DTO> products = new List<PRODUCT_MST_DTO>();
      private PRODUCT_MST_DTO product = new PRODUCT_MST_DTO();
      private PRODUCT_MST_DTO_Condition condition = new PRODUCT_MST_DTO_Condition();
      private User_DTO userinfo;
      bool isCondition = true;

      public Frm_Product()
      {
         InitializeComponent();
      }
      private void Frm_Product_Load(object sender, EventArgs e)
      {
         this.DgvInit();
         this.PpgInit();
         this.DgvFill();
         userinfo = (this.ParentForm as Frm_Main).userInfo;
      }
      private void DgvInit()
      {
         DgvUtil.DgvInit(dgvProduct);
         DgvUtil.AddTextCol(dgvProduct, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
         DgvUtil.AddTextCol(dgvProduct, "    품번 코드", "PRODUCT_CODE",align:0 ,width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvProduct, "    품번 명칭", "PRODUCT_NAME", align: 0, width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvProduct, "    품번 유형", "PRODUCT_TYPE", align: 1, width: 140, readOnly: true, frozen: true);
         DgvUtil.AddTextCol(dgvProduct, "    고객 코드", "CUSTOMER_CODE", align: 0, width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "    납품 업체 코드", "VENDOR_CODE", align: 0, width: 140, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "    생성 시간", "CREATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "    생성 사용자", "CREATE_USER_ID", align: 0, width: 150, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "    변경 시간", "UPDATE_TIME", width: 195, readOnly: true);
         DgvUtil.AddTextCol(dgvProduct, "    변경 사용자", "UPDATE_USER_ID", align: 0, width: 150, readOnly: true);
      }
      public void DgvFill()
      {
         //btnSearch.PerformClick();
         products = srvProduct.SelectProduts(condition);
         int seq = 1;
         dgvProduct.DataSource = products.Select((o) =>
         new
         {
            IDX = seq++,
            PRODUCT_CODE = o.PRODUCT_CODE,
            PRODUCT_NAME = o.PRODUCT_NAME,
            PRODUCT_TYPE = o.PRODUCT_TYPE,
            CUSTOMER_CODE = o.CUSTOMER_CODE,
            VENDOR_CODE = o.VENDOR_CODE,
            CREATE_TIME = o.CREATE_TIME,
            CREATE_USER_ID = o.CREATE_USER_ID,
            UPDATE_TIME = o.UPDATE_TIME,
            UPDATE_USER_ID = o.UPDATE_USER_ID
         }).ToList();
      }
      private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         int row = e.RowIndex;
         if (row < 0) return;
         product = new PRODUCT_MST_DTO
         {
            PRODUCT_CODE = (string)dgvProduct["PRODUCT_CODE", row].Value,
            PRODUCT_NAME = (string)dgvProduct["PRODUCT_NAME", row].Value,
            PRODUCT_TYPE = (string)dgvProduct["PRODUCT_TYPE", row].Value,
            CUSTOMER_CODE = (string)dgvProduct["CUSTOMER_CODE", row].Value,
            VENDOR_CODE = (string)dgvProduct["VENDOR_CODE", row].Value,
            CREATE_TIME = Convert.ToDateTime(dgvProduct["CREATE_TIME", row].Value),
            CREATE_USER_ID = (string)dgvProduct["CREATE_USER_ID", row].Value,
            UPDATE_TIME = Convert.ToDateTime(dgvProduct["UPDATE_TIME", row].Value),
            UPDATE_USER_ID = (string)dgvProduct["UPDATE_USER_ID", row].Value
         };
         ppgProduct.SelectedObject = product;

         ppgProduct.Enabled = false;
         btnAdd.Enabled = false;
         btnUpdate.Enabled = true;
         btnInsert.Enabled = true;
         isCondition = true;
      }
      private void PpgInit()
      {
         ppgProduct.PropertySort = PropertySort.Categorized;
         ppgProduct.SelectedObject = new PRODUCT_MST_DTO();
      }
      private void btnRefresh_Click(object sender, EventArgs e)
      {
         ppgProduct.Enabled = true;
         btnAdd.Enabled = true;
         btnUpdate.Enabled = false;
         btnInsert.Enabled = false;
         product = new PRODUCT_MST_DTO();
         ppgProduct.SelectedObject = product;
      }
      private void btnAdd_Click(object sender, EventArgs e)
      {
         PRODUCT_MST_DTO dto = ppgProduct.SelectedObject as PRODUCT_MST_DTO;
         if (dto == null) return;
         if (!Available(dto)) return;
         dto.CREATE_USER_ID = userinfo.USER_NAME;
         dto.CREATE_TIME = DateTime.Now;
         bool result = srvProduct.InsertProduct(dto);
         if (result)
         {
            MboxUtil.MboxInfo("품번이 등록되었습니다.");
            this.DgvFill();
         }
         else
            MboxUtil.MboxError("오류가 발생했습니다.");
      }
      private void btnInsert_Click(object sender, EventArgs e)
      {
         if (!ppgProduct.Enabled)
            return;
         if (!Available(product)) return;
         product.UPDATE_TIME = DateTime.Now;
         product.UPDATE_USER_ID = userinfo.USER_NAME;
         bool result = srvProduct.UpdateProduct(product);
         if (result)
         {
            MboxUtil.MboxInfo("품번이 수정되었습니다.");
            this.DgvFill();
         }
         else
         {
            MboxUtil.MboxError("오류가 발생했습니다.");
            return;
         }
         btnAdd.Enabled = true;
         isCondition = true;
         ppgProduct.Enabled = false;
      }
      private void btnUpdate_Click(object sender, EventArgs e)
      {
         ppgProduct.Enabled = true;
         btnAdd.Enabled = false;
      }
      private void btnSearchCondition_Click(object sender, EventArgs e)
      {
         if (isCondition)
         {
            lbl3.Text = "▶ 검색 조건";
            ppgProduct.Enabled = true;
            ppgProduct.SelectedObject = condition;
            isCondition = false;
         }
         else
         {
            lbl3.Text = "▶ 속성";
            ppgProduct.SelectedObject = product;
            condition = new PRODUCT_MST_DTO_Condition();
            isCondition = true;
            ppgProduct.Enabled = false;
         }
      }
      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (isCondition)
         {
            MboxUtil.MboxError("검색 조건을 먼저 눌러주세요.");
            return;
         }
         products = srvProduct.SelectProduts(condition);
         int seq = 1;
         dgvProduct.DataSource = products.Select((o) =>
         new
         {
            IDX = seq++,
            PRODUCT_CODE = o.PRODUCT_CODE,
            PRODUCT_NAME = o.PRODUCT_NAME,
            PRODUCT_TYPE = o.PRODUCT_TYPE,
            CUSTOMER_CODE = o.CUSTOMER_CODE,
            VENDOR_CODE = o.VENDOR_CODE,
            CREATE_TIME = o.CREATE_TIME,
            CREATE_USER_ID = o.CREATE_USER_ID,
            UPDATE_TIME = o.UPDATE_TIME,
            UPDATE_USER_ID = o.UPDATE_USER_ID
         }).ToList();
      }
      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
      private void btnDelete_Click(object sender, EventArgs e)
      {
         if (dgvProduct.SelectedRows.Count < 1) return;
         int row = dgvProduct.CurrentRow.Index;
         if (!MboxUtil.MboxInfo_("선택된 품번을 삭제하시겠습니까 ? ")) return;
         PRODUCT_MST_DTO dto = new PRODUCT_MST_DTO
         {
            PRODUCT_CODE = (string)dgvProduct["PRODUCT_CODE", row].Value,
            PRODUCT_NAME = (string)dgvProduct["PRODUCT_NAME", row].Value,
            PRODUCT_TYPE = (string)dgvProduct["PRODUCT_TYPE", row].Value,
            CUSTOMER_CODE = (string)dgvProduct["CUSTOMER_CODE", row].Value,
            VENDOR_CODE = (string)dgvProduct["VENDOR_CODE", row].Value,
            CREATE_TIME = Convert.ToDateTime(dgvProduct["CREATE_TIME", row].Value),
            CREATE_USER_ID = (string)dgvProduct["CREATE_USER_ID", row].Value,
            UPDATE_TIME = Convert.ToDateTime(dgvProduct["UPDATE_TIME", row].Value),
            UPDATE_USER_ID = (string)dgvProduct["UPDATE_USER_ID", row].Value
         };
         bool result = srvProduct.DeleteProduct(dto);
         if (result)
         {
            MboxUtil.MboxInfo("품번이 삭제되었습니다.");
            this.DgvFill();
         }
         else
            MboxUtil.MboxError("오류가 발생했습니다.");
      }
      private bool Available(PRODUCT_MST_DTO dto)
      {
         if (string.IsNullOrWhiteSpace(dto.PRODUCT_CODE))
         {
            MboxUtil.MboxWarn("품번 코드는 필수 입력입니다.");
            return false;
         }
         if (string.IsNullOrWhiteSpace(dto.PRODUCT_NAME))
         {
            MboxUtil.MboxWarn("품번명은 필수 입력입니다.");
            return false;
         }
         if (string.IsNullOrWhiteSpace(dto.PRODUCT_TYPE))
         {
            MboxUtil.MboxWarn("품번 유형은 필수 입력입니다.");
            return false;
         }
         return true;
      }
   }
}
