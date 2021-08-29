using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Users1
    {
        public Users1()
        {
            Bookings1s = new HashSet<Bookings1>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9]+\.[A-Za-z]{2,4}", ErrorMessage = "Please input valid email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your email")]
        [Compare("Email", ErrorMessage = "Please input the same email")]
        public string ConfirmEmail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input password")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Bookings1> Bookings1s { get; set; }
    }
}
