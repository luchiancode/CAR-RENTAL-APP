using CAR_RENTAL_APPLICATION.Repositories;

namespace CAR_RENTAL_APPLICATION.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper repositoryWrapper;

        public BaseService(IRepositoryWrapper IRepositoryWrapper)
        {
            repositoryWrapper = IRepositoryWrapper;
        }

        public void Save()
        {
            repositoryWrapper.Save();
        }
    }
}
