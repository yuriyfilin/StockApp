using FluentValidation;

namespace StockApp.Application.Commands.Good.Create;

public class CreateGoodCommandValidator : AbstractValidator<CreateGoodCommand>
{
    public CreateGoodCommandValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(255);
        RuleFor(x => x.VendorCode).NotNull();
        RuleFor(x => x.VendorCode).NotEmpty();
        RuleFor(x => x.VendorCode).MaximumLength(255);
        RuleFor(x => x.PurchasePrice).GreaterThan(0);
        RuleFor(x => x.SellingPrice).GreaterThan(0);
        RuleFor(x => x.Units).GreaterThan(0);
    }
}