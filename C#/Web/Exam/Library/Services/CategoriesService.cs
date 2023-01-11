namespace Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Library.Data;
    using Library.Models.Category;
    using Library.Services.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private readonly LibraryDbContext dbContext;

        public CategoriesService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var categories = await this.dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }
    }
}
