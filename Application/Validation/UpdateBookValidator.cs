using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
  public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
  {
    public UpdateBookValidator()
    {
      RuleFor(book => book.ISBN)
          .Length(5, 10).WithMessage("ISBN must be between 5 and 10 characters.")
          .When(book => !string.IsNullOrEmpty(book.ISBN));

      RuleFor(book => book.Name)
          .MaximumLength(100).WithMessage("Book name must not exceed 100 characters.")
          .When(book => !string.IsNullOrEmpty(book.Name));

      RuleFor(book => book.Jenre)
          .MaximumLength(50).WithMessage("Genre must not exceed 50 characters.")
          .When(book => !string.IsNullOrEmpty(book.Jenre));

      RuleFor(book => book.Author)
          .MaximumLength(100).WithMessage("Author must not exceed 100 characters.")
          .When(book => !string.IsNullOrEmpty(book.Author));

      RuleFor(book => book.Year)
            .InclusiveBetween(1500, DateTime.Now.Year)
            .WithMessage($"Year must be between 1500 and {DateTime.Now.Year}.")
            .When(book => book.Year > 0);
    }
  }
}
