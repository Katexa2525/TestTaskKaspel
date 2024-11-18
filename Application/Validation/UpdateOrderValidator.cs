using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
  public class UpdateOrderValidator : AbstractValidator<UpdateOrderDTO>
  {
    public UpdateOrderValidator()
    {
      RuleFor(order => order.Name)
          .MaximumLength(100).WithMessage("Order name must not exceed 100 characters.")
          .When(order => !string.IsNullOrEmpty(order.Name));

      RuleFor(order => order.Number)
          .GreaterThan(0).WithMessage("Order number must be greater than 0.")
          .When(order => order.Number > 0);

      RuleFor(order => order.OrderDate)
          .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.")
          .When(order => order.OrderDate != default);
    }
  }
}
