using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class TransactionService : BaseService
    {
        public TransactionService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Transaction> GetTransaction()
        {
            return repositoryWrapper.TransactionRepository.FindAll().ToList();
        }

        public List<Transaction> GetTransactionByCondition(Expression<Func<Transaction, bool>> expression)
        {
            return repositoryWrapper.TransactionRepository.FindByCondition(expression).ToList();
        }

        public void AddTransaction(Transaction Transaction)
        {
            repositoryWrapper.TransactionRepository.Create(Transaction);
        }

        public void UpdateTransaction(Transaction Transaction)
        {
            repositoryWrapper.TransactionRepository.Update(Transaction);
        }

        public void DeleteTransaction(Transaction Transaction)
        {
            repositoryWrapper.TransactionRepository.Delete(Transaction);
        }
    }
}
