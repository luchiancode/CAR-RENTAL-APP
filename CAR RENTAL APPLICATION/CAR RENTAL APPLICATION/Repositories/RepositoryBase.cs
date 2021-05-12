using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using CAR_RENTAL_APPLICATION.Models;

namespace CAR_RENTAL_APPLICATION.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarsContext mdbContext { get; set; }

        public RepositoryBase(CarsContext mdbContext)
        {
            this.mdbContext = mdbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.mdbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.mdbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            this.mdbContext.Set<T>().Add(entity);
        }
        public void Create(T entity)
        {
            this.mdbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.mdbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.mdbContext.Set<T>().Remove(entity);
        }

    }
}
