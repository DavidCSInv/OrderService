using OrderService.Models;

namespace OrderService.Repositories.Interfaces
{
    public interface ICategoryrRepository
    {
        Task<List<Category>> GetCategorysAsync(CancellationToken cancellationToken);
        Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetCategoryByNameAsync(List<string> name, CancellationToken cancellationToken);
        Task<List<Category>> GetSubCategoryByNameAsync(List<string> name, CancellationToken cancellationToken);
        Task<bool> AnyAsync(long id, string categoryName, string subCategory, CancellationToken cancellationToken);
    }
}
