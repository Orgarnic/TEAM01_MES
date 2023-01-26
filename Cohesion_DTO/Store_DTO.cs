using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Store_DTO
    {
        [Category("속성"), Description("창고코드 (= ST_xxxx) 입력"), DisplayName("창고코드")]
        public string STORE_CODE { get; set; }


        [Category("속성"), Description("창고명 입력"), DisplayName("창고명")]
        public string STORE_NAME { get; set; }


        [Category("속성"), Description("CM_ST_CODE"), DisplayName("창고유형"), TypeConverter(typeof(ComboStringConverter))]
        public string STORE_TYPE { get; set; }


        //[Category("속성"), Description("FIFO_FLAG"), DisplayName("선입선출 여부")]
        //public string FIFO_FLAG { get; set; }


        [Category("추적"), Description("생성 시 현재 시간 자동입력"), DisplayName("생성시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }


        [Category("추적"), Description("생성 시 사용자 자동입력"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }


        [Category("추적"), Description("변경 시 현재 시간 자동입력"),  DisplayName("변경시간"), ReadOnly(true)]
        public DateTime UPDATE_TIME { get; set; }


        [Category("추적"), Description("변경 시 최근 사용자 자동 업데이트"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; } 
    }

    public class Store_DTO_Search
    {
        [Category("검색조건"), Description("창고코드 (= ST_xxxx) 입력"), DisplayName("창고코드")]
        public string STORE_CODE { get; set; }
        [Category("검색조건"), Description("창고명 입력"), DisplayName("창고명")]
        public string STORE_NAME { get; set; }

        [Category("검색조건"), Description("CM_ST_CODE"), DisplayName("창고유형"), TypeConverter(typeof(ComboStringConverter))]
        public string STORE_TYPE { get; set; }
    }
}
