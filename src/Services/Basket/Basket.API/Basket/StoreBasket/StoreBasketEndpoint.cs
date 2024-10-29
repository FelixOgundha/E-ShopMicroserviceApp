﻿

using Basket.API.Basket.GetBasket;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(bool isSuccess);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created($"basket Added - {response.isSuccess}",response);

            })
            .WithName("StoreBasket")
            .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store GetBasket"); ;
        }
    }

}
