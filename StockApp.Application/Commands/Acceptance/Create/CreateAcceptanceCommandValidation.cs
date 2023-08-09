
using FluentValidation;

namespace StockApp.Application.Commands.Acceptance.Create;

public class CreateAcceptanceCommandValidation : AbstractValidator<CreateAcceptanceCommand>
{
    public CreateAcceptanceCommandValidation()
    {
        RuleFor(x => x.AcceptanceGoods).NotNull();
        RuleFor(x => x.AcceptanceGoods).NotEmpty();  
        RuleForEach(x => x.AcceptanceGoods).ChildRules(order => 
        {
            order.RuleFor(x => x.GoodId).GreaterThan(0);
            order.RuleFor(x => x.Count).GreaterThan(0);
        });
    }
}