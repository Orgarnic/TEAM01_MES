﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;
using System.Linq;

namespace Cohesion_Project
{
    public partial class Frm_BOM : Cohesion_Project.Frm_Base_3
    {
        Srv_BOM srv = new Srv_BOM();
        List<PRODUCT_MST_DTO> product = null;
        BOM_PRODUCT_SEARCH search = new BOM_PRODUCT_SEARCH();
        List<BOM_MST_DTO> bom = null;

        string pcode, ccode;

        public Frm_BOM()
        {
            InitializeComponent();
        }

        private void Frm_BOM_Load(object sender, EventArgs e)
        {
            DataGirdViewParent();
            DataGirdViewChild();

            ppgSearch.PropertySort = PropertySort.Categorized;
            ppgSearch.SelectedObject = new BOM_PRODUCT_SEARCH();
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
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
            if(product == null)
            {
                product = srv.SelectProductList();
            }

            dgvBOMParent.DataSource = product;
        }

        public void DataGirdViewChild()
        {
            dgvBOMChild.DataSource = null;

            DgvUtil.DgvInit(dgvBOMChild);
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품명", "CHILD_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "단위 수량", "REQUIRE_QTY", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);

        }

        // 자녀제품 목록 리셋
        public void DataGridViewReSet()
        {
            dgvBOMChild.DataSource = null;
            dgvBOMChild.DataSource = srv.SelectBOMList(pcode);
        }

        // 부모제품 리스트에서 선택
        private void dgvBOMParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀클릭시, 클릭된 완제품의 BOM을 Child에 뿌려줌.
            if (e.RowIndex < 0) return;
            string code = dgvBOMParent[0, e.RowIndex].Value.ToString();

            dgvBOMChild.DataSource = srv.SelectBOMList(code);

            //PRODUCT_MST_DTO product = DgvUtil.DgvToDto<PRODUCT_MST_DTO>(dgvBOMParent);
            //ppgSearch.SelectedObject = product;
            BOM_PRODUCT_SEARCH search = new BOM_PRODUCT_SEARCH();
            ppgSearch.SelectedObject = search;
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();

            pcode = dgvBOMParent[0, e.RowIndex].Value.ToString();
        }

        // 전체 초기화
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvBOMParent.DataSource = dgvBOMChild.DataSource = null;
            ppgSearch.SelectedObject = srv.SelectGetProduct(search);
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
        }

        // 조건 검색
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == null) return;
            //dgvBOMParent.DataSource = product.FindAll((s) => s.PRODUCT_NAME.Contains(txtSearch.Text));
            
        }

        // 자녀제품 리스트에서 선택
        private void dgvBOMChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            BOM_MST_DTO product = DgvUtil.DgvToDto<BOM_MST_DTO>(dgvBOMChild);
            ppgBOMAttribute.SelectedObject = product;

            ccode = dgvBOMChild[0, e.RowIndex].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BOM_MST_DTO prod = (BOM_MST_DTO)ppgSearch.SelectedObject;

        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            ppgSearch.SelectedObject = new BOM_PRODUCT_SEARCH();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "      변  경")
            {
                btnUpdate.Text = "      취  소";
                btnAdd.Text = "      추  가";
                btnDelete.Enabled = false;
                btnRefresh.Enabled = false;
                ppgBOMAttribute.Enabled = true;
            }
            else
            {
                btnUpdate.Text = "      변  경";
                btnAdd.Text = "      생  성";
                btnDelete.Enabled = true;
                btnRefresh.Enabled = true;
                ppgBOMAttribute.Enabled = false;
                ppgBOMAttribute.SelectedObject = new BOM_PRODUCT_SEARCH();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            BOM_MST_DTO dto = null;
            if (btnUpdate.Text != "      취  소") return;
            if (!MboxUtil.MboxInfo_($"제품 {pcode}에 '해당'제품을 BOM등록하시겠습니까?")) return;
            else
            {
                for(int i = 0; i < dgvBOMChild.Rows.Count; i++)
                {
                    dto = new BOM_MST_DTO
                    {
                        PRODUCT_CODE = dgvBOMChild[0, i].Value.ToString(),
                        REQUIRE_QTY = Convert.ToInt32(dgvBOMChild[1, i].Value),
                        ALTER_PRODUCT_CODE = dgvBOMChild[2, i].Value.ToString(),
                        CREATE_TIME = Convert.ToDateTime(dgvBOMChild[3, i].Value.ToString()),
                        CREATE_USER_ID = dgvBOMChild[4, i].Value.ToString(),
                        UPDATE_TIME = Convert.ToDateTime(dgvBOMChild[5, i].Value.ToString()),
                        UPDATE_USER_ID = dgvBOMChild[6, i].Value.ToString()
                    };
                }
                bom.Add(ppgBOMAttribute.SelectedObject as BOM_MST_DTO);
                dgvBOMChild.DataSource = bom;
            }
        }

        // 부모제품의 BOM 목록에서 자녀제품 삭제(제품 목록에서 삭제는 X)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvBOMChild.CurrentCell.Value == null)
            {
                MboxUtil.MboxWarn("삭제할 제품을 선택해주세요.");
            }
            else
            {
                if(MboxUtil.MboxInfo_("해당 제품의 BOM 제품을 삭제하시겠습니까?"))
                {
                    bool result = srv.DeleteProduct(pcode, ccode);
                    if(result)
                    {
                        MboxUtil.MboxInfo("삭제가 완료되었습니다.");
                        DataGridViewReSet();
                    }
                    else
                    {
                        MboxUtil.MboxError("오류가 발생하였습니다.\n다시시도해주세요.");
                    }
                }
            }
        }
    }

    public class ProdectSearch
    {
        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
        public string PRODUCT_NAME { get; set; }
    }


}
