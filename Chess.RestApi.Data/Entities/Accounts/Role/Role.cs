using Microsoft.AspNetCore.Identity;

namespace Chess.RestApi.Data.Entities
{
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
    }
}
