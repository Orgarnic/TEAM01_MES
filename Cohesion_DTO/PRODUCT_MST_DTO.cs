using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
	public class PRODUCT_MST_DTO
	{
		public string PRODUCT_CODE { get; set; }	 //제품 코드, 품번
		public string PRODUCT_NAME { get; set; }	 //제품명, 품명
		public string PRODUCT_TYPE { get; set; }	 //품번 유형, 완제품 : FERT, 반제품 : HALB, 원자재 : ROH
		public string CUSTOMER_CODE { get; set; }	 //완제품인 경우 고객코드
		public string VENDOR_CODE { get; set; }		 //원자재인 경우 납품업체 코드
		public DateTime CREATE_TIME { get; set; }	 //생성 시간
		public string CREATE_USER_ID { get; set; }	 //생성 사용자
		public DateTime UPDATE_TIME { get; set; }	 //변경 시간
		public string UPDATE_USER_ID { get; set; }	 //변경 사용자
	}
}