using CAR_RENTAL_APPLICATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(CarsContext PaymentContext)
            : base(PaymentContext)
        {
        }

    }
}
