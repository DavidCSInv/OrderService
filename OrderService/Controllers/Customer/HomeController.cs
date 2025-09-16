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
    public async Task<ActionResult> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var result = await repository.GetCustomersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet, Route("id")]
    public async Task<ActionResult> GetCustomerIdAsync([FromQuery] long id, CancellationToken cancellationToken)
    {
        var result = await repository.GetCustomerByIdAsync(id, cancellationToken);

        return result == null
            ? NotFound("Notting was found please check if the user exists")
            : Ok(result);
    }

    [HttpGet, Route("name")]
    public async Task<ActionResult> GetNameAsync([FromQuery] List<string> name, CancellationToken cancellationToken)
    {
        var result = await repository.GetCustomerByNameAsync(name, cancellationToken);

        return result.Count == 0
            ? NotFound("Notting was found please check if the user exists")
            : Ok(result);
    }
}
