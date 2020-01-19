using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Domain.BoardContext.Models;

namespace TaskList.Infra.Data.Context.EntityFramework.Mappings.BoardContext
{
    public sealed class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired();

            builder
                .Property(x => x.Description);

            builder
                .Property(x => x.Status)
                .IsRequired();

            builder
                .Property(x => x.IdUser)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.TaskItems)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
