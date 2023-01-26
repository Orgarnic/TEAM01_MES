using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cohesion_DAO;
using Cohesion_DTO;
using Cohesion_Project.Service;

namespace Cohesion_Project
{
    public partial class Frm_Store : Cohesion_Project.Frm_Base_2
    {
        private Store_DTO iProperty = new Store_DTO();
        private Store_DTO_Search sProperty = new Store_DTO_Search();
        Srv_Store srvStore = new Srv_Store();
        bool stateSearchCondition = false;
        Util.ComboUtil comboUtil = new Util.ComboUtil();

        List<Store_DTO> srcList;

        public Frm_Store()
        {
            InitializeComponent();
        }

        private void Frm_Store_Load(object sender, EventArgs e)
        {
            FormCondition();
            DataGridViewBinding();
        }
        private void DataGridViewBinding()
        {
            DgvUtil.DgvInit(dgv_Store);
            DgvUtil.AddTextCol(dgv_Store, "창고코드", "STORE_CODE", 190, readOnly: true, align: 1, frozen:true);
            DgvUtil.AddTextCol(dgv_Store, "창고명", "STORE_NAME", 250, readOnly: true, align: 0, frozen: true);
            DgvUtil.AddTextCol(dgv_Store, "창고유형", "STORE_TYPE", 140, readOnly: true, align: 1, frozen: true);
            //DgvUtil.AddTextCol(dataGridView1, "선입선출 여부", "FIFO_FLAG", 180, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Store, "생성시간", "CREATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Store, "생성 사용자", "CREATE_USER_ID", 160, readOnly: true, align: 0);
            DgvUtil.AddTextCol(dgv_Store, "변경시간", "UPDATE_TIME", 250, readOnly: true, align: 1);
            DgvUtil.AddTextCol(dgv_Store, "변경 사용자", "UPDATE_USER_ID", 160, readOnly: true, align: 0);

            LoadData();
        }
        private void FormCondition()
        {
            lbl4.Text = "▶ 창고 목록";
            lbl3.Text = "▶ 창고 속성";

            ppg_Store.PropertySort = PropertySort.Categorized;
            ppg_Store.SelectedObject = iProperty;
        }
        private void LoadData()
        {
            srcList = srvStore.SelectStoreList();
            dgv_Store.DataSource = srcList;
        }
        private void dgv_Store_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            iProperty = dgv_Store.Rows[e.RowIndex].DataBoundItem as Store_DTO;
            ppg_Store.SelectedObject = iProperty;
            ppg_Store.Enabled = false;
            btnAdd.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Store_DTO dto = ppg_Store.SelectedObject as Store_DTO;
            if (dto.STORE_CODE == null || dto.STORE_TYPE == null || dto.STORE_NAME == null)
            {
                MboxUtil.MboxInfo("등록하실 창고 정보를 입력해주세요.");
                return;
            }

            var list = dgv_Store.DataSource as List<Store_DTO>;
            bool codeExist = list.Exists((i) => i.STORE_CODE.Equals(dto.STORE_CODE, StringComparison.OrdinalIgnoreCase));
            if (codeExist)
            {
                MboxUtil.MboxInfo("동일한 코드의 창고가 존재합니다.");
                return;
            }
            dto.CREATE_USER_ID = "정민영";
            dto.CREATE_TIME = DateTime.Now;
           
            bool result = srvStore.InsertStore(dto);
            if (result)
            {
                MboxUtil.MboxInfo("창고 등록이 완료되었습니다.");
                LoadData();
            }
            else
                MboxUtil.MboxError("창고 등록 중 오류가 발생했습니다.");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ppg_Store.Enabled = true;
            btnAdd.Enabled = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            var dto = ppg_Store.SelectedObject as Store_DTO;
            if (dto.STORE_CODE == null || dto.STORE_TYPE == null || dto.STORE_NAME == null)
            {
                MboxUtil.MboxWarn("변경할 창고를 선택해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_("선택하신 창고 정보를 수정하시겠습니까?"))
            {
                return;
            }
            dto.UPDATE_USER_ID = "정민영";

            bool result = srvStore.UpdateStore(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 창고 정보 수정이 완료되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("선택하신 창고 정보 수정 중 오류가 발생했습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                ppg_Store.SelectedObject = new Store_DTO();
                ppg_Store.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                ppg_Store.SelectedObject = new Store_DTO_Search();
                ppg_Store.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택하신 창고 정보를 삭제하시겠습니까?"))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<Store_DTO>(dgv_Store);
            bool result = srvStore.DeleteStore(dto);
            if (result)
            {
                MboxUtil.MboxInfo("선택하신 창고 정보를 삭제가 되었습니다.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("선택하신 창고 정보를 삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }
        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (!stateSearchCondition)
            {
                lbl3.Text = "▶ 검색 조건";
                ppg_Store.SelectedObject = sProperty;
                stateSearchCondition = true;
                btnAdd.Enabled = true;
            }
            else
            {
                lbl3.Text = "▶ 창고 등록 속성";
                ppg_Store.Enabled = true;
                ppg_Store.SelectedObject = iProperty;
                stateSearchCondition = false;
                btnAdd.Enabled = true;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Store_DTO_Search condition = ppg_Store.SelectedObject as Store_DTO_Search;
            string storeCode = condition.STORE_CODE;
            string valueType = condition.STORE_TYPE;
            string searchText = txtSearch.Text;

            //데이터 베이스 안가고 조회조건

            //if (!string.IsNullOrEmpty(storeCode) && valueType.ToString() != "\0")
            //{
            //    if (!string.IsNullOrEmpty(searchText))
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE == storeCode && c.STORE_TYPE == valueType && c.STORE_CODE.Contains(searchText));
            //    }
            //    else
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE == storeCode && c.STORE_TYPE == valueType);
            //    }
            //}

            //else if (!string.IsNullOrEmpty(storeCode) && valueType.ToString() == "\0")
            //{
            //    if (!string.IsNullOrEmpty(searchText))
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE == storeCode && c.STORE_CODE.Contains(searchText));
            //    }
            //    else
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE == storeCode);
            //    }
            //}

            //else if (string.IsNullOrEmpty(storeCode) && valueType.ToString() != "\0")
            //{
            //    if (!string.IsNullOrEmpty(searchText))
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE.Contains(searchText) && c.STORE_TYPE == valueType);
            //    }
            //    else
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_TYPE == valueType);
            //    }
            //}

