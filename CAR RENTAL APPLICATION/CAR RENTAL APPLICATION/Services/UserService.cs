using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class UserService : BaseService
    {
        public UserService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<User> GetUser()
        {
            return repositoryWrapper.UserRepository.FindAll().ToList();
        }

        public List<User> GetUserByCondition(Expression<Func<User, bool>> expression)
        {
            return repositoryWrapper.UserRepository.FindByCondition(expression).ToList();
        }

        public void AddUser(User User)
        {
            repositoryWrapper.UserRepository.Create(User);
        }

        public void UpdateUser(User User)
        {
            repositoryWrapper.UserRepository.Update(User);
        }

        public void DeleteUser(User User)
        {
            repositoryWrapper.UserRepository.Delete(User);
        }
    }
}
