using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskList.Application.Core;

namespace TaskList.Api.Configurations.WebApi
{
    public static class WebApiConfiguration
    {
        public static IMvcBuilder AddCustomWebApi(this IServiceCollection services, IApiInfo apiInfo)
        {
            return services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute($"api/{apiInfo.Version}/{apiInfo.RoutePrefix}/[controller]"));
            });
        }

        public static void UseCentralRoutePrefix(this MvcOptions options, in IRouteTemplateProvider routeAttribute)
        {
            options.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }

        public static IMvcBuilder AddWebApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = services.AddMvcCore();
            builder.AddJsonFormatters();
            builder.AddApiExplorer();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        public static IMvcBuilder AddWebApi(this IServiceCollection services, in Action<MvcOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            var builder = services.AddWebApi();
            builder.Services.Configure(setupAction);

            return builder;
        }

    }
}
