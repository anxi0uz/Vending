using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;

namespace vendingbackend.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(UserRequest request);
        Task<int> DeleteUserAsync(int id);
        Task<User?> GetUserAsync(string email);
        Task<List<UserResponse>> GetUsersAsync();
        Task<int> UpdateUserAsync(int id, UserRequest request);
    }
}