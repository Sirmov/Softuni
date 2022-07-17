using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
