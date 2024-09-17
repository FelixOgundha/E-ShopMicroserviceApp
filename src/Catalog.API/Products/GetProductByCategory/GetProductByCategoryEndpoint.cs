
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategroryRequest(string Category);
    public record GetProductByCategroryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (GetProductByCategroryRequest request,ISender sender) =>
            {
                var query = request.Adapt<GetProductByCategoryQuery>(); 

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductByCategroryResponse>();

                return Results.Ok(response);
            })
             .WithName("GetproductByCategory")
             .Produces<GetProductByCategroryResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get product By Category")
             .WithDescription("Get product By Category");
        }
    }
}
