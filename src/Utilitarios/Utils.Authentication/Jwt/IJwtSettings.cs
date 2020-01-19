using Microsoft.IdentityModel.Tokens;
using System;

namespace Utils.Authentication.Jwt
{
    public interface IJwtSettings
    {
        string Audience { get; }

        string Issuer { get; }

        SigningCredentials SigningCredentials { get; }

        uint ValidForMinutes { get; }

        uint RefreshTokenValidForMinutes { get; }

        DateTime IssuedAt { get; }

        DateTime NotBefore { get; }

        DateTime AccessTokenExpiration { get; }

        DateTime RefreshTokenExpiration { get; }
    }
}
