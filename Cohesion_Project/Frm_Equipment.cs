using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cohesion_DAO;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Equipment : Cohesion_Project.Frm_Base_2
    {
        private Equipment_DTO iProperty = new Equipment_DTO();
        private Equipment_DTO_Search sProperty = new Equipment_DTO_Search();
        Srv_Equipment srvEquipment = new Srv_Equipment();
        bool stateSearchCondition = false;
        Util.ComboUtil comboUtil = new Util.ComboUtil();
        User_DTO user = new User_DTO();

        List<Equipment_DTO> srcList;

        public Frm_Equipment()
        {
            InitializeComponent();
        }

        private void Frm_Equipment_Load(object sender, EventArgs e)
        {
            user = (this.ParentForm as Frm_Main).userInfo;
            FormCondition();
            DataGridViewBinding();
        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_Equipment);
            DgvUtil.AddTextCol(dgv_Equipment, "    No", "DISPLAY_SEQ", 80, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_Equipment, "    설비코드"      , "EQUIPMENT_CODE"   , 200, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_Equipment, "    설비명", "EQUIPMENT_NAME"   , 180, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_Equipment, "    설비유형", "EQUIPMENT_TYPE"   , 130, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_Equipment, "    설비상태", "EQUIPMENT_STATUS" , 130, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(dgv_Equipment, "    최근 다운시간", "LAST_DOWN_TIME"    , 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "    생성 시간", "CREATE_TIME"      , 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "    생성 사용자", "CREATE_USER_ID"   , 150, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Equipment, "    변경 시간", "UPDATE_TIME"      , 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Equipment, "    변경 사용자", "UPDATE_USER_ID"    , 150, readOnly: true, align: 0);

            LoadData();
        }
        private void FormCondition()
        {
            lbl4.Text = "▶ 설비 목록";
            lbl3.Text = "▶ 설비 속성";

            ppg_Equipment.PropertySort = PropertySort.Categorized;
            ppg_Equipment.SelectedObject = iProperty;
        }
        private void LoadData()
        {
            //srcList = srvEquipment.SelectEquipmentList();
            //dgv_Equipment.DataSource = srcList;

            var list = srvEquipment.SelectEquipmentList();
            int seq = 1;
            dgv_Equipment.DataSource = list.Select((i) => new
            {
                EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                EQUIPMENT_TYPE = i.EQUIPMENT_TYPE,
                EQUIPMENT_STATUS = i.EQUIPMENT_STATUS,
                LAST_DOWN_TIME = i.LAST_DOWN_TIME,
                CREATE_TIME = i.CREATE_TIME,
                CREATE_USER_ID = i.CREATE_USER_ID,
                UPDATE_TIME = i.UPDATE_TIME,
                UPDATE_USER_ID = i.UPDATE_USER_ID,
                DISPLAY_SEQ = seq++
            }).ToList();
        }
        
        private void dgv_Equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var list = dgv_Equipment.Rows[e.RowIndex].DataBoundItem;

            Equipment_DTO data = default;
            string upDate = list.GetType().GetProperty("UPDATE_TIME").GetValue(list).ToString();
            string lastDown = list.GetType().GetProperty("LAST_DOWN_TIME").GetValue(list).ToString();
            data = new Equipment_DTO
            {
                EQUIPMENT_CODE = list.GetType().GetProperty("EQUIPMENT_CODE").GetValue(list).ToString(),
                EQUIPMENT_NAME = list.GetType().GetProperty("EQUIPMENT_NAME").GetValue(list).ToString(),
                EQUIPMENT_TYPE = list.GetType().GetProperty("EQUIPMENT_TYPE").GetValue(list).ToString(),
                EQUIPMENT_STATUS = list.GetType().GetProperty("EQUIPMENT_STATUS").GetValue(list).ToString(),
                CREATE_TIME = Convert.ToDateTime(list.GetType().GetProperty("CREATE_TIME").GetValue(list).ToString()),
                CREATE_USER_ID = list.GetType().GetProperty("CREATE_USER_ID").GetValue(list).ToString(),
            };
            if (!string.IsNullOrEmpty(upDate))
            {
                data.UPDATE_TIME = Convert.ToDateTime(upDate);
                data.UPDATE_USER_ID = (list.GetType().GetProperty("UPDATE_USER_ID").GetValue(list) != null) ? list.GetType().GetProperty("UPDATE_USER_ID").GetValue(list).ToString() : null;
            }
            if (!string.IsNullOrEmpty(lastDown))
            {
                data.LAST_DOWN_TIME = Convert.ToDateTime(lastDown);
            }
            ppg_Equipment.SelectedObject = data;

            ppg_Equipment.Enabled = false;
            btnAdd.Enabled = false;


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Equipment_DTO dto = ppg_Equipment.SelectedObject as Equipment_DTO;
            if (dto.EQUIPMENT_CODE == null || dto.EQUIPMENT_NAME == null || dto.EQUIPMENT_STATUS == null || dto.EQUIPMENT_TYPE == null)
            {
                MboxUtil.MboxInfo("등록하실 설비 정보를 입력해주세요.");
                return;
            }

            //var list = dgv_Equipment.DataSource as List<Equipment_DTO>;
            //bool codeExist = list.Exists((i) => i.EQUIPMENT_CODE.Equals(dto.EQUIPMENT_CODE, StringComparison.OrdinalIgnoreCase));
            //if (codeExist)
            //{
            //    MboxUtil.MboxInfo("동일한 코드의 창고가 존재합니다.");
            //    return;
            //}
            dto.CREATE_USER_ID = ((Frm_Main)this.MdiParent).userInfo.USER_ID.ToString();
            dto.CREATE_TIME = DateTime.Now;



            bool result = srvEquipment.InsertEquipment(dto);
            if (result)
            {
                MboxUtil.MboxInfo("설비 등록이 완료되었습니다.");
                LoadData();
            }
            else
                MboxUtil.MboxError("설비 등록 중 오류가 발생했습니다.");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ppg_Equipment.Enabled = true;
            btnAdd.Enabled = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            var dto = ppg_Equipment.SelectedObject as Equipment_DTO;
            if (dto.EQUIPMENT_CODE == null || dto.EQUIPMENT_NAME == null || dto.EQUIPMENT_STATUS == null || dto.EQUIPMENT_TYPE == null)
            {
                MboxUtil.MboxWarn("변경할 설비를 선택해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_("선택하신 설비 정보를 수정하시겠습니까 ? "))
            {
                return;
            }
            dto.UPDATE_USER_ID = ((Frm_Main)this.MdiParent).userInfo.USER_ID.ToString();

            bool result = srvEquipment.UpdateEquipment(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 설비 정보 수정이 완료되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxInfo("선택하신 설비 정보 수정 중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                ppg_Equipment.SelectedObject = new Equipment_DTO();
                ppg_Equipment.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                ppg_Equipment.SelectedObject = new Equipment_DTO_Search();
                ppg_Equipment.Enabled = true;
                btnAdd.Enabled = true;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택하신 설비 정보를 삭제하시겠습니까?"))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<Equipment_DTO>(dgv_Equipment);
            bool result = srvEquipment.DeleteEquipment(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 설비 정보를 삭제가 되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("선택하신 설비 정보를 삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                ppg_Equipment.SelectedObject = sProperty;
                stateSearchCondition = true;
                btnAdd.Enabled = true;
            }
            else
            {
                lbl3.Text = "▶ 설비 등록 속성";
                ppg_Equipment.Enabled = true;
                ppg_Equipment.SelectedObject = iProperty;
                stateSearchCondition = false;
                btnAdd.Enabled = true;
            }
            btnRefresh.PerformClick();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ppg_Equipment.Enabled)
            {
                MboxUtil.MboxError("검색조건을 활성화 시켜주십시오.");
                return;
            }
            else
            {
                var t = ppg_Equipment.SelectedObject as Equipment_DTO_Search;
                if (t == null)
                {
                    MboxUtil.MboxError("검색조건을 입력해십시오.");
                    return;
                }
                else
                {
                    Equipment_DTO_Search_Data dto = new Equipment_DTO_Search_Data
                    {
                        EQUIPMENT_CODE = t.EQUIPMENT_CODE,
                        EQUIPMENT_NAME = t.EQUIPMENT_NAME,
                        EQUIPMENT_TYPE = t.EQUIPMENT_TYPE,
                        EQUIPMENT_STATUS = t.EQUIPMENT_STATUS
                    };
                    int seq = 1;
                    var list = srvEquipment.SelectEquipmentSearchList(dto);
                    dgv_Equipment.DataSource = list.Select((i) => new
                    {
                        EQUIPMENT_CODE = i.EQUIPMENT_CODE,
                        EQUIPMENT_NAME = i.EQUIPMENT_NAME,
                        EQUIPMENT_TYPE = i.EQUIPMENT_TYPE,
                        EQUIPMENT_STATUS = i.EQUIPMENT_STATUS,
                        LAST_DOWN_TIME = i.LAST_DOWN_TIME,
                        CREATE_TIME = i.CREATE_TIME,
                        CREATE_USER_ID = i.CREATE_USER_ID,
                        UPDATE_TIME = i.UPDATE_TIME,
                        UPDATE_USER_ID = i.UPDATE_USER_ID,
                        DISPLAY_SEQ = seq++
                    }).ToList();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}





#region 기존코드
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//using Cohesion_DAO;
//using Cohesion_DTO;
//using Cohesion_Project.Service;

//namespace Cohesion_Project
//{
//    public partial class Frm_Equipment : Cohesion_Project.Frm_Base_2
//    {
//        Srv_Equipment srv = new Srv_Equipment();
//        List<Equipment_DTO> srvList;

//        private PropertyGridEquipment pg = new PropertyGridEquipment();
//        private SearchConditionEquipment condtion = new SearchConditionEquipment();
//        private List<Equipment_DTO> equipments = new List<Equipment_DTO>();
//        private Equipment_DTO equipment = new Equipment_DTO();

//        bool srcCondition = true;

//        public Frm_Equipment()
//        {
//            InitializeComponent();
//        }

//        private void Frm_Equipment_Load(object sender, EventArgs e)
//        {
//            FormCondition();
//            DataGridViewBinding();
//        }
//        private void DataGridViewBinding()
//        {
//            DgvUtil.DgvInit(dgv_Equipment);
//            DgvUtil.AddTextCol(dgv_Equipment, "설비코드", "EQUIPMENT_CODE", 200, readOnly: true, align: 0);
//            DgvUtil.AddTextCol(dgv_Equipment, "설비명", "EQUIPMENT_NAME", 150, readOnly: true, align: 0);
//            DgvUtil.AddTextCol(dgv_Equipment, "설비유형", "EQUIPMENT_TYPE", 150, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "설비상태", "EQUIPMENT_STATUS", 150, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "최근 다운시간", "LAST_DOWN_TIME", 250, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "생성 시간", "CREATE_TIME", 250, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "생성 사용자", "CREATE_USER_ID", 150, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "변경 시간", "UPDATE_TIME", 250, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Equipment, "변경 사용자", "UPDATE_USER_ID", 150, readOnly: true, align: 1);

//            LoadData();
//        }
//        private void LoadData()
//        {
//            srvList = srv.SelectEquipmentList();
//            dgv_Equipment.DataSource = srvList;
//        }
//        private void FormCondition()
//        {
//            lbl4.Text = "▶ 설비 목록";
//            lbl3.Text = "▶ 설비 속성";

//            ppg_Equipment.PropertySort = PropertySort.NoSort;
//            ppg_Equipment.SelectedObject = pg;
//        }
//        private void dgv_Equipment_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0)
//            {
//                return;
//            }
//            string sTableName = dgv_Equipment["설비코드", e.RowIndex].Value.ToString();
//            var target = srvList.Find((s) => s.EQUIPMENT_CODE.Equals(dgv_Equipment["설비코드", e.RowIndex].Value));
//            SelectedRowData(target);
//            ppg_Equipment.SelectedObject = pg;
//        }
//        private void SelectedRowData(Equipment_DTO target)
//        {
//            TypeConverter typeConverter = new TypeConverter();

//            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
//            {
//                string propertyName = target.GetType().GetProperties()[i].Name;
//                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
//                for (int j = 0; j < pg.GetType().GetProperties().Length; j++)
//                {
//                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
//                        continue;

//                    else if (propertyName == pg.GetType().GetProperties()[j].Name)
//                    {
//                        if (propertyType != pg.GetType().GetProperties()[j].PropertyType)
//                        {
//                            pg.GetType().GetProperties()[j].SetValue(pg, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), pg.GetType().GetProperties()[j].PropertyType));
//                            break;
//                        }

//                        else
//                        {
//                            pg.GetType().GetProperties()[j].SetValue(pg, target.GetType().GetProperties()[i].GetValue(target));
//                            break;
//                        }
//                    }
//                }
//            }
//        }
//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            equipments = srv.SelectEquipment(condtion.SearchCondition());
//            dgv_Equipment.DataSource = equipments;
//        }

//        //PropertyGrid 속성값 DTO 만들기
//        private T1 PropertyToDto<T, T1>(T data) where T1 : class, new()
//        {
//            T1 dto = new T1();

//            for (int i = 0; i < data.GetType().GetProperties().Length; i++)
//            {
//                for (int j = 0; j < dto.GetType().GetProperties().Length; j++)
//                {
//                    if (data.GetType().GetProperties()[i].Name.Equals(dto.GetType().GetProperties()[i].Name, StringComparison.OrdinalIgnoreCase))
//                    {
//                        dto.GetType().GetProperties()[i].SetValue(dto, data.GetType().GetProperties()[i].GetValue(data));
//                        break;
//                    }
//                }
//            }
//            return dto;
//        }

//        private class SearchConditionEquipment
//        {
//            public Equipment_DTO SearchCondition()
//            {
//                Equipment_DTO dto = new Equipment_DTO
//                {
//                    EQUIPMENT_CODE = this.EQUIPMENT_CODE,
//                    EQUIPMENT_NAME = this.EQUIPMENT_NAME,
//                    EQUIPMENT_TYPE = this.EQUIPMENT_TYPE,
//                    EQUIPMENT_STATUS = this.EQUIPMENT_STATUS
//                };
//                return dto;
//            }
//            [Category("검색조건"), Description("설비코드 (FC_xxxx) 입력"), DisplayName("설비코드")]
//            public string EQUIPMENT_CODE { get; set; }

//            [Category("검색조건"), Description("설비명 입력"), DisplayName("설비명")]
//            public string EQUIPMENT_NAME { get; set; }
//            [Category("검색조건"), Description("설비 유형 = 장비 : EQUIP, 도구 : TOOL, 측정기 : INSP"), DisplayName("설비유형")]
//            public string EQUIPMENT_TYPE { get; set; }

//            [Category("검색조건"), Description("설비 상태 = 가동 : PROC, 고장비가동 : DOWN, 일반비가동 : WAIT"), DisplayName("설비상태")]
//            public string EQUIPMENT_STATUS { get; set; }
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            PropertyGridEquipment data = ppg_Equipment.SelectedObject as PropertyGridEquipment;
//            var dto = PropertyToDto<PropertyGridEquipment, Equipment_DTO>(data);
//            bool result = srv.InsertStore(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("신규 설비가 생성 완료되었습니다.");
//                LoadData();
//            }
//            else
//            {
//                MboxUtil.MboxError("설비 생성을 실패하였습니다.\n다시 시도하여 주십시오.");
//            }
//        }

//        private void btnUpdate_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnInsert_Click(object sender, EventArgs e)
//        {
//            var data =ppg_Equipment.SelectedObject as PropertyGridEquipment;
//            if (data.EQUIPMENT_CODE == null)
//            {
//                MessageBox.Show("변경할 테이블을 선택해주세요.");
//                return;
//            }
//            var dto = PropertyToDto<PropertyGridEquipment, Equipment_DTO>(data);
//            if (!MboxUtil.MboxInfo_("선택하신 설비 정보를 수정하시겠습니까?")) return;
//            bool result = srv.UpdateEquipment(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("선택하신 설비 정보가 수정되었습니다.");
//                LoadData();
//            }
//            else
//            {
//                MboxUtil.MboxError("설비 정보 수정을 실패하였습니다.\n다시 시도하여 주십시오.");
//            }
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (!MboxUtil.MboxInfo_("선택하신 설비를 삭제하시겠습니까?")) return;
//            Equipment_DTO dto = DgvUtil.DgvToDto<Equipment_DTO>(dgv_Equipment);
//            bool result = srv.DeleteEquipment(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("선택하신 설비가 삭제되었습니다.");
//                btnSearch.PerformClick();
//            }
//            else
//                MboxUtil.MboxError("설비 정보 삭제 중 실패하였습니다.\n다시 시도하여 주십시오.");
//        }

//        private void btnSearchCondition_Click(object sender, EventArgs e)
//        {
//            if (srcCondition)
//            {
//                ppg_Equipment.Enabled = true;
//                ppg_Equipment.SelectedObject = condtion;
//                srcCondition = false;
//            }
//            else
//            {
//                ppg_Equipment.Enabled = false;
//                ppg_Equipment.SelectedObject = equipment;
//                srcCondition = true;
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            PropertyGridEquipment blankData = new PropertyGridEquipment();
//            ppg_Equipment.SelectedObject = blankData;
//        }

//        private void btnClose_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//    public class PropertyGridEquipment
//    {
//        [Category("속성"), Description("설비코드 (FC_xxxx) 입력"), DisplayName("설비코드")]
//        public string EQUIPMENT_CODE { get; set; }


//        [Category("속성"), Description("설비명 입력"), DisplayName("설비명")]
//        public string EQUIPMENT_NAME { get; set; }


//        [Category("속성"), Description("설비 유형 = 장비 : EQUIP, 도구 : TOOL, 측정기 : INSP"), DisplayName("설비유형")]
//        public string EQUIPMENT_TYPE { get; set; }

//        [Category("속성"), Description("설비 상태 = 가동 : PROC, 고장비가동 : DOWN, 일반비가동 : WAIT"), DisplayName("설비상태")]
//        public string EQUIPMENT_STATUS { get; set; }


//        [Category("속성"), Description("설비 상태 변경/확정 시 현재 시간 자동입력"), ReadOnlyAttribute(true), DisplayName("다운시간")]
//        public DateTime LAST_DOWN_TIME { get; set; }


//        [Category("속성"), Description("생성 시간 현재 시간 자동입력"), ReadOnlyAttribute(true), DisplayName("생성 시간")]
//        public DateTime CREATE_TIME { get; set; }


//        [Category("속성"), Description("생성 시 사용자 자동입력"), DisplayName("생성 사용자")]
//        public string CREATE_USER_ID { get; set; }


//        [Category("속성"), Description("변경 시 현재 시간 자동입력"), ReadOnlyAttribute(true), DisplayName("변경 시간")]
//        public DateTime UPDATE_TIME { get; set; }


//        [Category("속성"), Description("변경 시 사용자 자동입력"), DisplayName("변경 사용자")]
//        public string UPDATE_USER_ID { get; set; }
//    }
//}
#endregion