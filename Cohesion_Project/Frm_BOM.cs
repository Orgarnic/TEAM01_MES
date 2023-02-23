using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;
using System.Linq;
using System.Diagnostics;

namespace Cohesion_Project
{
    public partial class Frm_BOM : Cohesion_Project.Frm_Base_3
    {
        Srv_BOM srv = new Srv_BOM();
        Srv_Product srv2 = new Srv_Product();
        Srv_Operation srv3 = new Srv_Operation();
        List<PRODUCT_MST_DTO> product = null;
        List<BOM_MST_DTO> bom = new List<BOM_MST_DTO>();
        List<PRODUCT_MST_DTO> temp = null;
        Util.ComboUtil comboUtil = new Util.ComboUtil();
        List<OPERATION_MST_DTO> oper = null;
        User_DTO user = new User_DTO();
        bool check = true;
        string prodID;

        public Frm_BOM()
        {
            InitializeComponent();
        }

        private void Frm_BOM_Load(object sender, EventArgs e)
        {
            user = (this.ParentForm as Frm_Main).userInfo;
            DataGirdViewParent();
            DataGirdViewChild();
            GetComboData();
            dgvBOMParent.ClearSelection();
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
            temp = srv2.SelectProduts(new PRODUCT_MST_DTO_Condition());
            oper = srv3.SelectOperation(new OPERATION_MST_DTO_Condition());

            Cohesion_DTO.ComboUtil.ProductCode = (from t in temp
                                     select t.PRODUCT_CODE).ToList();
            Cohesion_DTO.ComboUtil.OperationCode = (from o in oper
                                       select o.OPERATION_CODE).ToList();
            txtSearch.Focus();
        }

        private void GetComboData()
        {
            ppgSearch.PropertySort = PropertySort.Categorized;
            ppgSearch.SelectedObject = new BOM_PRODUCT_SEARCH();
        }

        private void DataGirdViewParent()
        {
            DgvUtil.DgvInit(dgvBOMParent);
            DgvUtil.AddTextCol(dgvBOMParent, "  NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
            DgvUtil.AddTextCol(dgvBOMParent, "   제품 코드", "PRODUCT_CODE", 160, true, align: 0, frozen:true);
            DgvUtil.AddTextCol(dgvBOMParent, "  제품명", "PRODUCT_NAME", 160, true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "   제품 유형", "PRODUCT_TYPE", 150, true, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "   생성 시간", "CREATE_TIME", 200, true);
            DgvUtil.AddTextCol(dgvBOMParent, "    생성 사용자", "CREATE_USER_ID", 160, true, align: 0);
            DgvUtil.AddTextCol(dgvBOMParent, "  변경 시간", "UPDATE_TIME", 200, true);
            DgvUtil.AddTextCol(dgvBOMParent, "   변경 사용자", "UPDATE_USER_ID", 160, true, align: 0);
            if(product == null)
            {
                product = srv.SelectProductList();
            }
            int seq = 1;
            dgvBOMParent.DataSource = product.Select((p) => new
            {
               IDX = seq++,
               PRODUCT_CODE = p.PRODUCT_CODE,
               PRODUCT_NAME = p.PRODUCT_NAME,
               PRODUCT_TYPE = p.PRODUCT_TYPE,
               CREATE_TIME = p.CREATE_TIME,
               CREATE_USER_ID = p.CREATE_USER_ID,
               UPDATE_TIME = p.UPDATE_TIME,
               UPDATE_USER_ID = p.UPDATE_USER_ID
            }).ToList();
        }

        private void DataGirdViewChild()
        {
            dgvBOMChild.DataSource = null;

            DgvUtil.DgvInit(dgvBOMChild);
            DgvUtil.AddCheckBoxCol(dgvBOMChild, "Check", "Check", 50, frozen: true);
            DgvUtil.AddTextCol(dgvBOMChild, "제품 코드", "CHILD_PRODUCT_CODE", 160, true, 0, frozen:true);
            DgvUtil.AddTextCol(dgvBOMChild, "제품명", "PRODUCT_NAME", 160, true, 0, frozen:true);
            DgvUtil.AddTextCol(dgvBOMChild, "제품 유형", "PRODUCT_TYPE", 150, true, 1, frozen: true);
            DgvUtil.AddTextCol(dgvBOMChild, "단위 수량", "REQUIRE_QTY", 150, true, 2);
            DgvUtil.AddTextCol(dgvBOMChild, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 0);
            DgvUtil.AddTextCol(dgvBOMChild, "공정 코드", "OPERATION_CODE", 150, true, 0);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 사용자", "CREATE_USER_ID", 150, true, 0);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 사용자", "UPDATE_USER_ID", 150, true, 0);
        }

