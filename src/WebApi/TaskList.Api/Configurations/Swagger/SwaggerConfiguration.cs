using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using TaskList.Application.Core;

namespace TaskList.Api.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IApiInfo apiInfo)
        { 
            return services
                .AddSwaggerGen(options =>
                {
                    options.DescribeAllEnumsAsStrings();
                    options.SwaggerDoc(apiInfo.Version, new Info
                    {
                        Title = apiInfo.Title,
                        Version = apiInfo.Version,
                        Description = $"{apiInfo.Title} {apiInfo.Version?.ToUpper()}"
                    });
                    options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        Description = "Cabeçalho de autorização do JWT usando o esquema Bearer Exemplo: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
                    options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[] { }},
                    });
                });
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IApiInfo apiInfo)
        {
            return app.UseSwagger().UseCustomSwaggerUi(apiInfo);
        }

        private static IApplicationBuilder UseCustomSwaggerUi(this IApplicationBuilder app, IApiInfo apiInfo)
        {
            return app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{apiInfo.Version}/swagger.json", $"{apiInfo.Title} {apiInfo.Version}");
            });
        }
    }
}
