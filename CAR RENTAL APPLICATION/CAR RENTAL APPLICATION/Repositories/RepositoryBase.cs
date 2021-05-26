using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;

namespace CAR_RENTAL_APPLICATION.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarsContext carsContext { get; set; }

        public RepositoryBase(CarsContext carsContext)
        {
            this.carsContext = carsContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.carsContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.carsContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            this.carsContext.Set<T>().Add(entity);
        }
        public void Create(T entity)
        {
            this.carsContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.carsContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.carsContext.Set<T>().Remove(entity);
        }

    }
}
