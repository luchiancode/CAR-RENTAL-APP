namespace CAR_RENTAL_APPLICATION.Repositories

{
    public interface IRepositoryWrapper
    {
 
        InewsletterRepository newsletterRepository { get; }

        IcontactRepository contactRepository { get; }

        IUserRepository UserRepository { get; }
        ImailingListRepository mailingListRepository { get; }

     


        void Save();
    }
}
