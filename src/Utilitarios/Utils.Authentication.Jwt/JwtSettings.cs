using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Utils.Authentication.Jwt
{
    public sealed class JwtSettings : IJwtSettings
    {
        public string Audience { get; private set; }

        public string Issuer { get; private set; }

        public SigningCredentials SigningCredentials { get; private set; }

        public uint ValidForMinutes { get; private set; }

        public uint RefreshTokenValidForMinutes { get; private set; }

        public DateTime IssuedAt => DateTime.Now;

        public DateTime NotBefore => IssuedAt;

        public DateTime AccessTokenExpiration => IssuedAt.AddMinutes(ValidForMinutes);

        public DateTime RefreshTokenExpiration => IssuedAt.AddMinutes(RefreshTokenValidForMinutes);

        private JwtSettings() { }

        public static JwtSettings Create(IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings
            {
                Audience = configuration["JwtSettings:Audience"],
                Issuer = configuration["JwtSettings:Issuer"],
                ValidForMinutes = Convert.ToUInt32(configuration["JwtSettings:ValidForMinutes"]),
                RefreshTokenValidForMinutes = Convert.ToUInt32(configuration["JwtSettings:RefreshTokenValidForMinutes"])
            };

            var signingKey = configuration["JwtSettings:SigningKey"];
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            jwtSettings.SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            return jwtSettings;
        }
    }
}
