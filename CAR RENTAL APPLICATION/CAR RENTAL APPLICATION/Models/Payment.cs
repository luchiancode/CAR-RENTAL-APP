using CAR_RENTAL_APPLICATION.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class Payment
    {


        public Payment(int PaymentId, int PaymentMethodId, DateTime TimeStamp, int Amount, PaymentMethod paymentMethod)
        {
            this.PaymentId = PaymentId;
            this.PaymentMethodId = PaymentMethodId;
            this.TimeStamp = TimeStamp;
            this.Amount = Amount;
            this.PaymentMethod = paymentMethod;
        }

        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }
        public int Amount { get; set; }
        public DateTime TimeStamp { get; set; }

        public PaymentMethod PaymentMethod { get; set; }


    }
}
