using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using TaskList.Domain.IdentityContext.Models;
using TaskList.Infra.Data.Context.EntityFramework;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Infra.Data.Context
{
    public sealed class TaskListDbDataContext : DbContext, IDbContext
    {
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.TaskListApplicationMap();
            
            RemoveConventions(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void RemoveConventions(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("localdb");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(GetConnectionString());
        }

        public static string GetConnectionString(
            in string jsonFile = "appsettings.json", in string connectionStringName = "DefaultConnection") =>
            GetConfiguration(jsonFile).GetConnectionString(connectionStringName);

        public static T GetValue<T>(in string key, in string jsonFile = "appsettings.json") =>
            GetConfiguration(jsonFile).GetValue<T>(key);

        private static IConfigurationRoot GetConfiguration(in string jsonFile) =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(jsonFile)
                .Build();
    }
}
