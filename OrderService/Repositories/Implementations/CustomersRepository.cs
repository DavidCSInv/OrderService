using Microsoft.EntityFrameworkCore;
using OrderService.Context;
using OrderService.Models;
using OrderService.Repositories.Interfaces;

namespace OrderService.Repositories.Implementations
{
    public class CustomersRepository(AppDBContext appDBContext) : ICustomersRepository
    {
        public async Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken) => await appDBContext.Customers.ToListAsync(cancellationToken);

        public async Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken)
            => await appDBContext.Customers.Where(w => w.Id == id).SingleOrDefaultAsync(cancellationToken);

        public async Task<List<Customer>> GetCustomerByNameAsync(List<string> name, CancellationToken cancellationToken)
            => await appDBContext.Customers.Where(w => name.Contains(w.Name)).ToListAsync(cancellationToken);

        public async Task<bool> AnyAsync(long id, string name, string surname, string email, CancellationToken cancellationToken)
        {
            return await appDBContext.Customers
                .Where(w => w.Id != id
                        && w.Name == name
                        && w.Surname == surname
                        && w.Email == email)
                .AnyAsync(cancellationToken);
        }
    }
}
