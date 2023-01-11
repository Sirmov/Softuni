namespace Library.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Library.Data.Entities;

    public class ApplicationUserBookConfiguration : IEntityTypeConfiguration<ApplicationUserBook>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserBook> builder)
        {
            builder.HasKey(aub => new { aub.ApplicationUserId, aub.BookId });
        }
    }
}
