using System;
using System.Collections.Generic;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Transaction1
    {
        public int TransactionId { get; set; }
        public int BookingId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Amount { get; set; }
        public string Paymethod { get; set; }
        public string Status { get; set; }

        public virtual Bookings1 Booking { get; set; }
    }
}
