namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;
    using Watchlist.Data.Entities;
    using static Watchlist.Data.DataConstants.Movie;

    public class MovieInputModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength)]
        public string Director { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinRange, RatingMaxRange, ConvertValueInInvariantCulture = true, ParseLimitsInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
