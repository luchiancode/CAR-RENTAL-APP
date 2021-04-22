using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class mailingListService : BaseService
    {
        public mailingListService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<mailingList> GetMailingList()
        {
            return repositoryWrapper.mailingListRepository.FindAll().ToList();
        }

        public List<mailingList> GetMailingListByCondition(Expression<Func<mailingList, bool>> expression)
        {
            return repositoryWrapper.mailingListRepository.FindByCondition(expression).ToList();
        }

        public void AddMailingList(mailingList mailingList)
        {
            repositoryWrapper.mailingListRepository.Create(mailingList);
        }

        public void UpdateMailingList(mailingList mailingList)
        {
            repositoryWrapper.mailingListRepository.Update(mailingList);
        }

        public void DeleteMailingList(mailingList mailingList)
        {
            repositoryWrapper.mailingListRepository.Delete(mailingList);
        }
    }
}
