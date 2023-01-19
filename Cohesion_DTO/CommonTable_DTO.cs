using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class CommonTable_DTO
    {
        public string CODE_TABLE_NAME { get; set; }
        public string CODE_TABLE_DESC { get; set; }
        public string KEY_1_NAME { get; set; }
        public string KEY_2_NAME { get; set; }
        public string KEY_3_NAME { get; set; }
        public string DATA_1_NAME { get; set; }
        public string DATA_2_NAME { get; set; }
        public string DATA_3_NAME { get; set; }
        public string DATA_4_NAME { get; set; }
        public string DATA_5_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATE_USER_ID { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public string UPDATE_USER_ID { get; set; }
    }
}
