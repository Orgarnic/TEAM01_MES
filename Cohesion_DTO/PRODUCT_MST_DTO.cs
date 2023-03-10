using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;


namespace Cohesion_DTO
{
	public class PRODUCT_MST_DTO
	{
		[Category("속성"), Description("PRODUCT_CODE"), DisplayName("품번 코드"), ReadOnly(false)]
		public string PRODUCT_CODE { get; set; }   //제품 코드, 품번

		[Category("속성"), Description("PRODUCT_NAME"), DisplayName("품명")]
		public string PRODUCT_NAME { get; set; }   //제품명, 품명

		[Category("속성"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }   //품번 유형, 완제품 : FERT, 반제품 : HALB, 원자재 : ROH

		[Category("속성"), Description("CUSTOMER_CODE"), DisplayName("고객코드")]
		public string CUSTOMER_CODE { get; set; }  //완제품인 경우 고객코드

		[Category("속성"), Description("VENDOR_CODE"), DisplayName("납품업체 코드")]
		public string VENDOR_CODE { get; set; }    //원자재인 경우 납품업체 코드

		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }  //생성 시간

		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }    //생성 사용자

		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime UPDATE_TIME { get; set; }  //변경 시간

		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }    //변경 사용자
	}
	// 품번 관리 검색 조건 
	public class PRODUCT_MST_DTO_Condition
	{
		[Category("검색조건"), Description("PRODUCT_CODE"), DisplayName("품번 코드")]
		public string PRODUCT_CODE { get; set; }

		[Category("검색조건"), Description("PRODUCT_NAME"), DisplayName("품명")]
		public string PRODUCT_NAME { get; set; }

		[Category("검색조건"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }

		[Category("검색조건"), Description("CUSTOMER_CODE"), DisplayName("고객코드")]
		public string CUSTOMER_CODE { get; set; }
	}
}