using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;
using vendingbackend.Infrastructure.DataAccess;

namespace vendingbackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AppDbContext DbContext { get; }

        public async Task<List<UserResponse>> GetUsersAsync()
        {
            return await DbContext.Users
                .AsNoTracking()
                .Select(s => new UserResponse(s.Id, s.Email, s.Fio, s.role.ToString()))
                .ToListAsync();
        }

        public async Task<int> CreateUserAsync(UserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                Fio = request.Fio,
                PasswordHash = request.Password,
                role = (Role)request.Role,
            };
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> UpdateUserAsync(int id, UserRequest request)
        {
            await DbContext.Users.Where(t => t.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(s => s.PasswordHash, request.Password)
            .SetProperty(s => s.Email, request.Email)
            .SetProperty(s => s.role, (Role)request.Role));
            await DbContext.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            await DbContext.Users.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
