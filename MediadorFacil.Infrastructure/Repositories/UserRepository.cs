using MediadorFacil.Domain.AccountAggregate;
using MediadorFacil.Domain.AccountAggregate.Repository;
using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;

namespace MediadorFacil.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MediadorFacilContext context) : base(context)
        {
        }
    }
}
