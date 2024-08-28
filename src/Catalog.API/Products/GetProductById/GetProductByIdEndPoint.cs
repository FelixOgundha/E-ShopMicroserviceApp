
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdRequest(Guid id);
    public record GetProducttByIdResponse(Product product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{id}", async (GetProductByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductByIdQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetProducttByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get product")
            .WithDescription("Get product");
        }
    }
}
