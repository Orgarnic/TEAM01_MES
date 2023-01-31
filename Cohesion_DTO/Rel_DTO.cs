using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Rel_DTO
    {
		
	}
	public class PRODUCT_OPERATION_REL_DTO
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
	public class PRODUCT_OPERATION_Rel_Search
	{
		[Category("검색조건"), Description("PRODUCT_CODE"), DisplayName("품번 코드")]
		public string PRODUCT_CODE { get; set; }
		[Category("검색조건"), Description("PRODUCT_NAME"), DisplayName("품명")]
		public string PRODUCT_NAME { get; set; }

		[Category("검색조건"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }

		[Category("검색조건"), Description("CUSTOMER_CODE"), DisplayName("고객코드")]
		public string CUSTOMER_CODE { get; set; }  //완제품인 경우 고객코드

		[Category("검색조건"), Description("VENDOR_CODE"), DisplayName("납품업체 코드")]
		public string VENDOR_CODE { get; set; }    //원자재인 경우 납품업체 코드
	}

	public class Operation_Inspection_Rel_DTO
	{
		[Category("속성"), Description("OPERATION_CODE"), DisplayName("공정 코드")]
		public string OPERATION_CODE { get; set; }    //공정 코드
		[Category("속성"), Description("OPERATION_NAME"), DisplayName("공정 명칭")]
		public string OPERATION_NAME { get; set; }    //공정명
		[Category("속성"), Description("CHECK_DEFECT_FLAG"), DisplayName("불량 입력"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_DEFECT_FLAG { get; set; }   //불량 입력 체크 여부. 미체크 : null, 체크 : Y
		[Category("속성"), Description("CHECK_INSPECT_FLAG"), DisplayName("검사 데이터"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_INSPECT_FLAG { get; set; }  //검사 데이터 입력 체크 여부. 미체크 : null, 체크 : Y
		[Category("속성"), Description("CHECK_MATERIAL_FLAG"), DisplayName("자재 사용"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_MATERIAL_FLAG { get; set; }    //자재 사용 체크 여부. 미체크 : null, 체크 : Y

		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public DateTime? CREATE_TIME { get; set; }  //생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }    //생성 사용자
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public DateTime? UPDATE_TIME { get; set; }  //변경 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }   //변경 사용자
	}
	public class Operationg_Inspection_Rel_Search
	{
		[Category("속성"), Description("OPERATION_CODE"), DisplayName("공정 코드")]
		public string OPERATION_CODE { get; set; }    //공정 코드
		[Category("속성"), Description("OPERATION_NAME"), DisplayName("공정 명칭")]
		public string OPERATION_NAME { get; set; }    //공정명
		[Category("속성"), Description("CHECK_DEFECT_FLAG"), DisplayName("불량 입력"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_DEFECT_FLAG { get; set; }   //불량 입력 체크 여부. 미체크 : null, 체크 : Y
		[Category("속성"), Description("CHECK_INSPECT_FLAG"), DisplayName("검사 데이터"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_INSPECT_FLAG { get; set; }  //검사 데이터 입력 체크 여부. 미체크 : null, 체크 : Y
		[Category("속성"), Description("CHECK_MATERIAL_FLAG"), DisplayName("자재 사용"), TypeConverter(typeof(ComboCharConverter))]
		public char CHECK_MATERIAL_FLAG { get; set; }    //자재 사용 체크 여부. 미체크 : null, 체크 : Y
	}

	public class Inspection_REL_DTO
	{
		[Category("속성"), Description("INSPECT_ITEM_CODE"), DisplayName("검사 항목"), ReadOnly(false)]
		public string INSPECT_ITEM_CODE { get; set; }

		[Category("속성"), Description("INSPECT_ITEM_NAME"), DisplayName("검사 항목명")]
		public string INSPECT_ITEM_NAME { get; set; }

		public int DISPLAY_SEQ { get; set; }

		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }  //생성 시간

		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }    //생성 사용자

		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime? UPDATE_TIME { get; set; }  //변경 시간

		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }    //변경 사용자
	}

	public class Equipment_REL_DTO
	{
		[Category("속성"), Description("설비코드 (FC_xxxx) 입력"), DisplayName("설비코드")]
		public string EQUIPMENT_CODE { get; set; }


		[Category("속성"), Description("설비명 입력"), DisplayName("설비명")]
		public string EQUIPMENT_NAME { get; set; }

		public int DISPLAY_SEQ { get; set; }

		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }  //생성 시간

		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }    //생성 사용자

		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime? UPDATE_TIME { get; set; }  //변경 시간

		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }    //변경 사용자
	}
	public class OPERATION_REL_DTO
	{
		[Category("속성"), Description("OPERATION_CODE"), DisplayName("공정 코드")]
		public string OPERATION_CODE { get; set; }    //공정 코드
		[Category("속성"), Description("OPERATION_NAME"), DisplayName("공정 명칭")]
		public string OPERATION_NAME { get; set; }    //공정명

		public decimal DISPLAY_SEQ { get; set; }

		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }  //생성 시간

		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }    //생성 사용자

		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime? UPDATE_TIME { get; set; }  //변경 시간

		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }    //변경 사용자

	}
}
