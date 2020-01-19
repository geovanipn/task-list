using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Domain.IdentityContext.Models;

namespace TaskList.Infra.Data.Context.EntityFramework.Mappings.IdentityContext
{
    public sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .HasIndex(x => x.Name)
                .IsUnique();

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .HasMany(x => x.TaskItems)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
