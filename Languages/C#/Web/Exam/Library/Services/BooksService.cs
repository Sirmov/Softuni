namespace Library.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Library.Data;
    using Library.Models.Book;
    using Library.Services.Contracts;
    using Library.Data.Entities;

    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext dbContext;

        public BooksService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await this.dbContext.Books
                .Include(b => b.Category)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating =  b.Rating.ToString("0.00"),
                    Category = b.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<MyBookViewModel>> GetMineAsync(string userId)
        {
            var books = await this.dbContext.Books
                .Include(b => b.ApplicationUsersBooks)
                .ThenInclude(aub => aub.ApplicationUser)
                .Include(b => b.Category)
                .Where(b => b.ApplicationUsersBooks.Any(aub => aub.ApplicationUserId == userId))
                .Select(b => new MyBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating.ToString("0.00"),
                    Category = b.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task AddAsync(BookInputModel book)
        {
            Book entity = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Rating = decimal.Parse(book.Rating),
                CategoryId = int.Parse(book.CategoryId)
            };

            await this.dbContext.Books.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(string userId, int bookId)
        {
            var user = await this.dbContext.Users
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User cannot be found.");
            }

            var book = await this.dbContext.Books.FindAsync(bookId);

            if (book == null)
            {
                throw new ArgumentException("Movie cannot be found");
            }

            var applicationUserBook = new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                BookId = bookId
            };

            if (!user.ApplicationUsersBooks.Any(aub => aub.BookId == bookId))
            {
                await this.dbContext.AddAsync(applicationUserBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCollectionAsync(string userId, int bookId)
        {
            var user = await this.dbContext.Users
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User cannot be found.");
            }

            var book = await this.dbContext.Books.FindAsync(bookId);

            if (book == null)
            {
                throw new ArgumentException("Movie cannot be found");
            }

            var applicationUserBook = user.ApplicationUsersBooks
                .Where(aub => aub.BookId == bookId)
                .FirstOrDefault();

            if (applicationUserBook != null)
            {
                this.dbContext.Remove(applicationUserBook);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
