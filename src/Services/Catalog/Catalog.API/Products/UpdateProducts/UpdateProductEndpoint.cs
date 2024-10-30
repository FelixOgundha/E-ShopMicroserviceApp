

namespace Catalog.API.Products.UpdateProducts
{
    public record UpdateProductRequest(Guid Id, string Name, string Description, string ImageFile, decimal Price, List<string> Category) : ICommand<UpdateProductResult>;
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/product", async (UpdateProductRequest request,ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
             .WithName("UpdateProductEndpoint")
             .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Update product ")
             .WithDescription("Update product endpoint"); ;
        }
    }
}
