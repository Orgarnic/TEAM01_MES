using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cohesion_DTO
{
	public class BOM_MST_DTO
	{
		[Category("속성"), Description("PRODUCT_CODE"), DisplayName("제품 코드")]
		public string PRODUCT_CODE { get; set; }     //제품 코드, 품번
		[Category("속성"), Description("CHILD_PRODUCT_CODE"), DisplayName("자품번")]
		public string CHILD_PRODUCT_CODE { get; set; }   //자품번
		[Category("속성"), Description("REQUIRE_QTY"), DisplayName("단위 수량")]
		public decimal REQUIRE_QTY { get; set; }     //단위 수량
		[Category("속성"), Description("ALTER_PRODUCT_CODE"), DisplayName("대체 품번")]
		public string ALTER_PRODUCT_CODE { get; set; }   //대체 품번
		[Category("속성"), Description("CREATE_TIME"), DisplayName("생성 시간")]
		public DateTime CREATE_TIME { get; set; }    //생성 시간
		[Category("속성"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
		public string CREATE_USER_ID { get; set; }   //생성 사용자
		[Category("속성"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
		public DateTime UPDATE_TIME { get; set; }    //변경 시간
		[Category("속성"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자")]
		public string UPDATE_USER_ID { get; set; }   //변경 사용자

		// 김재형 추가
		[Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명")]
		public string PRODUCT_NAME { get; set; }     //제품명, 품명
	}
}