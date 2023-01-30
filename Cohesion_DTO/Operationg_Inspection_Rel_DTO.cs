using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Operationg_Inspection_Rel_DTO
    {
        public string OPERATION_CODE { get; set; }
        public string INSPECT_ITEM_CODE { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public string UPDATE_USER_ID { get; set; }
    }

    public class Operationg_Inspection_Rel_Search
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
    }
}
