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
    public class LoginController : Controller
    {

        private readonly hotelContext _db;

        public LoginController(hotelContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users1 obj)
        {


            var user = _db.Users1s.SingleOrDefault(e => e.Email == obj.Email && e.Password == obj.Password);

            
                if (user != null)
                {
                    HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "Home");
                }
            ViewBag.message = "Please provide correct email and password";

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Index","Home");
        }

        public IActionResult Error()
        {
            return View();
        }
        
    }
}
