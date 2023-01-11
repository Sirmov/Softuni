namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public virtual User Buyer { get; set; }

        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public virtual User Seller { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}