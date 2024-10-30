

namespace Basket.API.Basket.StoreBasket
{
    public class CachedBasketRepository(IBasketRepository repository) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            return await repository.DeleteBasket(username, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            return await repository.GetBasket(userName, cancellationToken);
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            return await repository.StoreBasket(basket, cancellationToken);
        }
    }
}