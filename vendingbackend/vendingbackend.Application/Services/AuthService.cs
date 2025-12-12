using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;
using vendingbackend.Core.Abstractions;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;
using vendingbackend.Infrastructure.Repositories;

namespace vendingbackend.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMemoryCache _memoryCache;

    public AuthService(
        IUserRepository userRepository,
        ITokenService tokenService,
        IConfiguration _configuration, IPasswordHasher<User> passwordHasher,
        IMemoryCache memoryCache)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _memoryCache = memoryCache;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userRepository.GetUserAsync(request.Email);
        if (user == null)
            throw new NullReferenceException("InvalidUser");

        if (_passwordHasher.VerifyHashedPassword(null, user.PasswordHash, request.Password) ==
            PasswordVerificationResult.Failed)
            throw new AuthenticationException("Invalid Password");

        var token = _tokenService.GenerateTokenAsync(user);

        return new AuthResponse(token);
    }

    public async Task<int> Register(UserRequest request)
    {
        var user = new User();
        var requestDto = new UserRequest(request.Email,request.Fio,_passwordHasher.HashPassword(user,request.Password),request.Role);
        return await _userRepository.CreateUserAsync(requestDto);
    }
}
