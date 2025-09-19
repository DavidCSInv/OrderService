using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrderService.Context;
using OrderService.Repositories.Interfaces;

namespace OrderService.Controllers.Customer;

[Route("api/customer_controller")]
[ApiController]
public class HomeController(ICustomersRepository repository, AppDBContext appContext, Validation validation) : Controller
{
    #region Gets

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
    #endregion

    [HttpPost, Route("create")]
    public async Task<ActionResult> CreateCustomerAsync([FromBody] ViewModels.CustomerViewModel viewModel, CancellationToken cancellationToken)
    {
        var model = new Models.Customer(name: viewModel.Name, surname: viewModel.Surname, pronouns: viewModel.Pronouns,
            age: viewModel.Age, birthday: viewModel.Birthday, adress: viewModel.Adress, email: viewModel.Email,
            password: viewModel.Password, phoneNumber: viewModel.PhoneNumber, registrationDate: DateTime.UtcNow);

        ValidationResult result = await validation.ValidateAsync(model, cancellationToken);

        if (!result.IsValid)
            return BadRequest(result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

        await appContext.AddAsync(model, cancellationToken);

        return Ok(model);
    }
}
