using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string ImageFile,decimal Price)
        :IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
