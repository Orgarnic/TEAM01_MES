using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNCTION_MST
{
	public class FUNCTION_MST_DTO
	{
		public string FUNCTION_CODE { get; set;}	//화면 기능 코드
		public string FUNCTION_NAME { get; set;}	//화면 기능명
		public string SHORT_CUT_KEY { get; set;}	//단축키
		public decimal ICON_INDEX { get; set;}	//아이콘 인덱스
		public DateTime CREATE_TIME { get; set;}	//생성 시간
		public string CREATE_USER_ID { get; set;}	//생성 사용자
		public DateTime UPDATE_TIME { get; set;}	//변경 시간
		public string UPDATE_USER_ID { get; set;}	//변경 사용자
	}
}