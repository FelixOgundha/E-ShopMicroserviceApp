
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product product);
    internal class GetProductByIdHandler(IDocumentSession session) : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.id,cancellationToken);

            if (product != null) {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResult(product);
        }
    }

  
}
