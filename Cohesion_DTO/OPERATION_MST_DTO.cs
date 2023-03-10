using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
	public class OPERATION_MST_DTO
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
	// 공정 관리 검색 조건
	public class OPERATION_MST_DTO_Condition
	{
      [Category("속성"), Description("OPERATION_CODE"), DisplayName("공정 코드")]
      public string OPERATION_CODE { get; set; }    //공정 코드
      [Category("속성"), Description("OPERATION_NAME"), DisplayName("공정 명칭")]
      public string OPERATION_NAME { get; set; }    //공정명
      [Category("속성"), Description("CM_ANSWER"), DisplayName("불량 입력"), TypeConverter(typeof(ComboCharConverter))]
      public char CHECK_DEFECT_FLAG { get; set; }   //불량 입력 체크 여부. 미체크 : null, 체크 : Y
      [Category("속성"), Description("CM_ANSWER"), DisplayName("검사 데이터"), TypeConverter(typeof(ComboCharConverter))]
      public char CHECK_INSPECT_FLAG { get; set; }  //검사 데이터 입력 체크 여부. 미체크 : null, 체크 : Y
      [Category("속성"), Description("CM_ANSWER"), DisplayName("자재 사용"), TypeConverter(typeof(ComboCharConverter))]
      public char CHECK_MATERIAL_FLAG { get; set; }    //자재 사용 체크 여부. 미체크 : null, 체크 : Y
   }
}