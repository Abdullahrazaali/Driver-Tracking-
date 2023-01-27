using MongoDB.Driver;

namespace DriverTracking.Models
{
    
   
    public class Booking 
    {
       
        //public static Booking sharedInstance = new Booking();

        //public Booking()
        //{

        //}


        public object _id { get; set; }
        public string account { get; set; }
        public string accuser { get; set; }
        public string bookedby { get; set; }
        public bool changed { get; set; }
        public string comment { get; set; }
        public string creditcard { get; set; }
        public string cstate { get; set; }
        public string custname { get; set; }
        public string date { get; set; }
        public double datentime { get; set; }
        public double despatchtime { get; set; }
        public string driverrate { get; set; }
        public double drvfare { get; set; }
        public string drvrcallsign { get; set; }
        public string drvreqdname { get; set; }
        public string drvrname { get; set; }
        public string drvrreqcallsign { get; set; }
        public string dstate { get; set; }
        public double fare { get; set; }
        public int flag { get; set; }
        public string flightno { get; set; }
        public string from { get; set; }
        public string from_info { get; set; }
        public string from_outcode { get; set; }
        public viaData[] fromtovia { get; set; }
        public bool hold { get; set; }
        public bool isdirty { get; set; }
        public double jobmileage { get; set; }
        public string jobref { get; set; }
        public string jobtype { get; set; }
        public string jstate { get; set; }
        public double leadtime { get; set; }
        public object[] logc { get; set; }
        public object[] logd { get; set; }
        public string mstate { get; set; }
        public int numofvia { get; set; }
        public string office { get; set; }
        public double oldfare { get; set; }
        public double olddrvfare { get; set; }
        public string orderno { get; set; }
        public string tag { get; set; }
        public string telephone { get; set; }
        public string time { get; set; }
        public double timetodespatch { get; set; }
        public string to { get; set; }
        public string to_info { get; set; }
        public string to_outcode { get; set; }
        public string userid { get; set; }
        public string vehicletype { get; set; }
        public string pin { get; set; }
        public string callerid { get; set; }
        public double price { get; set; }
    }

    public  class DriverData: Booking
    {
        public double lattitude { get; set; }

        public double longittitude { get; set; }
    }

    public class viaData
    {
        public string info { get; set; }
        public string address { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string postcode { get; set; }
    }
}

