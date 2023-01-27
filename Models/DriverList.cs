using Newtonsoft.Json.Linq;
using System;

namespace DriverTracking.Models
{
    public class DriverList
    {
        public string _id { get; set; }
        //public string reg { get; set; }
        public string vcolour { get; set; }
        public string vmake { get; set; }
        public string vmodel { get; set; }
        public string vtype { get; set; }
        public string lng { get; set; }
        public string lat { get; set; }
        public int accuracy { get; set; }
        public string isvirtual { get; set; }
        public string callsign { get; set; }
        public string name { get; set; }
        public string office_id { get; set; }
        public string state { get; set; }
        public string lstate { get; set; }
        public string battery { get; set; }
        public string clrtimestamp { get; set; }
        public loc loc { get; set; }
        public string outcodetime { get; set; }
        public string timestamp { get; set; }
        public string jobid { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int priority { get; set; }
        public string outcode { get; set; }
        public string speed { get; set; }
        public string telephone { get; set; }
    }
    public class loc
    {
        public string type { get; set; }
        public JArray coordinates { get; set; }





    }
}
