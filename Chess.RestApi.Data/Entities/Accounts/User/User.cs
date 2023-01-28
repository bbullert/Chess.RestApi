using Microsoft.AspNetCore.Identity;

namespace Chess.RestApi.Data.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
    }
}
