using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace Cohesion_DTO
{
    public class Sales_Order_DTO
    {
        [Category("속성"), Description("SALES_ORDER_ID"), DisplayName("주문서코드")]
        public string SALES_ORDER_ID { get; set; }

        [Category("속성"), Description("ORDER_DATE"), DisplayName("주문일자")]
        public DateTime ORDER_DATE { get; set; }

        [Category("속성"), Description("CUSTOMER_CODE"), DisplayName("고객사코드")]
        public string CUSTOMER_CODE { get; set; }

        //[Category("속성"), Description(""), DisplayName("고객사명")]
        //public string  { get; set; }

        [Category("속성"), Description("PRODUCT_CODE"), DisplayName("제품코드")]
        public string PRODUCT_CODE { get; set; }

        //[Category("속성"), Description(""), DisplayName("제품명")]
        //public string  { get; set; }

        [Category("속성"), Description("ORDER_QTY"), DisplayName("주문수량")]
        public string ORDER_QTY { get; set; }

        [Category("속성"), Description("CONFIRM_FLAG"), DisplayName("확정여부"), TypeConverter(typeof(ComboCharConverter))]
        public char CONFIRM_FLAG { get; set; }

        [Category("속성"), Description("SHIP_FLAG"), DisplayName("배송여부"), TypeConverter(typeof(ComboCharConverter))]
        public char SHIP_FLAG { get; set; }

        [Category("추적"), Description("CREATE_TIME"), DisplayName("생성시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }

        [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }

        [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경시간"), ReadOnly(true)]
        public DateTime UPDATE_TIME { get; set; }

        [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; }


        [Category("속성"), Description("CM_ST_CODE"), DisplayName("창고유형"), TypeConverter(typeof(ComboStringConverter))]
        public string STORE_TYPE { get; set; }
    }

    public class Sales_Order_DTO_Search
    {
        [Category("검색조건"), Description("창고코드 (= ST_xxxx) 입력"), DisplayName("창고코드")]
        public string STORE_CODE { get; set; }
        [Category("검색조건"), Description("창고명 입력"), DisplayName("창고명")]
        public string STORE_NAME { get; set; }

        [Category("검색조건"), Description("창고 타입 = 원자재창고 : RS, 반제품창고 : HS, 완제품창고 : FS"), DisplayName("창고유형")]
        public string STORE_TYPE { get; set; }
    }
}
