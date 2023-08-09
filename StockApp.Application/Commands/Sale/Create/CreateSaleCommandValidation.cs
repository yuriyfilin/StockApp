
using FluentValidation;

namespace StockApp.Application.Commands.Sale.Create;

public class CreateSaleCommandValidation : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidation()
    {
        RuleFor(x => x.SaleGoods).NotNull();
        RuleFor(x => x.SaleGoods).NotEmpty();   
        RuleForEach(x => x.SaleGoods).ChildRules(order => 
        {
            order.RuleFor(x => x.GoodId).GreaterThan(0);
            order.RuleFor(x => x.Count).GreaterThan(0);
        });
    }
}