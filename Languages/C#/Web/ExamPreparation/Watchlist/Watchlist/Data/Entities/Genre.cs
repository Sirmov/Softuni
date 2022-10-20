namespace Watchlist.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        // Navigational properties

        public virtual ICollection<Movie> Movies { get; set; } = null!;
    }
}
