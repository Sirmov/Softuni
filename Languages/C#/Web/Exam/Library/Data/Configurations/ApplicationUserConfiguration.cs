namespace Library.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Library.Data.Entities;
    using static Library.Data.DataConstants.ApplicationUser;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(au => au.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired(true);

            builder.Property(au => au.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired(true);

            builder.HasIndex(au => au.UserName)
                .IsUnique();
        }
    }
}
