using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
  public class OrdBookDTOValidator : AbstractValidator<OrdBookDTO>
  {
    public OrdBookDTOValidator()
    {
      RuleFor(book => book.BookId)
          .NotEmpty().WithMessage("BookId is required.");

      RuleFor(book => book.OrderId)
          .NotEmpty().WithMessage("OrderId is required.");
    }
  }
}
