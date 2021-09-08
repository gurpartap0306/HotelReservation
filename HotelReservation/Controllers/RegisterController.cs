using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class RegisterController : Controller
    {
        private hotelContext _db;

        public RegisterController(hotelContext db)
        {
           _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users1 obj)
        {
            _db.Users1s.Add(obj);
            _db.SaveChanges();
            return View();
        }


    }
}
