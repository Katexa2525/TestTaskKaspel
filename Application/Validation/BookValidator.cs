using Domain.Models;
using FluentValidation;

namespace Application.Validation
{
  public class BookValidator : AbstractValidator<Book>
  {
    public BookValidator()
    {
      RuleFor(book => book.ISBN)
          .NotEmpty().WithMessage("ISBN is required.")
          .Length(5, 10).WithMessage("ISBN must be between 10 and 13 characters.");

      RuleFor(book => book.Name)
          .NotEmpty().WithMessage("Book name is required.")
          .MaximumLength(100).WithMessage("Book name must not exceed 100 characters.");

      RuleFor(book => book.Jenre)
          .NotEmpty().WithMessage("Genre is required.");

      RuleFor(book => book.Author)
          .NotEmpty().WithMessage("Author name is required.")
          .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

      RuleFor(book => book.Year)
          .LessThanOrEqualTo(DateTime.Now).WithMessage("Year must not be in the future.");

      RuleFor(book => book.OrderId)
          .NotEmpty().WithMessage("Order ID is required.");
    }
  }
}
