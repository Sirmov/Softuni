namespace HouseRentingSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using HouseRentingSystem.Data.Entities;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private IEnumerable<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cottage"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Single-Family"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Duplex"
                }

             };

            return categories;
        }
    }
}
