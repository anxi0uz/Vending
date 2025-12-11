using vendingbackend.Core.DTOs;

namespace vendingbackend.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(UserRequest request);
        Task<int> DeleteUserAsync(int id);
        Task<List<UserResponse>> GetUsersAsync();
        Task<int> UpdateUserAsync(int id, UserRequest request);
    }
}