using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cohesion_DTO
{
    public class Work_Order_MST_DTO
    {
		[Category("속성"), Description("WORK_ORDER_ID"), DisplayName("생산 작업지시 코드")]
		public string WORK_ORDER_ID { get; set; }       //생산 작업지시 코드
		[Category("속성"), Description("ORDER_DATE"), DisplayName("작업 일자")]
		public DateTime ORDER_DATE { get; set; }        //작업 일자
		[Category("속성"), Description("PRODUCT_CODE"), DisplayName("생산 제품 코드")]
		public string PRODUCT_CODE { get; set; }        //생산 제품코드, 품번
		[Category("속성"), Description("CUSTOMER_CODE"), DisplayName("고객사 코드")]
		public string CUSTOMER_CODE { get; set; }       //고객사 코드
		[Category("속성"), Description("ORDER_QTY"), DisplayName("계획 수량")]
		public decimal ORDER_QTY { get; set; }          //계획 수량
		[Category("속성"), Description("ORDER_STATUS"), DisplayName("지시 상태")]
		public string ORDER_STATUS { get; set; }        //지시 상태. 최초 : OPEN, 생산 중 : PROC, 마감 : CLOSE
		[Category("추적"), Description("PRODUCT_QTY"), DisplayName("생산 수량")]
		public decimal PRODUCT_QTY { get; set; }        //생산 수량
		[Category("추적"), Description("DEFECT_QTY"), DisplayName("불량 수량")]
		public decimal DEFECT_QTY { get; set; }         //불량 수량
		[Category("추적"), Description("WORK_START_TIME"), DisplayName("작업 시작 시간")]
		public DateTime WORK_START_TIME { get; set; }   //작업 시작 시간
		[Category("추적"), Description("WORK_CLOSE_TIME"), DisplayName("지시 마감 시간")]
		public DateTime WORK_CLOSE_TIME { get; set; }   //지시 마감 시간
		[Category("추적"), Description("WORK_CLOSE_USER_ID"), DisplayName("지시 마감자")]
		public string WORK_CLOSE_USER_ID { get; set; }  //지시 마감자
		[Category("추적"), Description("CREATE_TIME"), DisplayName("작업지시 생성 시간")]
		public DateTime CREATE_TIME { get; set; }       //작업지시 생성 시간
		[Category("추적"), Description("CREATE_USER_ID"), DisplayName("작업지시 생성 사용자")]
		public string CREATE_USER_ID { get; set; }      //작업지시 생성 사용자
		[Category("추적"), Description("UPDATE_TIME"), DisplayName("작업지시 변경 시간")]
		public DateTime UPDATE_TIME { get; set; }       //작업지시 변경 시간
		[Category("추적"), Description("UPDATE_USER_ID"), DisplayName("작업지시 변경 사용자")]
		public string UPDATE_USER_ID { get; set; }      //작업지시 변경 사용자

		[Browsable(false)]
        public string OrderDate { get; set; }
    }
}
