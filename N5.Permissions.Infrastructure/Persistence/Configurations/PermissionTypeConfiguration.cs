using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionType");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description)
             .HasMaxLength(150)
            .IsRequired();                                        
        }
    }
}
