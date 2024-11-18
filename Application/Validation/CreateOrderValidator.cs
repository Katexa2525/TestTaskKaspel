using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
  public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
  {
    public CreateOrderValidator()
    {
      RuleFor(order => order.Name)
          .NotEmpty().WithMessage("Order name is required.")
          .MaximumLength(100).WithMessage("Order name must not exceed 100 characters.");

      RuleFor(order => order.Number)
          .GreaterThan(0).WithMessage("Order number must be greater than 0.");

      RuleFor(order => order.OrderDate)
          .NotEmpty().WithMessage("Order date is required.")
          .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");

      RuleFor(order => order.BookIds)
          .NotEmpty().WithMessage("At least one book ID must be provided.")
          .ForEach(bookId => bookId.NotEmpty().WithMessage("Book ID must not be empty."));
    }
  }
}
