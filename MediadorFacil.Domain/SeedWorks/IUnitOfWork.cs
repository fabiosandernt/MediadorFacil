
namespace MediadorFacil.Domain.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
