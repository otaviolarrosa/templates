namespace TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.UnityOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}