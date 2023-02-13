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
using Cohesion_Project.Util;

namespace Cohesion_Project
{
    public partial class Frm_UserMgt : Frm_Base_2
    {

        Srv_User srv_U = new Srv_User();
        Srv_User Srv_User;
        List<User_DTO> UserList;
        private User_Condition_DTO condition = new User_Condition_DTO();
        //   private SearchCondition condtion = new SearchCondition();
        private Udate ud = new Udate();
        bool isCondition = true;
        bool stateSearchCondition = true;

        public Frm_UserMgt()
        {
            InitializeComponent();
        }
        private void Frm_UserMgt_Load(object sender, EventArgs e)
        {
            Srv_User = new Srv_User();
            DgvInit();
            DataGridViewFill();
        }

        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUser);
            DgvUtil.AddTextCol(DgvUser, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
           // DgvUtil.AddTextCol(DgvUser, "번호 ", "", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "로그인 사용자 ID", "USER_ID", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 이름", "USER_NAME", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "사용자 그룹", "USER_GROUP_CODE", 120, true, align: 0);
            DgvUtil.AddTextCol(DgvUser, "암호 ", "USER_PASSWORD", 120, true, align: 0);
            DgvUtil.AddTextCol(DgvUser, "부서 ", "USER_DEPARTMENT", 120, true, align: 0);
            DgvUtil.AddTextCol(DgvUser, "생성 시간 ", "CREATE_TIME", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "생성 사용자", "CREATE_USER_ID", 120, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "수정 시간", "UPDATE_TIME", 150, true, align: 1);
            DgvUtil.AddTextCol(DgvUser, "변경 사용자 ", "UPDATE_USER_ID", 120, true, align: 1);

            //프로퍼티 그리드 초기 설정
            Ppg_User.PropertySort = PropertySort.Categorized;
            Ppg_User.SelectedObject = ud;

        }

        private void DataGridViewFill()
        {
            UserList = Srv_User.SelectUser();
            DgvUser.DataSource = UserList;
            int seq = 1;
            DgvUser.DataSource = UserList.Select((o) =>
            new
            {
                IDX = seq++,
                USER_ID = o.USER_ID,
                USER_NAME = o.USER_NAME,
                USER_GROUP_CODE = o.USER_GROUP_CODE,
                USER_PASSWORD = o.USER_PASSWORD,
                USER_DEPARTMENT = o.USER_DEPARTMENT,
                CREATE_TIME = o.CREATE_TIME,
                CREATE_USER_ID = o.CREATE_USER_ID,
                UPDATE_TIME = o.UPDATE_TIME,
                UPDATE_USER_ID = o.UPDATE_USER_ID
            }).ToList();
        }

        public class Udate
        {
            [Category("속성"), Description("USER_ID"), DisplayName("로그인 사용자 ID")]
            public string USER_ID { get; set; }

            [Category("속성"), Description("USER_NAME"), DisplayName("사용자 명")]
            public string USER_NAME { get; set; }

