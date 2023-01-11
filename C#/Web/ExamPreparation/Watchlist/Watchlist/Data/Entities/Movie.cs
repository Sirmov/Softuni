namespace Watchlist.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.DataConstants.Movie;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        // Navigational properties

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; } = null!;

        public virtual ICollection<UserMovie> UsersMovies { get; set; } = null!;
    }
}
