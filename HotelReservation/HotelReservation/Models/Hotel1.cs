using System;
using System.Collections.Generic;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Hotel1
    {
        public Hotel1()
        {
            AvailableHotelRoom1s = new HashSet<AvailableHotelRoom1>();
            Bookings1s = new HashSet<Bookings1>();
        }

        public int HotelId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<AvailableHotelRoom1> AvailableHotelRoom1s { get; set; }
        public virtual ICollection<Bookings1> Bookings1s { get; set; }
    }
}
