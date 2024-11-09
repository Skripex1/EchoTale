using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        
        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(256);
        builder.Property(u => u.FirstName).HasMaxLength(50).IsUnicode(false);
        builder.Property(u => u.LastName).HasMaxLength(50).IsUnicode(false);
        builder.Property(u => u.PhoneNumber).HasMaxLength(15).IsUnicode(false);
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.LastUpdatedAt).IsRequired();
        builder.Property(u => u.Gender).IsUnicode(false);
        builder.Property(u => u.UserType).HasConversion<int>().IsRequired().IsUnicode(false);

    }
}