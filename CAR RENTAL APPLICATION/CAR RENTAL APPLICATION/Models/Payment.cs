using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
