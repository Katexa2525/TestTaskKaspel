using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
  public class CreateBookValidator : AbstractValidator<CreateBookDTO>
  {
    public CreateBookValidator()
    {
      RuleFor(book => book.ISBN)
          .NotEmpty().WithMessage("ISBN is required.")
          .Length(5, 10).WithMessage("ISBN must be between 5 and 10 characters.");

      RuleFor(book => book.Name)
          .NotEmpty().WithMessage("Book name is required.")
          .MaximumLength(100).WithMessage("Book name must not exceed 100 characters.");

      RuleFor(book => book.Jenre)
          .NotEmpty().WithMessage("Genre is required.")
          .MaximumLength(50).WithMessage("Genre must not exceed 50 characters.");

      RuleFor(book => book.Author)
          .NotEmpty().WithMessage("Author is required.")
          .MaximumLength(100).WithMessage("Author must not exceed 100 characters.");

      RuleFor(book => book.Year)
            .NotEmpty()
            .InclusiveBetween(1500, DateTime.Now.Year)
            .WithMessage($"Year must be between 1500 and {DateTime.Now.Year}.");

      //RuleFor(book => book.OrderId)
      //    .NotEmpty().WithMessage("OrderId is required.");
    }
  }
}
