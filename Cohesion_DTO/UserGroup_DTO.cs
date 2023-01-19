using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
	public class UserGroup_DTO
	{
		public string USER_GROUP_CODE { get; set; }	 //사용자 그룹코드
		public string USER_GROUP_NAME { get; set; }	 //사용자 그룹명
		public string USER_GROUP_TYPE { get; set; }	 //사용자 그룹 유형
		public DateTime CREATE_TIME { get; set; }	 //생성 시간
		public string CREATE_USER_ID { get; set; }	 //생성 사용자
		public DateTime UPDATE_TIME { get; set; }	 //변경 시간
		public string UPDATE_USER_ID { get; set; }	 //변경 사용자
	}
}