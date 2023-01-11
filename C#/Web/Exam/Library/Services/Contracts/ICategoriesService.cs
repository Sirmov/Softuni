namespace Library.Services.Contracts
{
    using Library.Models.Category;

    public interface ICategoriesService
    {
        public Task<IEnumerable<CategoryViewModel>> GetAllAsync();
    }
}
