using System;
using System.Collections.Generic;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Room1
    {
        public int Rid { get; set; }
        public string Type { get; set; }
        public int? MaxGuest { get; set; }
        public int BookingId { get; set; }
        public int Price { get; set; }

        public virtual Bookings1 Booking { get; set; }
    }
}
