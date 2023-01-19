using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Equipment_DTO
    {
        public string   EQUIPMENT_CODE      { get; set; }
        public string   EQUIPMENT_NAME      { get; set; }
        public string   EQUIPMENT_TYPE      { get; set; }
        public string   EQUIPMENT_STATUS    { get; set; }
        public DateTime LAST_DOWN_TIME      { get; set; }
        public DateTime CREATE_TIME         { get; set; }
        public string   CREATE_USER_ID      { get; set; }
        public DateTime UPDATE_TIME         { get; set; }
        public string   UPDATE_USER_ID      { get; set; }
    }
}
