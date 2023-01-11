namespace Watchlist.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        // Navigational properties

        public virtual ICollection<UserMovie> UsersMovies { get; set; } = null!;
    }
}
