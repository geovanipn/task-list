using Microsoft.EntityFrameworkCore;
using TaskList.Infra.Data.Context.EntityFramework.Mappings.BoardContext;
using TaskList.Infra.Data.Context.EntityFramework.Mappings.IdentityContext;

namespace TaskList.Infra.Data.Context.EntityFramework
{
    public static class TaskListApplicationModelBuilder
    {
        public static void TaskListApplicationMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
