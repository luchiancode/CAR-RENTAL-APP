using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class CarRecordService : BaseService
    {
        public CarRecordService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<CarRecord> GetCarRecord()
        {
            return repositoryWrapper.CarRecordRepository.FindAll().ToList();
        }

        public List<CarRecord> GetCarRecordByCondition(Expression<Func<CarRecord, bool>> expression)
        {
            return repositoryWrapper.CarRecordRepository.FindByCondition(expression).ToList();
        }

        public void AddCarRecord(CarRecord CarRecord)
        {
            repositoryWrapper.CarRecordRepository.Create(CarRecord);
        }

        public void UpdateCarRecord(CarRecord CarRecord)
        {
            repositoryWrapper.CarRecordRepository.Update(CarRecord);
        }

        public void DeleteCarRecord(CarRecord CarRecord)
        {
            repositoryWrapper.CarRecordRepository.Delete(CarRecord);
        }
    }
}
