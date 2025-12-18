using Microsoft.AspNetCore.Mvc;
using vendingbackend.Application.Services;
using vendingbackend.Core.DTOs;

namespace vendingbackend.Mappings
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/auth");
            group.MapPost("/login", async (IAuthService service,[FromBody] AuthRequest request) =>
            {
                return await service.Login(request);
            });
            group.MapPost("/register", async (IAuthService service,[FromBody] UserRequest request) =>
            {
                return await service.Register(request);
            }).RequireAuthorization();
            return group;
        }
    }
}
