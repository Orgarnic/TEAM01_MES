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
        Srv_Product srv2 = new Srv_Product();
        List<PRODUCT_MST_DTO> product = null;
        BOM_PRODUCT_SEARCH search = new BOM_PRODUCT_SEARCH();
        List<BOM_MST_DTO> bom = null;
        List<PRODUCT_MST_DTO> temp = null;
        Util.ComboUtil comboUtil = new Util.ComboUtil();
        bool check = true, insert = true;

        string pcode, ccode;

        public Frm_BOM()
        {
            InitializeComponent();
        }

        private void Frm_BOM_Load(object sender, EventArgs e)
        {
            DataGirdViewParent();
            DataGirdViewChild();
            GetComboData();
            dgvBOMParent.ClearSelection();
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
            temp = srv2.SelectProduts(new PRODUCT_MST_DTO_Condition());
            Cohesion_DTO.ComboUtil.ProductCode = (from t in temp
                                                 select t.PRODUCT_CODE).ToList();
        }

        private void GetComboData()
        {
            ppgSearch.PropertySort = PropertySort.Categorized;
            ppgSearch.SelectedObject = new BOM_PRODUCT_SEARCH();
        }

        private void DataGirdViewParent()
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

        private void DataGirdViewChild()
        {
            dgvBOMChild.DataSource = null;

            DgvUtil.DgvInit(dgvBOMChild);
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품 코드", "CHILD_PRODUCT_CODE", 150, true, 1, frozen:true);
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품명", "PRODUCT_NAME", 150, true, 1, frozen:true);
            DgvUtil.AddTextCol(dgvBOMChild, "단위 수량", "REQUIRE_QTY", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);
        }

        // 자녀제품 목록 리셋
        private void DataGridViewReSet()
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
            bom = srv.SelectBOMList(code);
            dgvBOMChild.DataSource = bom;

            //PRODUCT_MST_DTO product = DgvUtil.DgvToDto<PRODUCT_MST_DTO>(dgvBOMParent);
            //ppgSearch.SelectedObject = product;
            BOM_PRODUCT_SEARCH search = new BOM_PRODUCT_SEARCH();
            ppgSearch.SelectedObject = search;
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();

            pcode = dgvBOMParent[0, e.RowIndex].Value.ToString();
            dgvBOMChild.ClearSelection();
        }

        // 전체 초기화
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvBOMParent.DataSource = product;
            dgvBOMChild.DataSource = null;
            ppgSearch.SelectedObject = new BOM_PRODUCT_SEARCH();
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
            dgvBOMParent.ClearSelection();
            txtSearch.Text = "";
        }

        // 조건 검색
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BOM_PRODUCT_SEARCH ppgdata = (BOM_PRODUCT_SEARCH)ppgSearch.SelectedObject;

            if (string.IsNullOrWhiteSpace(txtSearch.Text) &&
                ppgdata.CREATE_USER_ID == null &&
                ppgdata.PRODUCT_CODE == null &&
                ppgdata.PRODUCT_NAME == null &&
                ppgdata.PRODUCT_TYPE == null)
            {
                MboxUtil.MboxWarn("검색조건을 입력해주세요.");
                return;
            }
            else
            {
                dgvBOMParent.DataSource = srv.SelectGetProduct(ppgdata);
            }
        }

        // 자녀제품 리스트에서 선택
        private void dgvBOMChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //BOM_MST_DTO product = DgvUtil.DgvToDto<BOM_MST_DTO>(dgvBOMChild);
            BOM_MST_DTO product = BOMDeepCapy.DeepCopy(DgvUtil.DgvToDto<BOM_MST_DTO>(dgvBOMChild));
            ppgBOMAttribute.SelectedObject = product;

            ccode = dgvBOMChild[0, e.RowIndex].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvBOMParent.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("BOM 정보를 등록할 제품을 선택해주세요.");
                return;
            }/*
            if(dgvBOMChild.SelectedRows.Count > 0)
            {
                MboxUtil.MboxWarn("BOM등록이 되지 않은 제품만 등록이 가능합니다.\n다른 제품을 등록해주세요.");
                return;
            }*/
            bom = null;
            if(dgvBOMChild.DataSource == null)
            {
                bom = new List<BOM_MST_DTO>();
            }
            else
            {
                bom = (List<BOM_MST_DTO>)dgvBOMChild.DataSource;
            }

            BOM_MST_DTO bomlist = null;
            if (btnUpdate.Text != "      취  소")
            {
                btnUpdate.Text = "      취  소";
                btnAdd.Text = "      추  가";
                btnDelete.Text = "      빼  기";
                btnRefresh.Enabled = false;
                ppgBOMAttribute.Enabled = true;
                return;
            }
            else
            {
                bomlist = BOMDeepCapy.DeepCopy((BOM_MST_DTO)ppgBOMAttribute.SelectedObject);
                if (bomlist == null || bomlist.PRODUCT_TYPE == null) return;
                if (insert)
                {
                    bomlist.CREATE_TIME = DateTime.Now;
                    if (!bomlist.PRODUCT_TYPE.Equals("FERT"))
                    {
                        for (int i = 0; i < dgvBOMChild.Rows.Count; i++)
                        {
                            string str = dgvBOMChild[0, i].Value.ToString();
                            if (str.Equals(ppgBOMAttribute.SelectedGridItem.PropertyDescriptor.Name.Equals("CHILD_PRODUCT_CODE")))
                                bomlist.REQUIRE_QTY += 1;
                            else bomlist.CHILD_PRODUCT_CODE = bomlist.PRODUCT_CODE;
                        }
                    }
                    else
                    {
                        MboxUtil.MboxWarn("완제품은 등록할 수 없습니다.\n완제품 : FT");
                        return;
                    }
                }
                else
                {
                    if(bomlist.CREATE_TIME == null || bomlist.CREATE_TIME.Year < 2000)
                    {
                        bomlist.CREATE_TIME = DateTime.Now;
                        bomlist.CREATE_USER_ID = "김재형";
                    }
                    if (!bomlist.PRODUCT_TYPE.Equals("FERT"))
                    {
                        for (int i = 0; i < dgvBOMChild.Rows.Count; i++)
                        {
                            string str = dgvBOMChild[0, i].Value.ToString();
                            if (str.Equals(ppgBOMAttribute.SelectedGridItem.PropertyDescriptor.Name.Equals("CHILD_PRODUCT_CODE")))
                                bomlist.REQUIRE_QTY += 1;
                            else bomlist.CHILD_PRODUCT_CODE = bomlist.PRODUCT_CODE;
                        }
                    }
                    else
                    {
                        MboxUtil.MboxWarn("완제품은 등록할 수 없습니다.");
                        return;
                    }
                }
                bom.Add(bomlist);
                dgvBOMChild.DataSource = null;
                dgvBOMChild.DataSource = bom;
            }
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if(check)
            {
                btnSearchCondition.Text = "취소";
                btnSearch.Enabled = true;
                ppgSearch.Enabled = true;
                check = false;
            }
            else
            {
                btnSearchCondition.Text = "검색조건";
                btnSearch.Enabled = false;
                ppgSearch.Enabled = false;
                ppgSearch.SelectedObject =  new BOM_PRODUCT_SEARCH();
                check = true;
            }
        }

        // 부모제품 BOM 변경
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "      변  경")
            {
                insert = false;
                btnUpdate.Text = "      취  소";
                btnAdd.Text = "      추  가";
                btnDelete.Text = "      제  거";
                btnRefresh.Enabled = false;
                ppgBOMAttribute.Enabled = true;
            }
            else
            {
                insert = true;
                btnUpdate.Text = "      변  경";
                btnAdd.Text = "      생  성";
                btnDelete.Text = "      삭  제";
                btnDelete.Enabled = true;
                btnRefresh.Enabled = true;
                ppgBOMAttribute.Enabled = false;
                ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text != "      취  소") return;
            if (dgvBOMChild.DataSource == null)
            {
                MboxUtil.MboxWarn("하위 제품이 존재하지 않습니다.\n제품을 등록해주세요.");
                return;
            }
            List<BOM_MST_DTO> list = null;
            BOM_MST_DTO dto = null;

            if (insert)
            {
                if (!MboxUtil.MboxInfo_($"해당 제품({pcode})에 BOM정보를 등록하시겠습니까?")) return;
                else
                {
                    list = new List<BOM_MST_DTO>();
                    for (int i = 0; i < dgvBOMChild.Rows.Count; i++)
                    {
                        BOM_MST_DTO ddt = dgvBOMChild.Rows[i].DataBoundItem as BOM_MST_DTO;
                        ddt.PRODUCT_CODE = pcode;
                        ddt.CREATE_USER_ID = "lll";
                        ddt.CREATE_TIME = DateTime.Now;
                        list.Add(ddt);
                    }
                    bool result = srv.InsertBOM(list);
                    if (!result)
                    {
                        MboxUtil.MboxWarn("등록되지 못했습니다.\n다시 시도해주세요.");
                        return;
                    }
                    List<BOM_MST_DTO> list2 = srv.SelectBOMList(pcode);
                    dgvBOMChild.DataSource = null;
                    dgvBOMChild.DataSource = list2;
                }
            }
            else
            {
                if (!MboxUtil.MboxInfo_($"해당 제품({pcode})에 BOM정보를 변경하시겠습니까?")) return;
                list = new List<BOM_MST_DTO>();
                
                for (int i = 0; i < dgvBOMChild.Rows.Count; i++)
                {
                    dto = new BOM_MST_DTO
                    {
                        CHILD_PRODUCT_CODE = dgvBOMChild[0, i].Value.ToString(),
                        PRODUCT_CODE = pcode,
                        PRODUCT_NAME = dgvBOMChild[1, i].Value.ToString(),
                        CREATE_TIME = Convert.ToDateTime(dgvBOMChild[4, i].Value),
                        CREATE_USER_ID = dgvBOMChild[5,i].Value.ToString(),
                        REQUIRE_QTY = Convert.ToInt32(dgvBOMChild[2, i].Value),
                        UPDATE_TIME = DateTime.Now,
                        UPDATE_USER_ID = "김재형" //dgvBOMChild[5, i].Value.ToString(),
                    };
                    list.Add(dto);
                }
                bool result = srv.UpdateBOM(list);
                if (!result)
                {
                    MboxUtil.MboxWarn("등록되지 못했습니다.\n다시 시도해주세요.");
                    return;
                }
                List<BOM_MST_DTO> list2 = srv.SelectBOMList(pcode);
                dgvBOMChild.DataSource = null;
                dgvBOMChild.DataSource = list2;
            }
        }

        // ppgBOMAttribute에 제품 코드에 따라 제품명, 타입을 가져옴.
        private void ppgBOMAttribute_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Description.Equals("PRODUCT_CODE"))
            {
                var list = temp.Find((c) => c.PRODUCT_CODE.Equals(e.ChangedItem.Value.ToString()));
                if(list != null)
                {
                    BOM_MST_DTO bbom = (BOM_MST_DTO)ppgBOMAttribute.SelectedObject;
                    bbom.PRODUCT_NAME = list.PRODUCT_NAME;
                    bbom.PRODUCT_TYPE = list.PRODUCT_TYPE;
                }
            }
        }

        // 부모제품의 BOM 목록에서 자녀제품 삭제(제품 목록에서 삭제는 X)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBOMChild.SelectedRows.Count < 1) return;
            if (btnDelete.Text != "      삭  제")
            {
                if (dgvBOMChild.SelectedRows[0].Index < 1)
                {
                    dgvBOMChild.DataSource = null;
                }
                else
                {
                    bom = dgvBOMChild.DataSource as List<BOM_MST_DTO>;
                    bom.RemoveAt(dgvBOMChild.SelectedRows.Count);
                    dgvBOMChild.DataSource = null;
                    dgvBOMChild.DataSource = bom;
                }
            }
            else
            {
                if (dgvBOMChild.CurrentCell.Value == null)
                {
                    MboxUtil.MboxWarn("삭제할 제품을 선택해주세요.");
                }
                else
                {
                    if (MboxUtil.MboxInfo_("해당 제품의 BOM 제품을 삭제하시겠습니까?"))
                    {
                        bool result = srv.DeleteProduct(pcode, ccode);
                        if (result)
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
    }

    public class ProdectSearch
    {
        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
        public string PRODUCT_NAME { get; set; }
    }
    public class BOMDeepCapy
    {
        public static BOM_MST_DTO DeepCopy(BOM_MST_DTO origin)
        {
            return new BOM_MST_DTO
            {
                PRODUCT_CODE = origin.PRODUCT_CODE,
                PRODUCT_NAME = origin.PRODUCT_NAME,
                PRODUCT_TYPE = origin.PRODUCT_TYPE,
                REQUIRE_QTY = origin.REQUIRE_QTY,
                CHILD_PRODUCT_CODE = origin.CHILD_PRODUCT_CODE,
                ORDER_QTY = origin.ORDER_QTY,
                LOT_QTY = origin.LOT_QTY,
                CREATE_TIME = origin.CREATE_TIME,
                CREATE_USER_ID = origin.CREATE_USER_ID,
                UPDATE_TIME = origin.UPDATE_TIME,
                UPDATE_USER_ID = origin.UPDATE_USER_ID,
                ALTER_PRODUCT_CODE = origin.ALTER_PRODUCT_CODE
            };
        }
    }

}
