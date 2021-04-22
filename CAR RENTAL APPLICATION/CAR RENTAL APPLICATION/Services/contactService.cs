using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class contactService : BaseService
    {
        public contactService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<contact> GetContact()
        {
            return repositoryWrapper.contactRepository.FindAll().ToList();
        }

        public List<contact> GetContactByCondition(Expression<Func<contact, bool>> expression)
        {
            return repositoryWrapper.contactRepository.FindByCondition(expression).ToList();
        }

        public void AddContact(contact contact)
        {
            repositoryWrapper.contactRepository.Create(contact);
        }

        public void UpdateContact(contact contact)
        {
            repositoryWrapper.contactRepository.Update(contact);
        }

        public void DeleteContact(contact contact)
        {
            repositoryWrapper.contactRepository.Delete(contact);
        }
    }
}
