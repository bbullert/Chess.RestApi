using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class UserRepository : Repository<Guid, User, ISearchCriteria>, IUserRepository
    {
        public UserRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<User> GetBasicAsync(Guid id)
        {
            return await dbSet
                .Where(x => x.Id == id)
                .Select(x => new User()
                {
                    Id = x.Id,
                    UserName = x.UserName
                })
                .FirstOrDefaultAsync();
        }
    }
}
