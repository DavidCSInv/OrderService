using Microsoft.AspNetCore.Mvc;
using OrderService.Context;
using OrderService.Repositories.Interfaces;

namespace OrderService.Controllers.Customer;

[Route("api/customer_controller")]
[ApiController]
public class HomeController(ICustomersRepository repository, AppDBContext appContext) : Controller
{
    // GET: HomeController
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Customer>))]
    [ProducesResponseType(400, Type = typeof(IEnumerable<Models.Customer>))]
    public async Task<ActionResult> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var result = await repository.GetCustomersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet, Route("id")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Customer>))]
    [ProducesResponseType(400, Type = typeof(IEnumerable<Models.Customer>))]
    public async Task<ActionResult> GetCustomerIdAsync(long id, CancellationToken cancellationToken)
    {
        var result = await repository.GetCustomerByIdAsync(id, cancellationToken);

        return Ok(result);
    }
}
