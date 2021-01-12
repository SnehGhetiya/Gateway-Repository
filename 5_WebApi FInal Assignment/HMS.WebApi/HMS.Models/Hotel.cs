using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Hotel
    {
        public int Hotel_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Contact_Number { get; set; }
        public string Contact_Person { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string IsActive { get; set; }
        public string Created_Date { get; set; }
        public string Created_By { get; set; }
        public string Updated_Date { get; set; }
        public string Updated_By { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
