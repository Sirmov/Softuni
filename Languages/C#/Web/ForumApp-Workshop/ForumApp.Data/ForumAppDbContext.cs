namespace ForumApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using ForumApp.Data.Entities;
    using ForumApp.Data.Configurations;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext()
        {
        }

        public ForumAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=localhost;Database=ForumApp;User Id=username;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostSeeder());

            base.OnModelCreating(builder);
        }
    }
}
