using Domain.Models;
using FluentValidation;

namespace Application.Validation
{
  public class OrderValidator : AbstractValidator<Order>
  {
    public OrderValidator()
    {
      RuleFor(order => order.Name)
          .NotEmpty().WithMessage("Order name is required.")
          .MaximumLength(100).WithMessage("Order name must not exceed 100 characters.");

      RuleFor(order => order.Number)
          .GreaterThan(0).WithMessage("Order number must be greater than 0.");

      RuleFor(order => order.OrderDate)
          .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date must not be in the future.");

      RuleFor(order => order.Books)
          .NotNull().WithMessage("Books collection cannot be null.")
          .Must(books => books.Count > 0).WithMessage("An order must contain at least one book.");
    }
  }
}
