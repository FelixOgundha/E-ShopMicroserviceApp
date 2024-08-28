using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProduct : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = new Guid(),
                Name = command.Name,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return new CreateProductResult(product.Id);
        }
    }
}
