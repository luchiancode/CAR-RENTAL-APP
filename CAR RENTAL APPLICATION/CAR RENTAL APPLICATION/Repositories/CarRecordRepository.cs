using CAR_RENTAL_APPLICATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Repositories
{
    public class CarRecordRepository : RepositoryBase<CarRecord>, ICarRecordRepository
    {
        public CarRecordRepository(CarsContext CarRecordContext)
            : base(CarRecordContext)
        {
        }
    }
}
