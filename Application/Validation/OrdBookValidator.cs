using Application.DTO;
using Domain.Models;
using FluentValidation;

namespace Application.Validation
{
  public class OrdBookValidator : AbstractValidator<OrdBook>
  {
    public OrdBookValidator()
    {
      RuleFor(book => book.BookId)
          .NotEmpty().WithMessage("BookId is required.");

      RuleFor(book => book.OrderId)
          .NotEmpty().WithMessage("OrderId is required.");
    }
  }
}
