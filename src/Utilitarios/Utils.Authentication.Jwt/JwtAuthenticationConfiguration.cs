using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Utils.Authentication.Jwt
{
    public static class JwtAuthenticationConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = JwtSettings.Create(configuration);

            services.AddSingleton<IJwtService>(serviceProvider => new JwtService(jwtSettings));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters.ValidateActor = true;
                    jwtBearerOptions.TokenValidationParameters.ValidateAudience = true;
                    jwtBearerOptions.TokenValidationParameters.ValidateIssuer = true;
                    jwtBearerOptions.TokenValidationParameters.ValidateLifetime = true;
                    jwtBearerOptions.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    jwtBearerOptions.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
                    jwtBearerOptions.TokenValidationParameters.ValidAudience = jwtSettings.Audience;
                    jwtBearerOptions.TokenValidationParameters.ValidIssuer = jwtSettings.Issuer;
                    jwtBearerOptions.TokenValidationParameters.IssuerSigningKey = jwtSettings.SigningCredentials.Key;
                });
        }
    }
}
