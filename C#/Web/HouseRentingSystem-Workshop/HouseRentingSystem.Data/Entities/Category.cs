namespace HouseRentingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static HouseRentingSystem.Common.DataConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<House> Houses { get; set; }
    }
}
