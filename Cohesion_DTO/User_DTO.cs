using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cohesion_DTO
{
	public class User_DTO
	{
		[Category("속성"), Description("USER_ID"), DisplayName("로그인 사용자 ID")]
		public string USER_ID { get; set; }  //로그인 사용자 ID
		[Category("속성"), Description("USER_NAME"), DisplayName("사용자 명")]
		public string USER_NAME { get; set; }    //사용자명
		[Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드"),TypeConverter(typeof(ComboStringConverter))]
		public string USER_GROUP_CODE { get; set; }  //사용자 그룹 코드
		[Category("속성"), Description("USER_PASSWORD"), DisplayName("사용자 암호")]
		public string USER_PASSWORD { get; set; }    //사용자 암호
		[Category("속성"), Description("USER_DEPARTMENT"), DisplayName("사용자 부서"), TypeConverter(typeof(ComboStringConverter))]
		public string USER_DEPARTMENT { get; set; }  //사용자 부서
		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간")]
		public DateTime CREATE_TIME { get; set; }    //생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자")]
		public string CREATE_USER_ID { get; set; }   //생성 사용자
		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간")]
		public DateTime UPDATE_TIME { get; set; }    //변경 시간
		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자")]
		public string UPDATE_USER_ID { get; set; }   //변경 사용자
	}

	public class User_Condition_DTO
	{
		[Category("속성"), Description("USER_ID"), DisplayName("로그인 사용자 ID")]
		public string USER_ID { get; set; }  //로그인 사용자 ID
		[Category("속성"), Description("USER_NAME"), DisplayName("사용자 명")]
		public string USER_NAME { get; set; }    //사용자명
		[Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드")]
		public string USER_GROUP_CODE { get; set; }  //사용자 그룹 코드
		[Category("속성"), Description("USER_DEPARTMENT"), DisplayName("사용자 부서")]
		public string USER_DEPARTMENT { get; set; }  //사용자 부서

	} 
}