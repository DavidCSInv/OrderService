using OrderService.Models;

namespace OrderService.Repositories.Interfaces
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken);
        Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken);
        Task<List<Customer>> GetCustomerByNameAsync(List<string> name, CancellationToken cancellationToken);
        Task<bool> AnyAsync(long id, string name, string surname, string email, CancellationToken cancellationToken);
    }
}
