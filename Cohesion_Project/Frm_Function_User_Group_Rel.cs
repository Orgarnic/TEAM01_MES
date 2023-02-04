using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public partial class Frm_Function_User_Group_Rel : Cohesion_Project.Frm_Base_4
    {
        Srv_Function_User_Group_Rel SrvFUG = new Srv_Function_User_Group_Rel();
        List<FUNCTION_USER_GROUP_REL_DTO> FList;
      
        public Frm_Function_User_Group_Rel()
        {
            InitializeComponent();
        }

        private void Frm_Function_User_Group_Rel_Load(object sender, EventArgs e)
        {

            DgvInit();
            DataGridViewFill();
            DataGridViewFill2();
            PpgInit();





        }

        //private void LoadData() // 2
        //{
        //    var list = SrvFUG.SelectFUGR(new FUNCTION_USER_GROUP_REL_DTO());
        //    int seq = 1;
        //    DgvF1.DataSource = list.Select((i) => new
        //    {
        //        USER_GROUP_CODE = i.USER_GROUP_CODE,
        //        USER_GROUP_NAME = i.USER_GROUP_NAME,
        //        USER_GROUP_TYPE = i.USER_GROUP_TYPE,
        //        CREATE_TIME = i.CREATE_TIME,
        //        CREATE_USER_ID = i.CREATE_USER_ID,
        //        UPDATE_TIME = i.UPDATE_TIME,
        //        UPDATE_USER_ID = i.UPDATE_USER_ID,

        //        DISPLAY_SEQ = seq++
        //    }).ToList();
        //}

        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvFUG);
            DgvUtil.AddTextCol(DgvFUG, "사용자 그룹 코드", "USER_GROUP_CODE", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "사용자 그룹 명", "USER_GROUP_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "사용자 그룹 유형", "USER_GROUP_TYPE", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "생성 시간", "CREATE_TIME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "생성 사용자", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "변경 시간", "UPDATE_TIME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvFUG, "변경 사용자", "UPDATE_USER_ID", 120, true, align: 2);

            DgvUtil.DgvInit(DgvF1);
            DgvUtil.AddTextCol(DgvF1, "순번", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(DgvF1, "화면 기능 코드", "FUNCTION_NAME", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvF1, "화면 기능명", "FUNCTION_CODE", 120, true, align: 1);


            DgvUtil.DgvInit(DgvF2);
            DgvUtil.AddTextCol(DgvF2, "순번", "DISPLAY_SEQ", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(DgvF2, "화면 기능 코드", "FUNCTION_NAME", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvF2, "화면 기능명", "FUNCTION_CODE", 120, true, align: 1);

   

        }


        private void PpgInit()
        {
            PpgFUG.PropertySort = PropertySort.Categorized;
            PpgFUG.SelectedObject = new FUNCTION_USER_GROUP_REL_DTO();
        }

        private void DataGridViewFill()
        {
            FList = SrvFUG.SelectFUG();
            DgvFUG.DataSource = FList;

            //FList = SrvFUG.SelectFUG1();
            //DgvF2.DataSource = FList;
        }

        private void DataGridViewFill2()
        {


            FList = SrvFUG.SelectFUG1();
            DgvF2.DataSource = FList;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (DgvF1.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = DgvF1.CurrentRow.Index;

            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }
            if (DgvF1.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사 항목이 존재하지 않습니다.");
                return;
            }
            else
            {
                var dto = DgvF1.Rows[idx].DataBoundItem as FUNCTION_USER_GROUP_REL_DTO;
                var addList = DgvF1.DataSource as List<FUNCTION_USER_GROUP_REL_DTO>;
                addList.Remove(dto);
                DgvF1.DataSource = null;
                DgvF1.DataSource = addList.OrderBy((i) => i.FUNCTION_CODE).Select((i) => new FUNCTION_USER_GROUP_REL_DTO { FUNCTION_CODE = i.FUNCTION_CODE, FUNCTION_NAME = i.FUNCTION_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<FUNCTION_USER_GROUP_REL_DTO> list = DgvF2.DataSource as List<FUNCTION_USER_GROUP_REL_DTO>;
                if (list.Exists((i) => i.FUNCTION_CODE.Equals(dto.FUNCTION_CODE)))
                {
                    return;
                }
                else
                {
                    list.Add(dto);
                    DgvF2.DataSource = list.Select((i) => new FUNCTION_USER_GROUP_REL_DTO
                    {
                        FUNCTION_CODE = i.FUNCTION_CODE,
                        FUNCTION_NAME = i.FUNCTION_NAME,
                        DISPLAY_SEQ = seqI++
                    }).ToList();
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (DgvF2.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = DgvF2.CurrentRow.Index;
            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }


            FUNCTION_USER_GROUP_REL_DTO dto = new FUNCTION_USER_GROUP_REL_DTO
            {
                FUNCTION_CODE = DgvF2.Rows[idx].Cells[0].Value.ToString()
               ,
                FUNCTION_NAME = DgvF2.Rows[idx].Cells[1].Value.ToString()
            };

            if (DgvF1.Rows.Count == 0)
            {
                List<FUNCTION_USER_GROUP_REL_DTO> addList = new List<FUNCTION_USER_GROUP_REL_DTO>();
                addList.Add(dto);
                DgvF1.DataSource = null;
                DgvF1.DataSource = addList.OrderBy((i) => i.FUNCTION_CODE).Select((i) => new FUNCTION_USER_GROUP_REL_DTO { FUNCTION_CODE = i.FUNCTION_CODE, FUNCTION_NAME = i.FUNCTION_NAME, DISPLAY_SEQ = seq++ }).ToList();
                var l1 = DgvF1.DataSource;

                List<FUNCTION_USER_GROUP_REL_DTO> list = DgvF2.DataSource as List<FUNCTION_USER_GROUP_REL_DTO>;
                list.RemoveAt(list.FindIndex((i) => i.FUNCTION_CODE.Equals(dto.FUNCTION_CODE, StringComparison.OrdinalIgnoreCase)));

                DgvF2.DataSource = list.Select((i) => new FUNCTION_USER_GROUP_REL_DTO
                {
                    FUNCTION_CODE = i.FUNCTION_CODE,
                    FUNCTION_NAME = i.FUNCTION_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
            else
            {
                var addList = DgvF1.DataSource as List<FUNCTION_USER_GROUP_REL_DTO>;
                addList.Add(dto);
                DgvF1.DataSource = null;
                DgvF1.DataSource = addList.OrderBy((i) => i.FUNCTION_CODE).Select((i) => new FUNCTION_USER_GROUP_REL_DTO { FUNCTION_CODE = i.FUNCTION_CODE, FUNCTION_NAME = i.FUNCTION_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<FUNCTION_USER_GROUP_REL_DTO> list = DgvF2.DataSource as List<FUNCTION_USER_GROUP_REL_DTO>;
                list.Remove(list.Find((i) => i.FUNCTION_CODE.Equals(dto.FUNCTION_CODE, StringComparison.OrdinalIgnoreCase)));

                DgvF2.DataSource = list.Select((i) => new FUNCTION_USER_GROUP_REL_DTO
                {
                    FUNCTION_CODE = i.FUNCTION_CODE,
                    FUNCTION_NAME = i.FUNCTION_NAME,
                    DISPLAY_SEQ = seqI++
                }).ToList();
            }
        }

        private void DgvFUG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string operationCode = DgvFUG[1, e.RowIndex].Value.ToString();
            var list = SrvFUG.SelectFUGR(operationCode);
            int seq = 1;
            int seqI = 1;
            DgvF1.DataSource = list.Select((i) => new FUNCTION_USER_GROUP_REL_DTO
            {
                FUNCTION_CODE = i.FUNCTION_CODE,
                FUNCTION_NAME = i.FUNCTION_NAME,
                DISPLAY_SEQ = seq++
            }).ToList();


            DgvF2.DataSource = FList.Where((i) => !list.Any((o) => i.FUNCTION_CODE == o.FUNCTION_CODE)).Select((i) => new FUNCTION_USER_GROUP_REL_DTO
            {
                FUNCTION_CODE = i.FUNCTION_CODE,
                FUNCTION_NAME = i.FUNCTION_NAME,
                DISPLAY_SEQ = seqI++
            }).ToList();


            if (DgvF1.Rows.Count != 0)
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
    }
}
