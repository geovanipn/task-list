using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Application.AutoMapper;
using TaskList.Application.BoardContext.Interfaces;
using TaskList.Application.BoardContext.Services;
using TaskList.Application.IdentityContext.Interfaces;
using TaskList.Application.IdentityContext.Services;
using TaskList.Domain.BoardContext.CommandHandlers;
using TaskList.Domain.BoardContext.Interfaces.Repositories;
using TaskList.Domain.IdentityContext.Interfaces.Identity;
using TaskList.Domain.IdentityContext.Interfaces.Repositories;
using TaskList.Infra.CrossCutting.Identity;
using TaskList.Infra.Data.Context;
using TaskList.Infra.Data.Repository.BoardContext;
using TaskList.Infra.Data.Repository.IdentityContext;
using Utils.Domain.Interfaces;
using Utils.EntityFramework.SqlDataContext;
using Utils.Mediator;

namespace TaskList.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static void RegisterServices(this IServiceCollection services, in Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            
            //dbContext
            services.AddScoped<IDbContext, TaskListDbDataContext>();

            //identity
            services.AddScoped<ITaskListIdentity, TaskListIdentity>();

            //mediator
            services.AddMediatR(typeof(CreateTaskCommandHandler).Assembly);
            
            //autoMapper
            services.AddAutoMapper(typeof(InputModelToDomainMappingProfile));
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            //serviços
            services.AddScoped<ITaskAppService, TaskAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();

            //repositórios
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
