using FluentValidation;
using OrderService.Repositories.Interfaces;

namespace OrderService.Controllers.Customer
{
    public class Validation : AbstractValidator<Models.Customer>
    {
        private readonly ICustomersRepository _repository;

        public Validation()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Name).MaximumLength(300);
            RuleFor(c => c.Surname).NotNull().NotEmpty();
            RuleFor(c => c.Surname).MaximumLength(300);
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Password).NotNull().NotEmpty();
            RuleFor(c => c.Age).NotNull().NotEmpty();
            RuleFor(c => c.Birthday).NotNull().NotEmpty();
            RuleFor(c => c.Birthday).NotNull().NotEmpty();
            RuleFor(c => c.Birthday).NotNull().NotEmpty();
            RuleFor(c => c.Birthday).NotNull().NotEmpty();

            RuleFor(c => c).MustAsync(InvalidDuplicateAsync).WithMessage("The customer already exists.");
        }
        private async Task<bool> InvalidDuplicateAsync(Models.Customer model, CancellationToken cancellationToken)
             => await _repository.AnyAsync(model.Id, model.Name, model.Surname, model.Email, cancellationToken);

    }
}
