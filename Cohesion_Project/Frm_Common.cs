using Cohesion_DTO;
using Cohesion_Project.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Cohesion_Project
{
    public partial class Frm_Common : Cohesion_Project.Frm_Base_2
    {
        Srv_CommonData srvC = new Srv_CommonData();
        private CommonData cd = new CommonData();
        private SearchData sd = new SearchData();

        public CommonTable_DTO Table { get; set; }

        List<CommonTable_DTO> srcList;
        bool state = false;


        public Frm_Common()
        {
            InitializeComponent();
        }

        private void Frm_Common_Load(object sender, EventArgs e)
        {
            //데이터 그리드 뷰 초기 설정
            DgvUtil.DgvInit(Dgv_CommonTable);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      테이블명", "CODE_TABLE_NAME", 180, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      테이블 설명", "CODE_TABLE_DESC", 150, readOnly: true, align: 1, frozen: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      키1 이름", "KEY_1_NAME", 110, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      키2 이름", "KEY_2_NAME", 110, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      키3 이름", "KEY_3_NAME", 110, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      데이터1 이름", "DATA_1_NAME", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      데이터2 이름", "DATA_2_NAME", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      데이터3 이름", "DATA_3_NAME", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      데이터4 이름", "DATA_4_NAME", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "      데이터5 이름", "DATA_5_NAME", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "    생성 시간", "CREATE_TIME", 150, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "    생성자", "CREATE_USER_ID", 130, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "    변경 시간", "UPDATE_TIME", 150, readOnly: true);
            DgvUtil.AddTextCol(Dgv_CommonTable, "    변경자", "UPDATE_USER_ID", 130, readOnly: true);


            //프로퍼티 그리드 초기 설정
            Ppg_CommonTable.PropertySort = PropertySort.Categorized;
            Ppg_CommonTable.SelectedObject = cd;

            LoadData();
            Dgv_CommonTable.CellClick += Dgv_CommonTable_CellClick;
            Dgv_CommonTable.CellDoubleClick += Dgv_CommonTable_CellDoubleClick;
        }

        //========================================================데이터 그리드 뷰 이벤트===================================================

        //테이블 데이터 그리드뷰 작성
        private void Dgv_CommonTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            //갖고있는 데이터의 프로퍼티의 정보를 갖고 간다.
            var target = srcList.Find((s) => s.CODE_TABLE_NAME.Equals(Dgv_CommonTable["테이블명", e.RowIndex].Value));
            this.Table = target;

            Pop_CommonTableData pop = new Pop_CommonTableData();
            pop.Owner = this;
            pop.Location = new Point(200, 250);
            pop.ShowDialog();
        }

        //테이블 정보 그리드뷰에 보여주기
        private void Dgv_CommonTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string sTableName = Dgv_CommonTable["테이블명", e.RowIndex].Value.ToString();
            var target = srcList.Find((s) => s.CODE_TABLE_NAME.Equals(Dgv_CommonTable["테이블명", e.RowIndex].Value));
            SelectedRowData(target);
            Ppg_CommonTable.SelectedObject = cd;
        }

        //==================================================================================================================================




        //=============================================================버튼 이벤트===========================================================

        //테이블 정보 새로 넣기
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CommonData data = Ppg_CommonTable.SelectedObject as CommonData;
            var dto = CommonUtil.PropertyToDto<CommonData, CommonTable_DTO>(data);
            bool result = srvC.InsertCommonTable(dto);
            if (result)
            {
                MessageBox.Show("입력 성공");
                LoadData();
            }
            else
            {
                MessageBox.Show("입력 실패");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ppg_CommonTable.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!MboxUtil.MboxInfo_("선택된 테이블 정보를 삭제하시겠습니까 ? "))
            {
                return;
            }
            var dto = DgvUtil.DgvToDto<CommonTable_DTO>(Dgv_CommonTable);
            bool result = srvC.DeleteTable(dto);
            if (result)
            {
                MboxUtil.MboxInfo("테이블 삭제 성공.");
                LoadData();
            }
            else
            {
                MboxUtil.MboxError("테이블 삭제 실패.");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var data = Ppg_CommonTable.SelectedObject as CommonData;
            if (data.CODE_TABLE_NAME == null)
            {
                MessageBox.Show("변경할 테이블을 선택해주세요.");
                return;
            }

            if (!MboxUtil.MboxInfo_("선택된 테이블 정보를 변경하시겠습니까 ? "))
            {
                return;
            }

            var dto = PropertyToDto<CommonData, CommonTable_DTO>(data);
            bool result = srvC.UpdateCommonTable(dto);
            if (result)
            {
                MessageBox.Show("수정 성공");
                LoadData();
            }
            else
            {
                MessageBox.Show("수정 실패");
            }
        }


        //초기화 버튼
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (state)
            {
                SearchData blankData = new SearchData();
                Ppg_CommonTable.SelectedObject = blankData;
            }
            else if (cd.CODE_TABLE_NAME != null)
            {
                CommonData blankData = new CommonData();
                Ppg_CommonTable.SelectedObject = blankData;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            if (state)
            {
                Ppg_CommonTable.SelectedObject = cd;
                state = false;
            }
            else
            {
                Ppg_CommonTable.SelectedObject = sd;
                state = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tableName = sd.CODE_TABLE_NAME;
            string searchText = txtSearch.Text.ToUpper();
            //검색창 내부에 텍스트가 1개도 없으면 전체를 출력
            //검색창 내부에 텍스트가 1개라도 있으면 /  프로퍼티 그리드  null
            //검색창 내부 텍스트 null / 프로퍼티 그리드 입력
            if (Ppg_CommonTable.SelectedObject is SearchData)
            {

                if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(searchText))
                {
                    Dgv_CommonTable.DataSource = srcList.FindAll((c) => c.CODE_TABLE_NAME == tableName && c.CODE_TABLE_NAME.Contains(searchText));
                }

                else if (!string.IsNullOrEmpty(tableName) && string.IsNullOrEmpty(searchText))
                {
                    Dgv_CommonTable.DataSource = srcList.FindAll((c) => c.CODE_TABLE_NAME == tableName);
                }

                else if (string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(searchText))
                {
                    Dgv_CommonTable.DataSource = srcList.FindAll((c) => c.CODE_TABLE_NAME.Contains(searchText));
                }
                else
                {
                    Dgv_CommonTable.DataSource = srcList;
                }
            }
            else
            {
                MboxUtil.MboxError("검색 조건을 먼저 눌러주세요.");
            }
        }

        //==================================================================================================================================




        //=============================================================메서드===============================================================

        //데이터 가져오기
        private void LoadData()
        {
            srcList = srvC.SelectCommonTable();

            Dictionary<string, List<string>> searchDic = new Dictionary<string, List<string>>();

            List<string> l1 = new List<string>();
            srcList.ForEach((c) => l1.Add(c.CODE_TABLE_NAME));
            searchDic.Add("CODE_TABLE_NAME", l1);

            sd.SearchList = searchDic;

            Dgv_CommonTable.DataSource = srcList;
        }

        //Grid행 데이터 PropertyGrid에 보여줌
        private void SelectedRowData(CommonTable_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < cd.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == cd.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != cd.GetType().GetProperties()[j].PropertyType)
                        {
                            cd.GetType().GetProperties()[j].SetValue(cd, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), cd.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            cd.GetType().GetProperties()[j].SetValue(cd, target.GetType().GetProperties()[i].GetValue(target));
                            break;
                        }
                    }
                }
            }
        }

        //PropertyGrid 속성값 DTO 만들기
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

        //==================================================================================================================================
    }

    //테이블정보 PropertyGrid 프로퍼티 셋팅 
    public class CommonData
    {
        [Category("속성"), Description("CODE_TABLE_NAME"), DisplayName("테이블명")]
        public string CODE_TABLE_NAME { get; set; }

        [Category("속성"), Description("CODE_TABLE_DESC"), DisplayName("테이블 설명")]
        public string CODE_TABLE_DESC { get; set; }

        [Category("속성"), Description("KEY_1_NAME"), DisplayName("키 1 이름")]
        public string KEY_1_NAME { get; set; }

        [Category("속성"), Description("KEY_2_NAME"), DisplayName("키 2 이름")]
        public string KEY_2_NAME { get; set; }

        [Category("속성"), Description("KEY_3_NAME"), DisplayName("키 3 이름")]
        public string KEY_3_NAME { get; set; }

        [Category("속성"), Description("DATA_1_NAME"), DisplayName("데이터 1 이름")]
        public string DATA_1_NAME { get; set; }

        [Category("속성"), Description("DATA_2_NAME"), DisplayName("데이터 2 이름")]
        public string DATA_2_NAME { get; set; }

        [Category("속성"), Description("DATA_3_NAME"), DisplayName("데이터 3 이름")]
        public string DATA_3_NAME { get; set; }

        [Category("속성"), Description("DATA_4_NAME"), DisplayName("데이터 4 이름")]
        public string DATA_4_NAME { get; set; }

        [Category("속성"), Description("DATA_5_NAME"), DisplayName("데이터 5 이름")]
        public string DATA_5_NAME { get; set; }

        [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get; set; }

        [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성자"), TypeConverter(typeof(ComboStringConverter))]
        public string CREATE_USER_ID { get; set; }

        [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get; set; }

        [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경자")]
        public string UPDATE_USER_ID { get; set; }
    }

    //검색조건 PropertyGrid 프로퍼티 셋팅 
    public class SearchData
    {
        [Category("속성"), Description("CODE_TABLE_NAME"), DisplayName("테이블명"), TypeConverter(typeof(ComboStringConverter))]
        public string CODE_TABLE_NAME { get; set; }

        [Browsable(false)]
        public Dictionary<string, List<string>> SearchList { get; set; }

        public Dictionary<string, List<string>> GetList()
        {
            return SearchList;
        }
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
}
