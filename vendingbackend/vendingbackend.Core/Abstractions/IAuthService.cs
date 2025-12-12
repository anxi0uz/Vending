using vendingbackend.Core.DTOs;

namespace vendingbackend.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<int> Register(UserRequest request);
    }
}