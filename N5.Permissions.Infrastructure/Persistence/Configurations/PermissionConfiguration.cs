using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NameEmployee)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(p => p.SurnameEmployee)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(p => p.PermissionDate)
               .HasColumnType("datetime");
            builder.HasOne(x => x.PermissionType);
            builder.Navigation(i => i.PermissionType).AutoInclude();

        }
    }
}
