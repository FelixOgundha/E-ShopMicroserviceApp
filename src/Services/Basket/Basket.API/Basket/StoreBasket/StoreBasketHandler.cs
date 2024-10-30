
using Basket.API.Data;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string Username);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator() 
        { 
            RuleFor(x=>x.Cart).NotEmpty().WithMessage("Cart cannot be null!");
            RuleFor(x=>x.Cart.UserName).NotEmpty().WithMessage("Username is required!");
        }
    }
    public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;
            var result = await repository.StoreBasket(cart,cancellationToken);
            return new StoreBasketResult(result.UserName);
        }
    }
}
