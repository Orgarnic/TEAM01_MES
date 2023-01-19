using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cohesion_DTO;
using System.Linq;

namespace Cohesion_Project
{
    public partial class Frm_BOM : Cohesion_Project.Frm_Base_3
    {
        Srv_BOM srv = new Srv_BOM();
        List<PRODUCT_MST_DTO> product = null;

        private ProductData pdata = new ProductData();
        private SearchData sdata = new SearchData();

        public Frm_BOM()
        {
            InitializeComponent();
        }

        private void Frm_BOM_Load(object sender, EventArgs e)
        {
            DataGirdViewParent();
            DataGirdViewChild();

            ppgSearch.PropertySort = PropertySort.Categorized;
            ppgSearch.SelectedObject = pdata;
        }

        public void DataGirdViewParent()
        {
            DgvUtil.DgvInit(dgvBOMParent);
            DgvUtil.AddTextCol(dgvBOMParent, "제품 코드", "PRODUCT_CODE", 150, true, 1, frozen:true);
            DgvUtil.AddTextCol(dgvBOMParent, "제품명", "PRODUCT_NAME", 150, true, 1, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "제품 유형", "PRODUCT_TYPE", 150, true, 1, frozen: true);
            DgvUtil.AddTextCol(dgvBOMParent, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMParent, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);
            if(product == null)
            {
                product = srv.SelectProductList();
            }

            dgvBOMParent.DataSource = product;
            /*  public string PRODUCT_CODE { get; set; }	 //제품 코드, 품번
		        public string PRODUCT_NAME { get; set; }	 //제품명, 품명
		        public string PRODUCT_TYPE { get; set; }	 //품번 유형, 완제품 : FERT, 반제품 : HALB, 원자재 : ROH
		        public string CUSTOMER_CODE { get; set; }	 //완제품인 경우 고객코드
		        public string VENDOR_CODE { get; set; }		 //원자재인 경우 납품업체 코드
		        public DateTime CREATE_TIME { get; set; }	 //생성 시간
		        public string CREATE_USER_ID { get; set; }	 //생성 사용자
		        public DateTime UPDATE_TIME { get; set; }	 //변경 시간
		        public string UPDATE_USER_ID { get; set; }	 //변경 사용자*/
        }

        public void DataGirdViewChild()
        {
            dgvBOMChild.DataSource = null;

            DgvUtil.DgvInit(dgvBOMChild);
            DgvUtil.AddTextCol(dgvBOMChild, "구성 제품명", "CHILD_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "단위 수량", "REQUIRE_QTY", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "대체 품번", "ALTER_PRODUCT_CODE", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 시간", "CREATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "생성 사용자", "CREATE_USER_ID", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 시간", "UPDATE_TIME", 150, true, 1);
            DgvUtil.AddTextCol(dgvBOMChild, "변경 사용자", "UPDATE_USER_ID", 150, true, 1);

        }

        private void dgvBOMParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀클릭시, 클릭된 완제품의 BOM을 Child에 뿌려줌.
            if (e.ColumnIndex < 0) return;
            string code = dgvBOMParent[0, e.RowIndex].Value.ToString();

            dgvBOMChild.DataSource = srv.SelectBOMList(code);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvBOMParent.DataSource = dgvBOMChild.DataSource = null;
            ppgSearch = ppgBOMAttribute = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == null) return;
            dgvBOMParent.DataSource = product.FindAll((s) => s.PRODUCT_NAME.Contains(txtSearch.Text));
        }

        private void GetGridViewData(PRODUCT_MST_DTO prod)
        {
            for(int i = 0; i < prod.GetType().GetProperties().Length; i++)
            {
                string propertyName = prod.GetType().GetProperties()[i].Name;
                Type propertyType = prod.GetType().GetProperties()[i].PropertyType;
            }
        }

        private void SelectedRowData(PRODUCT_MST_DTO target)
        {
            TypeConverter typeConverter = new TypeConverter();

            for (int i = 0; i < target.GetType().GetProperties().Length; i++)
            {
                string propertyName = target.GetType().GetProperties()[i].Name;
                Type propertyType = target.GetType().GetProperties()[i].PropertyType;
                for (int j = 0; j < pdata.GetType().GetProperties().Length; j++)
                {
                    if (target.GetType().GetProperties()[i].GetValue(target) == null)
                        continue;

                    else if (propertyName == pdata.GetType().GetProperties()[j].Name)
                    {
                        if (propertyType != pdata.GetType().GetProperties()[j].PropertyType)
                        {
                            pdata.GetType().GetProperties()[j].SetValue(pdata, typeConverter.ConvertTo(target.GetType().GetProperties()[i].GetValue(target), pdata.GetType().GetProperties()[j].PropertyType));
                            break;
                        }

                        else
                        {
                            pdata.GetType().GetProperties()[j].SetValue(pdata, target.GetType().GetProperties()[i].GetValue(target));
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

            for (int i = 0; i < data.GetType().GetProperties().Length - 1; i++)
            {
                for (int j = 0; j < dto.GetType().GetProperties().Length - 1; j++)
                {
                    if (data.GetType().GetProperties()[i].Name.Equals(dto.GetType().GetProperties()[i].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        dto.GetType().GetProperties()[i].SetValue(dto, data.GetType().GetProperties()[i].GetValue(data));
                        break;
                    }
                }
            }
            return dto;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }

    public class ProductData
    {
        [Category("속성"), Description("PRODUCT_CODE"), DisplayName("제품 코드")]
        public string PRODUCT_CODE { get; set; }   //제품 코드, 품번
        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
        public string PRODUCT_NAME { get; set; }   //제품명, 품명
        [Category("속성"), Description("PRODUCT_TYPE"), DisplayName("품번 유형")]
        public string PRODUCT_TYPE { get; set; }   //품번 유형, 완제품 : FERT, 반제품 : HALB, 원자재 : ROH
        [Category("속성"), Description("CUSTOMER_CODE"), DisplayName("고객코드")]
        public string CUSTOMER_CODE { get; set; }  //완제품인 경우 고객코드
        [Category("속성"), Description("VENDOR_CODE"), DisplayName("납품업체코드")]
        public string VENDOR_CODE { get; set; }    //원자재인 경우 납품업체코드
        [Category("속성"), Description("CREATE_TIME"), DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get; set; }  //생성 시간
        [Category("속성"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get; set; }    //생성 사용자
        [Category("속성"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get; set; }  //변경 시간
        [Category("속성"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get; set; }    //변경 사용자
    }

    public class ProdectSearch
    {
        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
        public string PRODUCT_NAME { get; set; }
    }
}
