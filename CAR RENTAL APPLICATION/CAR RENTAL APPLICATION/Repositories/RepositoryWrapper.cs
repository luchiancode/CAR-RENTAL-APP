using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAR_RENTAL_APPLICATION.Models;

namespace CAR_RENTAL_APPLICATION.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CarsContext _CarsContext;
     
        private InewsletterRepository _newsletterRepository;

        private IcontactRepository _IcontactRepository;
        private ImailingListRepository _ImailingListRepository;
        private IUserRepository _IUserRepository;
        private ICarRepository _ICarRepository;
        private ICarRecordRepository _ICarRecordRepository;

        private IPaymentRepository _IPaymentRepository;

        private IPaymentMethodRepository _IPaymentMethodRepository;

        private ITransactionRepository _ITransactionRepository;

        public InewsletterRepository newsletterRepository
        {
            get
            {
                if (_newsletterRepository == null)
                {
                    _newsletterRepository = new newsletterRepository(_CarsContext);
                }
                return _newsletterRepository;
            }
        }

        public IcontactRepository contactRepository
        {
            get
            {
                if (_IcontactRepository == null)
                {
                    _IcontactRepository = new contactRepository(_CarsContext);
                }
                return _IcontactRepository;
            }
        }

        public ImailingListRepository mailingListRepository
        {
            get
            {
                if (_ImailingListRepository == null)
                {
                    _ImailingListRepository = new mailingListRepository(_CarsContext);
                }
                return _ImailingListRepository;
            }
        }



        public IUserRepository UserRepository
        {
            get
            {
                if (_IUserRepository == null)
                {
                    _IUserRepository = new UserRepository(_CarsContext);
                }
                return _IUserRepository;
            }
        }

        public ICarRepository CarRepository
        {
            get
            {
                if (_ICarRepository == null)
                {
                    _ICarRepository = new CarRepository(_CarsContext);
                }
                return _ICarRepository;
            }
        }

        public ICarRecordRepository CarRecordRepository
        {
            get
            {
                if (_ICarRecordRepository == null)
                {
                    _ICarRecordRepository = new CarRecordRepository(_CarsContext);
                }
                return _ICarRecordRepository;
            }
        }

        
        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_IPaymentRepository == null)
                {
                    _IPaymentRepository = new PaymentRepository(_CarsContext);
                }
                return _IPaymentRepository;
            }
        }


        public IPaymentMethodRepository PaymentMethodRepository
        {
            get
            {
                if (_IPaymentMethodRepository == null)
                {
                    _IPaymentMethodRepository = new PaymentMethodRepository(_CarsContext);
                }
                return _IPaymentMethodRepository;
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_ITransactionRepository == null)
                {
                    _ITransactionRepository = new TransactionRepository(_CarsContext);
                }
                return _ITransactionRepository;
            }
        }



        public RepositoryWrapper(CarsContext CarsContext)
        {
            _CarsContext = CarsContext;
        }

        public void Save()
        {
            _CarsContext.SaveChanges();
        }
    }
}