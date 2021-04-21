using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class CarRecord
    {
        public int CarRecordId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime DateAdded { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
    }
}
