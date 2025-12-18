using vendingbackend.Application.Services;
using vendingbackend.Core.DTOs;

namespace vendingbackend.Mappings
{
    public static class TradeApparatusEndpoints
    {
        public static IEndpointRouteBuilder MapTradeApparatusEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/trade-apparatus").RequireAuthorization();
            group.MapGet("/",async (ITradeApparatusService service) =>
            {
                return await service.GetAllTradeApparatusesAsync();
            });

            group.MapGet("/{id}",async (ITradeApparatusService service, int id) =>
            {
                return await service.GetTradeApparatusByIdAsync(id);
            });

            group.MapPut("/{id}", async (ITradeApparatusService service, TradeApparatusRequest request, int id) =>
            {
                return await service.UpdateTradeApparatusAsync(id,request);
            });

            group.MapDelete("/{id}", async (ITradeApparatusService service, int id) =>
            {
                return await service.DeleteTradeApparatusAsync(id);
            });

            group.MapPost("/", async (ITradeApparatusService service, TradeApparatusRequest request) =>
            {
                return await service.CreateTradeApparatusAsync(request);
            });
            return group;
        }
    }
}
