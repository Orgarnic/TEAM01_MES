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
	public class UserGroup_DTO
	{
		[Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드"), TypeConverter(typeof(ComboProductConverter))]
		public string USER_GROUP_CODE { get; set; }  //사용자 그룹코드
		[Category("속성"), Description("USER_GROUP_NAME"), DisplayName("사용자 그룹 명"),TypeConverter(typeof(ComboProductConverter))]
		public string USER_GROUP_NAME { get; set; }  //사용자 그룹명
		[Category("속성"), Description("USER_GROUP_TYPE"), DisplayName("사용자 그룹 유형"),TypeConverter(typeof(ComboProductConverter))]
		public string USER_GROUP_TYPE { get; set; }  //사용자 그룹 유형
		[Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
		public DateTime CREATE_TIME { get; set; }    //생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성자"), ReadOnly(true)]
		public string CREATE_USER_ID { get; set; }   //생성 사용자
		[Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
		public DateTime UPDATE_TIME { get; set; }    //변경 시간
		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경자"), ReadOnly(true)]
		public string UPDATE_USER_ID { get; set; }	 //변경 사용자
	}



	public class UserGoupCondition_DTO
	{
		[Category("속성"), Description("USER_GROUP_CODE"), DisplayName("사용자 그룹 코드")]
		public string USER_GROUP_CODE { get; set; }  //로그인 사용자 ID
		[Category("속성"), Description("USER_GROUP_NAME"), DisplayName("사용자 그룹 명")]
		public string USER_GROUP_NAME { get; set; }    //사용자명
		[Category("속성"), Description("USER_GROUP_TYPE"), DisplayName("사용자 그룹 유형")]
		public string USER_GROUP_TYPE { get; set; }  //사용자 그룹 코드


	}

}