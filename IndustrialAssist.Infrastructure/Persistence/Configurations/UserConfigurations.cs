using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IndustrialAssist.Domain.UserAggregate;
using IndustrialAssist.Domain.UserAggregate.ValueObjects;

namespace IndustrialAssist.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();

        builder.Property(u => u.LastName)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();

        builder.Property(u => u.Password)
            .HasMaxLength(256)
            .IsRequired()
            .IsUnicode();

        builder.Property(u => u.CreatedDateTime)
            .IsRequired();

        builder.Property(u => u.UpdatedDateTime)
            .IsRequired();
    }
}
