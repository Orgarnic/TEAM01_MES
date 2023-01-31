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
            DataGridViewFill1();
            PpgInit();
        }

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
            DgvUtil.AddTextCol(DgvF1, "화면 기능 코드", "FUNCTION_NAME", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvF1, "화면 기능명", "FUNCTION_CODE", 120, true, align: 1);


            DgvUtil.DgvInit(DgvF2);
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

            FList = SrvFUG.SelectFUG1();
            DgvF2.DataSource = FList;
        }

        private void DataGridViewFill1()
        {


            FList = SrvFUG.SelectFUG1();
            DgvF1.DataSource = FList;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (DgvFUG.Rows.Count == 0)
            {
                return;
            }
            int seq = 1;
            int seqI = 1;
            int idx = DgvFUG.CurrentRow.Index;

            if (idx < 0)
            {
                MboxUtil.MboxError("검사 항목을 선택해주세요.");
                return;
            }
            if (DgvFUG.Rows.Count == 0)
            {
                MboxUtil.MboxError("검사 항목이 존재하지 않습니다.");
                return;
            }
            else
            {
                var dto = DgvFUG.Rows[idx].DataBoundItem as Inspection_REL_DTO;
                var addList = DgvFUG.DataSource as List<Inspection_REL_DTO>;
                addList.Remove(dto);
                DgvFUG.DataSource = null;
                DgvFUG.DataSource = addList.OrderBy((i) => i.INSPECT_ITEM_CODE).Select((i) => new Inspection_REL_DTO { INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE, INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME, DISPLAY_SEQ = seq++ }).ToList();

                List<Inspection_REL_DTO> list = DgvF1.DataSource as List<Inspection_REL_DTO>;
                if (list.Exists((i) => i.INSPECT_ITEM_CODE.Equals(dto.INSPECT_ITEM_CODE)))
                {
                    return;
                }
                else
                {
                    list.Add(dto);
                    DgvF1.DataSource = list.Select((i) => new Inspection_REL_DTO
                    {
                        INSPECT_ITEM_CODE = i.INSPECT_ITEM_CODE,
                        INSPECT_ITEM_NAME = i.INSPECT_ITEM_NAME,
                        DISPLAY_SEQ = seqI++
                    }).ToList();
                }
            }
        }
    }
}
