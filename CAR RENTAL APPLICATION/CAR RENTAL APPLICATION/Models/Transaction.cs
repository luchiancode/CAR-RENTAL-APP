using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public int CarId { get; set; }
        public int OwnerId { get; set; }
        public int PaymentId { get; set; }
        public DateTime TimeStamp { get; set; }
        
        public User User { get; set; }
        public Car Car { get; set; }
        public Payment Payment { get; set; }
    }
}
