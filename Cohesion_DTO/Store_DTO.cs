using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_DTO
{
    public class Store_DTO
    {
        public string   STORE_CODE        { get; set; }
        public string   STORE_NAME        { get; set; }
        public string   STORE_TYPE        { get; set; }
        //public string   FIFO_FLAG         { get; set; }
        public DateTime CREATE_TIME       { get; set; }
        public string   CREATE_USER_ID    { get; set; }
        public DateTime UPDATE_TIME       { get; set; }
        public string   UPDATE_USER_ID    { get; set; }
    }
}
