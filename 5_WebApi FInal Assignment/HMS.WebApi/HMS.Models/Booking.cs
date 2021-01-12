using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Booking
    {
        public int Booking_Id { get; set; }
        public string Booking_Date { get; set; }
        public int Room_Id { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
    }
}
