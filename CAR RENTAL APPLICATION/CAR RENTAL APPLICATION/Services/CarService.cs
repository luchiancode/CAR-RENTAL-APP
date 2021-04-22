using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class CarService : BaseService
    {
        public CarService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Car> GetCar()
        {
            return repositoryWrapper.CarRepository.FindAll().ToList();
        }

        public List<Car> GetCarByCondition(Expression<Func<Car, bool>> expression)
        {
            return repositoryWrapper.CarRepository.FindByCondition(expression).ToList();
        }

        public void AddCar(Car Car)
        {
            repositoryWrapper.CarRepository.Create(Car);
        }

        public void UpdateCar(Car Car)
        {
            repositoryWrapper.CarRepository.Update(Car);
        }

        public void DeleteCar(Car Car)
        {
            repositoryWrapper.CarRepository.Delete(Car);
        }
    }
}
