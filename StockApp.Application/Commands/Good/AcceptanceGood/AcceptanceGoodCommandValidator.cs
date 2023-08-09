using FluentValidation;

namespace StockApp.Application.Commands.Good.AcceptanceGood;

public class CreateGoodCommandValidator : AbstractValidator<AcceptanceGoodCommand>
{
    public CreateGoodCommandValidator()
    {
        RuleFor(x => x.UpdateGoods).NotNull();
        RuleFor(x => x.UpdateGoods).NotEmpty();
        RuleForEach(x => x.UpdateGoods).ChildRules(order => 
        {
            order.RuleFor(x => x.GoodId).GreaterThan(0);
            order.RuleFor(x => x.Count).GreaterThan(0);
        });
    }
}