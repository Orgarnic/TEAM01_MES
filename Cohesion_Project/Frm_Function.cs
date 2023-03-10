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
    public partial class Frm_Function : Frm_Base_2
    {
        Srv_Function Srv_F = new Srv_Function();
        List<FUNCTION_MST_DTO> FList;
        FUNCTION_MST_DTO_Condition condition = new FUNCTION_MST_DTO_Condition();
        FUNCTION_MST_DTO FD = new FUNCTION_MST_DTO();
        bool isCondition = true;
        bool stateSearchCondition = false;
        User_DTO user = new User_DTO();
        public Frm_Function()
        {
            InitializeComponent();
        }

        private void Frm_Function_Load(object sender, EventArgs e)
        {
            user = (this.ParentForm as Frm_Main).userInfo;
            DgvInit();
            DataGridViewFill();
            PpgInit();
        }
        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvFunction);
            DgvUtil.AddTextCol(DgvFunction, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
            DgvUtil.AddTextCol(DgvFunction, "    화면 기능 코드", "FUNCTION_CODE", 200, true, align: 0);
            DgvUtil.AddTextCol(DgvFunction, "    화면 기능명", "FUNCTION_NAME", 150, true, align: 0);
     //       DgvUtil.AddTextCol(DgvFunction, "    단축키", "SHORT_CUT_KEY", 120, true, align: 0);
     //       DgvUtil.AddTextCol(DgvFunction, "    아이콘 인덱스 ", "ICON_INDEX", 140, true, align: 0);
            DgvUtil.AddTextCol(DgvFunction, "    생성 사용자 ", "CREATE_USER_ID", 120, true, align: 0);
            DgvUtil.AddTextCol(DgvFunction, "    생성 시간 ", "CREATE_TIME", 180, true, align: 1);
            DgvUtil.AddTextCol(DgvFunction, "    수정 사용자", "UPDATE_USER_ID", 120, true, align: 0);
            DgvUtil.AddTextCol(DgvFunction, "    수정 시간", "UPDATE_TIME", 180, true, align: 1);

            //프로퍼티 그리드 초기 설정
            PpgFunction.PropertySort = PropertySort.Categorized;
            PpgFunction.SelectedObject = FList;
        }
        private void PpgInit()
        {
            PpgFunction.PropertySort = PropertySort.Categorized;
            PpgFunction.SelectedObject = new FUNCTION_MST_DTO();
        }

        private void DataGridViewFill()
        {
            FList = Srv_F.SelectFunction();
            DgvFunction.DataSource = FList;

            int seq = 1;
            DgvFunction.DataSource = FList.Select((o) =>
            new
            {
                IDX = seq++,
                FUNCTION_CODE = o.FUNCTION_CODE,
                FUNCTION_NAME = o.FUNCTION_NAME,
                SHORT_CUT_KEY = o.SHORT_CUT_KEY,
                ICON_INDEX = o.ICON_INDEX,
                CREATE_USER_ID = o.CREATE_USER_ID,
                CREATE_TIME = o.CREATE_TIME,
                UPDATE_USER_ID = o.UPDATE_USER_ID,
                UPDATE_TIME = o.UPDATE_TIME,

            }).ToList();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgvFunction.SelectedRows.Count < 1)
                return;
            if (!MboxUtil.MboxInfo_($"{DgvFunction[1, DgvFunction.CurrentRow.Index].Value.ToString()} 화면기능을 삭제하시겠습니까 ?")) return;
            string functioCode = Convert.ToString(DgvFunction[1, DgvFunction.CurrentRow.Index].Value);

            bool result = Srv_F.DeleteFunctio(functioCode);
            if (!result)
            {
                MessageBox.Show("오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("화면기능이 삭제되었습니다.", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewFill();
            DgvFunction.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FUNCTION_MST_DTO data = PpgFunction.SelectedObject as FUNCTION_MST_DTO;

            var dto = PropertyToDto<FUNCTION_MST_DTO, FUNCTION_MST_DTO>(data); dto.CREATE_USER_ID = "김민식";

            if (dto.FUNCTION_CODE == null || dto.FUNCTION_NAME == null)
            {
                MboxUtil.MboxInfo("등록하실 기능 정보를 입력해주세요.");
                return;
            }
            dto.CREATE_TIME = DateTime.Now;
            bool result = Srv_F.InsertFunction(dto);

            if (result)
            {
                MessageBox.Show("화면 기능 입력 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("화면 기능 입력 입력 실패");
            }
        }
        private T1 PropertyToDto<T, T1>(T data) where T1 : class, new()
        {
            T1 dto = new T1();

            for (int i = 0; i < data.GetType().GetProperties().Length; i++)
            {
                for (int j = 0; j < dto.GetType().GetProperties().Length; j++)
                {
                    if (data.GetType().GetProperties()[i].Name.Equals(dto.GetType().GetProperties()[j].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        dto.GetType().GetProperties()[j].SetValue(dto, data.GetType().GetProperties()[i].GetValue(data));
                        break;
                    }
                }
            }
            return dto;
        }
        

        private void DgvFunction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = DgvFunction["FUNCTION_CODE", e.RowIndex].Value.ToString();
            var target = FList.Find((s) => s.FUNCTION_CODE.Equals(DgvFunction["FUNCTION_CODE", e.RowIndex].Value));
            SelectedRowData(target);
            PpgFunction.SelectedObject = FD;
            PpgFunction.Enabled = false;
            btnAdd.Enabled = false;
            //PpgFunction.SelectedObject  = DgvUtil.DgvToDto<FUNCTION_MST_DTO>(DgvFunction);
            //PpgFunction.Enabled = false;
            //btnAdd.Enabled = false;
        }
        private void SelectedRowData(FUNCTION_MST_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < FD.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == FD.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != FD.GetType().GetProperties()[j].PropertyType)
                        {
                            condition.GetType().GetProperties()[j].SetValue(FD, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), FD.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            FD.GetType().GetProperties()[j].SetValue(FD, target.GetType().GetProperties()[i].GetValue(target));
                            break;
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (isCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                PpgFunction.Enabled = true;
                PpgFunction.SelectedObject = condition;
                isCondition = false;
            }
            else
            {
                lbl3.Text = "▶ 속성";
                PpgFunction.SelectedObject = FD;
                condition = new FUNCTION_MST_DTO_Condition();
                isCondition = true;
                PpgFunction.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PpgFunction.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var data = PpgFunction.SelectedObject as FUNCTION_MST_DTO;
            if (data.FUNCTION_CODE == null)
            {
                MessageBox.Show("변경할 테이블을 선택해주세요.");
                return;
            }
            var dto = PropertyToDto<FUNCTION_MST_DTO, FUNCTION_MST_DTO>(data); dto.UPDATE_USER_ID = "김민식";
            dto.UPDATE_TIME = DateTime.Now;
            bool result = Srv_F.UpdateFunction(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }

            //   Ppg_UserGourp.Enabled = false; 추적창만 펄스헤야ㅐ되는대 안됨
            btnAdd.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                PpgFunction.SelectedObject = new FUNCTION_MST_DTO();
                PpgFunction.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                PpgFunction.SelectedObject = new FUNCTION_MST_DTO_Condition();
                PpgFunction.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FList = Srv_F.SelectFunction2(condition);
            DgvFunction.DataSource = FList;

            int seq = 1;
            DgvFunction.DataSource = FList.Select((o) =>
            new
            {
                IDX = seq++,
                FUNCTION_CODE = o.FUNCTION_CODE,
                FUNCTION_NAME = o.FUNCTION_NAME,
                SHORT_CUT_KEY = o.SHORT_CUT_KEY,
                ICON_INDEX = o.ICON_INDEX,
                CREATE_USER_ID = o.CREATE_USER_ID,
                CREATE_TIME = o.CREATE_TIME,
                UPDATE_USER_ID = o.UPDATE_USER_ID,
                UPDATE_TIME = o.UPDATE_TIME,

            }).ToList();
        }
    }
}
