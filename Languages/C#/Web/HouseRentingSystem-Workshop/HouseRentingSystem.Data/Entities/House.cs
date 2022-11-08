namespace HouseRentingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static HouseRentingSystem.Common.DataConstants.House;

    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AgentId { get; set; }

        public string? RenterId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(AgentId))]
        public virtual Agent Agent { get; set; } = null!;
    }
}
