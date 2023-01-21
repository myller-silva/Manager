using ToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User> //server para indicar que é uma classe de configuracao do entity framework
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn() // auto increment
            .HasColumnType("BIGINT"); // tipo da coluna em sql
        
        builder.Property(x => x.Name)
            .IsRequired() // equivalente a not null ??? 
            .HasMaxLength(80)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(180)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(180)");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(30)");
    }
}