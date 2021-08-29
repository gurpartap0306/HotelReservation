using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HotelReservation.Controllers
{
    public class BookingController : Controller
    {

        private hotelContext _db;

        //constructor
        public BookingController(hotelContext db)
        {
            _db = db;
        }

        //Index method
        public IActionResult Index()
        {
            IEnumerable<Customer1> customer = _db.Customer1s;
            return View();
        }

        //room search
        [HttpPost]
        public IActionResult SearchRoom(DateTime From, DateTime To, string city, int room, string type, int guest)
        {
            TempData["Type"] = type;
            TempData["StartDate"] = From;
            TempData["EndDate"] = To;
            TempData["GuestCount"] = guest;
            TempData["Room"] = room;
            TempData["Hid"] = city.Equals("Halifax") ? 1 : city.Equals("Toronto") ? 2 : 3;
            int Testint = 1;

            int id;
            id = city.Equals("Halifax") ? 1 : city.Equals("Toronto") ? 2 : 3;
            IEnumerable<AvailableHotelRoom1> obj = null;
            int flag = 0;

            /*
            for (var day = From.Date; day.Date <= To.Date; day = day.AddDays(1))
            {
                IQueryable<AvailableHotelRoom1> availableHotelRoom1s = _db.AvailableHotelRoom1s.Where(a => a.Date == day && a.Type == type && a.HotelId == id);
                IEnumerable<AvailableHotelRoom1> temp = availableHotelRoom1s;


                foreach (AvailableHotelRoom1 i in temp)
                {
                    if (i.AvailRoom != null && i.AvailRoom >= 10)
                    {
                        flag = 1;
                        break;
                    }
                }

                if (temp != null && temp.A)
                {
                    message = "room not availabel";
                    break;
                    
                }


                //  if(temp != null)
                // obj = obj.Concat(temp);

            }
            */
            TempData["x"] = flag;

            /*
            if(type.Equals("King"))
            return RedirectToAction("KingRoom");
            else
                return RedirectToAction("DoubleRoom")*/
            if (DateTime.Compare((DateTime)TempData["EndDate"], (DateTime)TempData["StartDate"]) > 0)
            {
                return RedirectToAction("RoomList");
            }
            else
            {
                TempData["DateError"] = "Check out date should after check in date!!";
                return Redirect("Index");

            }
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public IActionResult KingRoom()
        {
            return View();
        }
        public IActionResult DoubleRoom()
        {
            return View();
        }
        public IActionResult CustomerInfo()
        {
            

            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Error", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<Users1>(HttpContext.Session.GetString("UserSession"));

                TempData["Uid"] = user.Id;
                return View();
            }
        }


        [HttpPost]
        public IActionResult AddCustomer(Customer1 obj)
        {
            int id = _db.Customer1s.Max(c => c.CustomerId);
            TempData["Cid"] = id + 1;

            _db.Customer1s.Add(obj);
            _db.SaveChanges();

            return View();
        }



        //Payment
        public IActionResult Payment(string paymethod)
        {
            TempData["paymethod"] = paymethod;
            Bookings1 booking = new Bookings1();

            booking.Uid = TempData["Uid"] != null ? (int)TempData["Uid"] : 7;
            booking.Cid = (int)TempData["Cid"];
            booking.Hid = (int)TempData["Hid"];
            booking.StartDate = (DateTime)TempData["StartDate"];
            booking.EndDate = (DateTime)TempData["EndDate"];
            booking.GuestCount = (int)TempData["GuestCount"];

            _db.Bookings1s.Add(booking);
            _db.SaveChanges();
            TempData["BookingId"] = _db.Bookings1s.Max(c => c.BookingId);

            Transaction1 transaction = new Transaction1
            {
                BookingId = (int)TempData["BookingId"],
                TransactionDate = DateTime.Today,
                Amount = "150",
                Paymethod = (string)TempData["Paymethod"]
            };
            _db.Transaction1s.Add(transaction);
            _db.SaveChanges();
            TempData["Amount"] = transaction.Amount;
            int total_amount;
            if ((string)TempData["Type"] == "king")
            {
                total_amount = 180 * (int)TempData["Room"];
            }
            else
            {
                total_amount = 220 * (int)TempData["Room"];
            }
            TempData["Total_Amount"] = total_amount;

            return View();

        }
    }
}
