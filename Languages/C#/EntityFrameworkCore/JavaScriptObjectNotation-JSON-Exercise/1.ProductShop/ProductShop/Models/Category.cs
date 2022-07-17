namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
