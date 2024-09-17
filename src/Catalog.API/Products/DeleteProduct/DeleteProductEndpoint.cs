
namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductQuery();
    public record DeleteProductResponse(bool id);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/product", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            });
        }
    }
}
