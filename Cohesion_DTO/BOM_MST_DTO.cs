using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace Cohesion_DTO
{
	public class BOM_MST_DTO
	{
		[Category("속성"), Description("PRODUCT_CODE"), DisplayName("제품 코드"), Browsable(false)]
		public string PRODUCT_CODE { get; set; }     //제품 코드, 품번
		[Category("속성"), Description("CHILD_PRODUCT_CODE"), DisplayName("자품번"), TypeConverter(typeof(ComboProductConverter))]
		public string CHILD_PRODUCT_CODE { get; set; }   //자품번
		[Category("속성"), Description("REQUIRE_QTY"), DisplayName("단위 수량")]
		public decimal REQUIRE_QTY { get; set; }     //단위 수량
		[Category("속성"), Description("ALTER_PRODUCT_CODE"), DisplayName("대체 품번")]
		public string ALTER_PRODUCT_CODE { get; set; }   //대체 품번
		[Category("속성"), Description("OPERATION_CODE"), DisplayName("공정 코드"), TypeConverter(typeof(ComboOperationConverter))]
		public string OPERATION_CODE { get; set; }   //공정 코드
		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }    //생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }   //생성 사용자
		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime UPDATE_TIME { get; set; }    //변경 시간
		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }   //변경 사용자

		// 김재형 추가
		[Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
		public string PRODUCT_NAME { get; set; }     //제품명, 품명
		[Category("속성"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }
		[Browsable(false)]
		public decimal ORDER_QTY { get; set; }
		[Browsable(false)]
		public decimal LOT_QTY { get; set; } // 현 재고 수량

		public static BOM_MST_DTO DeepCopy(BOM_MST_DTO origin)
		{
			return new BOM_MST_DTO
			{
				PRODUCT_CODE = origin.PRODUCT_CODE,
				PRODUCT_NAME = origin.PRODUCT_NAME,
				PRODUCT_TYPE = origin.PRODUCT_TYPE,
				REQUIRE_QTY = origin.REQUIRE_QTY,
				CHILD_PRODUCT_CODE = origin.CHILD_PRODUCT_CODE,
				ORDER_QTY = origin.ORDER_QTY,
				LOT_QTY = origin.LOT_QTY,
				CREATE_TIME = origin.CREATE_TIME,
				CREATE_USER_ID = origin.CREATE_USER_ID,
				UPDATE_TIME = origin.UPDATE_TIME,
				UPDATE_USER_ID = origin.UPDATE_USER_ID,
				ALTER_PRODUCT_CODE = origin.ALTER_PRODUCT_CODE,
				OPERATION_CODE = origin.OPERATION_CODE
			};
		}
	}

	// ppg 검색조건 목록 
	public class BOM_PRODUCT_SEARCH
	{
		[Category("검색조건"), Description("PRODUCT_CODE"), DisplayName("품번 코드"), TypeConverter(typeof(ComboProductConverter))]
		public string PRODUCT_CODE { get; set; }

		[Category("검색조건"), Description("PRODUCT_NAME"), DisplayName("제품명")]
		public string PRODUCT_NAME { get; set; }

		[Category("검색조건"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }

		[Category("검색조건"), Description("OPERATION_CODE"), DisplayName("공정 코드"), TypeConverter(typeof(ComboOperationConverter))]
		public string OPERATION_CODE { get; set; }   //변경 사용자

		[Category("검색조건"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
		public string CREATE_USER_ID { get; set; }    //생성 사용자
	}

	public class BOM_MST_WORKORDER_DTO
	{
		[Category("속성"), Description("PRODUCT_CODE"), DisplayName("제품 코드"), Browsable(false)]
		public string PRODUCT_CODE { get; set; }     //제품 코드, 품번
		[Category("속성"), Description("CHILD_PRODUCT_CODE"), DisplayName("자품번"), TypeConverter(typeof(ComboProductConverter))]
		public string CHILD_PRODUCT_CODE { get; set; }   //자품번
		[Category("속성"), Description("REQUIRE_QTY"), DisplayName("단위 수량")]
		public decimal REQUIRE_QTY { get; set; }     //단위 수량
		[Category("속성"), Description("ALTER_PRODUCT_CODE"), DisplayName("대체 품번")]
		public string ALTER_PRODUCT_CODE { get; set; }   //대체 품번
		[Category("추적"), Description("OPERATION_CODE"), DisplayName("공정 코드"), ReadOnly(true), TypeConverter(typeof(ComboOperationConverter))]
		public string OPERATION_CODE { get; set; }   //공정 코드
		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }    //생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }   //생성 사용자
		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime UPDATE_TIME { get; set; }    //변경 시간
		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }   //변경 사용자

		// 김재형 추가
		[Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
		public string PRODUCT_NAME { get; set; }     //제품명, 품명
		[Category("속성"), Description("CM_PRODUCT_TYPE"), DisplayName("품번 유형"), TypeConverter(typeof(ComboStringConverter))]
		public string PRODUCT_TYPE { get; set; }
		//[Browsable(false)]
		public decimal ORDER_QTY { get; set; }
		//[Browsable(false)]
		public decimal LOT_QTY { get; set; } // 현 재고 수량

        public string VENDOR_CODE { get; set; }

    }
}