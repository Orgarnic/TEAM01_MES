using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
	public class FUNCTION_MST_DTO
	{
		[Category("속성"), Description("FUNCTION_CODE"), DisplayName("화면 기능 코드")]
		public string FUNCTION_CODE { get; set;}    //화면 기능 코드
		[Category("속성"), Description("FUNCTION_NAME"), DisplayName("화면 기능명")]
		public string FUNCTION_NAME { get; set;}    //화면 기능명
		[Category("속성"), Description("SHORT_CUT_KEY"), DisplayName("단축키")]
		public string SHORT_CUT_KEY { get; set; }   //단축키
		[Category("속성"), Description("ICON_INDEX"), DisplayName("아이콘 인덱스")]
		public decimal ICON_INDEX { get; set;}  //아이콘 인덱스
		[Category("속성"), Description("CREATE_TIME"), DisplayName("생성 시간")]
		public DateTime CREATE_TIME { get; set;}    //생성 시간
		[Category("속성"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
		public string CREATE_USER_ID { get; set;}   //생성 사용자
		[Category("속성"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
		public DateTime UPDATE_TIME { get; set;}    //변경 시간
		[Category("속성"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자")]
		public string UPDATE_USER_ID { get; set;}	//변경 사용자
	}

	public class FUNCTION_MST_DTO_Condition
    {
		[Category("속성"), Description("FUNCTION_CODE"), DisplayName("화면 기능 코드")]
		public string FUNCTION_CODE { get; set; }    //화면 기능 코드
		[Category("속성"), Description("FUNCTION_NAME"), DisplayName("화면 기능명")]
		public string FUNCTION_NAME { get; set; }    //화면 기능명
		[Category("속성"), Description("SHORT_CUT_KEY"), DisplayName("단축키")]
		public string SHORT_CUT_KEY { get; set; }   //단축키
		[Category("속성"), Description("ICON_INDEX"), DisplayName("아이콘 인덱스")]
		public decimal ICON_INDEX { get; set; }  //아이콘 인덱스
	}
}