            [Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드"), TypeConverter(typeof(ComboString2Converter))]
            public string USER_GROUP_CODE { get; set; }

            [Category("속성"), Description("USER_PASSWORD"), DisplayName("사용자 암호")]
            public string USER_PASSWORD { get; set; }

            [Category("속성"), Description("USER_DEPARTMENT"), DisplayName("사용자 부서")]
            public string USER_DEPARTMENT { get; set; }

            [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
            public DateTime CREATE_TIME { get; set; }

            [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
            public string CREATE_USER_ID { get; set; }
            [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
            public DateTime UPDATE_TIME { get; set; }
            [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
            public string UPDATE_USER_ID { get; set; }
        }
        //테이블 정보 그리드뷰에 보여주기
        private void DgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = DgvUser["USER_ID", e.RowIndex].Value.ToString();
            var target = UserList.Find((s) => s.USER_ID.Equals(DgvUser["USER_ID", e.RowIndex].Value));
            SelectedRowData(target);
            Ppg_User.SelectedObject = ud;
            Ppg_User.Enabled = false;
  
            btnAdd.Enabled = false;
        }
        private void SelectedRowData(User_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < ud.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == ud.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != ud.GetType().GetProperties()[j].PropertyType)
                        {
                            ud.GetType().GetProperties()[j].SetValue(ud, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), ud.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            ud.GetType().GetProperties()[j].SetValue(ud, target.GetType().GetProperties()[i].GetValue(target));
                            break;
                        }
                    }
                }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Udate data = Ppg_User.SelectedObject as Udate;
            var dto = PropertyToDto<Udate, User_DTO>(data);
            if (dto.USER_ID == null || dto.USER_NAME == null || dto.USER_PASSWORD == null)
            {
                MboxUtil.MboxInfo("등록하실 사원 정보를 입력해주세요.");
                return;
            }
           

            dto.CREATE_USER_ID = "김민식";
            dto.CREATE_TIME = DateTime.Now;
            bool result = srv_U.InsertUser(dto);
            //User_DTO Udto = Ppg_User.SelectedObject as User_DTO;


            //var list = DgvUser.DataSource as List<User_DTO>;
            //bool codeExist = list.Exists((i) => i.USER_ID.Equals(dto.USER_ID, StringComparison.OrdinalIgnoreCase));
            //if (codeExist)
            //{
            //    MboxUtil.MboxInfo("동일한 사원번호가 존재합니다.");
            //    return;
            //}

            if (result)
            {
                MessageBox.Show("사원 정보 등록이 완료되었습니다");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("사원 정보 등록 중 오류가 발생했습니다");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ppg_User.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var data = Ppg_User.SelectedObject as Udate;

            if (data.USER_ID == null)
            {
                MessageBox.Show("변경할 유저ID을 선택해주세요.");
                return;
            }
            var dto = PropertyToDto<Udate, User_DTO>(data);
            dto.UPDATE_TIME = DateTime.Now;
            dto.UPDATE_USER_ID = "321";
            bool result = srv_U.UpdateUser(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }

            //   Ppg_UserGourp.Enabled = false; 추적창만 펄스해야 됨 안됨
            btnAdd.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            if (stateSearchCondition)
            {
                Ppg_User.SelectedObject = new Udate();
                Ppg_User.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                Ppg_User.SelectedObject = new User_Condition_DTO();
                Ppg_User.Enabled = true;
                btnAdd.Enabled = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgvUser.SelectedRows.Count < 1)
                return;
            if (MessageBox.Show($"{DgvUser[1, DgvUser.CurrentRow.Index].Value.ToString()} 사용자그룹을 삭제하시겠습니까 ?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string userCode = Convert.ToString(DgvUser[1, DgvUser.CurrentRow.Index].Value);
            bool result = Srv_User.DeleteUser(userCode);
            if (!result)
            {
                MessageBox.Show("오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("권한 저장정보가 삭제되었습니다.", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewFill();
            DgvUser.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Ppg_User.SelectedObject is User_Condition_DTO)
            {

                UserList = Srv_User.SelectUser2(condition);
                DgvUser.DataSource = UserList;
                int seq = 1;
                DgvUser.DataSource = UserList.Select((o) =>
                new
                {
                    IDX = seq++,
                    USER_ID = o.USER_ID,
                    USER_NAME = o.USER_NAME,
                    USER_GROUP_CODE = o.USER_GROUP_CODE,
                    USER_PASSWORD = o.USER_PASSWORD,
                    USER_DEPARTMENT = o.USER_DEPARTMENT,
                    CREATE_TIME = o.CREATE_TIME,
                    CREATE_USER_ID = o.CREATE_USER_ID,
                    UPDATE_TIME = o.UPDATE_TIME,
                    UPDATE_USER_ID = o.UPDATE_USER_ID
                }).ToList();
            }
            else
            {
                MboxUtil.MboxError("검색조건을 먼저 눌러주세요");
            }

        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (isCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                Ppg_User.Enabled = true;
                Ppg_User.SelectedObject = condition;
                isCondition = false;
            }
            else
            {
                lbl3.Text = "▶ 속성";
                Ppg_User.SelectedObject = ud;
                condition = new User_Condition_DTO();
                isCondition = true;
                Ppg_User.Enabled = false;
            }
        }
    }
}
