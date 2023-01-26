using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Equipment_DTO
    {
        [Category("속성"), Description("설비코드 (FC_xxxx) 입력"), DisplayName("설비코드")]
        public string EQUIPMENT_CODE { get; set; }


        [Category("속성"), Description("설비명 입력"), DisplayName("설비명")]
        public string EQUIPMENT_NAME { get; set; }


        [Category("속성"), Description("CM_EQUIPMENT_TYPE"), DisplayName("설비유형"), TypeConverter(typeof(ComboStringConverter))]
        public string EQUIPMENT_TYPE { get; set; }

        [Category("속성"), Description("CM_EQUIPMENT_CONDITON"), DisplayName("설비상태"), TypeConverter(typeof(ComboStringConverter))]
        public string EQUIPMENT_STATUS { get; set; }


        [Category("추적"), Description("설비 상태 변경/확정 시 현재 시간 자동입력"), DisplayName("다운시간"), ReadOnly(true)]
        public DateTime LAST_DOWN_TIME { get; set; }


        [Category("추적"), Description("생성 시간 현재 시간 자동입력"), DisplayName("생성 시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }


        [Category("추적"), Description("생성 시 사용자 자동입력"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }


        [Category("추적"), Description("변경 시 현재 시간 자동입력"), DisplayName("변경 시간"), ReadOnly(true)]
        public DateTime UPDATE_TIME { get; set; }


        [Category("추적"), Description("변경 시 사용자 자동입력"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; }
    }

    public class Equipment_DTO_Search
    {
        [Category("검색조건"), Description("설비코드 (FC_xxxx) 입력"), DisplayName("설비코드")]
        public string EQUIPMENT_CODE { get; set; }

        [Category("검색조건"), Description("설비명 입력"), DisplayName("설비명")]
        public string EQUIPMENT_NAME { get; set; }
        [Category("검색조건"), Description("CM_EQUIPMENT_TYPE"), DisplayName("설비유형"), TypeConverter(typeof(ComboStringConverter))]
        public string EQUIPMENT_TYPE { get; set; }

        [Category("검색조건"), Description("CM_EQUIPMENT_CONDITON"), DisplayName("설비상태"), TypeConverter(typeof(ComboStringConverter))]
        public string EQUIPMENT_STATUS { get; set; }
    }
}
