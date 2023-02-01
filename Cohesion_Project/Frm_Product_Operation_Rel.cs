using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cohesion_Project;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Product_Operation_Rel : Cohesion_Project.Frm_Base_4
    {
        PRODUCT_OPERATION_Rel_Search oSearch = new PRODUCT_OPERATION_Rel_Search();
        Srv_Operation svP = new Srv_Operation();
        Srv_Product svC = new Srv_Product();
        Srv_Relation svR = new Srv_Relation();
        List<OPERATION_REL_DTO> iList = new List<OPERATION_REL_DTO>();
        Util.ComboUtil comboUtil = new Util.ComboUtil();

        bool searchState = false;
        public Frm_Product_Operation_Rel()
        {
            InitializeComponent();
        }

        private void Frm_Product_Operation_Rel_Load(object sender, EventArgs e)
        {
            InitDgv();
            var list = svC.SelectProductInRel();
            int seq = 1;
            dgvProductList.DataSource = list.Select((i) => new
            {
                PRODUCT_CODE = i.PRODUCT_CODE,
                PRODUCT_NAME = i.PRODUCT_NAME,
                PRODUCT_TYPE = i.PRODUCT_TYPE,
                CUSTOMER_CODE = i.CUSTOMER_CODE,
                VENDOR_CODE = i.VENDOR_CODE,
                CREATE_TIME = i.CREATE_TIME,
                CREATE_USER_ID = i.CREATE_USER_ID,
                UPDATE_TIME = i.UPDATE_TIME,
                UPDATE_USER_ID = i.UPDATE_USER_ID,
                DISPLAY_SEQ = seq++
            }).ToList();
        }

        private void InitDgv()
        {
            //데이터 그리드 뷰 초기 설정
            DgvUtil.DgvInit(dgvProductList);
            DgvUtil.AddTextCol(dgvProductList, "NO", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvProductList, "품번", "PRODUCT_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvProductList, "품명", "PRODUCT_NAME", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "품번 유형", "PRODUCT_TYPE", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "고객 코드", "CUSTOMER_CODE", 100, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "업체 코드", "VENDOR_CODE", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "생성 시간", "CREATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "생성자", "CREATE_USER_ID", 120, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "변경 시간", "UPDATE_TIME", 140, readOnly: true);
            DgvUtil.AddTextCol(dgvProductList, "변경자", "UPDATE_USER_ID", 120, readOnly: true);

            DgvUtil.DgvInit(dgvOperationList);
            DgvUtil.AddTextCol(dgvOperationList, "순번", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "공정 코드", "OPERATION_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvOperationList, "공정명", "OPERATION_NAME", 100, readOnly: true);

            DgvUtil.DgvInit(dgvAddOperationList);
            DgvUtil.AddTextCol(dgvAddOperationList, "순번", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddOperationList, "공정 코드", "OPERATION_CODE", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgvAddOperationList, "공정명", "OPERATION_NAME", 100, readOnly: true);


            btnLeft.Enabled = false;
            btnRight.Enabled = false;

            var list = svP.SelectOperationInRel(new Operation_Inspection_Rel_DTO());
            int seq = 1;
            iList = list.Select((i) => new OPERATION_REL_DTO
            {
                OPERATION_CODE = i.OPERATION_CODE,
                OPERATION_NAME = i.OPERATION_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();
            dgvOperationList.DataSource = iList;

            ppgSearchCondition.PropertySort = PropertySort.Categorized;
            ppgSearchCondition.SelectedObject = oSearch;
            ppgSearchCondition.Enabled = false;

        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!searchState)
            {
                searchState = true;
                ppgSearchCondition.Enabled = true;
            }
            else
            {
                searchState = false;
                ppgSearchCondition.SelectedObject = new PRODUCT_OPERATION_Rel_Search();
                ppgSearchCondition.Enabled = false;
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string productCode = dgvProductList[1, e.RowIndex].Value.ToString();
            var list = svR.SelectOperWithProduct(productCode);
            dgvAddOperationList.DataSource = list.Select((i) => new
            OPERATION_REL_DTO
            {
                OPERATION_CODE = i.OPERATION_CODE,
                OPERATION_NAME = i.OPERATION_NAME,
                DISPLAY_SEQ = i.DISPLAY_SEQ
            }).ToList();
            
            int seq = 1;

            dgvOperationList.DataSource = iList.Where((i) => !list.Any((o) => i.OPERATION_CODE == o.OPERATION_CODE)).Select((i) => new OPERATION_REL_DTO
            {
                OPERATION_CODE = i.OPERATION_CODE,
                OPERATION_NAME = i.OPERATION_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();

            if (dgvAddOperationList.Rows.Count != 0)
            {
                btnAdd.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.PerformClick();
                btnUpdate.Enabled = false;
                btnInsert.Enabled = false;
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (dgvOperationList.Rows.Count == 0 )
            {
                return;
            }

            int seq = 1;
            int seqI = 1;
            int idx = dgvOperationList.CurrentRow.Index;
            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }


            OPERATION_REL_DTO dto = new OPERATION_REL_DTO
            {
                OPERATION_CODE = dgvOperationList.Rows[idx].Cells[1].Value.ToString()
               ,
                OPERATION_NAME = dgvOperationList.Rows[idx].Cells[2].Value.ToString()
            };

            if (dgvAddOperationList.Rows.Count == 0)
            {
                List<OPERATION_REL_DTO> addList = new List<OPERATION_REL_DTO>();
                addList.Add(dto);
                dgvAddOperationList.DataSource = null;
                dgvAddOperationList.DataSource = addList.OrderBy((i) => i.OPERATION_CODE).Select((i) => new OPERATION_REL_DTO { OPERATION_CODE = i.OPERATION_CODE, OPERATION_NAME = i.OPERATION_NAME, DISPLAY_SEQ = seq++ }).ToList();
                var l1 = dgvAddOperationList.DataSource;

                List<OPERATION_REL_DTO> list = dgvOperationList.DataSource as List<OPERATION_REL_DTO>;
                
                list.Remove(list.Find((i) => i.OPERATION_CODE.Equals(dto.OPERATION_CODE, StringComparison.OrdinalIgnoreCase)));

                dgvOperationList.DataSource = list.Select((i) => new OPERATION_REL_DTO
                {
                    OPERATION_CODE = i.OPERATION_CODE,
                    OPERATION_NAME = i.OPERATION_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
            else
            {
                var addList = dgvAddOperationList.DataSource as List<OPERATION_REL_DTO>;
                //if (addList.Exists((i)=>i.OPERATION_CODE.Equals(dto.OPERATION_CODE, StringComparison.OrdinalIgnoreCase)))
                //{
                //    return;
                //}
                //else
                //{
                    addList.Add(dto);
                    dgvAddOperationList.DataSource = null;
                    dgvAddOperationList.DataSource = addList.OrderBy((i) => i.OPERATION_CODE).Select((i) => new OPERATION_REL_DTO { OPERATION_CODE = i.OPERATION_CODE, OPERATION_NAME = i.OPERATION_NAME, DISPLAY_SEQ = seq++ }).ToList();

                    List<OPERATION_REL_DTO> list = dgvOperationList.DataSource as List<OPERATION_REL_DTO>;

                    list.Remove(list.Find((i) => i.OPERATION_CODE.Equals(dto.OPERATION_CODE, StringComparison.OrdinalIgnoreCase)));

                    dgvOperationList.DataSource = list.Select((i) => new OPERATION_REL_DTO
                    {
                        OPERATION_CODE = i.OPERATION_CODE,
                        OPERATION_NAME = i.OPERATION_NAME,
                        DISPLAY_SEQ = seqI++
                    }).ToList();
                //}
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (dgvAddOperationList.Rows.Count == 0)
            {
                return;
            }

            int seq = 1;
            int seqI = 1;
            int idx = dgvAddOperationList.CurrentRow.Index;

            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }

            if (dgvAddOperationList.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사 항목이 존재하지 않습니다.");
                return;
            }
            else
            {
                var dto = dgvAddOperationList.Rows[idx].DataBoundItem as OPERATION_REL_DTO;
                var addList = dgvAddOperationList.DataSource as List<OPERATION_REL_DTO>;
                addList.Remove(dto);
                dgvAddOperationList.DataSource = null;
                dgvAddOperationList.DataSource = addList.OrderBy((i) => i.OPERATION_CODE).Select((i) => new OPERATION_REL_DTO { OPERATION_CODE = i.OPERATION_CODE, OPERATION_NAME = i.OPERATION_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<OPERATION_REL_DTO> list = dgvOperationList.DataSource as List<OPERATION_REL_DTO>;
                if (list.Exists((i)=>i.OPERATION_CODE.Equals(dto.OPERATION_CODE)))
                {
                    return;
                }
                else
                {
                    list.Add(dto);
                    dgvOperationList.DataSource = list.Select((i) => new OPERATION_REL_DTO
                    {
                        OPERATION_CODE = i.OPERATION_CODE,
                        OPERATION_NAME = i.OPERATION_NAME,
                        DISPLAY_SEQ = seqI++
                    }).ToList();
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productCode = dgvProductList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<OPERATION_REL_DTO> list = dgvAddOperationList.DataSource as List<OPERATION_REL_DTO>;

            if (dgvAddOperationList.Rows.Count == 0)
            {
                MboxUtil.MboxError("공정항목을 등록해주세요");
                return;
            }

            bool result = svR.InsertOperWithProduct(productCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("공정 정보를 입력했습니다.");
                dgvAddOperationList.DataSource = null;
                int seq = 1;
                dgvOperationList.DataSource = iList.Select((i) => new OPERATION_REL_DTO
                {
                    OPERATION_CODE = i.OPERATION_CODE,
                    OPERATION_NAME = i.OPERATION_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("설비 정보 입력중 오류가 발생했습니다.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string productCode = dgvProductList[1, dgvOperationList.CurrentRow.Index].Value.ToString();
            List<OPERATION_REL_DTO> list = dgvAddOperationList.DataSource as List<OPERATION_REL_DTO>;
            var result = svR.UpdateOperWithProduct(productCode, list);
            if (result)
            {
                MboxUtil.MboxInfo("공정 정보를 수정했습니다.");
                dgvAddOperationList.DataSource = null;
                int seq = 1;
                dgvOperationList.DataSource = iList.Select((i) => new OPERATION_REL_DTO
                {
                    OPERATION_CODE = i.OPERATION_CODE,
                    OPERATION_NAME = i.OPERATION_NAME,
                    DISPLAY_SEQ = seq++
                }).ToList();
                return;
            }
            else
            {
                MboxUtil.MboxError("공정 정보 수정중 오류가 발생했습니다.");
            }
        }
    }
}
