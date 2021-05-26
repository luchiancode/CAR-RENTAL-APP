using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class PaymentMethod
    {
      

        public PaymentMethod(int PaymentMethodId, string pName)
        {
            this.PaymentMethodId = PaymentMethodId;
            this.PName = pName;
        }

        public int PaymentMethodId { get; set; }
        public string PName { get; set; }
    }
}
