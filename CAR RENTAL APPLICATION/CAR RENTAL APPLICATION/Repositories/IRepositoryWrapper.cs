namespace CAR_RENTAL_APPLICATION.Repositories

{
    public interface IRepositoryWrapper
    {
 
        InewsletterRepository newsletterRepository { get; }

        IcontactRepository contactRepository { get; }

        IUserRepository UserRepository { get; }
        ImailingListRepository mailingListRepository { get; }

        ICarRepository CarRepository { get; }
        

        ICarRecordRepository CarRecordRepository { get; }

        IPaymentRepository PaymentRepository { get; }

        IPaymentMethodRepository PaymentMethodRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        void Save();
    }
}
