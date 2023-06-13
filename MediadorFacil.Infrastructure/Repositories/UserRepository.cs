using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.Account.Repository;
using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MediadorFacil.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MediadorFacilContext context) : base(context)
        {
           
        }
        public async Task<IEnumerable<User>> ObterTodosUsuarios()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<IEnumerable<User>> ObterUsuarioPorId(Guid id)
        {
            return await this.Query.Where(x => x.Id == id).ToListAsync();
        }
    }
}
