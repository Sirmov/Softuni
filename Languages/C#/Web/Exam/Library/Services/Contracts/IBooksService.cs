namespace Library.Services.Contracts
{
    using Library.Models.Book;

    public interface IBooksService
    {
        public Task<IEnumerable<BookViewModel>> GetAllAsync();

        public Task<IEnumerable<MyBookViewModel>> GetMineAsync(string userId);

        public Task AddAsync(BookInputModel book);

        public Task AddToCollectionAsync(string userId, int bookId);

        public Task RemoveFromCollectionAsync(string userId, int bookId);
    }
}
