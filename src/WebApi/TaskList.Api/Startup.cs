using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Api.Configurations.Swagger;
using TaskList.Api.Configurations.WebApi;
using TaskList.Application.Core;
using TaskList.Infra.CrossCutting.IoC;
using Utils.Authentication.Jwt;

namespace TaskList.Api
{
    public class Startup
    {
        private readonly IApiInfo _apiInfo;

        public Startup(IConfiguration configuration)
        {
            _apiInfo = new ApiInfo();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.RegisterServices(Configuration);

            services.AddCustomWebApi(_apiInfo);
            services.AddCustomSwagger(_apiInfo);

            services.AddHttpContextAccessor();

            services.AddJwtAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc();

            app.UseCustomSwagger(_apiInfo);
        }
    }
}
