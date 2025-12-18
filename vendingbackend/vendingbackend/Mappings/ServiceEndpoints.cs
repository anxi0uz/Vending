using vendingbackend.Application.Services;
using vendingbackend.Core.DTOs;

namespace vendingbackend.Mappings
{
    public static class ServiceEndpoints
    {
        public static IEndpointRouteBuilder MapServiceEndpoints(this IEndpointRouteBuilder router)
        {
            var group = router.MapGroup("/services").RequireAuthorization();

            group.MapGet("/", async (IServicesService service) =>
            {
                return await service.GetAllServicesAsync();
            });

            group.MapPost("/", async (ServiceRequest request, IServicesService service) =>
            {
                return await service.CreateServiceAsync(request);
            });

            group.MapPut("/{id}", async (IServicesService service, int id, ServiceRequest request) =>
            {
                return await service.UpdateServiceAsync(id, request);
            });

            group.MapDelete("/{id}", async (IServicesService service, int id) =>
            {
                return await service.DeleteServiceAsync(id);
            });

            return group;
        }
    }
}
