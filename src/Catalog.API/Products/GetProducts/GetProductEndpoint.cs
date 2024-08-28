﻿
namespace Catalog.API.Products.GetProducts
{
    //public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {

                var result = await sender.Send(new GetProductQuery());

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }
            ).WithName("Getproducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get products")
            .WithDescription("Get products");
        }
    }
}
