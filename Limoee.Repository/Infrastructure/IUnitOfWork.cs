namespace Limoee.Repository.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}