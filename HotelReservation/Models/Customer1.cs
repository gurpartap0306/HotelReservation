using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Customer1
    {
        public Customer1()
        {
            Bookings1s = new HashSet<Bookings1>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Street Number is required")]
        [StringLength(20)]
        public string StreetNo { get; set; }

        [Required(ErrorMessage = "The City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "The Province is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string Province { get; set; }

        [Required(ErrorMessage = "The Country is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Postal Code is required")]
        [StringLength(6)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Use letters and numbers only please")]
        public string PostalCode { get; set; }

        

        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public virtual ICollection<Bookings1> Bookings1s { get; set; }
    }
}
