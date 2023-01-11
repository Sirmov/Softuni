namespace Watchlist.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Rating { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
