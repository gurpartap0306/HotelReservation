using System;
using System.Collections.Generic;

#nullable disable

namespace HotelReservation.Models
{
    public partial class Bookings1
    {
        public Bookings1()
        {
            Room1s = new HashSet<Room1>();
            Transaction1s = new HashSet<Transaction1>();
        }

        public int BookingId { get; set; }
        public int Cid { get; set; }
        public int Uid { get; set; }
        public int Hid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }

        public virtual Customer1 CidNavigation { get; set; }
        public virtual Hotel1 HidNavigation { get; set; }
        public virtual Users1 UidNavigation { get; set; }
        public virtual ICollection<Room1> Room1s { get; set; }
        public virtual ICollection<Transaction1> Transaction1s { get; set; }
    }
}
