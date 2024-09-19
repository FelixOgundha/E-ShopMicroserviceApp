

namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductQuery();
    public record DeleteProductResponse(bool Id);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/product", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(Id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            }).WithName("Delete Product")
             .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Delete Product")
             .WithDescription("Delete Product"); ;
        }
    }
}
