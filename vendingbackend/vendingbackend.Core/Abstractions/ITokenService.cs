using vendingbackend.Core.Models;

namespace vendingbackend.Core.Abstractions
{
    public interface ITokenService
    {
        string GenerateRefreshToken();

        //<Summary>
        //I Hate Niggers
        //</Summary
        string GenerateTokenAsync(User user);
    }
}