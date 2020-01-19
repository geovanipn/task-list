using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Utils.Authentication.Jwt
{
    public sealed class JwtService : IJwtService
    {
        private readonly IJwtSettings jwtSettings;

        public JwtService(IJwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public Authorization CreateAccessToken(IUser user)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                SigningCredentials = jwtSettings.SigningCredentials,
                Subject = GetClaimsIdentityFromUser(user),
                IssuedAt = jwtSettings.IssuedAt,
                NotBefore = jwtSettings.NotBefore,
                Expires = jwtSettings.AccessTokenExpiration,
            });

            return Authorization.Create(jwtSecurityTokenHandler.WriteToken(securityToken));
        }

        private static ClaimsIdentity GetClaimsIdentityFromUser(IUser user)
        {
            var identity = new ClaimsIdentity
            (
                new GenericIdentity(user.UserName, "username"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }
            );

            if (user.AdditionalInformations != null)
            {
                foreach (var additionalInformation in user.AdditionalInformations)
                    identity.AddClaim(new Claim(additionalInformation.Key, additionalInformation.Value));
            }

            return identity;
        }
    }
}
