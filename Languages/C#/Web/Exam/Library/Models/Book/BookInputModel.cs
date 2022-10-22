namespace Library.Models.Book
{
    using System.ComponentModel.DataAnnotations;

    using Library.Models.Category;
    using static Library.Data.DataConstants.Book;

    public class BookInputModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLenght)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinRange, RatingMaxRange, ConvertValueInInvariantCulture = true, ParseLimitsInInvariantCulture = true)]
        public string Rating { get; set; } = null!;

        [Required]
        public string CategoryId { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories = new List<CategoryViewModel>();
    }
}
