using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class newsletterService : BaseService
    {
        public newsletterService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<newsletter> Getnewsletter()
        {
            return repositoryWrapper.newsletterRepository.FindAll().ToList();
        }

        public List<newsletter> GetNewsletterByCondition(Expression<Func<newsletter, bool>> expression)
        {
            return repositoryWrapper.newsletterRepository.FindByCondition(expression).ToList();
        }

        public void AddNewsletter(newsletter newsletter)
        {
            repositoryWrapper.newsletterRepository.Create(newsletter);
        }

        public void UpdateNewsletter(newsletter newsletter)
        {
            repositoryWrapper.newsletterRepository.Update(newsletter);
        }

        public void DeleteNewsletter(newsletter newsletter)
        {
            repositoryWrapper.newsletterRepository.Delete(newsletter);
        }
    }
}
