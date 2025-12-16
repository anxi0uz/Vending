using vendingbackend.Application.Services;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;

namespace vendingbackend.Mappings
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/product");

            group.MapGet("/", async (IProductService service) =>
            {
                return await service.GetAllProductsAsync();
            });

            group.MapPost("/", async (IProductService service, ProductRequest request) =>
            {
                return await service.CreateProductAsync(request);
            });

            group.MapPut("/{id}", async (IProductService service, int id, ProductRequest request) =>
            {
                return service.CreateProductAsync(request); 
            });

            group.MapDelete("/{id}", async (IProductService service, int id) =>
            {
                return await service.DeleteProductAsync(id);
            });

            return group;
        }
    }
}
