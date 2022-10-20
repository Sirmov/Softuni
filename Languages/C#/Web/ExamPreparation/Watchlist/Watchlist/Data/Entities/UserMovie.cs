namespace Watchlist.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserMovie
    {
        public string UserId { get; set; }

        public int MovieId { get; set; }

        // Navigational properties

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } = null!;
    }
}
