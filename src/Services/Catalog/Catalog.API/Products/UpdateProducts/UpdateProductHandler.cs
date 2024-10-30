

namespace Catalog.API.Products.UpdateProducts
{
    public record UpdateProductCommand(Guid Id,string Name, string Description, string ImageFile, decimal Price, List<string> Category) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requires");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Requires");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.ImageFile).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    internal class UpdateProductCommandHandler(IDocumentSession session,ILogger logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommand.Handle called with {@Command}", command.Name);

            var product = await session.LoadAsync<Product>(command.Id,cancellationToken);

            if (product == null) 
            {
                throw new ProductNotFoundException(command.Id);
            }                                                      
            
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;
            
            session.Update(product);

            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
