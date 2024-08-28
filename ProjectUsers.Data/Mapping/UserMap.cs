using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(u => u.CreatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(u => u.UpdatedAt)
                .HasColumnType("DATETIME");

            builder.Property(u => u.Name)
                .HasColumnType("NVARCHAR(200)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("NVARCHAR(256)")
                .IsRequired();

            builder.Property(u => u.Role)
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}