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
        [Category("속성"), Description("SALES_ORDER_ID"), DisplayName("주문서코드"), ReadOnly(true)]
        public string SALES_ORDER_ID { get; set; }

        [Category("속성"), Description("ORDER_DATE"), DisplayName("주문일자"), ReadOnly(true)]
        public DateTime ORDER_DATE { get; set; }

        [Category("속성"), Description("CM_CUSTOMER"), DisplayName("고객사코드"), TypeConverter(typeof(ComboStringConverter))]
        public string CUSTOMER_CODE { get; set; }

        [Category("속성"), Description("CUSTOMER_NAME"), DisplayName("고객사명"), ReadOnly(true)]
        public string CUSTOMER_NAME { get; set; }


        [Category("속성"), Description("CM_PRODUCT_CODE"), DisplayName("제품코드"), TypeConverter(typeof(ComboStringConverter))]
        public string PRODUCT_CODE { get; set; }

        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명"), ReadOnly(true)]
        public string PRODUCT_NAME { get; set; }

        [Category("속성"), Description("ORDER_QTY"), DisplayName("주문수량")]
        public decimal ORDER_QTY { get; set; }

        [Category("속성"), Description("CM_ANSWER"), DisplayName("확정여부"), TypeConverter(typeof(ComboStringConverter))]
        public string CONFIRM_FLAG { get; set; }

        [Category("속성"), Description("CM_ANSWER"), DisplayName("배송여부"), TypeConverter(typeof(ComboStringConverter))]
        public string SHIP_FLAG { get; set; }

        [Category("추적"), Description("CREATE_TIME"), DisplayName("생성시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }

        [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }

        [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경시간"), ReadOnly(true)]
        public DateTime? UPDATE_TIME { get; set; }

        [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; }
    }

    public class Sales_Order_DTO_Search
    {
        [Category("검색조건"), Description("SEARCH_START_DATE"), DisplayName("조회 시작 일자")]
        public DateTime FROM_DATE { get; set; }

        [Category("검색조건"), Description("SEARCH_END_DATE"), DisplayName("조회 종료 일자")]
        public DateTime TO_DATE { get; set; }

        [Category("검색조건"), Description("SALES_ORDER_ID"), DisplayName("주문서코드")]
        public string SALES_ORDER_ID { get; set; }


        [Category("검색조건"), Description("CM_CUSTOMER"), DisplayName("고객사코드"), TypeConverter(typeof(ComboStringConverter))]
        public string CUSTOMER_NAME { get; set; }


        [Category("검색조건"), Description("CM_PRODUCT_CODE"), DisplayName("품번"), TypeConverter(typeof(ComboStringConverter))]
        public string PRODUCT_CODE { get; set; }

        [Category("검색조건"), Description("CM_ANSWER"), DisplayName("확정여부"), TypeConverter(typeof(ComboStringConverter))]
        public string CONFIRM_FLAG { get; set; }
        [Category("검색조건"), Description("CM_ANSWER"), DisplayName("배송여부"), TypeConverter(typeof(ComboStringConverter))]
        public string SHIP_FLAG { get; set; }
    }

    // 김재형 추가
    public class Sales_Order_Work_DTO
    {
        [Category("속성"), Description("SALES_ORDER_ID"), DisplayName("주문서코드"), ReadOnly(true)]
        public string SALES_ORDER_ID { get; set; }

        [Category("속성"), Description("ORDER_DATE"), DisplayName("주문일자"), ReadOnly(true)]
        public DateTime ORDER_DATE { get; set; }

        [Category("속성"), Description("CM_CUSTOMER"), DisplayName("고객사코드"), TypeConverter(typeof(ComboStringConverter))]
        public string CUSTOMER_CODE { get; set; }

        [Category("속성"), Description("CUSTOMER_NAME"), DisplayName("고객사명"), ReadOnly(true)]
        public string CUSTOMER_NAME { get; set; }


        [Category("속성"), Description("CM_PRODUCT_CODE"), DisplayName("제품코드"), TypeConverter(typeof(ComboStringConverter))]
        public string PRODUCT_CODE { get; set; }

        [Category("속성"), Description("PRODUCT_NAME"), DisplayName("제품명"), ReadOnly(true)]
        public string PRODUCT_NAME { get; set; }

        [Category("속성"), Description("ORDER_QTY"), DisplayName("주문수량")]
        public decimal ORDER_QTY { get; set; }

        [Category("속성"), Description("CM_ANSWER"), DisplayName("확정여부"), TypeConverter(typeof(ComboStringConverter))]
        public string CONFIRM_FLAG { get; set; }

        [Category("속성"), Description("CM_ANSWER"), DisplayName("배송여부"), TypeConverter(typeof(ComboStringConverter))]
        public string SHIP_FLAG { get; set; }

        [Category("추적"), Description("CREATE_TIME"), DisplayName("생성시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }

        [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }

        [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경시간"), ReadOnly(true)]
        public DateTime UPDATE_TIME { get; set; }

        [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; }

        // 김재형 추가
        public decimal LOT_QTY { get; set; }
    }
    public class Sales_Order_VO
    {
        public Int64 DISPLAY_SEQ { get; set; }
        public string       SALES_ORDER_ID          { get; set; }
        public DateTime ORDER_DATE              { get; set; }
        public DateTime FROM_DATE               { get; set; }
        public DateTime TO_DATE                 { get; set; }
        public string       CUSTOMER_CODE           { get; set; }
        public string       CUSTOMER_NAME           { get; set; }
        public string       PRODUCT_CODE            { get; set; }
        public string       PRODUCT_NAME            { get; set; }
        public decimal       ORDER_QTY               { get; set; }
        public string       PURCHASE_QTY            { get; set; }
        public string       CONFIRM_FLAG            { get; set; }
        public string       SHIP_FLAG               { get; set; }
        public DateTime     CREATE_TIME             { get; set; }
        public string       CREATE_USER_ID          { get; set; }
        public DateTime     UPDATE_TIME             { get; set; }
        public string       UPDATE_USER_ID          { get; set; }
        public string       CHILD_PRODUCT_CODE      { get; set; }
        public string       CHILD_PRODUCT_NAME      { get; set; }
        public decimal      REQUIRE_QTY             { get; set; }
        public decimal      NEED_QTY                { get; set; }
        public string       VENDOR_CODE             { get; set; }
        public decimal      LOT_QTY                 { get; set; }
        public decimal      LEFT_QTY                { get; set; }
        public string       STOCK_IN_FLAG           { get; set; }
        public string       MATERIAL_CODE           { get; set; }
        public int          PURCHASE_SEQ            { get; set; }
        public decimal      ORDERING_QTY            { get; set; }
    }

    public class Purchase_DTO
    {
        public string PURCHASE_ORDER_ID { get; set; }
        public int PURCHASE_SEQ { get; set; }
        public string SALES_ORDER_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string VENDOR_CODE { get; set; }
        public string MATERIAL_CODE { get; set; }
        public decimal ORDER_QTY { get; set; }
        public string STOCK_IN_FLAG { get; set; }
    }

    public class Sales_Order_DTO_Data
    {
        public string SALES_ORDER_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string ORDER_QTY { get; set; }
        public string CONFIRM_FLAG { get; set; }
        public string SHIP_FLAG { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public string UPDATE_USER_ID { get; set; }
    }
}
