using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Inspection_DTO
    {
        [Category("속성"), Description("INSPECT_ITEM_CODE"), DisplayName("검사 항목"), ReadOnly(false)]
        public string INSPECT_ITEM_CODE { get; set; }
        
        [Category("속성"), Description("INSPECT_ITEM_NAME"), DisplayName("검사 항목명")]
        public string INSPECT_ITEM_NAME { get; set; }

        [Category("속성"), Description("VALUE_TYPE"), DisplayName("값 유형"), TypeConverter(typeof(ComboInspectUnitConverter))]
        public char VALUE_TYPE { get; set; }
        
        [Category("속성"), Description("SPEC_LSL"), DisplayName("규격 하한")]
        public string SPEC_LSL { get; set; }

        [Category("속성"), Description("SPEC_TARGET"), DisplayName("평균 규격")]
        public string SPEC_TARGET { get; set; }

        [Category("속성"), Description("SPEC_USL"), DisplayName("규격 상한")]
        public string SPEC_USL { get; set; }
        
        [Category("추적"), Description("CREATE_TIME"), DisplayName("생성 시간"), ReadOnly(true)]
        public DateTime CREATE_TIME { get; set; }  //생성 시간

        [Category("추적"), Description("CREATE_USER_ID"), DisplayName("생성 사용자"), ReadOnly(true)]
        public string CREATE_USER_ID { get; set; }    //생성 사용자

        [Category("추적"), Description("UPDATE_TIME"), DisplayName("변경 시간"), ReadOnly(true)]
        public DateTime? UPDATE_TIME { get; set; }  //변경 시간

        [Category("추적"), Description("UPDATE_USER_ID"), DisplayName("변경 사용자"), ReadOnly(true)]
        public string UPDATE_USER_ID { get; set; }    //변경 사용자
    }

    public class Inspection_DTO_Search
    {
        [Category("속성"), Description("INSPECT_ITEM_CODE"), DisplayName("검사 항목"), ReadOnly(false)]
        public string INSPECT_ITEM_CODE { get; set; }

        [Category("속성"), Description("VALUE_TYPE"), DisplayName("값 유형"), TypeConverter(typeof(ComboInspectUnitConverter))]
        public char VALUE_TYPE { get; set; }
    }
}