        // 부모제품 리스트에서 선택
        private void dgvBOMParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀클릭시, 클릭된 완제품의 BOM을 Child에 뿌려줌.
            if (e.RowIndex < 0) return;

            prodID = dgvBOMParent["PRODUCT_CODE", e.RowIndex].Value.ToString();
            bom = srv.SelectBOMList(prodID);
            if (bom.Count > 0)
            {
                dgvBOMChild.DataSource = null;
                dgvBOMChild.DataSource = bom;
            }
            else
            {
                dgvBOMChild.DataSource = null;
            }
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
        }

        // 전체 초기화
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled|| ppgBOMAttribute.Enabled)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                ppgBOMAttribute.Enabled = false;
            }
            if(ppgSearch.Enabled)
            {
                ppgSearch.Enabled = false;
                check = true;
            }
            ppgBOMAttribute.SelectedObject = new BOM_MST_DTO();
            dgvBOMChild.DataSource = null;
            ppgBOMAttribute.Enabled = false;
            dgvBOMParent.DataSource = null;
            dgvBOMParent.DataSource = product;
            dgvBOMParent.ClearSelection();
        }

        // 조건 검색
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(check)
            {
                MboxUtil.MboxWarn("검색조건을 입력해주세요.");
                return;
            }
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
            BOM_MST_DTO product = BOM_MST_DTO.DeepCopy(DgvUtil.DgvToDto<BOM_MST_DTO>(dgvBOMChild));
            ppgBOMAttribute.SelectedObject = product;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 생산 버튼으로 제품을 dgvBOMChild에 입력
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvBOMParent.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("BOM 정보를 등록할 제품을 선택해주세요.");
                return;
            }
            
            BOM_MST_DTO dto = BOM_MST_DTO.DeepCopy((BOM_MST_DTO)ppgBOMAttribute.SelectedObject);
            dto.PRODUCT_CODE = prodID;
            dto.CREATE_USER_ID = user.USER_NAME;
            dto.UPDATE_USER_ID = user.USER_NAME;
            if (dto.REQUIRE_QTY < 1)
            {
                MboxUtil.MboxWarn("BOM 단위 수량은 최소 1개 이상 등록되어야합니다.");
                return;
            }
            if (string.IsNullOrWhiteSpace(dto.CHILD_PRODUCT_CODE))
            {
                MboxUtil.MboxWarn("제품 번호는 필수 입력입니다.");
                return;
            }
            if (string.IsNullOrWhiteSpace(dto.PRODUCT_NAME))
            {
                MboxUtil.MboxWarn("제품명은 필수 입력입니다.");
                return;
            }
            if (string.IsNullOrWhiteSpace(dto.OPERATION_CODE))
            {
                MboxUtil.MboxWarn("공정은 필수 입력입니다.");
                return;
            }

            if (dto != null)
            {
                if (!dto.PRODUCT_TYPE.Equals("FERT"))
                {
                    if (bom.Any((b) => b.CHILD_PRODUCT_CODE.Equals(dto.CHILD_PRODUCT_CODE)))
                    {
                        bom.Find((b) => b.CHILD_PRODUCT_CODE.Equals(dto.CHILD_PRODUCT_CODE)).REQUIRE_QTY = dto.REQUIRE_QTY;
                    }
                    else 
                        bom.Add(dto);
                }
                else
                {
                    MboxUtil.MboxWarn("완제품은 등록할 수 없습니다.\n완제품 코드 : FT");
                    return;
                }
            }
            dgvBOMChild.DataSource = null;
            dgvBOMChild.DataSource = bom;
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if(check)
            {
                ppgSearch.Enabled = true;
                check = false;
            }
            else
            {
                ppgSearch.Enabled = false;
                ppgSearch.SelectedObject =  new BOM_PRODUCT_SEARCH();
                check = true;
            }
        }

        // 부모제품 BOM 변경
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBOMParent.SelectedRows.Count < 1)
            {
                MboxUtil.MboxWarn("BOM 정보를 변경할 제품을 선택해주세요.");
                return;
            }
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            ppgBOMAttribute.Enabled = true;
        }

        // dgvBOMChild에 등록된 제품 확정(DB Insert)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dgvBOMChild.DataSource == null)
            {
                MboxUtil.MboxWarn("하위 제품이 존재하지 않습니다.\n제품을 등록해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_($"해당 제품({prodID})에 BOM정보를 변경하시겠습니까?")) return;

            bool result = srv.UpdateBOM(bom, prodID);
            if (!result)
            {
                MboxUtil.MboxWarn("등록되지 못했습니다.\n다시 시도해주세요.");
                return;
            }
            MboxUtil.MboxInfo("등록되었습니다.");
            bom = srv.SelectBOMList(prodID);
            btnRefresh.PerformClick();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        // ppgBOMAttribute에 제품 코드에 따라 제품명, 타입을 가져옴.
        private void ppgBOMAttribute_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            BOM_MST_DTO bbom = null;
            if (e.ChangedItem.PropertyDescriptor.Description.Equals("CHILD_PRODUCT_CODE"))
            {                
                var list = temp.Find((c) => c.PRODUCT_CODE.Equals(e.ChangedItem.Value.ToString()));
                if (list != null)
                {
                    bbom = (BOM_MST_DTO)ppgBOMAttribute.SelectedObject;
                    bbom.PRODUCT_NAME = list.PRODUCT_NAME;
                    bbom.PRODUCT_TYPE = list.PRODUCT_TYPE;
                }
            }
        }

        // 부모제품의 BOM 목록에서 자녀제품 삭제(제품 목록에서 삭제는 X)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBOMChild.Rows.Count < 1) return;

            int cnt = 0;
            for (int i = dgvBOMChild.Rows.Count - 1; i >= 0; i--)
            {
                bool bb = dgvBOMChild.Rows[i].Cells[0].Value == null ? false : Convert.ToBoolean(dgvBOMChild.Rows[i].Cells[0].Value);
                if (bb)
                {
                    cnt++;
                    string code = (string)dgvBOMChild.Rows[i].Cells["CHILD_PRODUCT_CODE"].Value;
                    int num = bom.FindIndex((s) => s.CHILD_PRODUCT_CODE.Equals(code));
                    bom.RemoveAt(num);
                }
            }
            if (cnt == 0)
            {
                MboxUtil.MboxWarn("삭제 항목을 선택해주세요.");
                return;
            }
            MboxUtil.MboxInfo("삭제되었습니다.");
            dgvBOMChild.DataSource = null;
            dgvBOMChild.DataSource = bom;
        }

        private void ppgSearch_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Description.Equals("PRODUCT_CODE"))
            {
                var list = temp.Find((c) => c.PRODUCT_CODE.Equals(e.ChangedItem.Value.ToString()));
                if (list != null)
                {
                    BOM_PRODUCT_SEARCH bbom = (BOM_PRODUCT_SEARCH)ppgSearch.SelectedObject;
                    bbom.PRODUCT_NAME = list.PRODUCT_NAME;
                    bbom.PRODUCT_TYPE = list.PRODUCT_TYPE;
                    bbom.CREATE_USER_ID = list.CREATE_USER_ID;
                }
            }
        }
    }
}