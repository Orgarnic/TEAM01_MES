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
    public partial class Frm_UserGroupMgt : Frm_Base_2
    {
        Srv_UserGroup srv_UG = new Srv_UserGroup();
        Srv_UserGroup Srv_UserGroup;
        List<UserGroup_DTO> UGroupList;
        private UserGroup_DTO Udto = new UserGroup_DTO();
        private UserGoupCondition_DTO condition = new UserGoupCondition_DTO();
       // private SearchCondition condtion = new SearchCondition();
        private UGdate ugd = new UGdate();
        private SearchData sd = new SearchData();
        bool isCondition = true;
        bool stateSearchCondition = true;
        User_DTO user = new User_DTO();

        public Frm_UserGroupMgt()
        {
            InitializeComponent();
        }
        bool state = false;
        private void Frm_UserGroup_Load(object sender, EventArgs e)
        {
            user = (this.ParentForm as Frm_Main).userInfo;
            Srv_UserGroup = new Srv_UserGroup();
            DgvInit();
            DataGridViewFill();

        }
        private void DgvInit()
        {
            DgvUtil.DgvInit(DgvUserGroup);
            DgvUtil.AddTextCol(DgvUserGroup, "   NO", "IDX", width: 70, readOnly: true, frozen: true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 코드", "USER_GROUP_CODE", 170, true, align: 0);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 명", "USER_GROUP_NAME", 150, true, align: 0);
            DgvUtil.AddTextCol(DgvUserGroup, "사용자 그룹 유형", "USER_GROUP_TYPE", 165, true, align: 0);
            DgvUtil.AddTextCol(DgvUserGroup, "생선 시간 ", "CREATE_TIME", 250, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "생성 사용자 ", "CREATE_USER_ID", 150, true, align: 0);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 시간 ", "UPDATE_TIME", 250, true, align: 1);
            DgvUtil.AddTextCol(DgvUserGroup, "수정 사용자", "UPDATE_USER_ID", 150, true, align: 0);

            //프로퍼티 그리드 초기 설정
            Ppg_UserGourp.PropertySort = PropertySort.Categorized;
            Ppg_UserGourp.SelectedObject = ugd;
        }


        private void DataGridViewFill()
        {
            UGroupList = Srv_UserGroup.SelectUserGroup();
            DgvUserGroup.DataSource = UGroupList;
            int seq = 1;
            DgvUserGroup.DataSource = UGroupList.Select((o) =>
            new
            {
                IDX = seq++,
                USER_GROUP_CODE = o.USER_GROUP_CODE,
                USER_GROUP_NAME = o.USER_GROUP_NAME,
                USER_GROUP_TYPE = o.USER_GROUP_TYPE,
                CREATE_TIME = o.CREATE_TIME,
                CREATE_USER_ID = o.CREATE_USER_ID,
                UPDATE_TIME = o.UPDATE_TIME,
                UPDATE_USER_ID = o.UPDATE_USER_ID,

            }).ToList();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (DgvUserGroup.SelectedRows.Count < 1)
                return;
            if (MessageBox.Show($"{DgvUserGroup[1, DgvUserGroup.CurrentRow.Index].Value.ToString()} 사용자구룹을 삭제하시겠습니까 ?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string userGroupCode = Convert.ToString(DgvUserGroup[1, DgvUserGroup.CurrentRow.Index].Value);
            bool result = Srv_UserGroup.DeleteUserGroup(userGroupCode);
            if (!result)
            {
                MessageBox.Show("오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("권한 저장정보가 삭제되었습니다.", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewFill();
            DgvUserGroup.ClearSelection();

        }

        public class UGdate
        {
            [Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드")]
            public string USER_GROUP_CODE { get; set; }

            [Category("속성"), Description("USER_GROUP_NAME"), DisplayName("사용자 그룹 명")]
            public string USER_GROUP_NAME { get; set; }

            [Category("속성"), Description("USER_GROUP_TYPE"), DisplayName("사용자 그룹 유형")]
            public string USER_GROUP_TYPE { get; set; }

            [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
            public DateTime CREATE_TIME { get; set; }

            [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성자"), ReadOnly(true)]
            public string CREATE_USER_ID { get; set; }

            [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
            public DateTime UPDATE_TIME { get; set; }

            [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경자"), ReadOnly(true)]
            public string UPDATE_USER_ID { get; set; }
        }

        //테이블 정보 그리드뷰에 보여주기

        private void DgvUserGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = DgvUserGroup["USER_GROUP_CODE", e.RowIndex].Value.ToString();
            var target = UGroupList.Find((s) => s.USER_GROUP_CODE.Equals(DgvUserGroup["USER_GROUP_CODE", e.RowIndex].Value));
            SelectedRowData(target);
            Ppg_UserGourp.SelectedObject = ugd;
            Ppg_UserGourp.Enabled = false;
            btnAdd.Enabled = false;

        }

        private void SelectedRowData(UserGroup_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < ugd.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == ugd.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != ugd.GetType().GetProperties()[j].PropertyType)
                        {
                            ugd.GetType().GetProperties()[j].SetValue(ugd, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), ugd.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            ugd.GetType().GetProperties()[j].SetValue(ugd, target.GetType().GetProperties()[i].GetValue(target));
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
            UGdate data = Ppg_UserGourp.SelectedObject as UGdate;

            var dto = PropertyToDto<UGdate, UserGroup_DTO>(data); dto.CREATE_USER_ID = "김민식";
            if (dto.USER_GROUP_CODE == null || dto.USER_GROUP_NAME == null || dto.USER_GROUP_TYPE == null)
            {
                MboxUtil.MboxInfo("등록하실 정보를 입력해주세요.");
                return;


            }
            dto.CREATE_TIME = DateTime.Now;
            bool result = srv_UG.InsertUserGroup(dto);


            if (result)
            {
                MessageBox.Show("정보 등록이 완료되었습니다");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("등록 중 오류가 발생했습니다");
            }

        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (isCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                Ppg_UserGourp.Enabled = true;
                Ppg_UserGourp.SelectedObject = condition;
                isCondition = false;
            }
            else
            {
                lbl3.Text = "▶ 속성";
                Ppg_UserGourp.SelectedObject = ugd;
                condition = new UserGoupCondition_DTO();
                isCondition = true;
                Ppg_UserGourp.Enabled = false;
            }
        }

        public class SearchData
        {

            [Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드"), TypeConverter(typeof(ComboStringConverter))]
            public string USER_GROUP_CODE { get; set; }

            [Category("속성"), Description("USER_GROUP_NAME"), DisplayName("사용자 그룹 명"), TypeConverter(typeof(ComboStringConverter))]
            public string USER_GROUP_NAME { get; set; }

            [Category("속성"), Description("USER_GROUP_TYPE"), DisplayName("사용자 그룹 유형"), TypeConverter(typeof(ComboStringConverter))]
            public string USER_GROUP_TYPE { get; set; }


            [Browsable(false)]
            public Dictionary<string, List<string>> SearchList { get; set; }

            public Dictionary<string, List<string>> GetList()
            {
                return SearchList;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (stateSearchCondition)
            {
                UserGroup_DTO blankData = new UserGroup_DTO();
                Ppg_UserGourp.SelectedObject = blankData;
            }
            else  
            {
                UserGoupCondition_DTO blankData = new UserGoupCondition_DTO();
                Ppg_UserGourp.SelectedObject = blankData;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var data = Ppg_UserGourp.SelectedObject as UGdate;
            if (data.USER_GROUP_CODE == null)
            {
                MessageBox.Show("변경할 테이블을 선택해주세요.");
                return;
            }
            var dto = PropertyToDto<UGdate, UserGroup_DTO>(data); dto.UPDATE_USER_ID = "김민식";
            dto.UPDATE_TIME = DateTime.Now;
            bool result = srv_UG.UpdateUserGroup(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                DataGridViewFill();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }
            btnAdd.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ppg_UserGourp.Enabled = true;
            btnAdd.Enabled = false;

        }
        public class ComboProductConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(ComboUtil.ProductCode);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public class ComboStringConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                SearchData refMyObject = context.Instance as SearchData;
                return new StandardValuesCollection(refMyObject.SearchList[context.PropertyDescriptor.Description]);
            }
        }
        public static T DgvToDto<T>(DataGridView dgv)
        {
          
                return (T)dgv.Rows[dgv.CurrentRow.Index].DataBoundItem;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Ppg_UserGourp.SelectedObject is UserGoupCondition_DTO)
            {

                UGroupList = Srv_UserGroup.SelectUserGroup2(condition);
                DgvUserGroup.DataSource = UGroupList;
            }
            else 
            {
                MboxUtil.MboxError("검색조건을 먼저 눌러주세요");
            }

            int seq = 1;
            DgvUserGroup.DataSource = UGroupList.Select((o) =>
            new
            {
                IDX = seq++,
                USER_GROUP_CODE = o.USER_GROUP_CODE,
                USER_GROUP_NAME = o.USER_GROUP_NAME,
                USER_GROUP_TYPE = o.USER_GROUP_TYPE,
                CREATE_TIME = o.CREATE_TIME,
                CREATE_USER_ID = o.CREATE_USER_ID,
                UPDATE_TIME = o.UPDATE_TIME,
                UPDATE_USER_ID = o.UPDATE_USER_ID,

            }).ToList();
        }
    }

}

