using OrderService.Models;
using OrderService.Repositories.Interfaces;

namespace OrderService.Repositories.Implementations
{
    public class CategoryRepository : ICategoryrRepository
    {
        public Task<bool> AnyAsync(long id, string categoryName, string subCategory, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoryByNameAsync(List<string> name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategorysAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetSubCategoryByNameAsync(List<string> name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
