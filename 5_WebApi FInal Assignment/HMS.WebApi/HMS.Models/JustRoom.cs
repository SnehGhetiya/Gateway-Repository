using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class JustRoom
    {
        public int Hotel_Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string IsActive { get; set; }
        public string Created_Date { get; set; }
        public string Created_By { get; set; }
        public string Updated_Date { get; set; }
        public string Updated_By { get; set; }
    }
}
