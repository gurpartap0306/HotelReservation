using System;
using System.Collections.Generic;

#nullable disable

namespace HotelReservation.Models
{
    public partial class AvailableHotelRoom1
    {
        public int HotelId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int? AvailRoom { get; set; }

        public virtual Hotel1 Hotel { get; set; }
    }
}
