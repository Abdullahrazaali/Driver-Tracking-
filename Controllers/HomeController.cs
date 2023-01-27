using DriverTracking.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Security.Cryptography;

namespace DriverTracking.Controllers
{
    public class HomeController : Controller
    {
        SocketConnection sc = new SocketConnection();
        List<DriverList> list1 = new List<DriverList>();
        Booking book = new Booking();  
        DbConnect db = new DbConnect();
        public IActionResult Index()
        {
           // 63c7dd57b82d272434b07864
            //try
            //{
            //    ObjectId ID = ObjectId.Parse(id);
            //    var Collection = db.database.GetCollection<Booking>("Booking");
            //    var filter = Builders<Booking>.Filter.Eq("_id", ID);
            //    Booking documents = Collection.Find(filter).FirstOrDefault();

            //    ViewData["BookingData"] = documents;


            //}
            //catch (Exception)
            //{

            //}
            //return RedirectToAction("CheckBooking");
            return View();
        }

        // public static string jobref;

        [HttpPost]
        public IActionResult Index([FromBody] Jobrefmodel job)
        {
            // double Originlat;
            // double Originlng;

            var resulta = (dynamic)null;

            // Booking b
            //Booking.sharedInstance = null;

            try
            {
                Booking booking = sc.GetData(job.jobref);
                resulta = new { companyname = booking.logc[0], olat = booking.fromtovia[0].lat, olon = booking.fromtovia[0].lon, date = booking.date, time = booking.time, custname = booking.custname, from = booking.from, to = booking.to, fare = booking.fare, oldfare = booking.oldfare, comment = booking.comment, bookedby = booking.bookedby, jstate = booking.jstate, cstate = booking.cstate, dstate = booking.dstate, flag =booking.flag };
     
            }
            catch (Exception)
            {

            }

            return Json (resulta);
        }

        public IActionResult Map()
        {
            return View();
        }
        //public IActionResult CheckBooking()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult CheckBooking(string _id)
        {
            if (String.IsNullOrEmpty(_id) ==  true)
            {
                return Json(new { success = false, message = "No-Result Found" });
            }
            ObjectId ID = ObjectId.Parse(_id);
            var Collection = db.database.GetCollection<DriverData>("Booking");
            var filter = Builders<DriverData>.Filter.Eq("_id", ID);
            DriverData document = Collection.Find(filter).FirstOrDefault();
            if (document==null) 
            {
                return Json(new { success = false, message = "No-Result Found" });
            }
            if (document.cstate!="cancelled" && document.jstate != "JobDone" && document.drvrcallsign.Trim()!="" && document.drvrcallsign.Trim().Contains("@")==true )
            {
              var DrvrCallSign =document.drvrcallsign.Split("@");
                var Callsign = DrvrCallSign[0];
                var office = DrvrCallSign[1];
                var Drvrloccollection = db.database.GetCollection<BsonDocument>("Driverloc");
                var filter1 = Builders<BsonDocument>.Filter.Eq("callsign",Callsign);
                var filter2 = Builders<BsonDocument>.Filter.Eq("office_id", office);
                var CombineFilter= Builders<BsonDocument>.Filter.And(filter1, filter2);
                BsonDocument result = Drvrloccollection.Find(CombineFilter).FirstOrDefault();
                if (result!=null) {

                    var latitude = Convert.ToDouble(result.GetValue("lat"));
                    var longitude =Convert.ToDouble(result.GetValue("lng"));
                    document.lattitude = latitude;
                    document.longittitude = longitude;
                   return Json(new { success = true, obj = document });
                    

                }
                else
                {
                    return Json(new { success = false ,message ="we are finding driver for you."});
                }
            }
            else
            {
                return Json(new { success = true, message = "No-Result Found", obj = document });
            }
        }

        [HttpPost]
        public IActionResult GetBooking(string _id)
        {
            //63cbddf1b82d271ad43325d5
            if (String.IsNullOrEmpty(_id) == true)
            {
                return Json(new { success = false, message = "No-Result Found" });
            }
            ObjectId ID = ObjectId.Parse(_id)

                ;
            var Collection = db.database.GetCollection<DriverData>("Booking");
            var filter = Builders<DriverData>.Filter.Eq("_id", ID);
            DriverData document = Collection.Find(filter).FirstOrDefault();
            if (document == null)
            {
                return Json(new { success = false, message = "No-Result Found" });
            }
            else
            {
                return Json(new { success = true, message = "No-Result Found", obj = document });
            }
        }


        [HttpPost]
        public JsonResult Map(string str)

        {
            double let = 0;
            double lng = 0;
            try
            {
                // changes here 1 and map
                if (book.jstate == "allocated" && book.cstate == "despatched" && book.dstate == "Accepted" && book.flag == 1)
                {
                    // sc.socket_connect();
                    list1 = sc.Getdriverslist();
                    foreach (var item in list1)
                    {
                        HttpContext.Session.SetString("callsign", item.callsign);
                        HttpContext.Session.SetString("lat", item.lat);
                        let = Convert.ToDouble(item.lat);
                        HttpContext.Session.SetString("lng", item.lng);
                        lng = Convert.ToDouble(item.lng);
                        HttpContext.Session.SetString("speed", item.speed);
                    }

                    return Json (new { let = let, lng = lng });

                }

                else

                {

                    return Json(new { let = "", lng = "" });
                }

            }
            catch (Exception)
            {

            }

            // DriverList
            return Json(new { let = "", lng = "" });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    } 
}