            //else if (string.IsNullOrEmpty(storeCode) && valueType.ToString() == "\0")
            //{
            //    if (!string.IsNullOrEmpty(searchText))
            //    {
            //        dgv_Store.DataSource = srcList.FindAll((c) => c.STORE_CODE.Contains(searchText));
            //    }
            //    else
            //    {
            //        dgv_Store.DataSource = srcList;
            //    }
            //}
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ppg_Store_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
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
//    public partial class Frm_Store : Cohesion_Project.Frm_Base_2
//    {
//        private Store_DTO pg = new Store_DTO();
//        private List<Store_DTO> stores = new List<Store_DTO>();
//        private SearchConditionStore condtion = new SearchConditionStore();
//        private Store_DTO store = new Store_DTO();

//        Srv_Store srv = new Srv_Store();
//        List<Store_DTO> srvList;

//        bool srcCondition = true; 

//        public Frm_Store()
//        {
//            InitializeComponent();
//        }

//        private void Frm_Store_Load(object sender, EventArgs e)
//        {
//            FormCondition();
//            DataGridViewBinding();

//            // ppg_Store.Enabled = false;
//        }
//        private void DataGridViewBinding()
//        {
//            DgvUtil.DgvInit(dgv_Store);
//            DgvUtil.AddTextCol(dgv_Store, "창고코드", "STORE_CODE", 190, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Store, "창고명", "STORE_NAME", 250, readOnly: true, align: 0);
//            DgvUtil.AddTextCol(dgv_Store, "창고유형", "STORE_TYPE", 140, readOnly: true, align: 1);
//            //DgvUtil.AddTextCol(dataGridView1, "선입선출 여부", "FIFO_FLAG", 180, readOnly: true, align: 0);
//            DgvUtil.AddTextCol(dgv_Store, "생성시간", "CREATE_TIME", 250, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Store, "생성 사용자", "CREATE_USER_ID", 160, readOnly: true, align: 0);
//            DgvUtil.AddTextCol(dgv_Store, "변경시간", "UPDATE_TIME", 250, readOnly: true, align: 1);
//            DgvUtil.AddTextCol(dgv_Store, "변경 사용자", "UPDATE_USER_ID", 160, readOnly: true, align: 0);

//            LoadData();
//        }
//        private void FormCondition()
//        {
//            lbl4.Text = "▶ 창고 목록";
//            lbl3.Text = "▶ 창고 속성";

//            ppg_Store.PropertySort = PropertySort.NoSort;
//            ppg_Store.SelectedObject = pg;
//        }
//        private void LoadData()
//        {
//            srvList = srv.SelectStoreList();
//            dgv_Store.DataSource = srvList;
//        }
//        private void dgv_Store_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0)
//            {
//                return;
//            }
//            string sTableName = dgv_Store["창고코드", e.RowIndex].Value.ToString();
//            var target = srvList.Find((s) => s.STORE_CODE.Equals(dgv_Store["창고코드", e.RowIndex].Value));
//            SelectedRowData(target);
//            ppg_Store.SelectedObject = pg;
//        }
//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            stores = srv.SelectStore(condtion.SearchCondition());
//            dgv_Store.DataSource = stores;
//        }
//        private void btnSearchCondition_Click(object sender, EventArgs e)
//        {
//            if (srcCondition)
//            {
//                ppg_Store.Enabled = true;
//                ppg_Store.SelectedObject = condtion;
//                srcCondition = false;
//            }
//            else
//            {
//                ppg_Store.Enabled = false;
//                ppg_Store.SelectedObject = store;
//                srcCondition = true;

//            }
//        }
//        private void btnInsert_Click(object sender, EventArgs e)
//        {
//            var data = ppg_Store.SelectedObject as Store_DTO;
//            if (data.STORE_CODE == null)
//            {
//                MessageBox.Show("변경할 테이블을 선택해주세요.");
//                return;
//            }
//            var dto = ppg_Store.SelectedObject as Store_DTO;
//            if (!MboxUtil.MboxInfo_("선택하신 창고 정보를 수정하시겠습니까?")) return;
//            bool result = srv.UpdateStore(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("선택하신 창고 정보가 수정되었습니다.");
//                LoadData();
//                //ppg_Store.Enabled = false;
//            }
//            else
//            {
//                MboxUtil.MboxError("창고 정보 수정을 실패하였습니다.\n다시 시도하여 주십시오.");
//            }
//        }
//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            Store_DTO dto = ppg_Store.SelectedObject as Store_DTO;
//            //PropertyGridStore data = ppg_Store.SelectedObject as PropertyGridStore;

//            var list = dgv_Store.DataSource as List<Store_DTO>;
//            //var dto = PropertyToDto<PropertyGridStore, Store_DTO>(data);
//            bool result = srv.InsertStore(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("신규 창고가 생성 완료되었습니다.");
//                LoadData();
//            }
//            else
//            {
//                MboxUtil.MboxError("창고 생성을 실패하였습니다.\n다시 시도하여 주십시오.");
//            }
//        }
//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            //PropertyGridStore blankData = new PropertyGridStore();
//            //ppg_Store.SelectedObject = blankData;
//        }

//        private void btnUpdate_Click(object sender, EventArgs e)
//        {
//            //ppg_Store.Enabled = true;
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (!MboxUtil.MboxInfo_("선택하신 창고를 삭제하시겠습니까?")) return;
//            Store_DTO dto = DgvUtil.DgvToDto<Store_DTO>(dgv_Store);
//            bool result = srv.DeleteStore(dto);
//            if (result)
//            {
//                MboxUtil.MboxInfo("선택하신 창고가 삭제되었습니다.");
//                btnSearch.PerformClick();
//            }
//            else
//                MboxUtil.MboxError("창고 정보 삭제 중 실패하였습니다.\n다시 시도하여 주십시오.");
//        }
//        private void SelectedRowData(Store_DTO target)
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

//        private class SearchConditionStore
//        {
//            public Store_DTO SearchCondition()
//            {
//                Store_DTO dto = new Store_DTO
//                {
//                    STORE_CODE = this.STORE_CODE,
//                    STORE_NAME = this.STORE_NAME,
//                    STORE_TYPE = this.STORE_TYPE
//                };
//                return dto;
//            }
//            [Category("검색조건"), Description("창고코드 (= ST_xxxx) 입력"), DisplayName("창고코드")]
//            public string STORE_CODE { get; set; }
//            [Category("검색조건"), Description("창고명 입력"), DisplayName("창고명")]
//            public string STORE_NAME { get; set; }

//            [Category("검색조건"), Description("창고 타입 = 원자재창고 : RS, 반제품창고 : HS, 완제품창고 : FS"), DisplayName("창고유형")]
//            public string STORE_TYPE { get; set; }
//        }

//        private void btnClose_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }

//    //public class PropertyGridStore
//    //{
//    //    [Category("속성"), Description("창고코드 (= ST_xxxx) 입력"), DisplayName("창고코드")]
//    //    public string STORE_CODE { get; set; }


//    //    [Category("속성"), Description("창고명 입력"), DisplayName("창고명")]
//    //    public string STORE_NAME { get; set; }


//    //    [Category("속성"), Description("창고 타입 = 원자재창고 : RS, 반제품창고 : HS, 완제품창고 : FS"), DisplayName("창고유형")]
//    //    public string STORE_TYPE { get; set; }


//    //    //[Category("속성"), Description("FIFO_FLAG"), DisplayName("선입선출 여부")]
//    //    //public string FIFO_FLAG { get; set; }


//    //    [Category("속성"), Description("생성 시 현재 시간 자동입력"), ReadOnlyAttribute(true), DisplayName("생성시간")]
//    //    public DateTime CREATE_TIME { get; set; }


//    //    [Category("속성"), Description("생성 시 사용자 자동입력"), DisplayName("생성 사용자")]
//    //    public string CREATE_USER_ID { get; set; }


//    //    [Category("속성"), Description("변경 시 현재 시간 자동입력"), ReadOnlyAttribute(true), DisplayName("변경시간")]
//    //    public DateTime UPDATE_TIME { get; set; }


//    //    [Category("속성"), Description("변경 시 최근 사용자 자동 업데이트"), DisplayName("변경 사용자")]
//    //    public string UPDATE_USER_ID { get; set; }
//    //}



//    //public class JobStringConverter : StringConverter
//    //{
//    //    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
//    //    {
//    //        return true;
//    //    }

//    //    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
//    //    {
//    //        Customer refMyObject = context.Instance as Customer;
//    //        return new StandardValuesCollection(new JobSource().GetSourceList());
//    //    }
//    //}
//}

#endregion


