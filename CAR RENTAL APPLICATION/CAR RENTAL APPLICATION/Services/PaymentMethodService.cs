using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class PaymentMethodService : BaseService
    {
        public PaymentMethodService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<PaymentMethod> GetPaymentMethod()
        {
            return repositoryWrapper.PaymentMethodRepository.FindAll().ToList();
        }

        public List<PaymentMethod> GetPaymentMethodByCondition(Expression<Func<PaymentMethod, bool>> expression)
        {
            return repositoryWrapper.PaymentMethodRepository.FindByCondition(expression).ToList();
        }

        public void AddPaymentMethod(PaymentMethod PaymentMethod)
        {
            repositoryWrapper.PaymentMethodRepository.Create(PaymentMethod);
        }

        public void UpdatePaymentMethod(PaymentMethod PaymentMethod)
        {
            repositoryWrapper.PaymentMethodRepository.Update(PaymentMethod);
        }

        public void DeletePaymentMethod(PaymentMethod PaymentMethod)
        {
            repositoryWrapper.PaymentMethodRepository.Delete(PaymentMethod);
        }
    }
}
